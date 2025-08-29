import { createSlice } from '@reduxjs/toolkit';

const initialToken = localStorage.getItem("token") || null;
const initialRole = localStorage.getItem("role") || null;
const initialEmpId = localStorage.getItem("empId") || null;

const authSlice = createSlice({
  name: 'auth',
  initialState: {
    token: initialToken,
    role: initialRole,
    empId: initialEmpId,
  },
  reducers: {
    loginSuccess: (state, action) => {
      const { token, role, empId } = action.payload;
      state.token = token;
      state.role = role;
      state.empId = empId;

      localStorage.setItem("token", token);
      localStorage.setItem("role", role);
      localStorage.setItem("empId", empId);
    },
    logout: (state) => {
      state.token = null;
      state.role = null;
      state.empId = null;
      localStorage.clear();
    }
  }
});

export const { loginSuccess, logout } = authSlice.actions;
export default authSlice.reducer;
