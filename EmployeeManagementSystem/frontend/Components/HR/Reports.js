import axios from 'axios';
import React, { useEffect, useState } from 'react';

const Reports = () => {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    const fetch = async () => {
      const response = await axios.get("https://localhost:7008/api/Employees", {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setEmployees(response.data);
    };
    fetch();
  }, []);

  const totalEmployees = employees.length;
  const totalLeaves = employees.reduce((sum, e) => sum + (10 - e.leaveAvail), 0);

  return (
    <div>
      <h2>Employee Reports</h2>
      <p>Total Employees: {totalEmployees}</p>
      <p>Total Leaves Taken: {totalLeaves}</p>

      <h3>Employee Leave Balance</h3>
      <table border="1" align="center">
        <thead>
          <tr>
            <th>Emp Id</th>
            <th>Name</th>
            <th>Leave Balance</th>
          </tr>
        </thead>
        <tbody>
          {employees.map(e => (
            <tr key={e.empId}>
              <td>{e.empId}</td>
              <td>{e.empName}</td>
              <td>{e.leaveAvail}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Reports;
