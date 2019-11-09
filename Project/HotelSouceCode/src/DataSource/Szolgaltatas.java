package DataSource;

public class Szolgaltatas {
    int id;
    String szolgTipus;
    double afaKulcs;

    public Szolgaltatas(int id, String szolgTipus, double afaKulcs) {
        this.id = id;
        this.szolgTipus = szolgTipus;
        this.afaKulcs = afaKulcs;
    }

    public int getId() {
        return id;
    }

    public String getSzolgTipus() {
        return szolgTipus;
    }

    public void setSzolgTipus(String szolgTipus) {
        this.szolgTipus = szolgTipus;
    }

    public double getAfaKulcs() {
        return afaKulcs;
    }

    public void setAfaKulcs(double afaKulcs) {
        this.afaKulcs = afaKulcs;
    }
}
