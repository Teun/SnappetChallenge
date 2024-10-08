import Fetch from './fetch'

const getAllStudentWorksToday = async () => {
	try {
		const [studentWorks, errRes] = await Fetch.get('/StudentWork/today', {})

		if (errRes) throw errRes
		console.log(errRes)

		return studentWorks
	} catch (e) {
		console.log(e)
	}
}

const getTopPerformingStudentsToday = async ({ ...params }) => {
	try {
		const [students, errRes] = await Fetch.get('/StudentWork/today/top-performing-students', { ...params })

		if (errRes) throw errRes
		console.log(errRes)

		return students
	} catch (e) {
		console.log(e)
	}
}

const getAverageScoreOfSubjectToday = async () => {
	try {
		const [subjects, errRes] = await Fetch.get('/StudentWork/today/average-score', {})

		if (errRes) throw errRes
		console.log(errRes)

		return subjects
	} catch (e) {
		console.log(e)
	}
}

const getSubmissionCountToday = async () => {
	try {
		const [count, errRes] = await Fetch.get('/StudentWork/today/submission-count', {})

		if (errRes) throw errRes
		console.log(errRes)

		return count
	} catch (e) {
		console.log(e)
	}
}

export default {
	getAllStudentWorksToday,
    getTopPerformingStudentsToday,
    getAverageScoreOfSubjectToday,
    getSubmissionCountToday
}