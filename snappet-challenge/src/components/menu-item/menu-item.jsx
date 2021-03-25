import { Link } from "react-router-dom";
import "./menu-item.scss";

const MenuItem = ({ children, menuItemText, linkTo }) => {
  return (
    <Link to={linkTo} className="menu-item-content">
      <div className="menu-item-icon">{children}</div>
      <div className="menu-item-text">{menuItemText}</div>
    </Link>
  );
};

export default MenuItem;
