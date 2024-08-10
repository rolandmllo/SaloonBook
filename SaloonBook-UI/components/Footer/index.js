import React from 'react';
import styles from "../../styles/Home.module.css";
import Link from "next/link";

const Footer = () => {
    return(
        <footer className="footer-area">
            <Link href="/">
                <h2>
                    SaloonBook
                </h2>
            </Link>
        </footer>
    )
}

export default Footer;