import pandas as pd
import numpy as np

import pytz

local_tz = pytz.timezone('Europe/Amsterdam')

def utc_to_local(utc_dt):
    local_dt = utc_dt.replace(tzinfo = pytz.utc).astimezone(local_tz)
    return local_tz.normalize(local_dt)

def aslocaltimestr(utc_dt):
    return utc_to_local(utc_dt).strftime('%Y-%m-%d %H:%M:%S')

# import data
snappet_01 = pd.read_csv('data.txt', sep = '\t', encoding = 'ISO-8859-1', low_memory = False)

# convert datetime UTC to local
snappet_01['Datetime_UTC'] = pd.to_datetime(snappet_01['SubmitDateTime'])
snappet_01['Datetime_local'] = snappet_01['Datetime_UTC'].apply(lambda x: pd.to_datetime(aslocaltimestr(x)))

# create extra columns
snappet_01['Date'] = snappet_01['Datetime_local'].apply(lambda x: x.date())
snappet_01['Hour'] = snappet_01['Datetime_local'].apply(lambda x: x.hour)
snappet_01['Hour_string'] = snappet_01['Hour'].apply(lambda x: str(x).zfill(2) + ' - ' + str(x + 1).zfill(2) + ' uur')
snappet_01['Group'] = np.where(snappet_01['Subject'] == 'Rekenen', snappet_01['Domain'], snappet_01['Subject'])

def color_assignment(row):
    if row['Group'] == 'Begrijpend Lezen':
        return 'rgba(255, 255, 0, 0.8)'
    elif row['Group'] =='Getallen':
        return 'rgba(0, 128, 0, 0.8)'
    elif row['Group'] =='Meten':
        return 'rgba(255, 165, 0, 0.8)' 
    elif row['Group'] =='Spelling':
        return 'rgba(0, 128, 128, 0.8)'
    elif row['Group'] =='Verbanden':
        return 'rgba(255, 20, 147, 0.8)'
    elif row['Group'] =='Verhoudingen':
        return 'rgba(210, 105, 30, 0.8)'
    else:
        return 'foutje'

snappet_01['Color'] = snappet_01.apply(color_assignment, axis = 1)

# only include data until 2015-03-24 11:30 UTC
snappet_01 = snappet_01.loc[snappet_01['Datetime_UTC'] < '2015-03-24 11:30:00']

# export data
snappet_01[['Date', 'Hour_string', 'UserId', 'Group', 'LearningObjective', 'Correct', 'Progress', 'Color']].to_csv('data_bewerkt.txt', sep = '\t', index = False)