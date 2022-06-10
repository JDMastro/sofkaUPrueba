import React from 'react';
import ReactDOM from 'react-dom/client';
//import App from './App';

import { Provider } from 'react-redux';
import store from './store/Store'
import AuthenticationWrapper from './providers/Authentication';
import { Rutas } from './route/routes'

import { SnackbarProvider } from 'notistack';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <Provider store={store}>
      <SnackbarProvider maxSnack={3}>
        <AuthenticationWrapper>
          <Rutas />
        </AuthenticationWrapper>
      </SnackbarProvider>
    </Provider>
  </React.StrictMode>
);

