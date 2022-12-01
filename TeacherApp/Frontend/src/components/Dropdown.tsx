import React, { Fragment, FunctionComponent, MouseEvent, useState } from 'react';
import styled from 'styled-components';

interface Props {
  title: string,
  options?: string[],
  checked: string,
  setChecked: (checked: string) => void;
  disabled?: boolean;
}

const Dropdown: FunctionComponent<Props> = ({ title, options, checked, setChecked, disabled }) => {
  // States.
  const [expanded, setExpanded] = useState(false);

  const expandDropdown = (e: MouseEvent) => {
    e.preventDefault();
    setExpanded(!expanded);
  }

  return (
    <Wrapper className={disabled ? "disabled" : ""}>
      <DropdownContainer onClick={(e) => expandDropdown(e)} className={expanded ? "dropdown expanded" : "dropdown"}>
        {/* Title passed from props. */}
        <Input
          type="radio" 
          value={title} 
          checked={checked === title} 
          id="dropdown-title" 
          key="title" 
          onChange={() => {}}
        />
        <Label htmlFor="dropdown-title" onClick={() => setChecked(title)}>
          {title ? `- ${title} -` : "- Select -"}
        </Label>
        {/* Options passed from props. */}
        {options && options.length > 0 && options.map((option, i) => {
          return (
            <Fragment key={`option-${i}`}>
              <Input 
                type="radio" 
                value={option} 
                id={`option-${i}`} 
                checked={checked === option} 
                onChange={() => {}} 
              />
              <Label htmlFor={`option-${i}`} onClick={() => setChecked(option)}>
                {option?.charAt(0).toUpperCase() + option.slice(1)}
              </Label>
            </Fragment>
          )
        })}
      </DropdownContainer>
    </Wrapper>
  );
};

const Wrapper = styled.div`
  position: relative;
  z-index: 1;
  min-width: 12em;
  height: 2em;

  &.disabled {
    pointer-events: none;

    .dropdown {
      background: darkgray;
    }
  }
`;

const DropdownContainer = styled.div`
  display: inline-block;
  margin-right: 1em;
  max-height: 1.5em;
  overflow: hidden;
  cursor: pointer;
  text-align: left;
  white-space: nowrap;
  color: #444;
  outline: none;
  border: .06em solid transparent;
  border-radius: .5em;
  background-color: lightblue;
  transition: .3s all ease-in-out;
  width: 12em;

  input:focus + label {
    background: #def;
  }

  &::after {
    content: "";
    position: absolute;
    right: 1.3em;
    top: 0.7em;
    border: .3em solid dodgerblue;
    border-color: dodgerblue transparent transparent transparent;
    transition: .4s all ease-in-out;
  }

  &.expanded {
    background: #fff;
    border-radius: .1em;
    padding: 0;
    box-shadow: rgba(0, 0, 0, 0.1) 3px 3px 5px 0px;
    max-height:15em;
    
    label {
      border-top: .06em solid #d9d9d9;
      &:hover {
        color: dodgerblue;
      }
    }
    input:checked + label {
      color: dodgerblue;
    }
    
    &::after {
      transform: rotate(-180deg);
      top: .4em;
    }
  }
`

const Input = styled.input`
  width: 1px;
  height: 1px;
  display: inline-block;
  position: absolute;
  opacity: 0.01;

  &:checked + label {
    display: block;
    border-top: none;
    position: absolute;
    top: 0;
    width: 100%;

    &:nth-child(2) {
      margin-top: 0;
      position: relative;
    }
  }
`;

const Label = styled.label`
  border-top: .06em solid #d9d9d9;
  display: block;
  height: 1.5em;
  line-height: 1.5em;
  padding: 0 1em;
  cursor: pointer;
  position: relative;
  transition: .3s color ease-in-out;
  max-width: 10em;
  text-overflow: ellipsis;
  overflow: hidden;

  &:nth-child(2) {
    margin-top: 2em;
    border-top: .06em solid #d9d9d9;
  }
`;

export default Dropdown;
