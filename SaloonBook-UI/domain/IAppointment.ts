import { IBaseEntity } from "./IBaseEntity";

export interface IAppointment extends IBaseEntity {
    id: string
    employeeName: string,
    employeeId: string,


}