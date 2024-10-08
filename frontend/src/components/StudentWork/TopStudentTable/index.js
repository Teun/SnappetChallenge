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
	},
];

const TopStudentTable = () => {
	const [students, setStudents] = useState([])

	useEffect(() => {
		fetchData()
	}, [])

	const fetchData = async () => {
		const response = await StudentWorkService.getTopPerformingStudentsToday({ limit: 10 })
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
            <h1>Top Student Today</h1>
            <Table columns={columns} dataSource={students} style={{ width: '80vw' }} />
        </div>
	)
}

export default TopStudentTable