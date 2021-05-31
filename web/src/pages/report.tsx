import React, { useEffect, useState } from "react"
import { getReportForClass, getReportForStudent } from "../apis/SubmittedAnswers"
import ListReport from "../components/listReport"
import Search from "../components/search"
import { ReportResponse } from "../types/Report"

const Report = () => {
    const [loading, setLoading] = useState<boolean>(false)
    const [report, setReport] = useState<ReportResponse | undefined>(undefined)

    async function getClassReport(date: Date | undefined){
        setLoading(true)
        let response = await getReportForClass(date)
        setReport(response)
        setLoading(false)
    }

    async function getStudentReport(id: number, date: Date | undefined){
        setLoading(true)
        let response = await getReportForStudent(id, date)
        setReport(response)
        setLoading(false)
    }

    useEffect(() => {
        getClassReport(undefined)
      }, [])

    return (
        <div>
            <Search getClassReport={getClassReport} getStudentReport={getStudentReport}/>

            {loading && <div>loading</div>}
            {!loading && report &&
            <div>
                <div>
                    <h1>Domain Reports</h1>
                    <div className={"flex-container"}>
                        {report.domainReport?.map(x => <ListReport data={x}/>)}
                    </div>
                </div>
                <div>
                    <h1>Subject Reports</h1>
                    <div className={"flex-container"}>
                        {report.subjectReport?.map(x => <ListReport data={x}/>)}
                    </div>
                </div>
                <div>
                    <h1>Learning Objective Reports</h1>
                    <div className={"flex-container"}>
                        {report.learningObjectiveReport?.map(x => <ListReport data={x}/>)}
                    </div>
                </div>
                <div>
                    <h1>Difficulty Range Reports</h1>
                    <div className={"flex-container"}>
                        {report.difficultyRangeReport?.map(x => <ListReport data={x}/>)}
                    </div>
                </div>
            </div>
            }
        </div>
    )
}

export default Report;
