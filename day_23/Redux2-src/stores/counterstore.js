import { createStore } from "@reduxjs/toolkit";
import CouterReducer from "../reducers/counterreducer";
const store = createStore(CouterReducer);
export default store;