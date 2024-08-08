import React from 'react';
import memeImage from '../assets/meme.jpg';
import './Home.css';

const Home = () => {
  return (
    <div className="container">
      <h2>Welcome to the Home Page</h2>
      <p>This is the home page made by Jean-Luc.</p>
      <p>Here is a meme because I feel like the page is too empty.</p>
      <img src={memeImage} alt="Back to the future meme" style={{width: '100%', maxWidth: '600px'}} />
    </div>
  );
};

export default Home;
