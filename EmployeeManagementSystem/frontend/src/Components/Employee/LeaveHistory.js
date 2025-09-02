import axios from 'axios';
import React, { useEffect, useState } from 'react';

const LeaveHistory = () => {
  const [history, setHistory] = useState([]);

  useEffect(() => {
    const fetchHistory = async () => {
      try {
        const empId = localStorage.getItem("empId");
        const response = await axios.get(
          `https://localhost:7008/api/LeaveHistories/employee/${empId}`,
          { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } }
        );
        setHistory(response.data);
      } catch (err) {
        console.error("Error fetching leave history", err);
      }
    };
    fetchHistory();
  }, []);

  return (
    <div style={{ padding: "20px" }}>
      <h2 style={{ color: "#2c3e50", marginBottom: "15px" }}>My Leave History</h2>

      {history.length > 0 ? (
        <div style={{ overflowX: "auto" }}>
          <table style={tableStyle}>
            <thead style={theadStyle}>
              <tr>
                <th style={thTdStyle}>Leave Id</th>
                <th style={thTdStyle}>Start</th>
                <th style={thTdStyle}>End</th>
                <th style={thTdStyle}>No of Days</th>
                <th style={thTdStyle}>Status</th>
                <th style={thTdStyle}>Reason</th>
                <th style={thTdStyle}>Manager Comments</th>
              </tr>
            </thead>
            <tbody>
              {history.map((item, index) => (
                <tr key={item.leaveId} style={tbodyRowStyle(index)}>
                  <td style={thTdStyle}>{item.leaveId}</td>
                  <td style={thTdStyle}>{item.leaveStartDate}</td>
                  <td style={thTdStyle}>{item.leaveEndDate}</td>
                  <td style={thTdStyle}>{item.noOfDays}</td>
                  <td style={thTdStyle}>{item.leaveStatus}</td>
                  <td style={thTdStyle}>{item.leaveReason}</td>
                  <td style={thTdStyle}>{item.managerComments}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      ) : (
        <p style={{ marginTop: "15px" }}>No leave history found.</p>
      )}
    </div>
  );
};

// Styles
const tableStyle = {
  width: "100%",
  borderCollapse: "collapse",
  minWidth: "600px",
  textAlign: "center",
  fontFamily: "Arial, sans-serif"
};

const theadStyle = {
  backgroundColor: "#2c3e50",
  color: "white",
  fontWeight: "bold"
};

const thTdStyle = {
  padding: "8px",
  border: "1px solid #ddd"
};

const tbodyRowStyle = (index) => ({
  backgroundColor: index % 2 === 0 ? "#f8f9fa" : "white"
});

export default LeaveHistory;
