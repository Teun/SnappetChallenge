
FROM public.ecr.aws/bitnami/node:16.18.1
RUN mkdir -p /usr/src/snappetChallange
WORKDIR /usr/src/snappetChallange
COPY . .

WORKDIR /usr/src/snappetChallange/client
RUN npm install
RUN npm run build

WORKDIR /usr/src/snappetChallange/server
RUN npm install

# EXPOSE 3000
CMD [ "node", "server.js" ]