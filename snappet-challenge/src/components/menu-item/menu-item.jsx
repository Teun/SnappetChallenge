import "./menu-item.scss";

const MenuItem = ({ children, menuItemText }) => {
  return (
    <div class="menu-item-content">
      <div class="menu-item-icon">{children}</div>
      <div class="menu-item-text">{menuItemText}</div>
    </div>
  );
};

export default MenuItem;
