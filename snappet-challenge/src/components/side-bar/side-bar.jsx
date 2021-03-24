import MenuItem from "../menu-item/menu-item";
import "./side-bar.scss";
import { HiHome } from "react-icons/hi";
import { FaChild } from "react-icons/fa";

const SideBar = () => {
  return (
    <div class="side-bar-content">
      <MenuItem menuItemText="Home">
        <HiHome />
      </MenuItem>
      <MenuItem menuItemText="Students">
        <FaChild />
      </MenuItem>
    </div>
  );
};

export default SideBar;
