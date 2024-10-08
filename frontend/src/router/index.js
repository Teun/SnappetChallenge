import React from 'react'
import { Route, Routes } from 'react-router-dom'
import { StudentWork } from '../pages'

const Router = () => {
	return (
		<Routes>
			<Route exact path="/" element={<StudentWork />} />
		</Routes>
	)
}

export default Router
