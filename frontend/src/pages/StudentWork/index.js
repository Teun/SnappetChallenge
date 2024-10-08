import React from 'react'
import { StudentWorkTable, TopStudentTable, SubjectChart } from '../../components/StudentWork'

const StudentWork = () => {
	return (
		<div>
            <StudentWorkTable/>
            <TopStudentTable/>
            <SubjectChart/>
        </div>
	)
}

export default StudentWork