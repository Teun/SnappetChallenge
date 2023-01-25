const PORT = "3001";
const API_URL = `http://localhost:${PORT}`;

//api to request data from the json server

export async function searchWork(text = "2015-03-24") {
  try {
    const response = await fetch(API_URL + `/work?q=${text}`);
    const searchedWork = await response.json();
    return searchedWork;
  } catch (e) {
    console.warn("Error fetching searched work");
  }
}

export async function getAllWork() {
  try {
    const response = await fetch(API_URL + `/work`);
    const allWork = await response.json();
    return allWork;
  } catch (e) {
    console.warn("Error fetching the complete work");
  }
}
