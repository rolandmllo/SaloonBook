import {ICategory} from "../domain/ICategory";
import {PublicBaseEntityService} from "./PublicBaseEntityservice";
import {BaseEntityService} from "./BaseEntityService";
import {IJWTResponse} from "../dto/IJWTResponse";



export class CategoryService extends BaseEntityService<ICategory> {
    public constructor(setJwtResponse: ((data: IJWTResponse | null) => void) ){
        super('v1/PublicCategory/', setJwtResponse);
    }


}