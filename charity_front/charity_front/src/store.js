import { createStore, applyMiddleware, combineReducers } from "redux";
import thunk from "redux-thunk";
import { createLogger } from "redux-logger";
import userReducer from "./reducers/userReducer";
import snackbarReducer from "./reducers/snackbarReducer";
import adReducer from "./reducers/adReducer";


const loggerMiddleware = createLogger();

const store = createStore(combineReducers({
    userReducer,
    snackbarReducer,
    adReducer,
}), applyMiddleware(thunk, loggerMiddleware));

export default store;