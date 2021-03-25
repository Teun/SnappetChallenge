import { images } from "../../assets/images";
import "./header-bar.scss";

const HeaderBar = ({ isLoading }) => {
  return (
    <div className="header-bar-content">
      <img
        src={images.snappetLogo}
        alt="snappet-logo"
        className="header-image"
      />
      {isLoading && (
        <div className="loader-box">
          <div className="loader"></div>
        </div>
      )}
    </div>
  );
};

export default HeaderBar;
