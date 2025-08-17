import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';

const UpdateCustomer = () => {
  const { id } = useParams();
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    custName: '',
    custUserName: '',
    custPassword: '',
    city: '',
    state: '',
    email: '',
    mobileNo: ''
  });

  useEffect(() => {
    const fetchCustomer = async () => {
      try {
        const res = await axios.get(`https://localhost:7294/api/Customers/${id}`);
        setFormData(res.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchCustomer();
  }, [id]);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = async () => {
    try {
      await axios.put(`https://localhost:7294/api/Customers/${id}`, formData);
      alert("Customer updated successfully!");
      navigate('/dashboard');
    } catch (error) {
      console.error(error);
      alert("Error updating customer");
    }
  };

  return (
    <div>
      <h2>Update Customer</h2>
      <input type="text" name="custName" value={formData.custName} onChange={handleChange} placeholder="Name" /><br />
      <input type="text" name="custUserName" value={formData.custUserName} onChange={handleChange} placeholder="Username" /><br />
      <input type="password" name="custPassword" value={formData.custPassword} onChange={handleChange} placeholder="Password" /><br />
      <input type="text" name="city" value={formData.city} onChange={handleChange} placeholder="City" /><br />
      <input type="text" name="state" value={formData.state} onChange={handleChange} placeholder="State" /><br />
      <input type="email" name="email" value={formData.email} onChange={handleChange} placeholder="Email" /><br />
      <input type="text" name="mobileNo" value={formData.mobileNo} onChange={handleChange} placeholder="Mobile No" /><br />
      <button onClick={handleSubmit}>Update</button> &nbsp;
      <button onClick={() => navigate('/dashboard')}>Cancel</button>
    </div>
  );
};

export default UpdateCustomer;


