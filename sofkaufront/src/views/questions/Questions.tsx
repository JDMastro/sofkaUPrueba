import { Box, Grid } from '@mui/material';
import React from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import { ButtonUi } from '../../components/buttons';

import useUser from "../../hooks/useUser";
//import { useSnackbar } from 'notistack';

export function Questions({ score, category, username, data, setStartGame, HacerPregunta }: any) {

    // const[fallopregunta, setFallopregunta] = React.useState('error');
    // const[correctapregunta, setCorrectapregunta] = React.useState('success');
    const [fallopregunta, setFallopregunta] = React.useState<any>('primary');
    const [correctapregunta, setCorrectapregunta] = React.useState<any>('primary');
    const { gameover, nextquestion } = useUser()
    //const { enqueueSnackbar, closeSnackbar } = useSnackbar();

    const isCorrect = async (isCorrect: any) => {
        if (category < 5) {
            if (!isCorrect) {
                setFallopregunta('error')
                setCorrectapregunta('warning')
                setStartGame(false)
                
                await gameover({ category, score })
             
            } else {
                //setStartGame(false)
                await nextquestion(data.score)
                await HacerPregunta()
            }
        } else {
            setStartGame(false)
            await gameover({ category, score })
            /*enqueueSnackbar("has completado el juego", {
                variant: 'success',
                anchorOrigin: {
                    vertical: 'bottom',
                    horizontal: 'right',
                }
            });*/
        }



    }

    return (

        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="relative">
                <Toolbar>

                    <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                        {`${username} Ronda : ${category}`}
                    </Typography>
                    <Typography variant="h6" component="div">
                        {`Puntaje : ${score}`}

                    </Typography>

                </Toolbar>
            </AppBar>
            <Box>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>

                    {data ? `${data.name}` : ``}
                </Typography>


                <Grid container spacing={2}>
                    {
                        data ? (data.options.map((item: any, i: any) =>
                            <Grid item xs={6}>
                                <ButtonUi
                                    color={item.iscorrect ? correctapregunta : fallopregunta}
                                    key={i}
                                    disabled={false}
                                    text={`${item.name}`}
                                    type="submit"
                                    variant="outlined"
                                    onClick={() => isCorrect(item.iscorrect)} />
                            </Grid>
                        )) : ""
                    }
                </Grid>
                {/*<ButtonUi  
                        disabled={disable} 
                        text="Empezar juego" 
                        type="submit" 
                        variant="contained"
    onClick={()=> HacerPregunta () } />*/}
            </Box>
        </Box>


    )
}