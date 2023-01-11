import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const BASE_URI = "work.json";

const initialState = {
  workData: [],
  loading: false,
  error: "",
};

export const fetchWorkData = createAsyncThunk(
  "work/fetchWorkData",
  async () => {
    const response = await axios.get(BASE_URI);
    return response?.data;
  }
);

const workSlice = createSlice({
  name: "work",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchWorkData.pending, (state, action) => {
        state.loading = true;
      })
      .addCase(fetchWorkData.fulfilled, (state, { payload }) => {
        state.loading = false;
        state.workData = state.workData.concat(payload);
      })
      .addCase(fetchWorkData.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message;
      })
      .addDefaultCase((state, action) => {
        state.loading = false;
      });
  },
});

export const getWorkData = (state) => state.work.workData;
export const getWorkError = (state) => state.work.error;
export const getWorkLoadingStatus = (state) => state.work.loading;

export default workSlice.reducer;
