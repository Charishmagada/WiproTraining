import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { logout } from "../../Slices/AuthSlice";

const ManagerDashboard = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleLogout = () => {
    dispatch(logout());
    navigate("/");
  };

  return (
    <div>
      {/* Header/Navbar */}
      <div 
        style={{ 
          display: "flex", 
          justifyContent: "space-between", 
          alignItems: "center", 
          padding: "12px 20px", 
          backgroundColor: "#2c3e50", 
          color: "white",
          position: "sticky",
          top: 0,
          zIndex: 1000
        }}
      >
        <h3 style={{ margin: 0 }}>Employee Management System</h3>
        <button 
          onClick={handleLogout} 
          style={{
            padding: "6px 12px",
            border: "none",
            backgroundColor: "#dc3545",
            color: "white",
            borderRadius: "4px",
            cursor: "pointer"
          }}
        >
          Logout
        </button>
      </div>

      {/* Dashboard Content */}
      <div style={{ padding: "30px" }}>
        <h2 style={{ marginBottom: "20px", color: "#2c3e50" }}>Manager Dashboard</h2>

        {/* Cards Grid */}
        <div style={{ display: "grid", gridTemplateColumns: "1fr 1fr", gap: "20px", maxWidth: "500px" }}>
          <Link to="/Manager/ManagerTeamLeaves" style={cardStyle}>
            Approve Leave Requests
          </Link>
          <Link to="/Manager/DepartmentEmployees" style={cardStyle}>
            View Department Employees
          </Link>
        </div>
      </div>
    </div>
  );
};

const cardStyle = {
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  padding: "20px",
  backgroundColor: "#f8f9fa",
  border: "1px solid #ddd",
  borderRadius: "6px",
  textDecoration: "none",
  color: "#2c3e50",
  fontWeight: "500",
  boxShadow: "0 2px 6px rgba(0,0,0,0.1)",
  transition: "0.3s",
  textAlign: "center",
};

export default ManagerDashboard;
