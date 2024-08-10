import {IBaseEntity} from "../domain/IBaseEntity";
import {BaseService} from "./BaseService";
import axios from "axios";


export abstract class PublicBaseEntityService<TEntity extends IBaseEntity> extends BaseService {
    url: string;
    protected constructor(baseUrl:string){
        super(baseUrl);
        this.url = BaseService.hostBaseURL + baseUrl;
    }
    async getAll(): Promise<TEntity[] | undefined> {

        try {
            const response = await this.axios.get<TEntity[]>('');

            console.log('response', response);
            if (response.status === 200) {
                return response.data;
            }

            return undefined;
        } catch (e) {
            console.log('error: ', (e as Error).message, e);
            return undefined;
        }
    }

    async getById(id:string): Promise<TEntity[] | undefined> {
        try {
            const response = await axios.get<TEntity[]>(
                this.url + '/' + id
            );

            console.log('response', response);
            if (response.status === 200) {
                return response.data;
            }

            return undefined;
        } catch (e) {
            console.log('error: ', (e as Error).message, e);
            return undefined;
        }
    }



}
