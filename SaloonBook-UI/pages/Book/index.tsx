import React, {useContext, useEffect, useState} from 'react';
import BookAppointmentForm from "./BookAppointmentForm";
import { AppointmentService } from "../../services/AppointmentService";
import dayjs from "dayjs";
import Confirmation from "./Confirmation";
import {JwtContext} from "../_app";
import {UserService} from "../../services/UserService";
import {AppointmentDTO} from "../../dto/AppointmentDTO";


export default function Book() {
    const { jwtResponse, setJwtResponse } = useContext(JwtContext);
    const userService = new UserService(setJwtResponse);

    const [formSubmitted, setFormSubmitted] = useState(false);
    const [appointment, setAppointment] = useState({
        user: null,
        category: null,
        employee: null,
        saloon: null,
        service: null,
        startTime: dayjs(),
        endTime: dayjs().add(1, 'hour'),
    });

    useEffect(() => {
        const fetchUserInfo = async () => {
            try {
                if (jwtResponse) {
                    const user = await userService.getUserInfo(jwtResponse);
                    if (user != undefined) {
                        setAppointment((prevState) => ({
                            ...prevState.user,
                            user
                        }))
                    }
                }
            } catch (error) {
                console.log(error);
            }
        };

        if (jwtResponse != null) {
            fetchUserInfo();
        }

    }, [jwtResponse]);

    const appointmentService = new AppointmentService(setJwtResponse);

    const handleChange = (newValues) => {
        setAppointment((prevAppointment) => ({
            ...prevAppointment,
            ...newValues
        }));
    }

    const handlePostAppointment = async () => {
        const currentDateTime = new Date(); // Get the current date and time
        const formattedDateTime = currentDateTime.toISOString();
        try {
            const response = await appointmentService.createAppointment({
                id: "00000000-0000-0000-0000-000000000000",
                clientId: appointment.user.id,
                categoryId: appointment.category?.id,
                employeeId: appointment.employee?.id,
                salonId: appointment.saloon?.id,
                serviceId: appointment.service?.id,
                //StartTime: appointment.startTime?.toISOString(),
                startTime: formattedDateTime ,
                endTime: formattedDateTime,
                //EndTime: appointment.endTime?.toISOString(),
            } as AppointmentDTO, jwtResponse);

            console.log('Appointment created:', response);
            // setFormSubmitted(true);


        } catch (error) {
            console.error('Error creating appointment:', error);
            // Handle the error (e.g., show an error message to the user).
        }
    };

    useEffect(() => {
        console.log('Appointment updated:', appointment);
        // Optionally, you can call handlePostAppointment here if you want to post the appointment
    }, [appointment]);

    let submit = false;
    const handleSubmit = () => {
        // You can perform any actions before submitting, if needed
        handlePostAppointment();
        submit = true;
        alert(`Appointment submitted`);
    };

    return (
        <>
            {formSubmitted ? (
                <Confirmation appointment={appointment} />
            ) : (
                <BookAppointmentForm appointment={appointment} onChange={handleChange} onSubmit={handleSubmit} />
            )}
        </>
    );
}
