import axios from 'axios';
import React, { useEffect, useState } from 'react';

const EmployeeProfile = () => {
  const [employee, setEmployee] = useState(null);

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const empId = localStorage.getItem("empId");
        const response = await axios.get(`https://localhost:7008/api/Employees/${empId}`, {
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        });
        setEmployee(response.data);
      } catch (err) {
        console.error("Error fetching profile", err);
      }
    };
    fetchProfile();
  }, []);

  if (!employee) return <p>Loading profile...</p>;

  return (
    <div style={containerStyle}>
      <h2 style={headingStyle}>My Profile</h2>
      <div style={profileCardStyle}>
        <p><b>Employee Id:</b> {employee.empId}</p>
        <p><b>Name:</b> {employee.empName}</p>
        <p><b>Email:</b> {employee.email}</p>
        <p><b>Mobile:</b> {employee.mobile}</p>
        <p><b>Manager Id:</b> {employee.mgrId}</p>
        <p><b>Leave Balance:</b> {employee.leaveAvail}</p>
        <p><b>Date of Birth:</b> {new Date(employee.dateOfBirth).toLocaleDateString()}</p>
      </div>
    </div>
  );
};

// Styles
const containerStyle = {
  display: 'flex',
  flexDirection: 'column',
  alignItems: 'center',
  padding: '20px',
};

const headingStyle = {
  textAlign: 'center',
  color: '#2c3e50',
  marginBottom: '20px',
};

const profileCardStyle = {
  width: '100%',
  maxWidth: '400px',
  padding: '20px',
  border: '1px solid #ddd',
  backgroundColor: '#f8f9fa',
  fontFamily: 'Arial, sans-serif',
  boxShadow: '0 2px 6px rgba(0,0,0,0.1)',
  borderRadius: 0, // sharp corners
};

export default EmployeeProfile;
