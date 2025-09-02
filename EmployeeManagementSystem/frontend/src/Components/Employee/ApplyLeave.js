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
        leaveStartDate: data.leaveStartDate,
        leaveEndDate: data.leaveEndDate,
        leaveReason: data.leaveReason
      };

      await axios.post(
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
      setData({ leaveStartDate: '', leaveEndDate: '', leaveReason: '' });
    } catch (err) {
      console.error("Leave apply error:", err.response ? err.response.data : err.message);
      setResult("Failed to apply leave. Please try again.");
    }
  };

  const handleChange = e => {
    setData({ ...data, [e.target.name]: e.target.value });
  };

  return (
    <div style={containerStyle}>
      <h2 style={headingStyle}>Apply for Leave</h2>

      <div style={formStyle}>
        <div style={formGroupStyle}>
          <label style={labelStyle}>Leave Start Date:</label>
          <input
            type="date"
            name="leaveStartDate"
            value={data.leaveStartDate}
            onChange={handleChange}
            style={inputStyle}
          />
        </div>

        <div style={formGroupStyle}>
          <label style={labelStyle}>Leave End Date:</label>
          <input
            type="date"
            name="leaveEndDate"
            value={data.leaveEndDate}
            onChange={handleChange}
            style={inputStyle}
          />
        </div>

        <div style={formGroupStyle}>
          <label style={labelStyle}>Leave Reason:</label>
          <input
            type="text"
            name="leaveReason"
            value={data.leaveReason}
            onChange={handleChange}
            placeholder="Enter reason"
            style={inputStyle}
          />
        </div>

        <button onClick={applyLeave} style={buttonStyle}>Apply Leave</button>

        {result && (
          <p style={{
            marginTop: "15px",
            color: result.includes("successfully") ? "green" : "red",
            textAlign: "center"
          }}>{result}</p>
        )}
      </div>
    </div>
  );
};

// Styles
const containerStyle = {
  padding: "20px",
  maxWidth: "500px",
  margin: "0 auto"
};

const headingStyle = {
  color: "#2c3e50",
  marginBottom: "20px",
  textAlign: "center"
};

const formStyle = {
  display: "flex",
  flexDirection: "column"
};

const formGroupStyle = {
  display: "flex",
  flexDirection: "column",
  marginBottom: "15px"
};

const labelStyle = {
  marginBottom: "5px",
  fontWeight: "bold"
};

const inputStyle = {
  width: "100%",
  padding: "8px",
  border: "1px solid #ccc",
  borderRadius: 0,
  boxSizing: "border-box"
};

const buttonStyle = {
  padding: "10px 20px",
  backgroundColor: "#2c3e50",
  color: "white",
  border: "none",
  borderRadius: 0,
  cursor: "pointer",
  marginTop: "10px"
};

export default ApplyLeave;
