import { ISchedule } from "../domain/ISchedule";
import { IJWTResponse } from "../dto/IJWTResponse";
import { BaseEntityService } from "./BaseEntityService";


export class ScheduleService extends BaseEntityService<ISchedule> {
    constructor(setJwtResponse: ((data: IJWTResponse | null) => void)){
        super('v1/Schedule', setJwtResponse);
    }


    
}
