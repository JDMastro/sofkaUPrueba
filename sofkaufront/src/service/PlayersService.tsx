import { instance, responseBody } from './AxiosInstance'

const Requests = {
    Login : async (url : string, body : any) => await instance.post(url,body).then(responseBody),
    Me : async (url : string) => await instance.get(url).then(responseBody),
}

export const PlayersService =
{
    Login : async (body : any) => await Requests.Login(`auth/login`, body),
    Me : async () => await Requests.Me("players/me")
}
//await Requests.Login(`auth/login`, body)