//import {ICategory} from "../domain/ICategory";
import {PublicBaseEntityService} from "./PublicBaseEntityservice";
import {ServiceListDTO} from "../dto/ServiceListDTO";



export class ServicesService extends PublicBaseEntityService<ServiceListDTO> {
    public constructor(){
        super('v1/PublicService/GetByCategoryId');
    }


}