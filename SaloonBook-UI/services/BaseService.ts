import Axios, { AxiosInstance } from 'axios';

export abstract class BaseService {
    public static hostBaseURL = process.env.NEXT_PUBLIC_HOST_BASE_URL;

    protected axios: AxiosInstance;

    protected constructor(baseUrl: string) {

        this.axios = Axios.create(
            {
                baseURL: BaseService.hostBaseURL + baseUrl,
                headers: {
                    common: {
                        'Content-Type': 'application/json'
                    }
                }
            }
        )

        this.axios.interceptors.request.use(request => {
            console.log('Starting Request', JSON.stringify(request, null, 2))
            return request
        })
    }


}