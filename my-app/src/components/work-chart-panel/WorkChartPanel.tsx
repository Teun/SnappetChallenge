import { useState, useMemo } from "react";
import { Paper, Stack } from "@mui/material";
import WorkPageLabel from "../work-page/WorkPageLabel";
import WorkChart from "./WorkChart";
import ChartPanelSelect from "./work-chart-panel-select/ChartPanelSelect";
import { WorkEntry } from "../../types/WorkEntry";
import { DOMAIN } from "../../constants/domain";
import { SUBJECT } from "../../constants/subject";

const DOMAIN_SUBJECT_STRINGS = [DOMAIN, SUBJECT];

//Using a set to hold all uniques values of subject and domain
const getAvailableDomains = (
  workData: WorkEntry[],
  domainOrSubjectInput: string
) =>
  domainOrSubjectInput === DOMAIN
    ? new Set(workData.map((workEntry: WorkEntry) => workEntry.Domain))
    : [];

const getAvailableSubjects = (
  workData: WorkEntry[],
  domainOrSubjectInput: string
) =>
  domainOrSubjectInput === SUBJECT
    ? new Set(workData.map((workEntry: WorkEntry) => workEntry.Subject))
    : [];

//Creating a new array from the available domain and subject
//This will only be populated by either domain or subjects depending on the
//domainOrSubjectInput selection
const getDomainOrSubjectValues = (
  workData: WorkEntry[],
  domainOrSubjectInput: string
) =>
  [
    ...Array.from(getAvailableDomains(workData, domainOrSubjectInput)),
    ...Array.from(getAvailableSubjects(workData, domainOrSubjectInput)),
  ] as string[];

//Gets the actual domain or subject data
const getSelectedDomainOrSubjectData = (
  workData: WorkEntry[],
  domainOrSubjectInput: string,
  domainOrSubjectEntries: string
) => {
  if (domainOrSubjectInput === DOMAIN) {
    return workData.filter(
      (workEntry: WorkEntry) => workEntry.Domain === domainOrSubjectEntries
    );
  }
  if (domainOrSubjectInput === SUBJECT) {
    return workData.filter(
      (workEntry: WorkEntry) => workEntry.Subject === domainOrSubjectEntries
    );
  }

  return [];
};

//Component that accepts an array of daily and of monthly work data
// it renders two select components for choosing Domain/Subject and their values
// based on the user's selection, it filters the data by domain or subject and passes
//them on to the graphical charts

export default function WorkChartPanel({
  dailyWorkData,
  monthlyWorkData,
}: {
  dailyWorkData: WorkEntry[];
  monthlyWorkData: WorkEntry[];
}) {
  const [domainOrSubjectInput, setDomainOrSubjectInput] = useState("");
  const [domainOrSubjectEntries, setDomainOrSubjectEntries] = useState("");

  const dailyDomainOrSubjectValues = getDomainOrSubjectValues(
    dailyWorkData,
    domainOrSubjectInput
  );
  const dailySelectedDomainOrSubjectData = getSelectedDomainOrSubjectData(
    dailyWorkData,
    domainOrSubjectInput,
    domainOrSubjectEntries
  );
  const monthlySelectedDomainOrSubjectData = useMemo(
    () =>
      getSelectedDomainOrSubjectData(
        monthlyWorkData,
        domainOrSubjectInput,
        domainOrSubjectEntries
      ),
    [domainOrSubjectInput, domainOrSubjectEntries, monthlyWorkData]
  );

  return (
    <Stack direction="column" spacing={2} style={{ padding: "16px" }}>
      <WorkPageLabel
        variant="h4"
        message={"Visualisation of daily and monthly performance"}
      />
      <Paper
        variant="outlined"
        style={{
          display: "flex",
          minHeight: "30vh",
          justifyContent: "center",
          alignItems: "center",
          overflow: "scroll",
        }}
      >
        <Stack direction="column" spacing={3} mt={5}>
          <Stack direction="column" spacing={3}>
            <WorkPageLabel
              variant="h6"
              message={"Choose a domain or subject to view data for:"}
            />
            <ChartPanelSelect
              inputLabel="Domain/Subject"
              values={DOMAIN_SUBJECT_STRINGS}
              selectedValue={domainOrSubjectInput}
              setSelectedValue={setDomainOrSubjectInput}
            />
            <ChartPanelSelect
              inputLabel={domainOrSubjectInput}
              values={dailyDomainOrSubjectValues}
              selectedValue={domainOrSubjectEntries}
              setSelectedValue={setDomainOrSubjectEntries}
              disabled={!domainOrSubjectInput.length}
            />
          </Stack>
          <WorkChart
            workData={dailySelectedDomainOrSubjectData}
            chartTitle="Daily"
          />
          <WorkChart
            workData={monthlySelectedDomainOrSubjectData}
            chartTitle="Monthly"
          />
        </Stack>
      </Paper>
    </Stack>
  );
}
