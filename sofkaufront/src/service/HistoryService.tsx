import { instance, responseBody } from './AxiosInstance'

const Requests = {
    History : async (url : string, body : any) => await instance.post(url,body).then(responseBody),
    GetHistory : async (url : string) => await instance.get(url).then(responseBody),
   
}

export const HistoryService =
{
    Login : async (body : any) => await Requests.History(`history`, body),
    GetHistory : async () => await Requests.GetHistory("history"),
}
//await Requests.Login(`auth/login`, body)