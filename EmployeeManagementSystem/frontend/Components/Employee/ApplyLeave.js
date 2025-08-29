import axios from 'axios';
import React, { useState } from 'react';

const ApplyLeave = () => {
  const [result, setResult] = useState('');
  const [data, setData] = useState({
    leaveStartDate: '',
    leaveEndDate: '',
    leaveReason: '',
  });

  const applyLeave = async () => {
    const empId = parseInt(localStorage.getItem("empId"));
    if (!empId) {
      setResult("Employee ID not found. Please log in again.");
      return;
    }

    try {
      const payload = {
        empId,
        leaveStartDate: data.leaveStartDate,  // keeping as yyyy-MM-dd
        leaveEndDate: data.leaveEndDate,
        leaveReason: data.leaveReason
      };

      console.log("Sending payload:", payload);

      const response = await axios.post(
        "https://localhost:7008/api/LeaveHistories/apply",
        payload,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
            "Content-Type": "application/json"
          }
        }
      );

      setResult("Leave applied successfully!");
      setData({ leaveStartDate: '', leaveEndDate: '', leaveReason: '' }); // Reset form
    } catch (err) {
      console.error("Leave apply error:", err.response ? err.response.data : err.message);
      setResult("Failed to apply leave. Please try again.");
    }
  };

  const handleChange = e => {
    setData({ ...data, [e.target.name]: e.target.value });
  };

  return (
    <div>
      <h2>Apply for Leave</h2>
      <label>Leave Start Date: </label>
      <input
        type="date"
        name="leaveStartDate"
        value={data.leaveStartDate}
        onChange={handleChange}
      /> <br /><br />

      <label>Leave End Date: </label>
      <input
        type="date"
        name="leaveEndDate"
        value={data.leaveEndDate}
        onChange={handleChange}
      /> <br /><br />

      <label>Leave Reason: </label>
      <input
        type="text"
        name="leaveReason"
        value={data.leaveReason}
        onChange={handleChange}
        placeholder="Enter reason"
      /> <br /><br />

      <input type="button" value="Apply Leave" onClick={applyLeave} />
      <hr />
      <div>{result}</div>
    </div>
  );
};

export default ApplyLeave;
