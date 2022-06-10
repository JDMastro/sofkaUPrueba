import { Box, Grid } from '@mui/material';
import React from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import { ButtonUi } from '../../components/buttons';

import useUser from "../../hooks/useUser";
import { useTimer } from 'react-timer-hook';

export function Questions({ expiryTimestamp, id, score, category, username, data, setStartGame, HacerPregunta }: any) {

    const [fallopregunta, setFallopregunta] = React.useState<any>('primary');
    const [correctapregunta, setCorrectapregunta] = React.useState<any>('primary');
    const { gameover, nextquestion } = useUser()

    const {
        seconds,
        restart,
      } = useTimer({ expiryTimestamp, onExpire: async () =>{ await gameover({ category, score, id }); setStartGame(false)} });
    

    

    const isCorrect = async (isCorrect: any) => {
        if (category < 5) {
            if (!isCorrect) {
                setFallopregunta('error')
                setCorrectapregunta('warning')
                setStartGame(false)
                
                await gameover({ category, score, id })
             
            } else {
                await nextquestion(data.score)
                await HacerPregunta()
                const time = new Date();
                time.setSeconds(time.getSeconds() + 30);
                restart(time)
            }
        } else {
            setStartGame(false)
            await gameover({ category, score, id })
           
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
                        {`Temporizador : ${seconds}`}

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
               
            </Box>
        </Box>


    )
}