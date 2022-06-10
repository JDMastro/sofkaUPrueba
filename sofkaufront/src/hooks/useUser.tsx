import { useDispatch, useSelector } from 'react-redux';
import {
    findWhereAction,
    GameOver,
    NextQuestion
} from '../store/actions/user.actions';

const useUser: Function = () => {
    const dispatch = useDispatch<any>();

    return {
        user: useSelector((state: any) => state.user),
        findWhere: (data: any) => dispatch(findWhereAction(data)),
        gameover: (data:any)=> dispatch(GameOver(data)),
        nextquestion: (data:any)=> dispatch(NextQuestion(data))
    };
};

export default useUser;
