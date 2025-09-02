import { useState } from "react";
import { useDispatch } from "react-redux";
import { loginSuccess } from "../../Slices/AuthSlice";
import AuthService from "../../Services/AuthService";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const [data, setData] = useState({ username: "", password: "" });

  const handleChange = (e) => {
    setData({ ...data, [e.target.name]: e.target.value });
  };

  const handleLogin = async () => {
    try {
      const resp = await AuthService.login(data.username, data.password);
      // resp = { token, role, empId }

      // Dispatch will also update localStorage via AuthSlice
      dispatch(loginSuccess(resp));

      // Navigate by role
      if (resp.role === "HR") navigate("/HR/HRDashboard");
      else if (resp.role === "Manager") navigate("/Manager/ManagerDashboard");
      else if (resp.role === "Employee") navigate("/Employee/EmployeeDashboard");
      else navigate("/");
    } catch (err) {
      alert("Login failed. Please check username/password.");
    }
  };

  return (
    <div style={containerStyle}>
      {/* Main content */}
      <div style={contentStyle}>
        <h1 style={titleStyle}>Employee Management System</h1>
        <div style={cardStyle}>
          <h2 style={cardTitleStyle}>Login</h2>
          <input
            type="text"
            name="username"
            value={data.username}
            onChange={handleChange}
            placeholder="Enter Username"
            style={inputStyle}
            required
          />
          <input
            type="password"
            name="password"
            value={data.password}
            onChange={handleChange}
            placeholder="Enter Password"
            style={inputStyle}
            required
          />
          <button onClick={handleLogin} style={buttonStyle}>
            Login
          </button>
        </div>
      </div>

      {/* Footer */}
      <footer style={footerStyle}>© 2025 EMS Project</footer>
    </div>
  );
};

// Styles
const containerStyle = {
  display: "flex",
  flexDirection: "column",
  minHeight: "100vh",
  backgroundColor: "#f4f6f9",
};

const contentStyle = {
  flex: "0 0 auto",
  display: "flex",
  flexDirection: "column",
  alignItems: "center",
  justifyContent: "flex-start",
  padding: "20px",
};

const titleStyle = {
  marginBottom: "20px",
  color: "#2c3e50",
  fontWeight: "600",
  textAlign: "center",
};

const cardStyle = {
  width: "240px", 
  padding: "18px",
  border: "1px solid #ddd",
  boxShadow: "0 4px 12px rgba(0,0,0,0.1)",
  backgroundColor: "#fff",
  textAlign: "center",
};

const cardTitleStyle = {
  marginBottom: "10px",
  fontSize: "18px",
  color: "#222",
};

const inputStyle = {
  width: "100%",
  padding: "8px",
  marginBottom: "12px",
  border: "1px solid #ccc",
  fontSize: "14px",
  boxSizing: "border-box",
};

const buttonStyle = {
  width: "100%",
  padding: "10px",
  backgroundColor: "#007bff",
  border: "none",
  color: "white",
  fontWeight: "bold",
  cursor: "pointer",
  fontSize: "14px",
};

const footerStyle = {
  fontSize: "12px",
  color: "#777",
  textAlign: "center",
  padding: "15px",
  marginTop: "auto",
};

export default Login;
