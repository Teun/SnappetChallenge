import os
from setuptools import setup, find_packages


def read(fname):
    return open(os.path.join(os.path.dirname(__file__), fname)).read()

setup(
    name="answeranalysis",

    description="Snappet Challenge",

    author="Andrew Sutjahjo",

    packages=find_packages(exclude=['results', 'Data']),

    long_description=read('README.md'),
)