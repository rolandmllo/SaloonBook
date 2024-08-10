import Head from 'next/head';
import styles from '../../styles/Home.module.css';
import Frontpage from "../../components/Home";
import Link from "next/link";
import Info from "../../components/Identity/Info";
import MyInfo from "./MyInfo";

export default function Home() {
  return (
    <div className={styles.container}>
      <Head>
        <title>SaloonBook</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>
        <Frontpage />
        <MyInfo />

    </div>
  )
}
