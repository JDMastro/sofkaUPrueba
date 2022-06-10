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

import { useSnackbar } from 'notistack';

import { PlayersService } from '../../service/PlayersService'

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

export function Register() {
    const { enqueueSnackbar, closeSnackbar } = useSnackbar();
    const [disabled, setDisable] = React.useState(false);

    const onSubmit = async (values: initialFValuesTypes, formikHelpers: FormikHelpers<any>) => {
        setDisable(true)
        try {
            const response = await PlayersService.Register({ Username: values.Username, Password: values.Password })
            formik.setFieldValue("Password","")
            formik.setFieldValue("Username","")
            enqueueSnackbar("Se ha creado correctamente", {
                variant: 'success',
                anchorOrigin: {
                    vertical: 'bottom',
                    horizontal: 'right',
                }
            });
            setDisable(false)
        } catch (err: any) {
            setDisable(false)
            enqueueSnackbar("Error :'(", {
                variant: 'error',
                anchorOrigin: {
                    vertical: 'bottom',
                    horizontal: 'right',
                }
            });
            formikHelpers.setFieldError("Username", "Username ya existe")
        }


    }

    const formik = UseForm(initialValuesSignIn, PlayersSchema, onSubmit);

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
                        Registrate
                    </Typography>
                    <Box component="form" onSubmit={formik.handleSubmit} noValidate sx={{ mt: 3 }}>
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
                        </Grid>




                        <Grid container justifyContent="flex-end">
                            <Grid item>
                                <Link href="/" variant="body2">
                                    ¿ya tienes una cuenta? Entra
                                </Link>
                            </Grid>
                        </Grid>
                    </Box>
                </Box>
                <Copyright sx={{ mt: 5 }} />
            </Container>
        </ThemeProvider>
    )
}