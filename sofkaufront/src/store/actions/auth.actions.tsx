import * as types from "../actionsType/auth.actionstype";
import { PlayersService } from "../../service/PlayersService";
import { removeCookie, setCookieJson } from '../../utils/cookie';

export const authInitAction = () => ({
    type: types.AUTH_INIT,
});
export const authSuccessAction = () => ({
    type: types.AUTH_SUCCESS,
});
export const authErrorAction = (payload: any) => ({
    type: types.AUTH_ERROR,
    payload,
});

export const logoutInitAction = () => ({
    type: types.LOGOUT_INIT,
});
export const logoutSuccessAction = () => ({
    type: types.LOGOUT_SUCCESS,
});
export const logoutErrorAction = (payload: any) => ({
    type: types.LOGOUT_ERROR,
    payload,
});


export const authAction = (data: any) => async (dispatch: Function) => {
    dispatch(authInitAction());
    try {
        const response = await PlayersService.Login(data);
        const { accessToken, tokenType }: any = response;
        removeCookie('iv_at');
        setCookieJson('iv_at', { tokenType, accessToken });
        dispatch(authSuccessAction());
        window.location.replace('/dashboard');
    } catch (error:any) {
        dispatch(authErrorAction(error.response.data));
    }
};

export const logoutAction = () => async (dispatch: any) => {
    dispatch(logoutInitAction());
    try {
        // await logout();
        removeCookie('iv_at');
        dispatch(logoutSuccessAction());
        window.location.replace('/');
    } catch (error) {
        return dispatch(logoutErrorAction(error));
    }
};