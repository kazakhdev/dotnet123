import React from 'react';
import { NavLink } from 'react-router-dom';

const Header = () => {
  return (
    <header>
      <h1>Help Desk</h1>
      <hr />
      <div className="links">
        <NavLink to="/" className="link" activeClassName="active" exact>
          List Request
        </NavLink>
        <NavLink to="/add" className="link" activeClassName="active">
          Add Request
        </NavLink>
      </div>
    </header>
  );
};

export default Header;
