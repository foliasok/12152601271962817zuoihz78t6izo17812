import './App.css';
import { Route, Routes } from 'react-router-dom';
import Halak from './Halak';
import Horgaszok from './Horgaszok';
import Balaton from './Balaton';
import Navbar from './Navbar';
import SingleHal from './SingleHal';
import UjHorgasz from './UjHorgasz';
function App() {
  return (
    <div className="App">
    <Navbar/>
      <Routes>
        <Route path='/' element={<Halak/>}/>
        <Route path='/horgaszok' element={<Horgaszok/>}/>
        <Route path='/balaton' element={<Balaton/>}/>
        <Route path='/hal/:id' element={<SingleHal/>}/>
        <Route path='/ujhorgasz' element={<UjHorgasz/>}/>
      </Routes>
    </div>
  );
}

export default App;
