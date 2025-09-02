import axios from 'axios';
import React, { useEffect, useState } from 'react';

const RoleAssignment = () => {
  const [users, setUsers] = useState([]);
  const [roles] = useState(["HR", "Manager", "Employee"]);

  const fetchUsers = async () => {
    try {
      const response = await axios.get("https://localhost:7008/api/Users", {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      setUsers(response.data);
    } catch (err) {
      console.error("Error fetching users", err);
    }
  };

  const updateRole = async (userId, role) => {
    try {
      const user = users.find(u => u.userId === userId);
      const updated = { ...user, role };

      await axios.put(`https://localhost:7008/api/Users/${userId}`, updated, {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      fetchUsers();
    } catch (err) {
      console.error("Error updating role", err);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  return (
    <div style={{ padding: "10px 20px" }}>
      <h2 style={{ color: "#2c3e50", marginBottom: "10px" }}>Assign Roles</h2>
      
      <div style={{ overflowX: "auto" }}>
        <table style={tableStyle}>
          <thead style={theadStyle}>
            <tr>
              <th style={thTdStyle}>User Id</th>
              <th style={thTdStyle}>Username</th>
              <th style={thTdStyle}>Current Role</th>
              <th style={thTdStyle}>Change Role</th>
            </tr>
          </thead>
          <tbody>
            {users.map((u, index) => (
              <tr key={u.userId} style={tbodyRowStyle(index)}>
                <td style={thTdStyle}>{u.userId}</td>
                <td style={thTdStyle}>{u.username}</td>
                <td style={thTdStyle}>{u.role}</td>
                <td style={thTdStyle}>
                  <select
                    defaultValue={u.role}
                    onChange={e => updateRole(u.userId, e.target.value)}
                    style={selectStyle}
                  >
                    {roles.map(r => (
                      <option key={r} value={r}>{r}</option>
                    ))}
                  </select>
                </td>
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

const selectStyle = {
  padding: "6px 8px",
  border: "1px solid #ccc",
  outline: "none",
  cursor: "pointer"
};

export default RoleAssignment;
