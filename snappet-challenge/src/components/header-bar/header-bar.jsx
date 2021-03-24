import { images } from "../../assets/images";
import "./header-bar.scss";

const HeaderBar = () => {
  return (
    <div class="header-bar-content">
      <img src={images.snappetLogo} alt="snappet-logo" class="header-image" />
    </div>
  );
};

export default HeaderBar;
