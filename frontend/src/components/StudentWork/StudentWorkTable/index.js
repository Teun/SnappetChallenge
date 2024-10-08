import React, { useEffect, useState } from 'react';
import { Table } from 'antd';
import { StudentWorkService } from '../../../services'

const columns = [
	{
		title: 'Submitted Answer ID',
		dataIndex: 'submittedAnswerId',
		key: 'submittedAnswerId',
	},
	{
		title: 'Submit Date Time',
		dataIndex: 'submitDateTime',
		key: 'submitDateTime',
		render: (text) => new Date(text).toLocaleString(),
	},
	{
		title: 'Correct',
		dataIndex: 'correct',
		key: 'correct',
		render: (text) => (text === 1 ? 'Yes' : 'No'),
	},
	{
		title: 'Progress',
		dataIndex: 'progress',
		key: 'progress',
	},
	{
		title: 'User ID',
		dataIndex: 'userId',
		key: 'userId',
	},
	{
		title: 'Exercise ID',
		dataIndex: 'exerciseId',
		key: 'exerciseId',
	},
	{
		title: 'Difficulty',
		dataIndex: 'difficulty',
		key: 'difficulty',
	},
	{
		title: 'Subject',
		dataIndex: 'subject',
		key: 'subject',
	},
	{
		title: 'Domain',
		dataIndex: 'domain',
		key: 'domain',
	},
	{
		title: 'Learning Objective',
		dataIndex: 'learningObjective',
		key: 'learningObjective',
	},
];

const StudentWorkTable = () => {
	const [studentWorks, setStudentWorks] = useState([])
	const [submissionCount, setSubmissionCount] = useState(0)

	useEffect(() => {
		fetchStudentWorks()
		fetchSubmissionCount()
	}, [])

	const fetchStudentWorks = async () => {
		const response = await StudentWorkService.getAllStudentWorksToday()
		if (response) {
			setStudentWorks(response)
		}
	}

	const fetchSubmissionCount = async () => {
		const response = await StudentWorkService.getSubmissionCountToday()
		if (response) {
			setSubmissionCount(response)
		}
	}

	return (
		<div 
			className='sw-student-work-table' 
			style={{
				width: "100vw",
				display: "flex",
				alignItems: "center",
				justifyContent: "center",
                flexDirection: "column",
                gap: "20px"

			}}
        >
            <h1>Student Works Today</h1>
			<h3>Today has {submissionCount} submissions</h3>
            <Table columns={columns} dataSource={studentWorks} style={{ width: '80vw' }} />
        </div>
	)
}

export default StudentWorkTable