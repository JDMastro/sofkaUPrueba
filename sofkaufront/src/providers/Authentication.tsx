import React from "react";
import { getCookieToJson  } from '../utils/cookie';
import { AuthProvider } from './context';
import useUser from '../hooks/useUser';
import useAuth from "../hooks/useAuth";
import { Box } from "@mui/material";


const Authentication = ({children} : any) => {
    const auth = getCookieToJson('iv_at') || null;
    const { findWhere, user: currentUser } = useUser();
    const { login, logout } = useAuth();
    const authProviderValue = {
        isAuthenticated: !!auth,
        user: auth ? currentUser : {},
        login,
        logout,
    };

    React.useEffect(() => {
       // if (authProviderValue.isAuthenticated) {
            findWhere();
       // }
    }, []);

    return currentUser.loading
        ? (<Box sx={{
            display: 'flex',
            justifyContent: 'center',
            p: 1,
            m: 1,
            bgcolor: 'background.paper',
            borderRadius: 1,
          }}>Loading...</Box>)
        : (<AuthProvider value={authProviderValue}>{children}</AuthProvider>);
};


export default Authentication;
