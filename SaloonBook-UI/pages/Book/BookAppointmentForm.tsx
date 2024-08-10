import React, {useContext, useEffect, useState} from 'react';
import TextField from '@mui/material/TextField';
import Autocomplete from '@mui/material/Autocomplete';
import { Stack, Button } from '@mui/material';
import { CategoryService } from '../../services/CategoryService';
import { ServicesService } from '../../services/ServicesService';
import { SalonsService } from '../../services/SalonsService';
import { EmployeeService } from '../../services/EmployeeService';
import { Dayjs } from 'dayjs';
import {DatePicker, LocalizationProvider} from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";

import {JwtContext} from "../_app";

export default function BookAppointmentForm({ appointment, onChange, onSubmit }) {
    const { jwtResponse, setJwtResponse } = useContext(JwtContext);

    const categoryService = new CategoryService(setJwtResponse);
    const servicesService = new ServicesService();
    const salonService = new SalonsService();
    const employeeService = new EmployeeService();

    const [category, setCategory] = useState([]);
    const [selectedCategory, setSelectedCategory] = useState(null);

    const [service, setService] = useState([]);
    const [selectedService, setSelectedService] = useState(null);

    const [salon, setSalon] = useState([]);
    const [selectedSalon, setSelectedSalon] = useState(null);

    const [employee, setEmployee] = useState([]);
    const [selectedEmployee, setSelectedEmployee] = useState(null);

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const [time, setTime] = React.useState<Dayjs | null>(null);



    useEffect(() => {
        const fetchData = async () => {
            setLoading(true);
            try {
                const data = await categoryService.getAll(jwtResponse);
                const formattedData = data.map((item) => ({
                    label: item.categoryName,
                    id: item.id,
                }));
                setCategory(formattedData);
            } catch (error) {
                console.error('Error fetching categories:', error);
                setError(error);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    useEffect(() => {
        const fetchServices = async () => {
            if (selectedCategory && selectedCategory.id) {
                setLoading(true);
                try {
                    const data = await servicesService.getById(selectedCategory.id);
                    const formattedData = data.map((item) => ({
                        label: item.serviceName,
                        id: item.id,
                    }));
                    setService(formattedData);
                } catch (error) {
                    console.error('Error fetching services:', error);
                    setError(error);
                } finally {
                    setLoading(false);
                }
            } else {
                setService([]);
            }
        };

        fetchServices();
    }, [selectedCategory]);

    useEffect(() => {
        const fetchSalons = async () => {
            if (selectedService && selectedService.id) {
                setLoading(true);
                try {
                    const data = await salonService.getAll();
                    const flattenedData = data.flatMap((city) =>
                        city.salons.map((salon) => ({ ...city, ...salon }))
                    );
                    setSalon(flattenedData);
                } catch (error) {
                    console.error('Error fetching salons:', error);
                    setError(error);
                } finally {
                    setLoading(false);
                }
            } else {
                setSalon([]);
            }
        };

        fetchSalons();
    }, [selectedService]);

    useEffect(() => {
        const fetchEmployees = async () => {
            if (selectedService && selectedService.id && selectedSalon && selectedSalon.id) {
                setLoading(true);
                try {
                    const data = await employeeService
                        .getEmployeesByServiceAndSalon(selectedService.id, selectedSalon.id);

                    const formattedData = data.map((item) => ({
                        label: `${item.firstName} ${item.lastName}`,
                        id: item.id,
                    }));
                    setEmployee(formattedData);
                    console.log(formattedData);
                } catch (error) {
                    console.error('Error fetching employees:', error);
                    setError(error);
                } finally {
                    setLoading(false);
                }
            } else {
                setEmployee([]);
            }
        };

        fetchEmployees();
    }, [selectedService, selectedSalon]);


    return (
        <>
            <Stack spacing={2} direction="column" alignItems="center" justifyContent="center">
                <h2>Broneeri aeg:</h2>

                <Autocomplete
                    disablePortal
                    id="category-combobox"
                    options={category}
                    value={selectedCategory}
                    onChange={(_, newValue) => {
                        setSelectedCategory(newValue);
                        onChange({ category: newValue });
                    }}
                    sx={{ width: 300 }}
                    renderInput={(params) => <TextField {...params} label="Kategooria" />}
                />

                <Autocomplete
                    onChange={(_, newValue) => {
                        setSelectedService(newValue);
                        onChange({ service: newValue });
                    }}
                    disabled={!selectedCategory}
                    options={service}
                    value={selectedService}
                    sx={{ width: 300 }}
                    renderInput={(params) => <TextField {...params} label="Teenus" variant="outlined" />}
                />

                <Autocomplete
                    disablePortal
                    id="service-combobox"
                    disabled={!selectedService}
                    options={salon}
                    groupBy={(option) => option.city}
                    getOptionLabel={(option) => option.salonName}
                    value={selectedSalon}
                    onChange={(_, newValue) => {
                        setSelectedSalon(newValue);
                        onChange({ saloon: newValue });
                    }}
                    sx={{ width: 300 }}
                    renderInput={(params) => <TextField {...params} label="Salong" />}
                />

                {<Autocomplete
                    disablePortal
                    id="employee-combobox"
                    disabled={!selectedSalon}
                    options={employee}
                    value={selectedEmployee}
                    onChange={(_, newValue) => {
                        setSelectedEmployee(newValue);
                        onChange({ employee: newValue });
                    }}
                    sx={{ width: 300 }}
                    renderInput={(params) => <TextField {...params} label="Teenindaja" />}
                />}
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                    <DatePicker
                        label="Controlled picker"
                        value={time}
                        onChange={(newValue) => {
                            setTime(newValue);
                            onChange(setTime(newValue));
                        }}
                        // @ts-ignore
                        renderInput={(params) => <TextField {...params} />}
                    />

                </LocalizationProvider>

                <Button
                    variant="contained"
                    //onChange={handleChange}
                    onClick={onSubmit}
                >
                    Saada
                </Button>
            </Stack>
        </>
    );
}
