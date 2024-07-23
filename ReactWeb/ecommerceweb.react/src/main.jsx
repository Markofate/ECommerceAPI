import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App.jsx';
import Navbar from'./partials/navbar.jsx';
import './static/index.css';

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <Navbar />
    <App />
  </React.StrictMode>
)
