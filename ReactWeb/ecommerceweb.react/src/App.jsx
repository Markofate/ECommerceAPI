import './static/App.css';
import ProductDetail from "./ProductDetail.jsx";
import  Products  from "./Products.jsx";
import Cart from './Cart.jsx';
import CreateOrder from './CreateOrder.jsx';
import Favorites from "./Favorites.jsx";
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {

  return (
    <>
    <BrowserRouter>
      <Routes>
          <Route path="products" element={< Products/>} />
          <Route path="/product/:id" element={<ProductDetail />} />
          <Route path='/cart' element={<Cart/>}/>
          <Route path='/create-order' element={<CreateOrder/>}/>
          <Route path='/Favorites' element={<Favorites/>}/>
          <Route path= "*" element={404} />
      </Routes>
    </BrowserRouter>
    </>
  )
}

export default App