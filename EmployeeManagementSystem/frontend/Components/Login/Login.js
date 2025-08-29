import { useState } from "react";
import { useDispatch } from "react-redux";
import { loginSuccess } from "../../Slices/AuthSlice";
import AuthService from "../../Services/AuthService";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const [data, setData] = useState({ username: "", password: "" });

  const handleChange = (e) =>
    setData({ ...data, [e.target.name]: e.target.value });

  const handleLogin = async () => {
    try {
      const resp = await AuthService.login(data.username, data.password);
      // resp contains { token, role, empId }
      dispatch(loginSuccess(resp));

      if (resp.role === "HR") navigate("/HR/HRDashboard");
      else if (resp.role === "Manager") navigate("/Manager/ManagerDashboard");
      else if (resp.role === "Employee") navigate("/Employee/EmployeeDashboard");
      else navigate("/");
    } catch (err) {
      alert("Login failed");
    }
  };

  return (
    <div>
      <h2>Login</h2>
      <input
        type="text"
        name="username"
        value={data.username}
        onChange={handleChange}
        placeholder="Username"
      />
      <br />
      <input
        type="password"
        name="password"
        value={data.password}
        onChange={handleChange}
        placeholder="Password"
      />
      <br />
      <button onClick={handleLogin}>Login</button>
    </div>
  );
};

export default Login;
