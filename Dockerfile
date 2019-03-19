# Use an official Python runtime as a parent image
FROM python:3.6-slim

COPY . /

# Install any needed packages
RUN pip install -r requirements.txt

EXPOSE 5000

ENTRYPOINT [ "python" ]

CMD [ "app.py" ]
