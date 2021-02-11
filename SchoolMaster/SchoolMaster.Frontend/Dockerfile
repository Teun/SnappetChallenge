FROM node:lts-alpine
RUN npm install -g http-server

WORKDIR /src

COPY SchoolMaster.Frontend/package*.json ./

RUN npm install

COPY ./SchoolMaster.Frontend .

RUN npm run build

EXPOSE 8080
CMD [ "http-server", "dist" ]