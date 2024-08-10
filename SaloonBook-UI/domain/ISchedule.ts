import { IAppointment } from "./IAppointment";
import { IBaseEntity } from "./IBaseEntity";

export interface ISchedule extends IBaseEntity {

    appUserId: string,   
    appointments : IAppointment[]

}
