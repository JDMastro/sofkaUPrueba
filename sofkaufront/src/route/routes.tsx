import React from 'react';
import { Routes, Route,  BrowserRouter } from 'react-router-dom';
import App from '../App'
import { ProtectedRoute } from '../components/privateroute'
import { Register } from '../views/register'
import { Dashboard } from '../views/dashboard'
import { History } from "../views/history";

export const Rutas = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<App />} />
                <Route path='/register' element={<Register />} />
                <Route path='/dashboard' element={<ProtectedRoute><Dashboard /></ProtectedRoute>} />
                <Route path='/history' element={<History />} />
            </Routes>
        </BrowserRouter>
    )
}

export const RutasInernas = () => {
    return (
            <Routes>

            </Routes>
    )
}