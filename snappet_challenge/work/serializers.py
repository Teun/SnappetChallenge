from rest_framework import serializers
from work.models import Work

class WorkSerializer(serializers.ModelSerializer):
    class Meta:
        model = Work
        fields = ('id', 'submitdatetime', 'correct', 'progress', 'userid', 'exerciseid', 'difficulty', 'subject', 'domain', 'learningobjective')