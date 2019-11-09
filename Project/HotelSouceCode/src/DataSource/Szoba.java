package DataSource;

public class Szoba {
    int id;
    short szobaszam;
    String emelet;
    short maxVendeg;
    String leiras;
    boolean erkely;
    boolean dohanyzo;

    public Szoba(int id, short szobaszam, String emelet,
                 short maxVendeg, String leiras, boolean erkely,
                 boolean dohanyzo) {
        this.id = id;
        this.szobaszam = szobaszam;
        this.emelet = emelet;
        this.maxVendeg = maxVendeg;
        this.leiras = leiras;
        this.erkely = erkely;
        this.dohanyzo = dohanyzo;
    }

    public int getId() {
        return id;
    }

    public short getSzobaszam() {
        return szobaszam;
    }

    public void setSzobaszam(short szobaszam) {
        this.szobaszam = szobaszam;
    }

    public String getEmelet() {
        return emelet;
    }

    public void setEmelet(String emelet) {
        this.emelet = emelet;
    }

    public short getMaxVendeg() {
        return maxVendeg;
    }

    public void setMaxVendeg(short maxVendeg) {
        this.maxVendeg = maxVendeg;
    }

    public String getLeiras() {
        return leiras;
    }

    public void setLeiras(String leiras) {
        this.leiras = leiras;
    }

    public boolean isErkely() {
        return erkely;
    }

    public void setErkely(boolean erkely) {
        this.erkely = erkely;
    }

    public boolean isDohanyzo() {
        return dohanyzo;
    }

    public void setDohanyzo(boolean dohanyzo) {
        this.dohanyzo = dohanyzo;
    }
}
