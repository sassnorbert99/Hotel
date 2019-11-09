package DataSource;

public class Database {

    public static final String DB_NAME = "Hotel.db";
    /*connect to windows*/
    public static final String CONNECTION_STRING_WIN = "jdbc:sqlite:..\\Database\\" + DB_NAME;
    /*connect to MacOS*/
    public static final String CONNECTION_STRING_MAC = "jdbc:sqlite:Project/Database/" + DB_NAME;

    /*Vendég tábla mezői*/
    public static final String TABLA_VENDEG = "vendeg";
    public static final String MEZO_VENDEG_ID = "id";
    public static final String MEZO_VENDEG_NEV = "nev";
    public static final String MEZO_VENDEG_SZULIDO = "szulido";
    public static final String MEZO_VENDEG_ORSZAG = "orszag";
    public static final String MEZO_VENDEG_VAROS = "varos";

    /*Foglalás tábla mezői*/
    public static final String TABLA_FOGALAS = "foglalas";
    public static final String MEZO_FOGLALAS_ID = "id";
    public static final String MEZO_FOGLALAS_FOGLALONEV = "foglalonNev";
    public static final String MEZO_FOGLALAS_ERKEZES = "erkezes";
    public static final String MEZO_FOGLALAS_TAVOZAS = "tavozas";
    public static final String MEZO_FOGLALAS_SZOBAID = "szobaid";
    public static final String MEZO_FOGLALAS_VENDEGEKSZAMA = "vendegekSzama";
    public static final String MEZO_FOGLALAS_ARPERNAP = "arPerNap";
    public static final String MEZO_FOGLALAS_CONTACT = "contact";
    public static final String MEZO_FOGLALAS_BANKkARTYA = "bankKartya";
    public static final String MEZO_FOGLALAS_MEGJEGYZES = "megjegyzes";

    /*Szbák tábla mezői*/
    public static final String TABLA_SZOBAk = "szobak";
    public static final String MEZO_SZOBAK_ID = "id";
    public static final String MEZO_SZOBAK_SZOBASZAM = "szobaszam";
    public static final String MEZO_SZOBAK_EMELET = "emelet";
    public static final String MEZO_SZOBAK_MAXVENDEG = "maxvendeg";
    public static final String MEZO_SZOBAK_LEIRAS = "leiras";
    public static final String MEZO_SZOBAK_ERKELY = "erkely";
    public static final String MEZO_SZOBAK_DOHANYZO = "dohanyzo";

    /*SzobaSzamla tábla mezői*/
    public static final String TABLA_SZOBASZAMLA = "szobaSzamla";
    public static final String MEZO_SZOBASZAMLA_ID = "id";
    public static final String MEZO_SZOBASZAMLA_FOGYASZTASDATUM = "fogyasztasDatum";
    public static final String MEZO_SZOBASZAMLA_FOGLALASID = "foglalasid";
    public static final String MEZO_SZOBASZAMLA_OSSZEG = "osszeg";

    /*Szolgáltatások tábla mezői*/
    public static final String TABLA_SZOLGALTATASOK = "szolgaltatasok";
    public static final String MEZO_SZOLGALTATASOK_ID = "id";
    public static final String MEZO_SZOLGALTATASOK_SZOLTIPUS = "szolgtipus";
    public static final String MEZO_SZOLGALTATASOK_AFAKULCS = "afaKulcs";






}
