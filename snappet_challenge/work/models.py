# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
#
# Also note: You'll have to insert the output of 'django-admin sqlcustom [app_label]'
# into your database.
from __future__ import unicode_literals

from django.db import models


class Work(models.Model):
    id = models.IntegerField(primary_key=True, db_column='SubmittedAnswerId')  # Field name made lowercase.
    submitdatetime = models.DateTimeField(db_column='SubmitDateTime', blank=True, null=True)  # Field name made lowercase.
    correct = models.IntegerField(db_column='Correct', blank=True, null=True)  # Field name made lowercase.
    progress = models.IntegerField(db_column='Progress', blank=True, null=True)  # Field name made lowercase.
    userid = models.IntegerField(db_column='UserId', blank=True, null=True)  # Field name made lowercase.
    exerciseid = models.IntegerField(db_column='ExerciseId', blank=True, null=True)  # Field name made lowercase.
    difficulty = models.FloatField(db_column='Difficulty', blank=True, null=True)  # Field name made lowercase.
    subject = models.TextField(db_column='Subject', blank=True, null=True)  # Field name made lowercase.
    domain = models.TextField(db_column='Domain', blank=True, null=True)  # Field name made lowercase.
    learningobjective = models.TextField(db_column='LearningObjective', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'work'
