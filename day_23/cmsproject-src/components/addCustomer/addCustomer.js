import React, { Component,useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const AddCustomer = () => {
  const [formData, setFormData] = useState({
    custName: '',
    custUserName: '',
    custPassword: '',
    city: '',
    state: '',
    email: '',
    mobileNo: ''
  });

  const [nextId, setNextId] = useState(null);
  const navigate = useNavigate();

  // Fetch max custId on load
  useEffect(() => {
    const fetchLastId = async () => {
      try {
        const res = await axios.get(`https://localhost:7294/api/Customers`);
        if (res.data.length > 0) {
          const maxId = Math.max(...res.data.map(c => c.custId));
          setNextId(maxId + 1);
        } else {
          setNextId(1);
        }
      } catch (err) {
        console.error(err);
      }
    };
    fetchLastId();
  }, []);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = async () => {
    if (nextId === null) return alert("Loading customer ID...");
    try {
      await axios.post(`https://localhost:7294/api/Customers`, {
        custId: nextId,
        ...formData
      });
      alert('Customer added successfully!');
      navigate('/');
    } catch (error) {
      console.error(error);
      alert('Error adding customer');
    }
  };

  return (
    <div>
      <h2>Register New Customer</h2>
      {nextId && <p><b>New Customer ID:</b> {nextId}</p>}
      <input type="text" name="custName" placeholder="Name" onChange={handleChange} /><br />
      <input type="text" name="custUserName" placeholder="Username" onChange={handleChange} /><br />
      <input type="password" name="custPassword" placeholder="Password" onChange={handleChange} /><br />
      <input type="text" name="city" placeholder="City" onChange={handleChange} /><br />
      <input type="text" name="state" placeholder="State" onChange={handleChange} /><br />
      <input type="email" name="email" placeholder="Email" onChange={handleChange} /><br />
      <input type="text" name="mobileNo" placeholder="Mobile No" onChange={handleChange} /><br />
      <button onClick={handleSubmit}>Register</button> &nbsp;
      <button onClick={() => navigate('/')}>Cancel</button>
    </div>
  );
};

export default AddCustomer;
