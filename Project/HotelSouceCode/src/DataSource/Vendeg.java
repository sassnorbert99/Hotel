package DataSource;

import java.time.LocalDate;
import java.util.Date;

public class Vendeg {

    int id;
    String nev;
    LocalDate szulido;
    String orszag;
    String varos;

    public Vendeg(int id, String nev, LocalDate szulido,
                  String orszag, String varos) {
        this.id = id;
        this.nev = nev;
        this.szulido = szulido;
        this.orszag = orszag;
        this.varos = varos;
    }

    public int getId() {
        return id;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public LocalDate getSzulido() {
        return szulido;
    }

    public void setSzulido(LocalDate szulido) {
        this.szulido = szulido;
    }

    public String getOrszag() {
        return orszag;
    }

    public void setOrszag(String orszag) {
        this.orszag = orszag;
    }

    public String getVaros() {
        return varos;
    }

    public void setVaros(String varos) {
        this.varos = varos;
    }
}
