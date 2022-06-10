import React from 'react';
import Avatar from '@mui/material/Avatar';
import CssBaseline from '@mui/material/CssBaseline';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';

import { ButtonUi } from "../../components/buttons";
import { UseForm } from "../../components/form";
import { TextFieldUi } from "../../components/textfield";
import { PlayersSchema } from '../../schemas/PlayersSchema'
import { initialFValuesTypes } from '../../types/initialFValues';
import { FormikHelpers } from 'formik';
import useAuth from "../../hooks/useAuth";
import useUser from "../../hooks/useUser";

import { useSnackbar } from 'notistack';



const initialValuesSignIn: initialFValuesTypes = {
  Username: "test@email.com",
  Password: "Test123"
}


function Copyright(props: any) {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Copyright © '}
      <Link color="inherit" href="https://mui.com/">
        Your Website
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

const theme = createTheme();

export function SignIn() {

  const { auth, login } = useAuth();
  const { user } = useUser()
  const { enqueueSnackbar, closeSnackbar } = useSnackbar();
  const [disabled, setDisable] = React.useState(false);

  const onSubmit = async (values: initialFValuesTypes, formikHelpers: FormikHelpers<any>) => {
    setDisable(true)
    await login({
      Username: values.Username,
      Password: values.Password
    });
    setDisable(false)
  }

  const formik = UseForm(initialValuesSignIn, PlayersSchema, onSubmit);

  React.useEffect(() => {

    if (Object.keys(user.data).length !== 0) {
      window.location.replace('/dashboard');
    }
  }, []);

  React.useEffect(() => {
    if (auth.error) {
      enqueueSnackbar(auth.error, {
        variant: 'error',
        anchorOrigin: {
          vertical: 'bottom',
          horizontal: 'right',
        }
      });
    }
  }, [auth.error]);


  return (
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign in
          </Typography>
          <Box component="form" onSubmit={formik.handleSubmit} noValidate sx={{ mt: 1 }}>

            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextFieldUi
                  autofocus={true}
                  error={formik.errors.Username}
                  label="Usuario *"
                  name="Username"
                  onChange={formik.handleChange}
                  type="text"
                  value={formik.values.Username}
                />
              </Grid>

              <Grid item xs={12}>
                <TextFieldUi
                  autofocus={false}
                  error={formik.errors.Password}
                  label="Contraseña *"
                  name="Password"
                  onChange={formik.handleChange}
                  type="password"
                  value={formik.values.Password}
                />
              </Grid>

              <Grid item xs={12}>
                <ButtonUi fullWidth={true} disabled={disabled} text="Enviar" type="submit" variant="contained" />
              </Grid>



              <Grid item>
                <Link href="/register" variant="body2">
                  {"¿No tienes una cuenta?, Registrate"}
                </Link>
                <Grid container>
                </Grid>
              </Grid>

            </Grid>
          </Box>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
      </Container>



    </ThemeProvider>
  );
}