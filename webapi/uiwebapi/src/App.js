import logo from './logo.svg';
import './App.css';
import Button from './components/Button';
import Input from './components/Input';
import Encode from './components/Encode';
import Decode from './components/Decode';

function App() {

  

  

  return (
    <div className="center">
      <Encode></Encode>
      <Decode></Decode>
    </div>
    
    // <div className="App">
    //   <header className="App-header">
    //     <img src={logo} className="App-logo" alt="logo" />
    //     <p>
    //       Edit <code>src/App.js</code> and save to reload.
    //     </p>
    //     <a
    //       className="App-link"
    //       href="https://reactjs.org"
    //       target="_blank"
    //       rel="noopener noreferrer"
    //     >
    //       Learn React
    //     </a>
    //   </header>
    // </div>
  );
}

export default App;
