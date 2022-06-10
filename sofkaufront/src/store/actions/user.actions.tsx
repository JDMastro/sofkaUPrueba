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

export const findWhereAction = (data: any) => async (dispatch: Function) => {
    dispatch(findWhereInitAction());
    try {
        let response = await PlayersService.Me();
        dispatch(findWhereSuccessAction(response.data));
    } catch (error:any) {
        return dispatch(findWhereErrorAction(error.response.data));
    }
};