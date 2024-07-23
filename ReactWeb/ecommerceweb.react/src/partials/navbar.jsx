import './navbar.css';

const Navbar = () => {
  return (
    <header>
      <div className="navbar navbar-expand-sm">
        <div className="container-fluid">
          <a className="navbar-brand" href="/">ECommerce</a>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav mr-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <a className="nav-link" aria-current="page" href="/products">Products</a>
              </li>
              <li className="nav-item">
                <a className="nav-link" aria-current="page" href="/cart">Cart</a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="/about">About</a>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </header>
  );
}

export default Navbar;
