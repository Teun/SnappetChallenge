import { configureStore } from "@reduxjs/toolkit";
import filterReducer from "../features/filter/store/filterSlice";
import workReducer from "../features/work/store/workSlice";

const reducer = {
  filter: filterReducer,
  work: workReducer,
};

export const store = configureStore({ reducer });
