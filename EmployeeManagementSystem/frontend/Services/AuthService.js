// src/Services/AuthService.js
import axios from "axios";

const API_URL = "https://localhost:7008/api/Auth/";

const login = async (username, password) => {
  const response = await axios.post(API_URL + "login", { username, password });
  // backend returns { token, role, empId }
  return response.data;
};

export default {
  login,
};
