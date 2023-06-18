const express = require('express');
const { ApolloServer, gql } = require('apollo-server-express');
const fs = require('fs');
const moment = require('moment')
let data;
let users = [];

fs.readFile('../Data/work.json', 'utf8', function(err, output){
  // get all data
  data = JSON.parse(output)
  // get all users
  console.log(users)
  if(err){
    console.log(err);
    process.exit(1)
  }
});


const typeDefs = gql`
type User {
  UserId: ID!
  SubmittedAnswers: [SubmittedAnswer]
}
  type SubmittedAnswer {
    SubmittedAnswerId: ID!
    SubmitDateTime: String!
    Correct: Int!
    Progress: Int!
    UserId: ID!
    ExerciseId: ID!
    Difficulty: String!
    Subject: String!
    Domain: String!
    LearningObjective: String!
  }

  type Query {
    submittedAnswer(id: ID!): SubmittedAnswer,
    workOfTheDay(SubmitDateTime: String!): [User]
  }
`;



const resolvers = {
  Query: {
    submittedAnswer: (parent, args) => {
      // Logic to retrieve and return the submitted answer by its ID
      // Replace this with your own implementation
      return data.filter(data => data.SubmittedAnswerId === args.id);
    },
    workOfTheDay: async (parent, args) => {
      
     // Het is nu dinsdag 2015-03-24 11:30:00 UTC. De antwoorden van na dat tijdstip worden dus nog niet getoond.
     // get all data from current day
      let correctValues = await data.filter(object => (moment(object.SubmitDateTime).isSameOrBefore("2015-03-25T11:30:00.000")) && moment(object.SubmitDateTime).isSame(args.SubmitDateTime, 'day') );

      for (const obj of correctValues) {
        let user = users.find(item => item.UserId === obj.UserId)
        if (!user) {
          users.push({UserId: obj.UserId, SubmittedAnswers: [obj]});
        } else{
          user.SubmittedAnswers.push(obj)
        }
      };
      
      return users;
    }
  }
};




async function startServer() {

  const app = express();
  const server = new ApolloServer({
    typeDefs,
    resolvers,
  });
  await server.start();

  server.applyMiddleware({ app });

  app.use((req, res) => {
    res.status(200);
    res.send('Hello!');
    res.end();
  });

  await new Promise(resolve => app.listen({ port: 4000 }, resolve));
  console.log(`🚀 Server ready at http://localhost:4000${server.graphqlPath}`);
  return { server, app };
}

startServer()