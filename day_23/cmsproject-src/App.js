import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from './components/login/login';
import Dashboard from './components/dashboard/dashboard';
import AddCustomer from './components/addCustomer/addCustomer';
import UpdateCustomer from './components/updateCustomer/updateCustomer';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/dashboard" element={<Dashboard />} />
        <Route path="/addCustomer" element={<AddCustomer/>}/>
        <Route path="/updateCustomer/:id" element={<UpdateCustomer/>}/>
      </Routes>
    </BrowserRouter>
    </div>
  );
}

export default App;
