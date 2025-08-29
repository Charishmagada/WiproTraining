import axios from 'axios';
import React, { useEffect, useState } from 'react';

const DepartmentEmployees = () => {
  const [departments, setDepartments] = useState([]);
  const [employees, setEmployees] = useState([]);
  const [selectedDept, setSelectedDept] = useState("");

  // Fetch departments from backend
  useEffect(() => {
    const fetchDepartments = async () => {
      try {
        const response = await axios.get("https://localhost:7008/api/Departments", {
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        });
        setDepartments(response.data);
      } catch (err) {
        console.error("Error fetching departments", err);
      }
    };
    fetchDepartments();
  }, []);

  // Fetch employees for selected department
  const fetchEmployees = async (deptId) => {
    try {
      const response = await axios.get("https://localhost:7008/api/Employees", {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      // Filter employees by departmentId
      const filtered = response.data.filter(e => e.departmentId === deptId);
      setEmployees(filtered);
      setSelectedDept(deptId);
    } catch (err) {
      console.error("Error fetching employees", err);
    }
  };

  return (
    <div>
      <h2>Department Employees</h2>
      <label>Select Department: </label>
      <select onChange={e => fetchEmployees(parseInt(e.target.value))} value={selectedDept}>
        <option value="">--Choose--</option>
        {departments.map(d => (
          <option key={d.departmentId} value={d.departmentId}>{d.departmentName}</option>
        ))}
      </select>

      {selectedDept && employees.length > 0 ? (
        <table border="1" align="center" style={{ marginTop: '20px' }}>
          <thead>
            <tr>
              <th>Emp Id</th>
              <th>Name</th>
              <th>Email</th>
              <th>Mobile</th>
              <th>Manager Id</th>
              <th>Leave Balance</th>
            </tr>
          </thead>
          <tbody>
            {employees.map(e => (
              <tr key={e.empId}>
                <td>{e.empId}</td>
                <td>{e.empName}</td>
                <td>{e.email}</td>
                <td>{e.mobile}</td>
                <td>{e.mgrId}</td>
                <td>{e.leaveAvail}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : selectedDept ? (
        <p style={{ marginTop: '20px' }}>No employees found in this department.</p>
      ) : null}
    </div>
  );
};

export default DepartmentEmployees;
