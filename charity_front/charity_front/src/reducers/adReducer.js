import { SET_ADVERTS } from "../constants/action-types";
import { ADD_ADVERT } from "../constants/action-types";

const initialState = {
    adverts: [],
  };

  export default function snackbarReducer(state = initialState, action) {
    if (action.type === SET_ADVERTS) {
      return Object.assign({}, state, {
        adverts: action.payload
      });
    }

    if (action.type === ADD_ADVERT) {
        return Object.assign({}, state, {
          adverts: [...state.adverts, action.payload]
        });
      }
    return state;
  }; 