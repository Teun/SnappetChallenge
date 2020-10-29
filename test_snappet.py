from datetime import datetime   
import unittest
import snappet


class TestSnappet(unittest.TestCase):
    def setUp(self):
        self.today = datetime(2015, 3, 2, 7, 35, 38)
        self.datetime_1 = datetime(2015, 3, 1, 7, 35, 38)
        self.datetime_2 = datetime(2015, 3, 3, 7, 35, 38)
        self.pupils = [[100, 0, 0], [200, 0, 0]]
        self.subjects = ["Rekenen", "Spelling"]
        self.prefix_headers =  ["Leerling nummer", "Totaal aantal opdrachten", "Totaal goed"]
        self.suffix_headers = ["'Progress' totaal"]

    def test_split_csv_line(self):
        csv_line = "2395278,2015-03-02T07:35:38.740,1,0,40281,1038396,-200,Begrijpend Lezen,-,Diverse leerdoelen Begrijpend Lezen"
        expected_output = ['2395278', '2015-03-02T07:35:38.740', '1', '0', '40281',
                           '1038396', '-200', 'Begrijpend Lezen', '-', 'Diverse leerdoelen Begrijpend Lezen']
        self.assertEqual(snappet.split_csv_line(csv_line), expected_output)

    def test_string_to_datetime(self):
        string = "2015-03-02T07:35:38.740"
        self.assertEqual(snappet.string_to_datetime(string), self.today)

    def test_is_from_before_today(self):
        self.assertEqual(snappet.is_from_before_today(self.today, self.datetime_1), True)
        self.assertEqual(snappet.is_from_before_today(self.today, self.datetime_2), False)

    def test_is_from_after_today(self):
        self.assertEqual(snappet.is_from_after_today(self.today, self.datetime_1), False)
        self.assertEqual(snappet.is_from_after_today(self.today, self.datetime_2), True)

    def test_add_column_to_pupils(self):
        snappet.add_column_to_pupils(self.pupils)
        self.assertEqual(self.pupils, [[100, 0, 0, 0], [200, 0, 0, 0]])

    def test_get_pupil(self):
        pupil_id_1 = 100
        pupil_id_2 = 300
        self.assertEqual(snappet.get_pupil(self.pupils, pupil_id_1), [100, 0, 0])
        self.assertEqual(snappet.get_pupil(self.pupils, pupil_id_2), None)

    def test_create_pupil(self):
        self.assertEqual(snappet.create_pupil(100), [100, 0, 0])

    def test_assign_subjects_to_pupil(self):
        pupil = [100, 0, 0]
        snappet.assign_subjects_to_pupil(pupil, self.subjects)
        self.assertEqual(len(pupil), 5)

    def test_update_pupil_progress(self):
        pupil = [100, 0, 0, 3]
        subject_index = 0
        exercise_progress = -1
        snappet.update_pupil_progress(pupil, subject_index, exercise_progress, len(self.prefix_headers))
        self.assertEqual(pupil[3], 2)

    def test_update_pupil_totals(self):
        pupil = [100, 2, 0]
        correct = 1
        snappet.update_pupil_totals(pupil, correct)
        self.assertEqual(pupil, [100, 3, 1])


if __name__ == '__main__':
    unittest.main()
