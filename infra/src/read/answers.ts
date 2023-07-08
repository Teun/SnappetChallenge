import { APIGatewayProxyEvent, APIGatewayProxyHandler } from "aws-lambda";
import { DynamoDB } from "aws-sdk";

const dynamodb = new DynamoDB.DocumentClient();
const TableName = process.env.ANSWERS_TABLE ?? "";
const today = "2015-03-25";

function getDates(startDate, dateChoice) {
  const dates = [startDate]; // Initialize the array with the given date
  const currentDate = new Date(startDate);

  const N = dateChoice === "today" ? 1 : 7;

  // Loop N-1 times to get the preceding dates
  for (let i = 1; i < N; i++) {
    currentDate.setDate(currentDate.getDate() - 1); // Subtract 1 day from the current date
    const dateString = currentDate.toISOString().split("T")[0]; // Convert the date to "yyyy-mm-dd" format
    dates.push(dateString); // Add the date to the array
  }

  return dates;
}

export const main: APIGatewayProxyHandler = async (
  event: APIGatewayProxyEvent
) => {
  const date: string | undefined = event.queryStringParameters?.date;
  const dates: string[] = getDates(today, date);
  console.log({ dates });

  const insertPromises = dates.map(async (date: string) => {
    const queryParams: DynamoDB.DocumentClient.QueryInput = {
      TableName,
      ExpressionAttributeNames: {
        "#dateKey": "yyyy-mm-dd",
      },
      ExpressionAttributeValues: {
        ":dateVal": date,
      },
      KeyConditionExpression: "#dateKey = :dateVal",
    };

    const queryResult: DynamoDB.DocumentClient.QueryOutput = await dynamodb
      .query(queryParams)
      .promise();
    return queryResult;
  });

  const items: DynamoDB.DocumentClient.ItemList = (
    await Promise.all(insertPromises)
  ).reduce((prev, curr) => [...prev, ...curr.Items], []);
  console.log("Items retrieved");
  return {
    statusCode: 200,
    headers: {
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Credentials": true,
    },
    body: JSON.stringify({ items }),
  };
};
