import { BaseService } from "./BaseService";
import { IBaseEntity } from "../domain/IBaseEntity";
import {AxiosError, AxiosRequestConfig} from "axios";
import { IJWTResponse } from "../dto/IJWTResponse";
import { IdentityService } from "./IdentityService";

export interface IQueryParams {
    [param: string]: any;
}

export interface IFetchResponse<TData> {
    statusCode: number;
    errorMessage?: string;
    data?: TData;
}

export abstract class BaseEntityService<TEntity extends IBaseEntity> extends BaseService {
    protected apiEndpointUrl: string
    protected jwt;

    protected constructor(
        baseUrl: string,
        protected setJwtResponse: ((data: IJWTResponse | null) => void)) {
        super(baseUrl);
        this.jwt;
    }
    static getJwtHeader(jwtData: IJWTResponse): AxiosRequestConfig {
        return {
            headers: {
                'Authorization': 'Bearer ' + jwtData
            }
        };
    }

    async getAll(jwtData: IJWTResponse): Promise<TEntity[] | undefined> {
        try {
            const response = await this.axios.get<TEntity[]>('GetAll',
                {
                    headers: {
                        'Authorization': 'Bearer ' + jwtData
                    }
                }
            );

            console.log('response', response);
            if (response.status === 200) {
                return response.data;
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

                    const response = await this.axios.get<TEntity[]>('GetAll',
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

    async get(id: string, queryParams?: IQueryParams): Promise<IFetchResponse<TEntity>> {
        const {authHeaders, url} = this.prepareUrl(id, queryParams)
        try {
            const response = await this.axios.get(url, {headers: authHeaders})
            if (response.status > 199 && response.status < 300) {
                return {
                    statusCode: response.status,
                    data: response.data
                }
            }

            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }
        } catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }
    private prepareUrl(id: string, queryParams?: IQueryParams) {
        const authHeaders = this.jwt !== '' ? {Authorization: 'Bearer ' + this.jwt} : {}
        let url = this.apiEndpointUrl
        url = url + '/' + id

        const lang = localStorage.getItem('lang');
        if (lang != null) {
            url += '?culture=' + lang;
        }

        if (queryParams !== undefined) {
            url += '?'
            for (const param in Object.keys(queryParams)) {
                url += '&' + param + '=' + queryParams[param]
            }
        }
        return {authHeaders, url}
    }

    async post(entity: TEntity): Promise<IFetchResponse<TEntity>> {

        const authHeaders = this.jwt !== '' ? {Authorization: 'Bearer ' + this.jwt} : {}
        let url = this.apiEndpointUrl
        const lang = localStorage.getItem('lang');
        if (lang != null) {
            url += '?culture=' + lang;
        }
        try {
            const response = await this.axios.post(url, entity, {headers: authHeaders})
            if (response.status > 199 && response.status < 300) {
                console.log(response.data)
                return {
                    statusCode: response.status,
                    data: response.data
                }
            }

            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }
        } catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }

    async put(entity: TEntity, queryParams?: IQueryParams): Promise<IFetchResponse<TEntity>> {
        const {authHeaders, url} = this.prepareUrl(entity.id, queryParams)
        try {
            const response = await this.axios.put(url, entity, {headers: authHeaders})
            if (response.status > 199 && response.status < 300) {
                return {
                    statusCode: response.status,
                    data: response.data
                }
            }

            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }
        } catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }

    async delete(id: string, queryParams?: IQueryParams): Promise<IFetchResponse<TEntity>> {
        const {authHeaders, url} = this.prepareUrl(id, queryParams)
        try {
            const response = await this.axios.delete(url, {headers: authHeaders})
            if (response.status > 199 && response.status < 300) {
                return {
                    statusCode: response.status,
                    data: response.data
                }
            }

            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }
        } catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }

}