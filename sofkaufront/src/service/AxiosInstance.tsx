import Axios, { AxiosResponse } from 'axios';
import { getCookieToJson } from '../utils/cookie';

const axios = Axios.create({
	baseURL: `${process.env.REACT_APP_URL_BACK_END}`,
	timeout: 15000,
	headers : {
		"Content-Type": "application/json",
	},
	withCredentials : true,
});

axios.interceptors.request.use((config: any) => {
	const auth = getCookieToJson('iv_at');
	config.headers.Authorization = `Bearer ${ auth ? auth.accessToken : ""}`;
	//config.headers.Authorization = `Bearer ${auth?.accessToken}`;
	return config;
});

export const instance = axios;

export const responseBody = (response: AxiosResponse) => response.data;
