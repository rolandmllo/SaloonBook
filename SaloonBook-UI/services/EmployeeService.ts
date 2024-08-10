import {PublicBaseEntityService} from "./PublicBaseEntityservice";
import {EmployeeDTO} from "../dto/EmployeeDTO";
import {BaseService} from "./BaseService";
import axios from "axios";

export class EmployeeService extends PublicBaseEntityService<EmployeeDTO> {
    public constructor(){
        const baseUrl = 'v1/PublicUsers/GetAllEmployees';
        super(baseUrl);
        this.url = BaseService.hostBaseURL + baseUrl;

    }

    async getEmployeesByServiceAndSalon(serviceId: string, salonId: string) : Promise<EmployeeDTO[] | undefined>  {

            try {
                const response = await axios.get<EmployeeDTO[]>(this.url);

                console.log('response', response);
                if (response.status === 200) {
            return response.data;
        }

        return undefined;
    } catch (e) {
            console.log('error: ', (e as Error).message, e);
            return undefined;
        }
    }

}