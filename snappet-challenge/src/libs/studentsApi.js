import axios from "axios";
import { baseApiUrl } from "./general";

export const getStudentsApiData = async () => {
  try {
    const result = await axios.get(baseApiUrl + "students/get-students");
    return result.data;
  } catch (exception) {
    return exception;
  }
};
