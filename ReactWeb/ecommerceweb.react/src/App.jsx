import './App.css';
import ProductDetail from "./ProductDetail.jsx";
import  Products  from "./Products.jsx";
import "primereact/resources/themes/mdc-light-deeppurple/theme.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {

  return (
    <>
    <BrowserRouter>
      <Routes>
          <Route path="products" element={< Products/>} />
          <Route path="/product/:id" element={<ProductDetail />} />
          <Route path= "*" element={404} />
      </Routes>
    </BrowserRouter>
    </>
  )
}

export default App
