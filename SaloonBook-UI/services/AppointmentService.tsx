import {AppointmentDTO} from "../dto/AppointmentDTO";
import {BaseEntityService} from "./BaseEntityService";
import {IJWTResponse} from "../dto/IJWTResponse";

export class AppointmentService extends BaseEntityService<AppointmentDTO> {

    constructor(setJwtResponse: ((data: IJWTResponse | null) => void) ) {
        super('v1/PublicAppointment/', setJwtResponse);
    }


    public async createAppointment(appointment: AppointmentDTO, jwtData: IJWTResponse): Promise<AppointmentDTO> {

        try {
            const response = await this.axios.post<AppointmentDTO>('CreateAppointment',
                appointment,
                {
                    headers: {
                        'Authorization': 'Bearer ' + jwtData.jwt
                    },
                }
        );
                console.log(response);

            const createdAppointment =  response.data;
            console.log("sent query")
            console.log(createdAppointment)

            if (response.status != 200) {
                console.log("Server response:" + response.status + " Body: ")
                console.log(response.data)
                // Handle non-successful responses (e.g., show an error message)
                throw new Error(`Failed to create appointment. Status: ${response.status}. Errors: ${response.statusText}`);
            }

            return createdAppointment as AppointmentDTO;
        } catch (error) {
            console.error('Error creating appointment:', error);
            throw error; // Propagate the error to the calling code
        }
    }

}