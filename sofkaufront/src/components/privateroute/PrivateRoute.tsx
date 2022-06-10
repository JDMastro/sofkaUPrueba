import React from 'react';
import { Navigate } from "react-router-dom";
import useAuthentication from "../../providers/useAuthentication";

export const ProtectedRoute = ({ children }: any) => {
    const { isAuthenticated, user }: any = useAuthentication();

    if (!isAuthenticated) {
        return <Navigate to="/" />
    }
    return children;
};