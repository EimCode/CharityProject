import { SET_SNACKBAR } from "../constants/action-types";

const initialState = {
    open: false,
    variant: "success",
    message: "empty",
  };

  export default function snackbarReducer(state = initialState, action) {
    if (action.type === SET_SNACKBAR) {
      return Object.assign({}, state, {
        open: action.payload.open,
        variant: action.payload.variant,
        message: action.payload.message
      });
    }
    return state;
  }; 