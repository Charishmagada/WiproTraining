import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

// Components
import Login from './Components/Login/Login';
import ProtectedRoute from './Components/ProtectedRoute';

// Employee Components
import EmployeeDashboard from './Components/Employee/EmployeeDashboard';
import EmployeeProfile from './Components/Employee/EmployeeProfile';
import ApplyLeave from './Components/Employee/ApplyLeave';
import LeaveHistory from './Components/Employee/LeaveHistory';

// Manager Components
import ManagerDashboard from './Components/Manager/ManagerDashboard';
import ManagerTeamLeaves from './Components/Manager/ManagerTeamLeaves';
import DepartmentEmployees from './Components/Manager/DepartmentEmployees';

// HR Components
import EmployeeCrud from './Components/HR/EmployeeCrud';
import RoleAssignment from './Components/HR/RoleAssignment';
import LeaveApproval from './Components/HR/LeaveApproval';
import Reports from './Components/HR/Reports';
import HRDashboard from './Components/HR/HRDashboard';
import RegisterUser from './Components/HR/RegisterUser'; 

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          {/* Public Route */}
          <Route path="/" element={<Login />} />

          {/* Employee Routes */}
          <Route element={<ProtectedRoute roles={["Employee"]} />}>
            <Route path="/Employee/EmployeeDashboard" element={<EmployeeDashboard />} />
            <Route path="/Employee/EmployeeProfile" element={<EmployeeProfile />} />
            <Route path="/Employee/ApplyLeave" element={<ApplyLeave />} />
            <Route path="/Employee/LeaveHistory" element={<LeaveHistory />} />
          </Route>

          {/* Manager Routes */}
          <Route element={<ProtectedRoute roles={["Manager"]} />}>
            <Route path="/Manager/ManagerDashboard" element={<ManagerDashboard />} />
            <Route path="/Manager/ManagerTeamLeaves" element={<ManagerTeamLeaves />} />
            <Route path="/Manager/DepartmentEmployees" element={<DepartmentEmployees />} />
          </Route>

          {/* HR Routes */}
          <Route element={<ProtectedRoute roles={["HR"]} />}>
            <Route path="/HR/HRDashboard" element={<HRDashboard />} />
            <Route path="/HR/EmployeeCrud" element={<EmployeeCrud />} />
            <Route path="/HR/RoleAssignment" element={<RoleAssignment />} />
            <Route path="/HR/LeaveApproval" element={<LeaveApproval />} />
            <Route path="/HR/Reports" element={<Reports />} />
            <Route path="/HR/RegisterUser" element={<RegisterUser />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
