import React, { Component,useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await axios.get(`https://localhost:7294/api/Customers`);
      const customers = response.data;

      const matchedUser = customers.find(
        c => c.custUserName === username && c.custPassword === password
      );

      if (matchedUser) {
        localStorage.setItem('custId', matchedUser.custId);
        navigate('/dashboard');
      } else {
        alert('Invalid username or password');
      }
    } catch (error) {
      console.error(error);
      alert('Error logging in');
    }
  };

  return (
    <div>
      <h2>Customer Login</h2>
      <input
        type="text"
        placeholder="Username"
        value={username}
        onChange={e => setUsername(e.target.value)}
      /> <br />
      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={e => setPassword(e.target.value)}
      /> <br />
      <button onClick={handleLogin}>Login</button> &nbsp;
      <button onClick={() => navigate('/addcustomer')}>New User</button>
    </div>
  );
};

export default Login;
