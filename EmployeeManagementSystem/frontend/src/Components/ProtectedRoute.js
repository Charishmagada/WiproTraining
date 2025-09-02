import React from "react";
import { useSelector } from "react-redux";
import { Navigate, Outlet } from "react-router-dom";

const ProtectedRoute = ({ roles }) => {
  const { token, role } = useSelector(state => state.auth);

  if (!token) {
    return <Navigate to="/" />; // Redirect to login
  }

  if (roles && !roles.includes(role)) {
    return <h2>Unauthorized: You do not have permission</h2>;
  }

  return <Outlet />;
};

export default ProtectedRoute;
