
import * as types from "../actionsType/user.actionstype";

export const initialState = {
    data: {},
    loading: true,
    error: null,
    score: 0,
    category: 1,
    history : null
};

// eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
export default function reducer(state = initialState, action: any = {}) {

    switch (action.type) {

        case types.NEXT_QUESTION:
            return Object.assign({}, state, {
               score : state.score += action.payload,
               category : state.category+=1
            })

        case types.HISTORY:
            return {
                ...state,
                history : action.payload
            }
            

        case types.GAME_OVER:
            return {
                ...state,
                score: 0,
                category: 1
            }
        case types.FIND_WHERE_INIT:
            return {
                ...state,
                data: {},
                loading: true,
                error: null,
            };

        case types.FIND_WHERE_SUCCESS:
            return {
                ...state,
                data: action.payload,
                loading: false,
                error: null,
            };

        case types.FIND_WHERE_ERROR:
            return {
                ...state,
                data: {},
                loading: false,
                error: action.payload,
            };
        default:
            return state;
    }
}