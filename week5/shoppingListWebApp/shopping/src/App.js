import logo from './logo.svg';
import './App.css';
import React, { useState } from 'react';
import ListDisplay from './ListDisplay';
import InputText from './InputText';
import Header from './Header';
import Footer from './Footer';

function App() {

  const[items, setItems] = useState(["oranges", "apples", "candy"]);
  return (
    <>
    <Header></Header>
    <div id="list-container">
      <ListDisplay items={items} handleClick={(item) => {
        setItems(items.slice().filter((i) => i !== item));
      }}/>
      <InputText handleSubmit={(item) => {
        setItems(items.concat(item));
      }}
      />
    </div>
    <Footer></Footer>
    </>
  );
}

export default App;