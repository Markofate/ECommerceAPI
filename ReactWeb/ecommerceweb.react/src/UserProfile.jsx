import React, { useState, useEffect } from 'react';
import axios from 'axios';
import "./static/userprofile.css";
import Swal from 'sweetalert2';
import { Link } from 'react-router-dom';

const UserProfile = () => {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const email = localStorage.getItem('email');
  const [editMode, setEditMode] = useState(false);

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const response = await axios.get(`https://localhost:7227/User/Profile/${email}`);
        const user = response.data;
        setFirstName(user.firstName);
        setLastName(user.lastName);
      } catch (err) {
        console.error('Error fetching user data:', err);
      }
    };

    fetchUserData();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
        await axios.put('https://localhost:7227/User/Update', {
            email,
            firstName,
            lastName
          });
      Swal.fire({
        title: 'Success!',
        text: 'Your profile has been updated.',
        icon: 'success'
      }).then(()=> location.reload());
      setEditMode(false);
    }catch (err) {
      Swal.fire({
        title: 'Error!',
        text: 'There was a problem updating your profile.',
        icon: 'error'
      });
      console.error('Error updating profile:', err);
    }
  };

  return (
    <div className="user-profile-container">
      <h2>User Profile</h2>
      {!editMode ? (
        <div className="user-profile-details">
          <p><strong>First Name:</strong> {firstName}</p>
          <p><strong>Last Name:</strong> {lastName}</p>
          <p><strong>Email:</strong> {email}</p>
          <button onClick={() => setEditMode(true)} className="btn btn-primary">Edit Profile</button>
        </div>
      ) : (
        <form className="user-profile-form" onSubmit={handleSubmit}>
          <div className="form-group">
            <label>First Name</label>
            <input
              type="text"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
              required
            />
          </div>
          <div className="form-group">
            <label>Last Name</label>
            <input
              type="text"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
              required
            />
          </div>
          <div className="form-group">
            <label>Email</label>
            <input
              type="email"
              value={email}
              readOnly
            />
          </div>
          <button type="submit" className="btn btn-primary">Save Changes</button>
          <button onClick={() => setEditMode(false)} className="btn btn-secondary">Cancel</button>
        </form>
      )}
      <div className="orders-section">
        <h2>My Orders</h2>
        <Link to="/orders" className="btn btn-secondary">View Orders</Link>
      </div>
    </div>
  );
};

export default UserProfile;
