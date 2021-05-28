import React from 'react';
import { Bar } from 'react-chartjs-2';



const HorizontalBarChart = ({data,options}) => (
  <>   
    <Bar data={data} options={options} />
  </>
);

export default HorizontalBarChart;