import React from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter } from 'react-router-dom'
import Router from './router'

import './styles/index.css'
import './styles/antd-customize.css'
import 'antd/dist/reset.css'

const App = () => {

    return (
        <BrowserRouter>
            <Router />
        </BrowserRouter>
    )
}

if (module.hot) {
	module.hot.accept()
}

// eslint-disable-next-line no-undef
const rootElement = document.getElementById('root')
const root = createRoot(rootElement)

root.render(<App />)
