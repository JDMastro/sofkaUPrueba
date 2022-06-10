import React from 'react';
import { Box } from '@mui/material';
import { ButtonUi } from '../../components/buttons'
import { Questions } from "./Questions";
import useUser from "../../hooks/useUser";
import { QuestionsService } from "../../service/QuestionService";

export function StartGame() {

    const [startGame, setStartGame] = React.useState(false);
    const [data, setData] = React.useState([]);
    const [disable, setDisable] = React.useState(false);
    const { user } = useUser()

    const HacerPregunta = async () => {
            setDisable(true)
            const response = await QuestionsService.GetQuestionByIdCategory(user.category)
            setData(response.data)
            setStartGame(true)
            setDisable(false)

    }

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
                    data={data}
                    HacerPregunta={HacerPregunta}
                />) :
                    (<ButtonUi
                        disabled={disable}
                        text="Empezar juego"
                        type="submit"
                        variant="contained"
                        onClick={() => HacerPregunta()} />)
            }

        </Box>
    )
}

