import React, { useEffect, useState } from 'react';
import { Table } from 'antd';
import { StudentWorkService } from '../../../services'

const columns = [
	{
		title: 'User ID',
		dataIndex: 'userId',
		key: 'userId',
	},
	{
		title: 'Correct Submissions',
		dataIndex: 'correctSubmissions',
		key: 'correctSubmissions',
		defaultSortOrder: 'descend',
		sortDirections: ['ascend', 'descend', 'ascend'],
		sorter: (a, b) => a.correctSubmissions - b.correctSubmissions,
	},
    {
        title: 'Incorrect Submissions',
        dataIndex: 'incorrectSubmissions',
        key: 'incorrectSubmissions',
		sortDirections: ['ascend', 'descend', 'ascend'],
        sorter: (a, b) => a.incorrectSubmissions - b.incorrectSubmissions,
    },
    {
        title: 'Total Progress',
        dataIndex: 'totalProgress',
        key: 'totalProgress',
		defaultSortOrder: 'ascend',
		sortDirections: ['ascend', 'descend', 'ascend'],
        sorter: (a, b) => a.totalProgress - b.totalProgress,
    },
];

const StudentPerformanceTable = () => {
	const [students, setStudents] = useState([])

	useEffect(() => {
		fetchData()
	}, [])

	const fetchData = async () => {
		const response = await StudentWorkService.getStudentPerformancesToday({ limit: 10 })
		if (response) {
			setStudents(response)
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
            <h1>Student Performance</h1>
            <Table columns={columns} dataSource={students} style={{ width: '80vw' }} />
        </div>
	)
}

export default StudentPerformanceTable