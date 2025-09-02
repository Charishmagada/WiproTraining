import { createSlice } from "@reduxjs/toolkit";

//  Load initial state from localStorage (if present)
const initialToken = localStorage.getItem("token") || null;
const initialRole = localStorage.getItem("role") || null;
const initialEmpId = localStorage.getItem("empId") || null;

const authSlice = createSlice({
  name: "auth",
  initialState: {
    token: initialToken,
    role: initialRole,
    empId: initialEmpId,
  },
  reducers: {
    //  Save login data (token, role, empId)
    loginSuccess: (state, action) => {
      const { token, role, empId } = action.payload;
      state.token = token;
      state.role = role;
      state.empId = empId;

      // Persist in localStorage
      localStorage.setItem("token", token);
      localStorage.setItem("role", role);
      localStorage.setItem("empId", empId);
    },

    // Clear login data on logout
    logout: (state) => {
      state.token = null;
      state.role = null;
      state.empId = null;

      localStorage.removeItem("token");
      localStorage.removeItem("role");
      localStorage.removeItem("empId");
    },

    // Restore auth state (in case needed explicitly)
    restoreAuth: (state) => {
      state.token = localStorage.getItem("token") || null;
      state.role = localStorage.getItem("role") || null;
      state.empId = localStorage.getItem("empId") || null;
    },
  },
});

export const { loginSuccess, logout, restoreAuth } = authSlice.actions;
export default authSlice.reducer;
