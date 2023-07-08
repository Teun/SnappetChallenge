import { S3, DynamoDB } from "aws-sdk";
import { PromiseResult, Request } from "aws-sdk/lib/request";
import { GetObjectOutput } from "aws-sdk/clients/s3";
import { PutItemOutput } from "aws-sdk/clients/dynamodb";
import { Answer } from "../types";

const s3 = new S3();
const dynamodb = new DynamoDB.DocumentClient();

const Bucket = process.env.ANSWERS_BUCKET ?? "";
const Key = process.env.ANSWERS_FILE_KEY ?? "";
const TableName = process.env.ANSWERS_TABLE ?? "";

export async function main(): Promise<void | Error> {
  const s3DataReq: Request<GetObjectOutput, any> = s3.getObject({
    Bucket,
    Key,
  });

  const s3Data: GetObjectOutput = await s3DataReq.promise();

  const jsonContent: string | undefined = s3Data.Body?.toString();

  if (!jsonContent) throw new Error();

  const records: Answer[] = JSON.parse(jsonContent);

  const insertRecords: Promise<PromiseResult<PutItemOutput, any>>[] = records
    .slice(0, 300)
    .map((Item) => {
      const insertRecord: Request<PutItemOutput, any> = dynamodb.put({
        TableName,
        Item: {
          "yyyy-mm-dd": Item.SubmitDateTime.split("T")[0],
          ...Item,
        },
      });

      return insertRecord.promise();
    });

  await Promise.all(insertRecords);
}
