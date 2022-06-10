import { instance, responseBody } from './AxiosInstance'

const Requests = {
    GetQuestionByIdCategory : async (url : string) => await instance.get(url).then(responseBody),
}

export const QuestionsService =
{
    GetQuestionByIdCategory : async (id:number) => await Requests.GetQuestionByIdCategory(`Questions/${id}`),
}
//await Requests.Login(`auth/login`, body)

