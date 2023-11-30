import React from 'react';

export const PrivateRoute = ({ children, redirectTo = "/" }) => {
    const isAuthenticated = localStorage.getItem("token") !== null;

    return isAuthenticated ? children : <Navigate to={redirectTo} />
};