/* eslint-disable */
import * as types from "../actionsType/user.actionstype";
import { PlayersService } from "../../service/PlayersService";

export const findWhereInitAction = () => ({
    type: types.FIND_WHERE_INIT,
});
export const findWhereSuccessAction = (payload: any) => ({
    type: types.FIND_WHERE_SUCCESS,
    payload,
});
export const findWhereErrorAction = (payload: any) => ({
    type: types.FIND_WHERE_ERROR,
    payload,
});

export const gameOver = () => ({
    type: types.GAME_OVER
})

export const nextQuestion = (payload: any) => ({
    type: types.NEXT_QUESTION,
    payload
})

export const findWhereAction = (data: any) => async (dispatch: Function) => {
    dispatch(findWhereInitAction());
    try {
        let response = await PlayersService.Me();
        dispatch(findWhereSuccessAction(response.data));
    } catch (error: any) {
        return dispatch(findWhereErrorAction(error.response.data));
    }
};

export const GameOver = (data: any) => async (dispatch: Function) => {
    console.log(data)
    dispatch(gameOver());
};

export const NextQuestion = (data: any) => async (dispatch: Function) => {
    //category: 1, score: 0, questionScore: 2
   

        dispatch(nextQuestion(data))
   

    /*dispatch(nextQuestion({
        category : data.category + 1,
        score : data.score + data.questionScore
    }))*/
};