# -*- coding: UTF-8 -*-

import pandas as pd
import numpy as np
import datetime

# Global variables that indicate what date and time we've got 'now'.
CURRENT_TIME_END = datetime.datetime(2015, 3, 24, 11, 30, 00)
CURRENT_TIME_START = CURRENT_TIME_END.replace(hour=0, minute=0, second=0)


def load_data():
    """
    Loads the dataset from csv.
    Returns a pandas dataframe.
    It sets the SubmitDateTime to timestamp data format and it adds a session id and a time-spent indicator to the original dataset.
    """

    # Read data
    df = pd.read_csv('./Data/work.csv', encoding='utf-8')
    # Dome preprocessing
    # Make sure column submitdatetime is a timestamp
    df['SubmitDateTime'] = pd.to_datetime(df['SubmitDateTime'])
    # Cut the dataframe off at the 'current' date & time
    df = df[(df.SubmitDateTime <= CURRENT_TIME_END)]
    # Sort the dataframe by user, timestamp, and subject
    df = df.sort_values(by=['UserId', 'SubmitDateTime', 'Subject'])
    # Assign a session id. This session id identifies work on a certain subject for an uninterrupted (an interuption is a break > 15 min) period.
    # This will allow us, among others, to see much time users spent on a question
    time_break = df.SubmitDateTime.diff() > datetime.timedelta(minutes=15)
    subject_break = df.Subject != df.Subject.shift()
    user_break = df.UserId != df.UserId.shift()
    df['session_id'] = (time_break | user_break | subject_break).cumsum()
    # Add the time spent on a question
    df['question_duration'] = df.groupby('session_id')['SubmitDateTime'].diff().apply(lambda x: x/datetime.timedelta(minutes=1))
    return df

def get_group_and_filter_fields(df, filteron):
    """
    Helper function to find out on what variable we should group and filter, given a certain filter value


    :param df: the Pandas dataset
    :param filteron: value the dataset should be filtered on
    :return: tuple: group by column for grouping, and filter column for filtering, based on the 'filteron' variable.
    """

    if filteron is None:
        group_by_field = 'Subject'
        filter_field = None
    elif filteron in df['Subject'].to_list():
        group_by_field = 'Domain'
        filter_field='Subject'
    elif filteron in df['Domain'].to_list():
        group_by_field = 'LearningObjective'
        filter_field='Domain'
    else:
        group_by_field = 'LearningObjective'
        filter_field='LearningObjective'
    return (group_by_field, filter_field)


def time_spent(df, filteron=None):
    """
    Returns the total time spent per subject/domain/learning objective

    :param df: the pandas dataframe used throughout the app
    :param filteron: the value to filter on, e.g. 'Rekenen' or 'Getallen t/m 1000'. The value is sufficient.
                        the 'get_group_and_filter'-function will determine what dataframe columns we
                        will need to filter on.
    :return: dict: list of labels, list of minutes spent today per label, list of minutes spent over the current month.
    """

    filter_group_by = get_group_and_filter_fields(df, filteron)
    group_by_field = filter_group_by[0]
    filter_field = filter_group_by[1]

    if filter_field is not None:
        df_pr = df[df[filter_field] == filteron].copy(deep=True)
    else:
        df_pr = df.copy(deep=True)

    time_today = (pd.DataFrame(df_pr[(df_pr.SubmitDateTime > CURRENT_TIME_START) & (df_pr.SubmitDateTime <= CURRENT_TIME_END)]
                               .groupby([group_by_field]).question_duration.sum()))

    time_month = (pd.DataFrame(df_pr[(df_pr.SubmitDateTime <= CURRENT_TIME_END)]
                               .groupby([group_by_field]).question_duration.sum()))
    res = time_today.join(time_month, how='outer', lsuffix="_today", rsuffix="_month")
    res = res.fillna(0)
    return {
        'labels': list(res.index),
        'time_today': [round(i,1) for i in list(res.question_duration_today)],
        'time_month': [round(i, 1) for i in list(res.question_duration_month)]
    }


def absolute_progress_against_peer_group(df, user_id, filteron):
    """
    Returns vectors for the mean estimated level (median of difficulty of questions answered right)
    and standard deviation for the entire group for a given learningobjective/domain/subject
    Also returns progress for an individual student.

    :param df: the Pandas dataframe used throughout the app
    :param user_id: user to be compared to his peer group
    :param filteron: subject to filter on. Can be on any level (subject, domain, learningobjective). Helper function
                        get_group_and_filter_fields() finds out what to filter on.

    :return: dict: list of dates (labels), list of levels for student, mean for the class (mean),
                    values with +1 and -1 stDev (ubound/lbound), level of student (user).
    """

    filter_group_by = get_group_and_filter_fields(df, filteron)
    filter_field = filter_group_by[1]

    if filter_field is not None:
        df_pr = df[df[filter_field] == filteron].copy(deep=True)
    else:
        df_pr = df.copy(deep=True)

    # Add a date without the time to group on
    df_pr['SubmitDate'] = df_pr.SubmitDateTime.dt.date

    # Get the level per day, per user, for the given group value (can be a subject, a domain, or an objective)
    level_per_day = pd.DataFrame(df_pr[(df_pr.Difficulty > 0) &
                                           (df_pr.Correct == 1)].groupby(
                                           ['UserId', 'SubmitDate']).Difficulty.median())
    level_per_day = level_per_day.reset_index()

    # Get the level per day for the specified user
    level_per_day_user = level_per_day[level_per_day.UserId == user_id][['SubmitDate', 'Difficulty']]
    level_per_day_user.index = level_per_day_user.SubmitDate

    # Now calculate means and stdev
    level_per_day_means = level_per_day.groupby(['SubmitDate']).agg(['mean', np.std])
    level_per_day_means = level_per_day_means.reset_index()
    level_per_day_means.columns = [''.join(col).strip() for col in level_per_day_means.columns.values]

    # Join the user with the dataframe with group stats
    level_per_day = level_per_day_means.join(level_per_day_user[['SubmitDate', 'Difficulty']], on='SubmitDate', how='outer', rsuffix='_user')

    # Get rid of NaN values by backfilling
    level_per_day = level_per_day.fillna(method='bfill')

    # Stop gap: If there's NaN's left at the end, fill them with ffill, and ultimately put zeroes in what's left TODO: make more elegant
    level_per_day = level_per_day.fillna(method='ffill')
    level_per_day = level_per_day.fillna(0)

    return {'labels': [str(i) for i in level_per_day.SubmitDate.to_list()],
            'mean': [int(i) for i in level_per_day.Difficultymean.to_list()],
            'ubound': [int(i) for i in level_per_day.Difficultymean + level_per_day.Difficultystd.to_list()],
            'lbound': [int(i) for i in level_per_day.Difficultymean - level_per_day.Difficultystd.to_list()],
            'user': [int(i) for i in level_per_day.Difficulty.to_list()],
    }


def student_list():
    """
    Returns a list of the user IDs in the dataset, as well as some made-up names.
    """

    names = ['Mario Speedwagon','Petey Cruiser','Anna Sthesia','Paul Molive','Anna Mull','Gail Forcewind',
             'Paige Turner','Bob Frapples','Walter Melon','Nick R. Bocker','Barb Ackue','Buck Kinnear','Greta Life',
             'Ira Membrit','Shonda Leer','Brock Lee','Maya Didas','Rick Bareur','Pete Sariya','Monty Carlo']
    ids = {68421, 40267, 40268, 40270, 40271, 40272, 40273, 40274, 40275, 40276, 40277, 40278, 40279, 40280, 40281, 40282, 40283, 40284, 40285, 40286}
    return dict(zip(ids, names))
