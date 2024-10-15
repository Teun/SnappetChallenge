import React from 'react'
import { StudentWorkTable, StudentPerformanceTable, SubjectChart } from '../../components/StudentWork'

const StudentWork = () => {
	return (
		<div>
            <StudentWorkTable/>
            <StudentPerformanceTable/>
            <SubjectChart/>
        </div>
	)
}

export default StudentWork