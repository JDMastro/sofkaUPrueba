import React from 'react';
import { Routes, Route,  BrowserRouter } from 'react-router-dom';
import App from '../App'
import { ProtectedRoute } from '../components/privateroute'
import { Register } from '../views/register'

export const Rutas = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<App />} />
                <Route path='/register' element={<Register />} />
                <Route path='/dashboard' element={<ProtectedRoute><div>Dashboard</div></ProtectedRoute>} />
            </Routes>
        </BrowserRouter>
    )
}