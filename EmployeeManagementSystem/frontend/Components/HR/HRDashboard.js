import React from "react";
import { Link } from "react-router-dom";

const HRDashboard = () => {
  return (
    <div>
      <h2>HR Dashboard</h2>
        <Link to="/HR/EmployeeCrud">Manage Employees</Link><br/>
        <Link to="/HR/RoleAssignment">Assign Roles</Link><br/>
        <Link to="/HR/LeaveApproval">Approve/Reject Leaves</Link><br/>
        <Link to="/HR/Reports">Reports</Link>
    </div>
  );
};

export default HRDashboard;
