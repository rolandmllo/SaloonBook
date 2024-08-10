import {PublicBaseEntityService} from "./PublicBaseEntityservice";
import {SalonDTO} from "../dto/SalonDTO";
import {CityService} from "./CityService";
import {SalonsByCityDTO} from "../dto/SalonsByCityDTO";

export class SalonsService extends PublicBaseEntityService<SalonsByCityDTO> {
    public constructor(){
        super('v1/PublicSalon/GetAllSalonsByCity');
    }

    getSalonsByServiceId(serviceId: string) {
        //const cities = new CityService().getAll();
        //const salons = this.getById(serviceId);
    }
}