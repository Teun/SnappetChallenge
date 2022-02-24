import React, {useEffect, useState} from 'react';
import {Chart} from 'react-google-charts';

import {transformDataForChartReport} from './DataUtil';
import studentResults from '../Data/work.json';
import {JsonStructure} from "./Types";

const options = {
  title: 'Amount of Correct Answers by Subject',
  chartArea: {width: '50%'},
  hAxis: {
    title: 'Amount Corrects',
    minValue: 0,
  },
  vAxis: {
    title: 'Subject',
  },
};

const ChartReport = (): JSX.Element => {
  const [processedReport, setProcessedReport] = useState([] as Array<Array<string | number>>);

  useEffect(() => {
    setProcessedReport(
      transformDataForChartReport(studentResults as Array<JsonStructure>)
    );
  }, []);

  return (
    <Chart
      chartType="BarChart"
      width="100%"
      height="400px"
      data={processedReport}
      options={options}
    />
  );
};

export default ChartReport;
