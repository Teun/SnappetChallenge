from pathlib import Path
from datetime import datetime
import csv
from tabulate import tabulate

script_location = Path(__file__).absolute().parent
file_location = script_location / 'Data/work.csv'


def main():
    subjects = []
    pupils = []
    today = datetime(2015, 3, 24, 11, 30)

    prefix_headers = ["Leerling nummer", "Totaal aantal opdrachten", "Totaal goed"]
    suffix_headers = ["'Progress' totaal"]

    with open(file_location, newline='') as file:
        next(file)
        for line in file:
            split_values = split_csv_line(line)
            exercise_date_time = string_to_datetime(split_values[1])

            if is_from_before_today(today, exercise_date_time):
                continue
            elif is_from_after_today(today, exercise_date_time):
                break

            correct = int(split_values[2])
            progress = int(split_values[3])
            pupil_id = split_values[4]
            subject = split_values[7]

            if not subject in subjects:
                subjects.append(subject)
                add_column_to_pupils(pupils)

            pupil = get_pupil(pupils, pupil_id)
            if pupil is None:
                pupil = create_pupil(pupil_id)
                assign_subjects_to_pupil(pupil, subjects)
                pupils.append(pupil)

            update_pupil_progress(pupil, subjects.index(subject), progress, len(prefix_headers))
            update_pupil_totals(pupil, correct)

        display_results(pupils, subjects, prefix_headers, suffix_headers, today)


def split_csv_line(line):
    return ['{}'.format(x) for x in list(csv.reader([line], delimiter=',', quotechar='"'))[0]]


def string_to_datetime(string):
    # The [:-4] notation removes the milliseconds.
    return datetime.strptime(string[:-4], "%Y-%m-%dT%H:%M:%S")


def is_from_before_today(today, exercise_date_time):
    if today.date() > exercise_date_time.date():
        return True
    return False


def is_from_after_today(today, exercise_date_time):
    if today < exercise_date_time:
        return True
    return False


def add_column_to_pupils(pupils):
    for pupil in pupils:
        pupil.append(0)


def get_pupil(pupils, pupil_id):
    for pupil in pupils:
        if pupil[0] == pupil_id:
            return pupil
    return None


def create_pupil(pupil_id):
    return [pupil_id, 0, 0]


def assign_subjects_to_pupil(pupil, subjects):
    for _ in range(len(subjects)):
        pupil.append(0)


def update_pupil_progress(pupil, subject_index, exercise_progress, prefix_headers_length):
    current_progress = pupil[subject_index+prefix_headers_length]
    pupil[subject_index+prefix_headers_length] = current_progress + exercise_progress


def update_pupil_totals(pupil, correct):
    # Updates total exercises counter.
    pupil[1] += 1

    if correct == 1:
        # Updates total exercises correct counter.
        pupil[2] += 1


def _add_total_progress_column(pupils, prefix_headers_length):
    for pupil in pupils:
        pupil.append(sum(pupil[prefix_headers_length:]))


def _sort_by_total_progress(pupils):
    return sorted(pupils, key=lambda l: l[len(pupils[0])-1], reverse=True)


def display_results(pupils, subjects, prefix_headers, suffix_headers, today):
    _add_total_progress_column(pupils, len(prefix_headers))
    pupils = _sort_by_total_progress(pupils)


    for index, subject in enumerate(subjects):
        subjects[index] = "'Progress' " + subject

    table = tabulate(pupils, prefix_headers + subjects + suffix_headers, tablefmt="fancy_grid")

    print(f"Vandaag is {str(today)}")
    print("Hier vindt u een rapport van de 'progress' van de klas vandaag. De leerlingen zijn gesorteerd op basis van de totale 'progress'.")
    print(table)


if __name__ == "__main__":
    main()
