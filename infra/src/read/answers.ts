import { APIGatewayProxyHandler } from "aws-lambda";
import { DynamoDB } from "aws-sdk";
import * as fs from "fs";

const dynamodb = new DynamoDB.DocumentClient();

const TableName = process.env.ANSWERS_TABLE ?? "";

export const main: APIGatewayProxyHandler = async (_event, _context) => {
  const today: string = "2015-03-02";

  const queryParams: DynamoDB.DocumentClient.QueryInput = {
    TableName,
    ExpressionAttributeNames: {
      "#dateKey": "yyyy-mm-dd",
    },
    ExpressionAttributeValues: {
      ":dateVal": today,
    },
    KeyConditionExpression: "#dateKey = :dateVal",
  };

  const queryResul: DynamoDB.DocumentClient.ScanOutput = await dynamodb
    .query(queryParams)
    .promise();

  const items: DynamoDB.DocumentClient.ItemList | undefined = queryResul.Items;

  return {
    statusCode: 200,
    body: JSON.stringify({ items }),
  };
};
