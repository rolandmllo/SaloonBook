import React, {useContext, useEffect, useState} from "react";
import {JwtContext} from "../_app"; // assuming jwtContext resides in this path
import { AppointmentService } from "../../services/AppointmentService";
import {IJWTResponse} from "../../dto/IJWTResponse";

const MyAppointment: React.FC = () => {
    const [appointments, setAppointments] = useState([]);
    const {jwtResponse, setJwtResponse} = useContext(JwtContext);

    if (!jwtResponse) {
        console.error('jwtResponse is null or undefined.');
        return null; // Or handle error in appropriate manner
    }

    const appointmentService = new AppointmentService(setJwtResponse);

    const handleFetchError = (error: Error) => {
        console.error(`Failed to fetch appointments: ${error.message}`);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await appointmentService.getAll(jwtResponse);
                setAppointments(data);
            } catch (error) {
                handleFetchError(error);
            }
        };

        fetchData();
    }, [jwtResponse]);

    return (
        <>
            {/* Should map through appointments to display them */}
            appointment
        </>
    );
};
export default MyAppointment;