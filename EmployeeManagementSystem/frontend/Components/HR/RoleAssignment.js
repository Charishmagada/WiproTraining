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
    <div>
      <h2>Assign Roles</h2>
      <table border="1" align="center">
        <thead>
          <tr>
            <th>User Id</th>
            <th>Username</th>
            <th>Current Role</th>
            <th>Change Role</th>
          </tr>
        </thead>
        <tbody>
          {users.map(u => (
            <tr key={u.userId}>
              <td>{u.userId}</td>
              <td>{u.username}</td>
              <td>{u.role}</td>
              <td>
                <select defaultValue={u.role} onChange={e => updateRole(u.userId, e.target.value)}>
                  {roles.map(r => <option key={r} value={r}>{r}</option>)}
                </select>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default RoleAssignment;
