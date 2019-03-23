FROM jupyter/scipy-notebook:137a295ff71b

COPY requirements.txt /tmp/requirements.txt

# Set up our notebook config.
COPY jupyter_notebook_config.py /root/.jupyter/

RUN mkdir /home/jovyan/local

RUN pip install -r /tmp/requirements.txt

EXPOSE 8888

WORKDIR /home/jovyan/local

CMD jupyter notebook --allow-root