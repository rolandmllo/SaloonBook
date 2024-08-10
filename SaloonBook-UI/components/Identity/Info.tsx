import { useContext, useEffect, useState } from "react";
import { JwtContext } from "../../pages/_app";
import jwt_decode from "jwt-decode";
import {UserService} from "../../services/UserService";

import IdentityService from "../../services/IdentityService";
import WithNoSSR from "../WithNoSSR";

const Info = () => {
    const { jwtResponse, setJwtResponse } = useContext(JwtContext);
    const userService = new UserService(setJwtResponse!);
    const [userInfo, setUserInfo] = useState(null); // Add state variable for user info

    useEffect(() => {
        const getUser = async () => {
            // const userInfo = await userService.getAll(jwtResponse);
            setUserInfo(userInfo);    // Update userInfo state with response
        }
    }, []);
    if (jwtResponse) {
    //console.log(userInfo)

    }

    return (
        <>
            <dl className="row">
                <dt className="col-sm-2">
                    jwt decoded
                </dt>
                <dd className="col-sm-10 text-break">
                    <pre>
                        {jwtResponse ? JSON.stringify(jwt_decode(jwtResponse?.jwt), null, 4) : "no jwt"}
                    </pre>
                </dd>
                <dt className="col-sm-2">
                    jwt
                </dt>
                <dd className="col-sm-10 text-break">
                    {jwtResponse?.jwt}
                </dd>
                <dt className="col-sm-2">
                    refreshToken
                </dt>
                <dd className="col-sm-10">
                    {jwtResponse?.refreshToken}
                </dd>
                <dt className="col-sm-2">
                    User Info
                </dt>
                <dd className="col-sm-10 text-break">
                    <pre>
                        {userInfo ? JSON.stringify(userInfo, null, 4) : "Loading..."}
                    </pre>
                </dd>
                <dd className="col-sm-10">
                </dd>
            </dl>
        </>
    );
}

export default     WithNoSSR(Info);