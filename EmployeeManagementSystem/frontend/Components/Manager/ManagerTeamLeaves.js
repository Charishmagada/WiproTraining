import axios from 'axios';
import React, { useEffect, useState } from 'react';

const ManagerTeamLeaves = () => {
  const [requests, setRequests] = useState([]);
  const [message, setMessage] = useState("");

  const fetchTeamLeaves = async () => {
    try {
      // For simplicity: manager sees all pending leaves 
      const response = await axios.get("https://localhost:7008/api/LeaveHistories", {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setRequests(response.data);
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
      fetchTeamLeaves(); // refresh list
    } catch (err) {
      console.error("Error updating leave", err);
    }
  };

  useEffect(() => {
    fetchTeamLeaves();
  }, []);

  return (
    <div>
      <h2>Team Leave Requests</h2>
      {message && <p>{message}</p>}
      <table border="1" align="center">
        <thead>
          <tr>
            <th>Leave Id</th>
            <th>Emp Id</th>
            <th>Start</th>
            <th>End</th>
            <th>Days</th>
            <th>Status</th>
            <th>Reason</th>
            <th>Manager Comments</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {requests.map(item => (
            <tr key={item.leaveId}>
              <td>{item.leaveId}</td>
              <td>{item.empId}</td>
              <td>{item.leaveStartDate}</td>
              <td>{item.leaveEndDate}</td>
              <td>{item.noOfDays}</td>
              <td>{item.leaveStatus}</td>
              <td>{item.leaveReason}</td>
              <td>{item.managerComments}</td>
              <td>
                {item.leaveStatus === "PENDING" && (
                  <>
                    <button onClick={() => updateLeaveStatus(item.leaveId, "APPROVED")}>Approve</button>
                    <button onClick={() => updateLeaveStatus(item.leaveId, "REJECTED")}>Reject</button>
                  </>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ManagerTeamLeaves;
