import { configureStore } from "@reduxjs/toolkit"
import workDataReducer from "../reducers/work_data_reducer"

export const store = configureStore({
  reducer: {
    workData: workDataReducer,
  },
})
