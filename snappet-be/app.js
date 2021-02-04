const express = require("express");
const cors = require("cors");
const bodyParser = require("body-parser");
const ProgressController = require("./controllers/ProgressController");

// db instance connection
require("./config/db");

const app = express();

const port = process.env.PORT || 8001;
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(cors());

// API ENDPOINTS

app
  .route("/progress")
  .get(ProgressController.listAllProgress)

app
  .route("/progress/:date")
  .get(ProgressController.getProgressByDate)

app.listen(port, () => {
  console.log(`Server running at http://localhost:${port}`);
});