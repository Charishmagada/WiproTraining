import axios from 'axios';
import React, { useEffect, useState } from 'react';

const EmployeeProfile = () => {
  const [employee, setEmployee] = useState(null);

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        let empId = localStorage.getItem("empId");
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
    <div>
      <h2>My Profile</h2>
      <p><b>Employee Id:</b> {employee.empId}</p>
      <p><b>Name:</b> {employee.employName}</p>
      <p><b>Email:</b> {employee.email}</p>
      <p><b>Mobile:</b> {employee.mobile}</p>
      <p><b>Manager Id:</b> {employee.mgrId}</p>
      <p><b>Leave Balance:</b> {employee.leaveAvail}</p>
      <p><b>Date of Birth:</b> {employee.dateOfBirth}</p>
    </div>
  );
};

export default EmployeeProfile;
