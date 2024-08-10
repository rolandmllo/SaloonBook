import {IBaseEntity} from "../domain/IBaseEntity";

export interface UserInfoDTO extends IBaseEntity {
    firstName: string,
    lastName: string
    email: string,
    phone?: string
}