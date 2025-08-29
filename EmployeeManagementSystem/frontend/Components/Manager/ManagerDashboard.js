import React from "react";
import { Link } from "react-router-dom";

const ManagerDashboard = () => {
  return (
    <div>
      <h2>Manager Dashboard</h2>
      <Link to="/Manager/ManagerTeamLeaves">Approve Leave Requests</Link><br/>
        <Link to="/Manager/DepartmentEmployees">View Department Employees</Link>
    </div>
  );
};

export default ManagerDashboard;
