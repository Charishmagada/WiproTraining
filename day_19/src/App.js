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

function App() {
  return (
    <div className="App">
      <p>Welcome to react programming demo</p>
      <p><First/></p>
      <p><Second/></p>
      <p><Third firstName="Tapaswi" lastName="Bollina" company="Microsoft"/></p>
      <p><ButtonEx/></p>
      <p><Fourth/></p>
      <p><Fifth/></p>
      <p><Sixth/></p>
      <p><Seventh/></p>
      <p><Eighth/></p>
    </div>
  );
}

export default App;
