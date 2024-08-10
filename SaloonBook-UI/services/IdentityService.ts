import { IJWTResponse } from "../dto/IJWTResponse";
import { ILoginData } from "../dto/ILoginData";
import { IRegisterData } from "../dto/IRegisterData";
import { BaseService } from "./BaseService";
import {setCookie, getCookie, deleteCookie, hasCookie} from 'cookies-next';
import {useContext, useEffect} from "react";
import { JwtContext } from "../pages/_app";
import {RuntimeError} from "next/dist/client/components/react-dev-overlay/internal/container/RuntimeError";



export class IdentityService extends BaseService {

constructor() {
        super('v1/identity/account/');

    }


    public USER_TOKEN_KEY = 'userToken';
    public static USER_TOKEN_KEY = 'userToken';
    public COOKIE_EXPIRES_IN_DAYS = 7;



    storeUserToken(jwtResponse: IJWTResponse): void {
        if (!this.USER_TOKEN_KEY) {
            console.error('Error: USER_TOKEN_KEY is not set.');
            return;
        }
        if (!jwtResponse || !jwtResponse.jwt || !jwtResponse.refreshToken) {
            console.error('Error: JWT response is invalid.');
            return;
        }
        try {
            const tokenStr = JSON.stringify(jwtResponse);
            if (!tokenStr) {
                console.error('Error: Unable to stringify JWT response.');
                return;
            }
            const expirationDate = new Date();
            expirationDate.setDate(expirationDate.getDate() + this.COOKIE_EXPIRES_IN_DAYS);
            console.log(tokenStr)
            console.log(expirationDate)
            console.log(this.USER_TOKEN_KEY)

            setCookie(this.USER_TOKEN_KEY, tokenStr, { expires: expirationDate });
            //setCookie(this.USER_TOKEN_KEY, tokenStr, { expires: expirationDate });
        } catch (error) {
            console.error('Error storing user token:', error);
            throw error;
        }
    }

     static isUserAuthenticated(jwtResponse, setJwtResponse): boolean {

         if (jwtResponse === null || 'undefined') {
             const cookie = getCookie(IdentityService.USER_TOKEN_KEY)
             if (cookie) {
                 useEffect(() => {
                     const setJwt = () => {
                         const cookie = getCookie(IdentityService.USER_TOKEN_KEY);
                         const jwt: IJWTResponse = JSON.parse(cookie)
                         console.log("setting jwt")
                         console.log(jwt)

                         setJwtResponse(jwt);
                     }
                     setJwt();
                 }, []);

                 return true
             }
             return false

         } else {
             return !!jwtResponse;
         }

     }

    isUserAuthenticated(): boolean {
        const { jwtResponse, setJwtResponse } = useContext(JwtContext);

        return IdentityService.isUserAuthenticated(jwtResponse, setJwtResponse)

    }



    async register(data: IRegisterData): Promise<IJWTResponse | undefined> {
        try {
            const response = await this.axios.post<IJWTResponse>('register', data);

            console.log('register response', response);
            if (response.status === 200) {
                this.storeUserToken(response.data)
                return response.data;
            }
            return undefined;
        } catch (e) {
            console.log('error: ', (e as Error).message);
            console.log(e.response.data)
            return undefined;
        }
    }

    async login(data: ILoginData): Promise<IJWTResponse | undefined> {
        try {
            const response = await this.axios.post<IJWTResponse>('login', data);

            console.log('login response', response);
            if (response.status === 200) {
                this.storeUserToken(response.data)
                return response.data;
            }
            return undefined;
        } catch (e) {
            console.log('error: ', (e as Error).message);
            return undefined;
        }
    }

    async logout(data: IJWTResponse): Promise<true | undefined> {
        console.log(data);

        try {
            const response = await this.axios.post(
                'logout', 
                data,
                {
                    headers: {
                        'Authorization': 'Bearer ' + data.jwt
                    }
                }
            );

            console.log('logout response', response);
            if (response.status === 200) {
                if (hasCookie(this.USER_TOKEN_KEY)) {
                    deleteCookie(this.USER_TOKEN_KEY);
                }
                return true;
            }
            return undefined;
        } catch (e) {
            console.log('error: ', (e as Error));
            deleteCookie(this.USER_TOKEN_KEY);

            const ctx = useContext(JwtContext)
                ctx.setJwtResponse(null)

            return undefined;
        }
    }

    async refreshToken(data: IJWTResponse): Promise<IJWTResponse | undefined> {
        console.log(data);
        
        try {
            const response = await this.axios.post<IJWTResponse>(
                'refreshtoken', 
                data,
                {
                    headers: {
                        'Content-type': 'application/json',
                        'Authorization': 'Bearer ' + data.jwt
                    }
                }
            );

            console.log('refresh token response', response);
            if (response.status === 200) {
                this.storeUserToken(response.data)
                return response.data;
            }
            return undefined;
        } catch (e) {
            console.log('error: ', (e as Error).message);
            return undefined;
        }
    }
}
export default IdentityService