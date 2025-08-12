import logo from './logo.svg';
import './App.css';
import First from './components/first/first';
import Second from './components/second/second';
import Third from './components/third/third';
import ButtonEx from './components/buttonex/buttonex';
import Fourth from './components/fourth/fourth';
import Fifth from './components/fifth/fifth';
import Sixth from './components/sixth/sixth';
import Seventh from './components/seventh/seventh';
import Eighth from './components/eighth/eighth';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Menu from './components/menu/menu';
import Login from './components/login/login';


function App() {
  return (
    <div className="App">
      <p>Welcome to React Programming!</p>
      <BrowserRouter>
        <Routes>
           <Route path="/" element={<Login />} /> {/* Default route */}
          <Route path='/menu' element={<Menu />} />
          <Route path='/first' element={<First />} />
          <Route path='/second' element={<Second />} />
          <Route path='/third' element={<Third firstName="Tapaswi" lastName="Bollina" company="Microsoft" />} />
          <Route path='/fourth' element={<Fourth />} />
          <Route path='/fifth' element={<Fifth />} />
          <Route path='/sixth' element={<Sixth />} />
          <Route path='/seventh' element={<Seventh />} />
          <Route path='/eighth' element={<Eighth />} />
          <Route path='/buttonex' element={<ButtonEx />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
