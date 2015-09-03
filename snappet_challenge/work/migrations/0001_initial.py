# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models, migrations


class Migration(migrations.Migration):

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Work',
            fields=[
                ('id', models.IntegerField(serialize=False, primary_key=True, db_column='SubmittedAnswerId')),
                ('submitdatetime', models.TextField(blank=True, null=True, db_column='SubmitDateTime')),
                ('correct', models.IntegerField(blank=True, null=True, db_column='Correct')),
                ('progress', models.IntegerField(blank=True, null=True, db_column='Progress')),
                ('userid', models.IntegerField(blank=True, null=True, db_column='UserId')),
                ('exerciseid', models.IntegerField(blank=True, null=True, db_column='ExerciseId')),
                ('difficulty', models.FloatField(blank=True, null=True, db_column='Difficulty')),
                ('subject', models.TextField(blank=True, null=True, db_column='Subject')),
                ('domain', models.TextField(blank=True, null=True, db_column='Domain')),
                ('learningobjective', models.TextField(blank=True, null=True, db_column='LearningObjective')),
            ],
            options={
                'db_table': 'work',
                'managed': False,
            },
        ),
    ]
