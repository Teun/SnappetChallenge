#!make

setup:
	docker exec notebook pip install --editable .

launch:
	docker-compose build && docker-compose up --detach && make setup

.PHONY: launch setup