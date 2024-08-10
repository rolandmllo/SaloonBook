import {PublicBaseEntityService} from "./PublicBaseEntityservice";
import {CityDTO} from "../dto/CityDTO";

export class CityService extends PublicBaseEntityService<CityDTO> {
    public constructor(){
        super('v1/PublicService/GetAllCities');
    }


}