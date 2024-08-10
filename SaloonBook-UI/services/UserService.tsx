import {BaseService} from "./BaseService";
import { IJWTResponse } from "../dto/IJWTResponse";
import {UserInfoDTO} from "../dto/UserInfoDTO";
import {BaseEntityService} from "./BaseEntityService";
import {AxiosError} from "axios";
import IdentityService from "./IdentityService";
import jwtDecode from "jwt-decode";


export class UserService extends BaseEntityService<any> {
    constructor(setJwtResponse: ((data: IJWTResponse | null) => void) ) {
        super('v1/identity/account/', setJwtResponse);
    }

    async getUserInfo(jwtData: IJWTResponse): Promise<UserInfoDTO | undefined> {
        try {
            const response = await this.axios.get<UserInfoDTO>('GetUserInfo',
                {
                    headers: {
                        'Authorization': 'Bearer ' + jwtData.jwt
                    }
                }
            );

            console.log('response', response);
            if (response.status === 200) {

                return response.data
            }

            return undefined;
        } catch (e) {
            console.log('error: ', (e as Error).message, e);
            if ((e as AxiosError).response?.status === 401) {
                console.error("JWT expired, refreshing!");
                // try to refresh the jwt
                let identityService = new IdentityService();
                let refreshedJwt = await identityService.refreshToken(jwtData);
                if (refreshedJwt) {
                    this.setJwtResponse(refreshedJwt);

                    const response = await this.axios.get<UserInfoDTO>('GetUserInfo',
                        {
                            headers: {
                                'Authorization': 'Bearer ' + refreshedJwt.jwt
                            }
                        }
                    );
                    if (response.status === 200) {
                        return response.data;
                    }
                }
            }
            return undefined;
        }
    }

}
