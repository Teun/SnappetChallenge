import MenuItem from "../menu-item/menu-item";
import "./side-bar.scss";
import { HiHome } from "react-icons/hi";
import { FaChild } from "react-icons/fa";

const SideBar = () => {
  return (
    <div className="side-bar-content">
      <MenuItem menuItemText="Home" linkTo="/">
        <HiHome />
      </MenuItem>
      <MenuItem menuItemText="Students" linkTo="/students">
        <FaChild />
      </MenuItem>
    </div>
  );
};

export default SideBar;
