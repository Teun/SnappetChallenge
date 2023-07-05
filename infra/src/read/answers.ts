import { APIGatewayProxyHandler } from "aws-lambda";
import { DynamoDB } from "aws-sdk";
import * as fs from "fs";

const dynamodb = new DynamoDB.DocumentClient();

const TableName = process.env.ANSWERS_TABLE ?? "";
const cacheFilePath = "/tmp/cache.json";

export const main: APIGatewayProxyHandler = async (_event, _context) => {
  let resultItems: DynamoDB.DocumentClient.ItemList = [];

  if (fs.existsSync(cacheFilePath)) {
    const cacheData = fs.readFileSync(cacheFilePath, "utf8");
    resultItems = JSON.parse(cacheData);
    return {
      statusCode: 200,
      body: JSON.stringify({ items: resultItems, cacheHit: true }),
    };
  }

  let LastEvaluatedKey: undefined | DynamoDB.DocumentClient.Key;

  do {
    const scanParams: DynamoDB.DocumentClient.ScanInput = {
      TableName,
      ExclusiveStartKey: LastEvaluatedKey,
    };

    const scanResult: DynamoDB.DocumentClient.ScanOutput = await dynamodb
      .scan(scanParams)
      .promise();

    const items: DynamoDB.DocumentClient.ItemList | undefined =
      scanResult.Items;

    if (!items || !items.length) break;

    resultItems = [...resultItems, ...items];

    LastEvaluatedKey = scanResult.LastEvaluatedKey;
  } while (LastEvaluatedKey);

  if (!process.env.IS_LOCAL)
    fs.writeFileSync(cacheFilePath, JSON.stringify(resultItems));

  return {
    statusCode: 200,
    body: JSON.stringify({ items: resultItems }),
  };
};
