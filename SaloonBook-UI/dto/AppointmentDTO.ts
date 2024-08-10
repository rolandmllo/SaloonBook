import {IBaseEntity} from "../domain/IBaseEntity";

export interface AppointmentDTO extends IBaseEntity {
  clientId: string;
  employeeId?: string;
  categoryId?: string;
  serviceId?: string;
  salonId?: string;
  startTime?: any | string;
  endTime?: any | string;
}
