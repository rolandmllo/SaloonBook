import { IdentityService } from "../../services/IdentityService";
import { useContext, useEffect, useState } from "react";
import { JwtContext } from "../_app";
import Info from "../../components/Identity/Info";
import { UserInfoDTO } from "../../dto/UserInfoDTO";
import {UserService} from "../../services/UserService";

export default function MyInfo() {
    const { jwtResponse, setJwtResponse } = useContext(JwtContext);


    const [userInfo, setUserInfo] = useState<UserInfoDTO | null>(null);
    const userService = new UserService(setJwtResponse);

    useEffect(() => {
        const fetchUserInfo = async () => {
            try {

                if (jwtResponse) {
                    const user = await userService.getUserInfo(jwtResponse);

                    if (user != undefined) {
                        setUserInfo(user);
                    console.log(user)
                    }
                }

            } catch (error) {
                console.log(error);
            }
        };

        if (jwtResponse != null) {
            console.log(userInfo)
            fetchUserInfo();
        }
    }, []);


    return (
        <>
            <div>
                Kasutaja: {userInfo?.firstName || "Loading..."} {userInfo?.lastName || ""}
                <br />
                <Info />
            </div>
        </>
    );
}
