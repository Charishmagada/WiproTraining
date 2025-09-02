// src/Services/AuthService.js
import axios from "axios";

const API_URL = "https://localhost:7008/api/";

const login = async (username, password) => {
  const response = await axios.post(API_URL + "Auth/login", { username, password });
  // backend returns { token, role, empId }
  return response.data;
};

const register = async (username, password, role, empId) => {
  const token = localStorage.getItem("token"); 
  const payload = {
    userId: 0, // backend auto-increments
    username,
    passwordHash: password,
    role,
    empId,
  };

  console.log("Register Payload:", payload);

  const response = await axios.post(API_URL + "Users", payload, {
    headers: {
      Authorization: `Bearer ${token}`, 
      "Content-Type": "application/json",
    },
  });

  return response.data;
};

export default {
  login,
  register,
};
