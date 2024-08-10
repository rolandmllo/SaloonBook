import {IBaseEntity} from "../domain/IBaseEntity";

export interface EmployeeDTO extends IBaseEntity{
    firstName: string,
    lastName: string,
}