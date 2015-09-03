from django.shortcuts import get_object_or_404, render

from django.template import RequestContext, loader
from datetime import datetime

from .models import Work

from django.db import connection
connection.cursor()
connection.connection.text_factory = lambda x: str(x, "utf-8", "ignore")

import logging

def index(request):
    latest_question_list = Work.objects.order_by('-submitdatetime')[:5]
    start_time = datetime.strptime('2015-03-24 23:59:00', '%Y-%m-%d %H:%M:%S')
    end_time = datetime.strptime('2015-03-25 00:01:00', '%Y-%m-%d %H:%M:%S')
    print(str(start_time), str(end_time))
    latest_question_list = Work.objects.filter(submitdatetime__range=(start_time, end_time))
    latest_question_list = Work.objects.filter(submitdatetime__gte='2015-03-24').filter(submitdatetime__lt='2015-03-25')
    context = {'latest_question_list': latest_question_list, 'start_time' :start_time}
    return render(request, 'work/index.html', context)

def detail(request, work_id):
    question = get_object_or_404(Work, pk=work_id)
    return render(request, 'work/detail.html', {'question': question})

def results(request, work_id):
    question = get_object_or_404(Work, pk=work_id)
    return render(request, 'work/detail.html', {'question': question})

def vote(request, work_id):
    question = get_object_or_404(Work, pk=work_id)
    return render(request, 'work/detail.html', {'question': question})
