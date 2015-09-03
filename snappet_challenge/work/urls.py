from django.conf.urls import url

from . import views

urlpatterns = [
    # url(r'^$', views.work_list),
    # ex: /polls/
    url(r'^$', views.index, name='index'),
    # ex: /polls/5/
    url(r'^(?P<work_id>[0-9]+)/$', views.detail, name='detail'),
    # ex: /polls/5/results/
    url(r'^(?P<work_id>[0-9]+)/results/$', views.results, name='results'),
    # ex: /polls/5/vote/
    url(r'^(?P<work_id>[0-9]+)/vote/$', views.vote, name='vote'),
]