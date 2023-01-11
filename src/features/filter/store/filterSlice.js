import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  field: "Subject",
};

export const filterSlice = createSlice({
  name: "filter",
  initialState,
  reducers: {
    filterSelected: (state, action) => {
      state.field = action.payload;
    },
  },
});

export const { filterSelected } = filterSlice.actions;

export default filterSlice.reducer;
