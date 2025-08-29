import React from "react";
import { Link } from "react-router-dom";

const EmployeeDashboard = () => {
  return (
    <div>
      <h2>Employee Dashboard</h2>
      <Link to="/Employee/EmployeeProfile">View Profile</Link><br/>
        <Link to="/Employee/ApplyLeave">Apply Leave</Link><br/>
        <Link to="/Employee/LeaveHistory">Leave History</Link>
    </div>
  );
};

export default EmployeeDashboard;
