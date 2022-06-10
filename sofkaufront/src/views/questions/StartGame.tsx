import React from 'react';
import { Box } from '@mui/material';
import { ButtonUi } from '../../components/buttons'
import { Questions } from "./Questions";
import useUser from "../../hooks/useUser";
import { QuestionsService } from "../../service/QuestionService";
import { useSnackbar } from 'notistack';
import useAuth from '../../hooks/useAuth';


export function StartGame() {

  

  const { enqueueSnackbar, closeSnackbar } = useSnackbar();
  const [startGame, setStartGame] = React.useState(false);
  const [data, setData] = React.useState([]);
  const [disable, setDisable] = React.useState(false);
  const { user } = useUser()
  const { logout } = useAuth();

  const HacerPregunta = async () => {
    setDisable(true)
    const response = await QuestionsService.GetQuestionByIdCategory(user.category)
    setData(response.data)
    setStartGame(true)
    setDisable(false)

  }

  React.useEffect(() => {
    if (user.history) {
      enqueueSnackbar("Se terminó el juego", {
        variant: 'info',
        anchorOrigin: {
          vertical: 'bottom',
          horizontal: 'right',
        }
      });
    }
  }, [user.history]);

  return (
    <Box
      sx={{
        display: 'flex',
        justifyContent: 'center',
        p: 1,
        m: 1,
        bgcolor: 'background.paper',
        borderRadius: 1,
      }}>
      {
        startGame ? (<Questions
          setStartGame={setStartGame}
          score={user.score}
          category={user.category}
          username={user.data.username}
          id={user.data.id}
          data={data}
          HacerPregunta={HacerPregunta}
          expiryTimestamp={new Date().setSeconds(new Date().getSeconds() + 30)}
        />) :
          (<>
            <ButtonUi
              disabled={disable}
              text="Empezar juego"
              type="submit"
              variant="contained"
              onClick={() => HacerPregunta()} />

            <ButtonUi
              disabled={disable}
              text="Cerrar session"
              type="submit"
              variant="contained"
              onClick={() => logout()} />
          </>)
      }

    </Box>
  )
}

