import React from 'react';
import ReactDOM from 'react-dom/client';
//import App from './App';

import { Provider } from 'react-redux';
import store from './store/Store'
import AuthenticationWrapper from './providers/Authentication';
import { Rutas } from './route/routes'

import { SnackbarProvider } from 'notistack';

import { AppBar, Box, Link, Menu, MenuItem, Toolbar, Typography } from '@mui/material';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <Provider store={store}>
      <SnackbarProvider maxSnack={3}>
        <AuthenticationWrapper>
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="relative">
              <Toolbar>
                
                  <Link href="/" sx={{ color: "white" }}>Home</Link><div>&nbsp;</div>
                  <Link href="/register" sx={{ color: "white" }}>Registro</Link><div>&nbsp;</div>
                  <Link href="/history" sx={{ color: "white" }}>Puntaje</Link><div>&nbsp;</div>
              </Toolbar>
            </AppBar>
          </Box>
          <Rutas />
        </AuthenticationWrapper>
      </SnackbarProvider>
    </Provider>
  </React.StrictMode>
);

