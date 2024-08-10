import "react-toastify/dist/ReactToastify.min.css";
import 'bootstrap/dist/css/bootstrap.min.css';
import {ToastContainer} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import '../styles/style.css'
import Head from "next/head";
import {IJWTResponse} from "../dto/IJWTResponse";
import React, {createContext, useState} from "react";
import Navbar from "../components/Navbar";
import Footer from "../components/Footer";
import Scrollbar from "../components/scrollbar";


export const JwtContext = createContext<{
    jwtResponse: IJWTResponse | null,
    setJwtResponse: ((data: IJWTResponse | null) => void) | null
}>({jwtResponse: null, setJwtResponse: null});

function SaloonBook() {

    const [jwtResponse, setJwtResponse] = useState(null as IJWTResponse | null);

    return (
        <>
        <JwtContext.Provider value={{jwtResponse, setJwtResponse}}>
            <Head>
                <meta name="viewport" content="initial-scale=1, width=device-width"/>
                <title>SaloonBook</title>
            </Head>
            <Navbar/>
            <main className="container main-container">
            </main>
            <Footer/>
            <ToastContainer/>
            <Scrollbar/>
        </JwtContext.Provider>
</>
    )
}

export default SaloonBook