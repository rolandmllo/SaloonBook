import styles from '../../styles/Home.module.css';
import Link from "next/link";

export default function Frontpage() {
  return (
      <>
              <h1 className={styles.title}>
                  SaloonBook
              </h1>

              <p className={styles.description}>
                  Iluteenuste broneerimine
              </p>

          <div className={styles.grid}>
              <Link href="Book" className={styles.card}>
                  <h3>Broneeri &rarr;</h3>
                  <p>Lisa aeg</p>
              </Link>

              <Link href="Timetable" className={styles.card}>
                  <h3>Graafik &rarr;</h3>
                  <p>Vaata broneeringuid!</p>
              </Link>
          </div>

          </>
  )
}
