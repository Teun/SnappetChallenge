import React, { useEffect, useState } from 'react';
import { Column } from '@ant-design/plots';
import { StudentWorkService } from '../../../services';

const SubjectChart = () => {
    const [subjects, setSubjects] = useState([])

	useEffect(() => {
		fetchData()
	}, [])

	const fetchData = async () => {
		const response = await StudentWorkService.getAverageScoreOfSubjectToday()
        console.log("subject: ", response)
		if (response) {
			setSubjects(response)
		}
	}

    return (
        <div 
            className='sw-subject-chart'
            style={{
				width: "100vw",
				display: "flex",
				alignItems: "center",
				justifyContent: "center",
                flexDirection: "column",
                gap: "20px"

			}}
        >
            <h1>Average Progress per Subject Today</h1>
            <Column
                data={subjects}
                xField='subject'
                yField='averageProgress'
                style={
                    {
                        fill: ({ averageProgress }) => {
                            return averageProgress < 20 ? '#22CBCC' : '#2989FF'; 
                        },
                    }
                }
            />
        </div>
    );
};

export default SubjectChart
