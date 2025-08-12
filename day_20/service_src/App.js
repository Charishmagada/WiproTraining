import logo from './logo.svg';
import './App.css';
import UserShow from './components/usershow/usershow';
import EmployShow from './components/employeeshow/employeeshow';
import UserSearch from './components/usersearch/usersearch';
import EmploySearch from './components/employeesearch/employeesearch';

function App() {
  return (
    <div className="App">
      <UserShow/><br/>
      <EmployShow/><br/>
      <UserSearch/><br/>
      <EmploySearch/><br/>
    </div>
  );
}

export default App;
