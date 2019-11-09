package DataSource;

import java.time.LocalDate;

public class Foglalas {
    int id;
    String nev;
    LocalDate erkezes;
    LocalDate tavozas;
    int szobaid;
    short vendegekszama;
    double arpernap;
    String contact;
    String fizetesiAdat;
    String megjegyzes;

    public Foglalas(int id, String nev, LocalDate erkezes,
                    LocalDate tavozas, int szobaid, short vendegekszama,
                    double arpernap, String contact, String fizetesiAdat,
                    String megjegyzes) {
        this.id = id;
        this.nev = nev;
        this.erkezes = erkezes;
        this.tavozas = tavozas;
        this.szobaid = szobaid;
        this.vendegekszama = vendegekszama;
        this.arpernap = arpernap;
        this.contact = contact;
        this.fizetesiAdat = fizetesiAdat;
        this.megjegyzes = megjegyzes;
    }

    public int getId() {
        return id;
    }

    public int getSzobaid() {
        return szobaid;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public LocalDate getErkezes() {
        return erkezes;
    }

    public void setErkezes(LocalDate erkezes) {
        this.erkezes = erkezes;
    }

    public LocalDate getTavozas() {
        return tavozas;
    }

    public void setTavozas(LocalDate tavozas) {
        this.tavozas = tavozas;
    }

    public short getVendegekszama() {
        return vendegekszama;
    }

    public void setVendegekszama(short vendegekszama) {
        this.vendegekszama = vendegekszama;
    }

    public double getArpernap() {
        return arpernap;
    }

    public void setArpernap(double arpernap) {
        this.arpernap = arpernap;
    }

    public String getContact() {
        return contact;
    }

    public void setContact(String contact) {
        this.contact = contact;
    }

    public String getFizetesiAdat() {
        return fizetesiAdat;
    }

    public void setFizetesiAdat(String fizetesiAdat) {
        this.fizetesiAdat = fizetesiAdat;
    }

    public String getMegjegyzes() {
        return megjegyzes;
    }

    public void setMegjegyzes(String megjegyzes) {
        this.megjegyzes = megjegyzes;
    }
}
