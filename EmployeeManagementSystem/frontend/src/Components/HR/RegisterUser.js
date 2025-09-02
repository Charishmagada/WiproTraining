import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import AuthService from "../../Services/AuthService";

const RegisterUser = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    username: "",
    password: "",
    role: "Employee",
    empId: "", // 🔑 Added empId
  });
  const [loading, setLoading] = useState(false);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      await AuthService.register(
        formData.username,
        formData.password,
        formData.role,
        formData.empId
      );
      alert("User registered successfully!");
      navigate("/HR/HRDashboard");
    } catch (err) {
      console.error("Registration error:", err);
      alert("Registration failed. Please try again.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={containerStyle}>
      <div style={cardStyle}>
        <h2 style={{ textAlign: "center", marginBottom: "20px" }}>
          Register New User
        </h2>
        <form onSubmit={handleRegister}>
          <input
            type="text"
            name="username"
            value={formData.username}
            onChange={handleChange}
            placeholder="Enter Username"
            style={inputStyle}
            required
          />
          <input
            type="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            placeholder="Enter Password"
            style={inputStyle}
            required
          />
          <select
            name="role"
            value={formData.role}
            onChange={handleChange}
            style={inputStyle}
          >
            <option value="HR">HR</option>
            <option value="Manager">Manager</option>
            <option value="Employee">Employee</option>
          </select>
          <input
            type="number"
            name="empId"
            value={formData.empId}
            onChange={handleChange}
            placeholder="Enter Employee ID"
            style={inputStyle}
            required
          />
          <button type="submit" style={buttonStyle} disabled={loading}>
            {loading ? "Registering..." : "Register"}
          </button>
        </form>
        <button
          onClick={() => navigate("/HR/HRDashboard")}
          style={backButtonStyle}
        >
          Back to Dashboard
        </button>
      </div>
    </div>
  );
};

// Styles (same as before)
const containerStyle = { display: "flex", justifyContent: "center", alignItems: "center", minHeight: "100vh", backgroundColor: "#f4f6f9" };
const cardStyle = { width: "300px", padding: "20px", border: "1px solid #ddd", borderRadius: "0px", backgroundColor: "#fff", boxShadow: "0 4px 12px rgba(0,0,0,0.1)" };
const inputStyle = { width: "95%", padding: "10px", marginBottom: "10px", border: "1px solid #ccc", borderRadius: "0px", fontSize: "14px" };
const buttonStyle = { width: "100%", padding: "10px", backgroundColor: "#007bff", border: "none", borderRadius: "0px", color: "white", fontWeight: "bold", cursor: "pointer", fontSize: "14px", marginBottom: "10px" };
const backButtonStyle = { width: "100%", padding: "10px", backgroundColor: "#6c757d", border: "none", borderRadius: "0px", color: "white", cursor: "pointer", fontSize: "14px" };

export default RegisterUser;
