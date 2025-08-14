import logo from './logo.svg';
import './App.css';
import ContextEx1 from './components/contextEx1/contextEx1';
import ContextEx2 from './components/contextEx2/contextEx2';
import ColorTheme from './components/colorTheme/colorTheme';
import FontTheme from './components/fontTheme/fontTheme';
import RefEx1 from './components/useRefEx1/useRefEx1';
import RefEx2 from './components/useRefEx2/useRefEx2';
import Memo1 from './components/useMemo1/useMemo1';
import Memo2 from './components/useMemo2/useMemo2';
import Memo3 from './components/useMemo3/useMemo3';

function App() {
  return (
    <div className="App">
      <ContextEx1/>
      <ContextEx2/>
      <ColorTheme/>
      <FontTheme/>
      <RefEx1/>
      <RefEx2/>
      <Memo1/>
      <Memo2/>
      <Memo3/>
    </div>
  );
}

export default App;
