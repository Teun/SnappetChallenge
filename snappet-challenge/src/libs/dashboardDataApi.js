import axios from "axios";
import { baseApiUrl } from "./general";

export const getApiDashboardData = async (summaryDate) => {
  try {
    const result = await axios.get(
      baseApiUrl + "home/get-dashboard-data?summaryDate=" + summaryDate
    );
    return result.data;
  } catch (exception) {
    return exception;
  }
};

export const getApiSubjects = async (summaryDate) => {
  try {
    const result = await axios.get(
      baseApiUrl + "home/get-subjects?summaryDate=" + summaryDate
    );
    return result.data;
  } catch (exception) {
    return exception;
  }
};
