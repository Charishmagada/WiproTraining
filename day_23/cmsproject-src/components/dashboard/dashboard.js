import React, { Component,useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Dashboard = () => {
  const [customer, setCustomer] = useState({});
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCustomer = async () => {
      const id = localStorage.getItem('custId');
      if (!id) return;

      try {
        const response = await axios.get(`https://localhost:7294/api/Customers/${id}`);
        setCustomer(response.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchCustomer();
  }, []);

  // Delete Customer
  const handleDelete = async () => {
    if (window.confirm("Are you sure you want to delete your account?")) {
      try {
        await axios.delete(`https://localhost:7294/api/Customers/${customer.custId}`);
        alert("Customer deleted successfully!");
        localStorage.removeItem('custId');
        navigate('/');
      } catch (error) {
        console.error(error);
        alert("Error deleting customer");
      }
    }
  };

  // Navigate to Update Page
  const handleUpdate = () => {
    navigate(`/updateCustomer/${customer.custId}`);
  };

  return (
    <div>
      <h2>Customer Dashboard</h2>
      <div>
        <p><b>ID:</b> {customer.custId}</p>
        <p><b>Name:</b> {customer.custName}</p>
        <p><b>Username:</b> {customer.custUserName}</p>
        <p><b>City:</b> {customer.city}</p>
        <p><b>State:</b> {customer.state}</p>
        <p><b>Email:</b> {customer.email}</p>
        <p><b>Mobile:</b> {customer.mobileNo}</p>
      </div>

      <button onClick={handleUpdate}>Update Customer</button> &nbsp;
      <button onClick={handleDelete} style={{ backgroundColor: 'red', color: 'white' }}>
        Delete Customer
      </button>
    </div>
  );
};

export default Dashboard;
