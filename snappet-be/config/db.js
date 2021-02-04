const mongoose = require("mongoose");
const dbURI = 'mongodb+srv://admin:jWeDErMX3RqFkJzw@cluster.hp1cb.mongodb.net/snappet?retryWrites=true&w=majority'
const options = {
  useNewUrlParser: true,
  useUnifiedTopology: true
}

mongoose.connect(dbURI, options).then(
  () => {
    console.log("Database connection established!");
  },
  err => {
    console.log("Error connecting Database instance due to: ", err);
  }
);

// require any models

require("../models/Progress");
