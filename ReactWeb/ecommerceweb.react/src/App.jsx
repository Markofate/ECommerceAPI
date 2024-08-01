import './static/App.css';
import ProductDetail from "./ProductDetail.jsx";
import  Products  from "./Products.jsx";
import Cart from './Cart.jsx';
import CreateOrder from './CreateOrder.jsx';
import Favorites from "./Favorites.jsx";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Landing from './Landing.jsx';
import PrivateRoute from './PrivateRoute.jsx';
import Login from './Login.jsx';
import Register from './Register.jsx';
import UserProfile from './UserProfile.jsx';

function App() {

  return (
    <>
    <BrowserRouter>
      <Routes>
          <Route path="/" element={<Landing />} />
          <Route path="/login" element={<Login />} />
          <Route path='/register' element={<Register />}/>
          <Route path='/Profile' element={<PrivateRoute> <UserProfile/> </PrivateRoute>}/>
          <Route path="products" element={< Products/>} />
          <Route path="/product/:id" element={<ProductDetail />} />
          <Route path='/cart' element={<PrivateRoute> <Cart/> </PrivateRoute>}/>
          <Route path='/create-order' element={<PrivateRoute> <CreateOrder /> </PrivateRoute>}/>
          <Route path='/Favorites' element={<PrivateRoute> <Favorites /> </PrivateRoute>} />
          <Route path= "*" element={404} />
      </Routes>
    </BrowserRouter>
    </>
  )
}

export default App