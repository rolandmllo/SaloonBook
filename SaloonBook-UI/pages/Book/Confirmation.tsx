import {IAppointment} from "../../domain/IAppointment";

export default function Confirmation({appointment}) {

    return(
        <>
        <h2>Saadetud</h2>
        <p>
            {appointment.id}
        </p>
        </>
    );
}