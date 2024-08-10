import { useContext, useState } from "react";
import { IdentityService } from "../../services/IdentityService";
import { JwtContext } from "../_app";
import { useRouter } from 'next/router'
import { useEffect } from 'react';
import {deleteCookie, hasCookie} from "cookies-next";

const Logout = () => {
    const navigate = useRouter();
    const [validationErrors, setValidationErrors] = useState([] as string[]);
    const { jwtResponse, setJwtResponse } = useContext(JwtContext);
    const identityService = new IdentityService();

    const handleLogout = async () => {
        setValidationErrors([]);

        if (jwtResponse == undefined || null) {
            if (hasCookie(identityService.USER_TOKEN_KEY)) {
                deleteCookie(identityService.USER_TOKEN_KEY);
            }
            await navigate.push('/');
            return
        }

        try {
            const jwtData = await identityService.logout(jwtResponse);

            if (jwtData == undefined) {
                setValidationErrors(['no jwt']);
                return;
            }

            if (jwtData) {
                console.log('Logged out');
            }
        } catch (e) {
            console.log(e.error);
        } finally {
            navigate.push('/');
        }
    };
console.log()
    useEffect(() => {
        handleLogout();
    }, []); // Empty dependency array to run only once on component mount

    return null; // or some loading indicator if needed
};

export default Logout;
