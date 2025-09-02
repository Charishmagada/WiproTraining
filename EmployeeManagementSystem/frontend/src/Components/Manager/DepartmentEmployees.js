import axios from 'axios';
import React, { useEffect, useState } from 'react';

const DepartmentEmployees = () => {
  const [employees, setEmployees] = useState([]);
  const [loading, setLoading] = useState(true);
  const [managerId, setManagerId] = useState(null);

  useEffect(() => {
    // Get logged-in manager's empId from localStorage or token
    const empId = localStorage.getItem("empId");
    if (empId) {
      setManagerId(parseInt(empId));
      fetchEmployees(parseInt(empId));
    }
  }, []);

  const fetchEmployees = async (mgrId) => {
    try {
      const response = await axios.get("https://localhost:7008/api/Employees", {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });

      // Filter employees whose mgrId matches logged-in manager
      const filtered = response.data.filter(e => e.mgrId === mgrId);
      setEmployees(filtered);
    } catch (err) {
      console.error("Error fetching employees", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ padding: "10px 20px" }}>
      <h2 style={{ color: "#2c3e50", marginBottom: "10px" }}>
        My Team Details
      </h2>

      {loading ? (
        <p>Loading...</p>
      ) : employees.length > 0 ? (
        <div style={{ overflowX: "auto", marginTop: "15px" }}>
          <table style={tableStyle}>
            <thead style={theadStyle}>
              <tr>
                <th style={thTdStyle}>Emp Id</th>
                <th style={thTdStyle}>Name</th>
                <th style={thTdStyle}>Email</th>
                <th style={thTdStyle}>Mobile</th>
                <th style={thTdStyle}>Department </th>
                <th style={thTdStyle}>Leave Balance</th>
              </tr>
            </thead>
            <tbody>
              {employees.map((e, index) => (
                <tr key={e.empId} style={tbodyRowStyle(index)}>
                  <td style={thTdStyle}>{e.empId}</td>
                  <td style={thTdStyle}>{e.empName}</td>
                  <td style={thTdStyle}>{e.email}</td>
                  <td style={thTdStyle}>{e.mobile}</td>
                  <td style={thTdStyle}>{e.departmentId}</td>
                  <td style={thTdStyle}>{e.leaveAvail}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      ) : (
        <p style={{ marginTop: "15px" }}>No employees found in your team.</p>
      )}
    </div>
  );
};

// Styles
const tableStyle = {
  width: "100%",
  borderCollapse: "collapse",
  minWidth: "600px",
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

export default DepartmentEmployees;
