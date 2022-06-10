import React from 'react';
import { Routes, Route,  BrowserRouter } from 'react-router-dom';
import App from '../App'
import { ProtectedRoute } from '../components/privateroute'

export const Rutas = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<App />} />
                <Route path='/dashboard' element={<ProtectedRoute><div>Dashboard</div></ProtectedRoute>} />
            </Routes>
        </BrowserRouter>
    )
}