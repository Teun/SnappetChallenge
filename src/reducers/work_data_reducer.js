const initialState = {
  data: [],
  activeSubject: "Subject",
}

export default function reduce(state = initialState, action) {
  switch (action.type) {
    case "SET_ACTIVE_SUBJECT":
      return {
        ...state,
        activeSubject: action.subject,
      }
    case "SET_WORK_DATA":
      return {
        ...state,
        data: action.payload,
      }
    default:
      return state
  }
}
