import axios from 'axios';
import React, { useEffect, useState } from 'react';

const ManagerTeamLeaves = () => {
  const [requests, setRequests] = useState([]);
  const [employees, setEmployees] = useState([]);
  const [message, setMessage] = useState("");

  // Get current manager's empId from localStorage (set during login)
  const managerEmpId = parseInt(localStorage.getItem("empId"));

  // Fetch employees and leaves
  const fetchTeamLeaves = async () => {
    try {
      const [empResponse, leaveResponse] = await Promise.all([
        axios.get("https://localhost:7008/api/Employees", {
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        }),
        axios.get("https://localhost:7008/api/LeaveHistories", {
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        })
      ]);

      setEmployees(empResponse.data);

      // Filter team employees
      const teamEmpIds = empResponse.data
        .filter(emp => emp.mgrId === managerEmpId)
        .map(emp => emp.empId);

      // Filter leave requests for team
      const teamLeaves = leaveResponse.data.filter(leave =>
        teamEmpIds.includes(leave.empId)
      );

      setRequests(teamLeaves);

    } catch (err) {
      console.error("Error fetching team leaves", err);
    }
  };

  const updateLeaveStatus = async (leaveId, newStatus) => {
    try {
      const request = requests.find(r => r.leaveId === leaveId);
      const updated = { ...request, leaveStatus: newStatus, managerComments: "Updated by Manager" };

      await axios.put(`https://localhost:7008/api/LeaveHistories/${leaveId}`, updated, {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });

      setMessage(`Leave ${leaveId} ${newStatus}`);
      fetchTeamLeaves();
    } catch (err) {
      console.error("Error updating leave", err);
    }
  };

  useEffect(() => {
    fetchTeamLeaves();
  }, []);

  return (
    <div style={{ padding: "10px 20px" }}>
      <h2 style={{ color: "#2c3e50", marginBottom: "10px" }}>
        Team Leave Requests (Updated by Manager)
      </h2>

      {message && <p style={{ color: "green" }}>{message}</p>}

      <div style={{ overflowX: "auto", marginTop: "15px" }}>
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
            {requests.map((item, index) => (
              <tr key={item.leaveId} style={tbodyRowStyle(index)}>
                <td style={thTdStyle}>{item.leaveId}</td>
                <td style={thTdStyle}>{item.empId}</td>
                <td style={thTdStyle}>{item.leaveStartDate}</td>
                <td style={thTdStyle}>{item.leaveEndDate}</td>
                <td style={thTdStyle}>{item.noOfDays}</td>
                <td style={thTdStyle}>{item.leaveStatus}</td>
                <td style={thTdStyle}>{item.leaveReason}</td>
                <td style={thTdStyle}>{item.managerComments}</td>
                <td style={thTdStyle}>
                  {item.leaveStatus === "PENDING" && (
                    <>
                      <button style={buttonStyle} onClick={() => updateLeaveStatus(item.leaveId, "APPROVED")}>Approve</button>
                      <button style={{ ...buttonStyle, backgroundColor: "#dc3545" }} onClick={() => updateLeaveStatus(item.leaveId, "REJECTED")}>Reject</button>
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

const buttonStyle = {
  padding: "5px 10px",
  margin: "0 2px",
  border: "none",
  cursor: "pointer",
  borderRadius: "0",
  backgroundColor: "#28a745",
  color: "white"
};

export default ManagerTeamLeaves;
