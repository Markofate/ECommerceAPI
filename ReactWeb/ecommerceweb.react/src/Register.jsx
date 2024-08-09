import React, { useState } from 'react';
import axios from 'axios';
import "./static/register.css";
import Swal from 'sweetalert2';

const Register = () => {
  const [FirstName, setFirstName] = useState('');
  const [LastName, setLastName] = useState('');
  const [Email, setEmail] = useState('');
  const [Password, setPassword] = useState('');
  const [RePassword, setRePassword] = useState('');
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7227/register', {
        FirstName,
        LastName,
        Email,
        Password,
        RePassword
      });
      Swal.fire({
        title: 'Registration Complete!',
        text: "Successfully Registered",
        icon: 'success'
      }).then(()=>location.replace('/login'));
    } catch (err) {
      setError(err.message);;
      Swal.fire({
        title: 'Something Went Wrong',
        text: "Check Email or Passwords",
        icon: 'error'
      })
    }
  };

  return (
    <div className="Register-container">
      <h2>Register</h2>
      <form className="Register-form" onSubmit={handleSubmit}>
        <div>
          <label>FirstName</label>
          <input type="string" value={FirstName} onChange={(e) => setFirstName(e.target.value)} required />
        </div>
        <div>
          <label>LastName</label>
          <input type="string" value={LastName} onChange={(e) => setLastName(e.target.value)} required />
        </div>
        <div>
          <label>Email</label>
          <input type="email" value={Email} onChange={(e) => setEmail(e.target.value)} required />
        </div>
        <div>
          <label>Password</label>
          <input type="password" value={Password} onChange={(e) => setPassword(e.target.value)} required />
        </div>
        <div>
          <label>RePassword</label>
          <input type="password" value={RePassword} onChange={(e) => setRePassword(e.target.value)} required />
        </div>
        <button type="submit">Register</button>
      </form>
    </div>
  );
};

export default Register;
