import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { filterSelected } from "./filterSlice";
import { getActiveFilter } from "../../work/store/workSelector";
import { Container, Button } from "react-bootstrap";

const filterLabels = ["Subject", "Domain"];

export const FilterSection = () => {
  const dispatch = useDispatch();
  const activeFilter = useSelector(getActiveFilter);
  const handleFilterClick = (filterClickEvent) =>
    dispatch(filterSelected(filterClickEvent.target.value));

  return (
    <Container className="py-3 d-flex flex-row-reverse">
      <ul className="filters">
        {filterLabels.map((filterLabel) => (
          <Button
            variant="outline-dark"
            key={`${filterLabel}-category`}
            value={filterLabel}
            active={filterLabel === activeFilter}
            onClick={handleFilterClick}
          >
            {filterLabel}
          </Button>
        ))}
      </ul>
    </Container>
  );
};
