package DataSource;

import java.time.LocalDate;

public class SzobaSzamla {

    int id;
    int foglalas_id;
    LocalDate szolgaltasDatum;
    int szolgaltatas_id;
    double osszeg;

    public SzobaSzamla(int id, int foglalas_id, LocalDate szolgaltasDatum,
                       int szolgaltatas_id, double osszeg) {
        this.id = id;
        this.foglalas_id = foglalas_id;
        this.szolgaltasDatum = szolgaltasDatum;
        this.szolgaltatas_id = szolgaltatas_id;
        this.osszeg = osszeg;
    }

    public int getId() {
        return id;
    }

    public int getFoglalas_id() {
        return foglalas_id;
    }

    public int getSzolgaltatas_id() {
        return szolgaltatas_id;
    }

    public LocalDate getSzolgaltasDatum() {
        return szolgaltasDatum;
    }

    public void setSzolgaltasDatum(LocalDate szolgaltasDatum) {
        this.szolgaltasDatum = szolgaltasDatum;
    }

    public double getOsszeg() {
        return osszeg;
    }

    public void setOsszeg(double osszeg) {
        this.osszeg = osszeg;
    }
}
