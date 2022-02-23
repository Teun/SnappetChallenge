import * as React from 'react';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Box from '@mui/material/Box';
import {DetailedReport} from "../components";

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

const TabPanel = (props: TabPanelProps) => {
  const {children, value, index, ...other} = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      style={{margin: '2rem'}}
      {...other}
    >
      {value === index && (
        <Box>
          {children}
        </Box>
      )}
    </div>
  );
};

const a11yProps = (index: number) => {
  return {
    id: `simple-tab-${index}`,
    'aria-controls': `simple-tabpanel-${index}`,
  };
};

const HomePage = () => {
  const [currentTab, setCurrentTab] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setCurrentTab(newValue);
  };

  return (
    <Box sx={{width: '100%'}}>
      <Box sx={{borderBottom: 1, borderColor: 'divider', margin: '1rem'}}>
        <Tabs value={currentTab} onChange={handleChange}
              aria-label="basic tabs example">
          <Tab label="Detailed Report" {...a11yProps(0)} />
          <Tab label="General Report" {...a11yProps(1)} />
        </Tabs>
      </Box>
      <TabPanel value={currentTab} index={0}>
        <DetailedReport reportData={[{
          amountCorrects: 4,
          percentageCorrect: 0.8,
          learningObjective: 'Diverse leerdoelen Begrijpend Lezen',
          subject: 'Begrijpend Lezen'
        }]}/>
      </TabPanel>
      <TabPanel value={currentTab} index={1}>
        <h2>General Report</h2>
      </TabPanel>
    </Box>
  );
}

export default HomePage;
