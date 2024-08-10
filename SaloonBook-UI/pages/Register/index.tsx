import { MouseEvent, useContext, useState } from "react";
import { useRouter } from 'next/router'
import { IRegisterData } from "../../dto/IRegisterData";
import { IdentityService } from "../../services/IdentityService";
import { JwtContext } from "../_app";
import RegisterFormView from "../../components/Identity/RegisterFormView";

const Register = () => {
    const navigate = useRouter();

    const [values, setInput] = useState({
        password: "",
        confirmPassword: "",
        email: "",
        firstName: "",
        lastName: "",
    } as IRegisterData);

    const [validationErrors, setValidationErrors] = useState([] as string[]);

    const handleChange = (target: EventTarget & HTMLInputElement) => {
        // debugger;
        // console.log(target.name, target.value, target.type)

        setInput({ ...values, [target.name]: target.value });
    }

    const {setJwtResponse} = useContext(JwtContext);

    const identityService = new IdentityService();

    const onSubmit = async (event: MouseEvent) => {
        console.log('onSubmit', event);
        event.preventDefault();

        if (values.firstName.length == 0 || values.lastName.length == 0 || values.email.length == 0 || values.password.length == 0 || values.password != values.confirmPassword) {
            setValidationErrors(["Viga väärtustes"]);
            return;
        }
        // remove errors
        setValidationErrors([]);

        const jwtData = await identityService.register(values);

        if (jwtData == undefined) {
            // TODO: get error info
            setValidationErrors(["Viga!"]);
            return;
        } 

        if (setJwtResponse){
            setJwtResponse(jwtData);
            await navigate.push("/");
       }

    }

    return (
        <RegisterFormView values={values} handleChange={handleChange} onSubmit={onSubmit} validationErrors={validationErrors} />
    );
}

export default Register;