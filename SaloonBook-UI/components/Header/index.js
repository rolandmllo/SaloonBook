import Link from 'next/link'
import MobileMenu from "../MobileMenu";
import React, {useEffect, useState} from 'react';
import IdentityService from "../../services/IdentityService";
import withNoSSR from "../WithNoSSR";
import MyAppointments from "../../pages/Book/MyAppointments";

const Header = () => {
    // const {jwtResponse} = useContext(JwtContext)

    const identityService = new IdentityService();


    return(
        <div className="Header_root">
            <div className="header">
                <div className="container">
                    <div className="row">
                        <div className="col-lg-3 col-10">
                            <div className="logo">
                                <h2><Link href='/Home'>SalonBook</Link></h2>
                            </div>
                        </div>
                        <div className="col-lg-9">
                            <div className="header-menu d-lg-block d-none">
                                <ul className="d-flex">
                                    <li><Link href='/'>Avaleht</Link>
                                        <ul className="submenu">
                                        <li><Link href='/'>Algus</Link></li>

                                        </ul>
                                    </li>

                                    {!identityService.isUserAuthenticated() ? (
                                        <>

                                    <li><Link href='/Login'>Sisene</Link></li>
                                    <li><Link href='/Register'>Registreeri</Link></li>
                                        </>
                                        ) : (
                                            <>
                                        <li><Link href='/Book'>Broneeri aeg</Link></li>
                                        <li><Link href='/Book/MyAppointments'>Minu broneeringud</Link></li>
                                        <li><Link href='/Logout'>Välju</Link></li>
                                            </>
                                        )}
                                </ul>
                            </div>
                        </div>
                        <div className="col-2">
                            <MobileMenu/>
                        </div>
                    </div>
                </div>
             </div>
      </div>
    )
}

export default withNoSSR(Header);
