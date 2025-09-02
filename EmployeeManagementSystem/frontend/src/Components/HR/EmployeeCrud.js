import axios from 'axios';
import React, { useEffect, useState } from 'react';

const EmployeeCrud = () => {
  const [employees, setEmployees] = useState([]);
  const [newEmp, setNewEmp] = useState({
    empId: '',
    empName: '',
    email: '',
    mobile: '',
    dateOfBirth: '',
    departmentId: '',
    mgrId: '',
    leaveAvail: '' // placeholder instead of default 10
  });
  const [message, setMessage] = useState('');
  const [isEditing, setIsEditing] = useState(false);

  const fetchEmployees = async () => {
    try {
      const response = await axios.get("https://localhost:7008/api/Employees", {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setEmployees(response.data);
    } catch (err) {
      console.error(err);
      setMessage('Failed to fetch employees.');
    }
  };

  const validateForm = () => {
    if (!newEmp.empId || !newEmp.departmentId || !newEmp.mgrId) {
      setMessage('Emp Id, Dept Id, and Mgr Id are required.');
      return false;
    }
    return true;
  };

  const handleAdd = async () => {
    if (!validateForm()) return;

    const payload = {
      ...newEmp,
      empId: Number(newEmp.empId),
      departmentId: Number(newEmp.departmentId),
      mgrId: Number(newEmp.mgrId),
      leaveAvail: Number(newEmp.leaveAvail || 10) // default 10 if empty
    };

    try {
      const response = await axios.post("https://localhost:7008/api/Employees", payload, {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setMessage(`Employee added successfully! ID: ${response.data.empId}`);
      resetForm();
      fetchEmployees();
    } catch (err) {
      console.error(err);
      setMessage('Failed to add employee.');
    }
  };

  const handleEdit = (emp) => {
    setNewEmp({
      ...emp,
      empId: emp.empId.toString(),
      departmentId: emp.departmentId?.toString() || '',
      mgrId: emp.mgrId?.toString() || '',
      leaveAvail: emp.leaveAvail?.toString() || ''
    });
    setIsEditing(true);
  };

  const handleUpdate = async () => {
    if (!validateForm()) return;

    const payload = {
      ...newEmp,
      empId: Number(newEmp.empId),
      departmentId: Number(newEmp.departmentId),
      mgrId: Number(newEmp.mgrId),
      leaveAvail: Number(newEmp.leaveAvail || 10)
    };

    try {
      await axios.put(`https://localhost:7008/api/Employees/${newEmp.empId}`, payload, {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setMessage(`Employee ID ${newEmp.empId} updated successfully!`);
      resetForm();
      setIsEditing(false);
      fetchEmployees();
    } catch (err) {
      console.error(err);
      setMessage('Failed to update employee.');
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`https://localhost:7008/api/Employees/${id}`, {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setMessage(`Employee ID ${id} deleted successfully.`);
      setEmployees(prev => prev.filter(emp => emp.empId !== id));
    } catch (err) {
      console.error(err);
      setMessage('Failed to delete employee.');
    }
  };

  const handleChange = (e) => {
    setNewEmp({ ...newEmp, [e.target.name]: e.target.value });
  };

  const resetForm = () => {
    setNewEmp({
      empId: '',
      empName: '',
      email: '',
      mobile: '',
      dateOfBirth: '',
      departmentId: '',
      mgrId: '',
      leaveAvail: ''
    });
  };

  useEffect(() => {
    fetchEmployees();
  }, []);

  return (
    <div style={{ padding: "10px 20px" }}>
      <h2 style={{ color: "#2c3e50", marginBottom: "8px" }}>Manage Employees</h2>

      {message && <p style={{ color: 'green', marginBottom: "15px" }}>{message}</p>}

      {/* Employee Form */}
      <div style={formCardStyle}>
        <h3 style={{ marginBottom: "10px" }}>{isEditing ? 'Edit Employee' : 'Add New Employee'}</h3>
        <div style={inputGridStyle}>
          <input type="number" name="empId" placeholder="Emp Id" value={newEmp.empId} onChange={handleChange} disabled={isEditing} style={inputStyle} />
          <input type="text" name="empName" placeholder="Name" value={newEmp.empName} onChange={handleChange} style={inputStyle} />
          <input type="email" name="email" placeholder="Email" value={newEmp.email} onChange={handleChange} style={inputStyle} />
          <input type="text" name="mobile" placeholder="Mobile" value={newEmp.mobile} onChange={handleChange} style={inputStyle} />
          <input type="date" name="dateOfBirth" value={newEmp.dateOfBirth} onChange={handleChange} style={inputStyle} />
          <input type="number" name="departmentId" placeholder="Dept Id" value={newEmp.departmentId} onChange={handleChange} style={inputStyle} />
          <input type="number" name="mgrId" placeholder="Mgr Id" value={newEmp.mgrId} onChange={handleChange} style={inputStyle} />
          <input type="number" name="leaveAvail" placeholder="Leave Balance" value={newEmp.leaveAvail} onChange={handleChange} style={inputStyle} />
        </div>
        <div style={{ marginTop: "10px" }}>
          {isEditing ? (
            <>
              <button onClick={handleUpdate} style={primaryBtn}>Update</button>
              <button onClick={() => { resetForm(); setIsEditing(false); }} style={secondaryBtn}>Cancel</button>
            </>
          ) : (
            <button onClick={handleAdd} style={primaryBtn}>Add</button>
          )}
        </div>
      </div>

      {/* Employee Table */}
      <h3 style={{ margin: "15px 0 10px 0" }}>Employee List</h3>
      <div style={{ overflowX: "auto" }}>
        <table style={tableStyle}>
          <thead style={theadStyle}>
            <tr>
              <th style={thTdStyle}>Emp Id</th>
              <th style={thTdStyle}>Name</th>
              <th style={thTdStyle}>Email</th>
              <th style={thTdStyle}>Dept Id</th>
              <th style={thTdStyle}>Mgr Id</th>
              <th style={thTdStyle}>Leave Balance</th>
              <th style={thTdStyle}>Actions</th>
            </tr>
          </thead>
          <tbody>
            {employees.map((e, index) => (
              <tr key={e.empId} style={tbodyRowStyle(index)}>
                <td style={thTdStyle}>{e.empId}</td>
                <td style={thTdStyle}>{e.empName}</td>
                <td style={thTdStyle}>{e.email}</td>
                <td style={thTdStyle}>{e.departmentId}</td>
                <td style={thTdStyle}>{e.mgrId}</td>
                <td style={thTdStyle}>{e.leaveAvail}</td>
                <td style={thTdStyle}>
                  <button onClick={() => handleEdit(e)} style={editBtn}>Edit</button>
                  <button onClick={() => handleDelete(e.empId)} style={deleteBtn}>Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

// Styles (unchanged)
const formCardStyle = {
  padding: "10px",
  borderRadius: "0px",
  backgroundColor: "#f8f9fa",
  boxShadow: "0 2px 6px rgba(0,0,0,0.1)",
  marginBottom: "15px"
};

const inputGridStyle = {
  display: "grid",
  gridTemplateColumns: "repeat(auto-fit, minmax(150px, 1fr))",
  gap: "8px"
};

const inputStyle = {
  padding: "8px 10px",
  borderRadius: "4px",
  border: "1px solid #ccc",
  outline: "none"
};

const primaryBtn = {
  padding: "6px 12px",
  backgroundColor: "#2c3e50",
  color: "white",
  border: "none",
  borderRadius: "0px",
  cursor: "pointer",
  marginRight: "8px"
};

const secondaryBtn = {
  padding: "6px 12px",
  backgroundColor: "#6c757d",
  color: "white",
  border: "none",
  borderRadius: "4px",
  cursor: "pointer"
};

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

const editBtn = {
  padding: "4px 8px",
  backgroundColor: "#007bff",
  color: "white",
  border: "none",
  borderRadius: "4px",
  marginRight: "5px",
  cursor: "pointer"
};

const deleteBtn = {
  padding: "4px 8px",
  backgroundColor: "#dc3545",
  color: "white",
  border: "none",
  borderRadius: "4px",
  cursor: "pointer"
};

export default EmployeeCrud;
