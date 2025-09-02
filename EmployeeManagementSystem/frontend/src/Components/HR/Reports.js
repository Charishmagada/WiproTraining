import axios from 'axios';
import React, { useEffect, useState } from 'react';

const Reports = () => {
  const [employees, setEmployees] = useState([]);
  const [departments, setDepartments] = useState([]);

  // Fetch employees and departments
  useEffect(() => {
    const fetchData = async () => {
      try {
        const [empResponse, deptResponse] = await Promise.all([
          axios.get("https://localhost:7008/api/Employees", {
            headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
          }),
          axios.get("https://localhost:7008/api/Departments", {
            headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
          })
        ]);

        setEmployees(empResponse.data);
        setDepartments(deptResponse.data);
      } catch (err) {
        console.error("Error fetching data", err);
      }
    };

    fetchData();
  }, []);

  const totalEmployees = employees.length;

  // Assuming initial leave allocation is 30 for each employee
  const initialLeave = 30;
  const totalLeaves = employees.reduce((sum, e) => sum + (initialLeave - e.leaveAvail), 0);

  // Department-wise count
  const deptMap = Object.fromEntries(departments.map(d => [d.departmentId, d.departmentName]));
  const departmentCount = employees.reduce((acc, e) => {
    const dept = deptMap[e.departmentId] || "N/A";
    acc[dept] = (acc[dept] || 0) + 1;
    return acc;
  }, {});

  return (
    <div style={{ padding: "10px 20px" }}>
      <h2 style={{ color: "#2c3e50", marginBottom: "10px" }}>Employee Reports</h2>

      <div style={{ marginBottom: "15px" }}>
        <p>Total Employees: {totalEmployees}</p>
        <p>Total Leaves Taken: {totalLeaves}</p>
      </div>

      <h3 style={{ marginBottom: "10px" }}>Employee Leave Balance</h3>
      <div style={{ overflowX: "auto", marginBottom: "20px" }}>
        <table style={tableStyle}>
          <thead style={theadStyle}>
            <tr>
              <th style={thTdStyle}>Emp Id</th>
              <th style={thTdStyle}>Name</th>
              <th style={thTdStyle}>Leave Balance</th>
            </tr>
          </thead>
          <tbody>
            {employees.map((e, index) => (
              <tr key={e.empId} style={tbodyRowStyle(index)}>
                <td style={thTdStyle}>{e.empId}</td>
                <td style={thTdStyle}>{e.empName}</td>
                <td style={thTdStyle}>{e.leaveAvail}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <h3 style={{ marginBottom: "10px" }}>Department-wise Employee Count</h3>
      <div style={{ overflowX: "auto", marginBottom: "20px" }}>
        <table style={tableStyle}>
          <thead style={theadStyle}>
            <tr>
              <th style={thTdStyle}>Department</th>
              <th style={thTdStyle}>Count</th>
            </tr>
          </thead>
          <tbody>
            {Object.entries(departmentCount).map(([dept, count], index) => (
              <tr key={dept} style={tbodyRowStyle(index)}>
                <td style={thTdStyle}>{dept}</td>
                <td style={thTdStyle}>{count}</td>
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
  minWidth: "400px",
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

export default Reports;
