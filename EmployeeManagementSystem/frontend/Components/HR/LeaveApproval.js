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
    <div>
      <h2>Leave Requests (HR Approval)</h2>
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
          {leaves.map(l => (
            <tr key={l.leaveId}>
              <td>{l.leaveId}</td>
              <td>{l.empId}</td>
              <td>{l.leaveStartDate}</td>
              <td>{l.leaveEndDate}</td>
              <td>{l.noOfDays}</td>
              <td>{l.leaveStatus}</td>
              <td>{l.leaveReason}</td>
              <td>{l.managerComments}</td>
              <td>
                {l.leaveStatus === "PENDING" && (
                  <>
                    <button onClick={() => updateLeave(l.leaveId, "APPROVED")}>Approve</button>
                    <button onClick={() => updateLeave(l.leaveId, "REJECTED")}>Reject</button>
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

export default LeaveApproval;
