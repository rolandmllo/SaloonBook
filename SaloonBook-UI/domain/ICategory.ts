import {IBaseEntity} from "./IBaseEntity";

export interface ICategory extends IBaseEntity {
    categoryName : string,
    description : string
}