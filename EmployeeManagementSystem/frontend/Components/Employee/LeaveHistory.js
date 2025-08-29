import axios from 'axios';
import React, { useEffect, useState } from 'react';

const LeaveHistory = () => {
  const [history, setHistory] = useState([]);

  useEffect(() => {
    const fetchHistory = async () => {
      try {
        let empId = localStorage.getItem("empId");
        const response = await axios.get(`https://localhost:7008/api/LeaveHistories/employee/${empId}`, {
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        });
        setHistory(response.data);
      } catch (err) {
        console.error("Error fetching leave history", err);
      }
    };
    fetchHistory();
  }, []);

  return (
    <div>
      <h2>My Leave History</h2>
      <table border="1" align="center">
        <thead>
          <tr>
            <th>Leave Id</th>
            <th>Start</th>
            <th>End</th>
            <th>No of Days</th>
            <th>Status</th>
            <th>Reason</th>
            <th>Manager Comments</th>
          </tr>
        </thead>
        <tbody>
          {history.map(item => (
            <tr key={item.leaveId}>
              <td>{item.leaveId}</td>
              <td>{item.leaveStartDate}</td>
              <td>{item.leaveEndDate}</td>
              <td>{item.noOfDays}</td>
              <td>{item.leaveStatus}</td>
              <td>{item.leaveReason}</td>
              <td>{item.managerComments}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default LeaveHistory;
