import React, { useState } from 'react';
import axios from 'axios';
import "./static/login.css";
import Swal from 'sweetalert2';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7227/login', {
        email,
        password
      });
      localStorage.setItem('email', response.data.email);
      window.location.replace("/");
    } catch (err) {
      setError(err.message);
      Swal.fire({
        title: 'Something Went Wrong',
        text: err.response.data.message,
        icon: 'error'
      })
    }
  };

  return (
    <div className="login-container">
      <h2>Login</h2>
      <form className="login-form" onSubmit={handleSubmit}>
        <div>
          <label>Email</label>
          <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} required />
        </div>
        <div>
          <label>Password</label>
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} required />
        </div>
        <button type="submit">Login</button>
      </form>
    </div>
  );
};

export default Login;
