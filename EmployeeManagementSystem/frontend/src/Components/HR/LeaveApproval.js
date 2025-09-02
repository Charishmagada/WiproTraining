import axios from 'axios';
import React, { useEffect, useState } from 'react';

const LeaveApproval = () => {
  const [leaves, setLeaves] = useState([]);

  const fetchLeaves = async () => {
    try {
      const response = await axios.get("https://localhost:7008/api/LeaveHistories", {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setLeaves(response.data);
    } catch (err) {
      console.error("Error fetching leaves", err);
    }
  };

  const updateLeave = async (leaveId, status) => {
    try {
      const leave = leaves.find(l => l.leaveId === leaveId);
      const updated = { ...leave, leaveStatus: status, managerComments: "Updated by HR" };

      await axios.put(`https://localhost:7008/api/LeaveHistories/${leaveId}`, updated, {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      fetchLeaves();
    } catch (err) {
      console.error("Error updating leave", err);
    }
  };

  useEffect(() => {
    fetchLeaves();
  }, []);

  return (
    <div style={{ padding: "10px 20px" }}> {/* compact container */}
      <h2 style={{ color: "#2c3e50", marginBottom: "10px" }}>Leave Requests (HR Approval)</h2>
      
      <div style={{ overflowX: "auto" }}>
        <table style={tableStyle}>
          <thead style={theadStyle}>
            <tr>
              <th style={thTdStyle}>Leave Id</th>
              <th style={thTdStyle}>Emp Id</th>
              <th style={thTdStyle}>Start</th>
              <th style={thTdStyle}>End</th>
              <th style={thTdStyle}>Days</th>
              <th style={thTdStyle}>Status</th>
              <th style={thTdStyle}>Reason</th>
              <th style={thTdStyle}>Manager Comments</th>
              <th style={thTdStyle}>Action</th>
            </tr>
          </thead>
          <tbody>
            {leaves.map((l, index) => (
              <tr key={l.leaveId} style={tbodyRowStyle(index)}>
                <td style={thTdStyle}>{l.leaveId}</td>
                <td style={thTdStyle}>{l.empId}</td>
                <td style={thTdStyle}>{l.leaveStartDate}</td>
                <td style={thTdStyle}>{l.leaveEndDate}</td>
                <td style={thTdStyle}>{l.noOfDays}</td>
                <td style={thTdStyle}>{l.leaveStatus}</td>
                <td style={thTdStyle}>{l.leaveReason}</td>
                <td style={thTdStyle}>{l.managerComments}</td>
                <td style={thTdStyle}>
                  {l.leaveStatus === "PENDING" && (
                    <>
                      <button onClick={() => updateLeave(l.leaveId, "APPROVED")} style={approveBtn}>Approve</button>
                      <button onClick={() => updateLeave(l.leaveId, "REJECTED")} style={rejectBtn}>Reject</button>
                    </>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

// Styles
const tableStyle = {
  width: "100%",
  borderCollapse: "collapse",
  minWidth: "800px",
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

const approveBtn = {
  padding: "4px 8px",
  backgroundColor: "#28a745",
  color: "white",
  border: "none",
  cursor: "pointer",
  marginRight: "5px"
};

const rejectBtn = {
  padding: "4px 8px",
  backgroundColor: "#dc3545",
  color: "white",
  border: "none",
  cursor: "pointer"
};

export default LeaveApproval;
