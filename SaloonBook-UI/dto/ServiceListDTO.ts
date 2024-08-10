import {IBaseEntity} from "../domain/IBaseEntity";

export interface ServiceListDTO extends IBaseEntity{
    id: string,
    serviceName: string

}