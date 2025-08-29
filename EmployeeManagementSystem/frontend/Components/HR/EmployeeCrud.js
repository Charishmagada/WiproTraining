import axios from 'axios';
import React, { useEffect, useState } from 'react';

const EmployeeCrud = () => {
  const [employees, setEmployees] = useState([]);
  const [newEmp, setNewEmp] = useState({
    empId: 0,         // Added empId
    empName: '',
    email: '',
    mobile: '',
    dateOfBirth: '',
    departmentId: 0,
    mgrId: 0,
    leaveAvail: 10
  });
  const [message, setMessage] = useState('');

  // Fetch employees from backend
  const fetchEmployees = async () => {
    try {
      const response = await axios.get("https://localhost:7008/api/Employees", {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setEmployees(response.data);
    } catch (err) {
      console.error("Error fetching employees", err);
      setMessage('Failed to fetch employees.');
    }
  };

  // Add new employee
  const handleAdd = async () => {
    try {
      // Prepare payload with correct types
      const payload = {
        ...newEmp,
        empId: Number(newEmp.empId),
        dateOfBirth: newEmp.dateOfBirth, // yyyy-mm-dd format
        departmentId: Number(newEmp.departmentId),
        mgrId: Number(newEmp.mgrId),
        leaveAvail: Number(newEmp.leaveAvail)
      };

      console.log("Sending payload:", payload);

      const response = await axios.post(
        "https://localhost:7008/api/Employees",
        payload,
        {
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        }
      );

      setMessage(`Employee added successfully! ID: ${response.data.empId}`);

      // Reset form
      setNewEmp({
        empId: 0,
        empName: '',
        email: '',
        mobile: '',
        dateOfBirth: '',
        departmentId: 0,
        mgrId: 0,
        leaveAvail: 10
      });

      // Refresh table
      fetchEmployees();
    } catch (err) {
      console.error("Error adding employee", err);
      setMessage('Failed to add employee. Check console for details.');
    }
  };

  // Delete employee
  const handleDelete = async (id) => {
    try {
      await axios.delete(`https://localhost:7008/api/Employees/${id}`, {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setMessage(`Employee ID ${id} deleted successfully.`);
      setEmployees(prev => prev.filter(emp => emp.empId !== id));
    } catch (err) {
      console.error("Error deleting employee", err);
      setMessage('Failed to delete employee.');
    }
  };

  // Handle input changes
  const handleChange = (e) => {
    setNewEmp({ ...newEmp, [e.target.name]: e.target.value });
  };

  useEffect(() => {
    fetchEmployees();
  }, []);

  return (
    <div>
      <h2>Manage Employees</h2>

      {message && <p style={{ color: 'green' }}>{message}</p>}

      <h3>Add New Employee</h3>
      <input type="number" name="empId" placeholder="Emp Id" value={newEmp.empId} onChange={handleChange} />
      <input type="text" name="empName" placeholder="Name" value={newEmp.empName} onChange={handleChange} />
      <input type="email" name="email" placeholder="Email" value={newEmp.email} onChange={handleChange} />
      <input type="text" name="mobile" placeholder="Mobile" value={newEmp.mobile} onChange={handleChange} />
      <input type="date" name="dateOfBirth" value={newEmp.dateOfBirth} onChange={handleChange} />
      <input type="number" name="departmentId" placeholder="Dept Id" value={newEmp.departmentId} onChange={handleChange} />
      <input type="number" name="mgrId" placeholder="Mgr Id" value={newEmp.mgrId} onChange={handleChange} />
      <input type="number" name="leaveAvail" placeholder="Leave Balance" value={newEmp.leaveAvail} onChange={handleChange} />
      <button onClick={handleAdd}>Add</button>

      <h3>Employee List</h3>
      <table border="1" align="center">
        <thead>
          <tr>
            <th>Emp Id</th>
            <th>Name</th>
            <th>Email</th>
            <th>Dept Id</th>
            <th>Mgr Id</th>
            <th>Leave Balance</th>
            <th>Delete</th>
          </tr>
        </thead>
        <tbody>
          {employees.map(e => (
            <tr key={e.empId}>
              <td>{e.empId}</td>
              <td>{e.empName}</td>
              <td>{e.email}</td>
              <td>{e.departmentId}</td>
              <td>{e.mgrId}</td>
              <td>{e.leaveAvail}</td>
              <td>
                <button onClick={() => handleDelete(e.empId)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default EmployeeCrud;
