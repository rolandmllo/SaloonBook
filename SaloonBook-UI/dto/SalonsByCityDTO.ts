import {IBaseEntity} from "../domain/IBaseEntity";
import {SalonDTO} from "./SalonDTO";

export interface SalonsByCityDTO extends IBaseEntity{
    city: string,
    salons: SalonDTO[]
}