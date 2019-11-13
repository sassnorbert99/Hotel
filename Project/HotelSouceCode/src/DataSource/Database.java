package DataSource;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;

public class Database {

    public static final String DB_NAME = "Hotel.db";
    /*connect to windows*/
    public static final String CONNECTION_STRING_WIN = "jdbc:sqlite:..\\Database\\" + DB_NAME;
    /*connect to MacOS*/
    public static final String CONNECTION_STRING_MAC = "jdbc:sqlite:Project/Database/" + DB_NAME;

    //region Vendégek tábla
    /*Vendég tábla mezői*/
    public static final String TABLA_VENDEGEK = "vendegek";
    public static final String MEZO_VENDEGEK_ID = "id";
    public static final String MEZO_VENDEGEK_NEV = "nev";
    public static final String MEZO_VENDEGEK_SZULIDO = "szulido";
    public static final String MEZO_VENDEGEK_ORSZAG = "orszag";
    public static final String MEZO_VENDEGEK_VAROS = "varos";

    public static void CreateVendegek() {

        Connection conn = null;
        Statement statement = null;

        try {
            conn = DBConnection.Open();
            statement = conn.createStatement();

            statement.execute( "CREATE TABLE IF NOT EXISTS " + Database.TABLA_VENDEGEK + " (" +
                    Database.MEZO_VENDEGEK_ID + " INTEGER PRIMARY KEY, " +
                    Database.MEZO_VENDEGEK_NEV + " VARCHAR(30) NOT NULL, " +
                    Database.MEZO_VENDEGEK_SZULIDO + " DATE NOT NULL, " +
                    Database.MEZO_VENDEGEK_ORSZAG + " VARCHAR(50) NOT NULL, " +
                    Database.MEZO_VENDEGEK_VAROS + " VARCHAR(50) NOT NULL "
                    + ")"
            );
        }
        catch (SQLException e){

            System.out.println("HIBA A VENDÉGEK TÁBLA LÉTREHOZÁSÁNÁL: " + e.getMessage());
        }
        finally {
            try {
                statement.close();
                conn.close();
            } catch (SQLException e) {
                System.out.println("HIBA: " + e.getMessage());
            }
        }
    }
    //endregion

    //region Foglalások tábla
    /*Foglalás tábla mezői*/
    public static final String TABLA_FOGALASOK = "foglalasok";
    public static final String MEZO_FOGLALASOK_ID = "id";
    public static final String MEZO_FOGLALASOK_FOGLALONEV = "foglaloNev";
    public static final String MEZO_FOGLALASOK_ERKEZES = "erkezes";
    public static final String MEZO_FOGLALASOK_TAVOZAS = "tavozas";
    public static final String MEZO_FOGLALASOK_SZOBAID = "szobaid";
    public static final String MEZO_FOGLALASOK_VENDEGEKSZAMA = "vendegekSzama";
    public static final String MEZO_FOGLALASOK_ARPERNAP = "arPerNap";
    public static final String MEZO_FOGLALASOK_CONTACT = "contact";
    public static final String MEZO_FOGLALASOK_BANKKARTYA = "bankKartya";
    public static final String MEZO_FOGLALASOK_MEGJEGYZES = "megjegyzes";

    public static void CreateFoglalasok() {

        Connection conn = null;
        Statement statement = null;

        try {
            conn = DBConnection.Open();
            statement = conn.createStatement();

            statement.execute( "CREATE TABLE  IF NOT EXISTS " + Database.TABLA_FOGALASOK + " (" +
                    Database.MEZO_FOGLALASOK_ID + " INTEGER PRIMARY KEY, " +
                    Database.MEZO_FOGLALASOK_FOGLALONEV + " VARCHAR(30) NOT NULL, " +
                    Database.MEZO_FOGLALASOK_ERKEZES + " DATE NOT NULL, " +
                    Database.MEZO_FOGLALASOK_TAVOZAS + " DATE NOT NULL, " +
                    Database.MEZO_FOGLALASOK_SZOBAID + " INTEGER NOT NULL, " +
                    Database.MEZO_FOGLALASOK_VENDEGEKSZAMA + " INTEGER NOT NULL, " +
                    Database.MEZO_FOGLALASOK_ARPERNAP + " REAL NOT NULL, " +
                    Database.MEZO_FOGLALASOK_CONTACT + " VARCHAR(100) NOT NULL, " +
                    Database.MEZO_FOGLALASOK_BANKKARTYA + " VARCHAR(50) NOT NULL, " +
                    Database.MEZO_FOGLALASOK_MEGJEGYZES + " VARCHAR(100) NOT NULL, " +
                    " FOREIGN KEY (" + Database.MEZO_FOGLALASOK_SZOBAID + ")" +
                    " REFERENCES " + Database.TABLA_SZOBAK + "(" + Database.MEZO_SZOBAK_ID +")"
                    + ");"
            );
        }
        catch (SQLException e){
            System.out.println("HIBA A FOGLALÁSOK TÁBLA LÉTREHOZÁSÁNÁL: " + e.getMessage());
        }
        finally {
            try {
                statement.close();
                conn.close();
            } catch (SQLException e) {
                System.out.println("HIBA: " + e.getMessage());
            }
        }
    }
    //endregion

    //region Szobák tábla
    /*Szobák tábla mezői*/
    public static final String TABLA_SZOBAK = "szobak";
    public static final String MEZO_SZOBAK_ID = "id";
    public static final String MEZO_SZOBAK_SZOBASZAM = "szobaszam";
    public static final String MEZO_SZOBAK_EMELET = "emelet";
    public static final String MEZO_SZOBAK_MAXVENDEG = "maxvendeg";
    public static final String MEZO_SZOBAK_LEIRAS = "leiras";
    public static final String MEZO_SZOBAK_ERKELY = "erkely";
    public static final String MEZO_SZOBAK_DOHANYZO = "dohanyzo";

    public static void CreateSzobak() {

        Connection conn = null;
        Statement statement = null;

        try {
            conn = DBConnection.Open();
            statement = conn.createStatement();

            statement.execute( "CREATE TABLE IF NOT EXISTS " + Database.TABLA_SZOBAK + " (" +
                    Database.MEZO_SZOBAK_ID + " INTEGER PRIMARY KEY, " +
                    Database.MEZO_SZOBAK_SZOBASZAM + " INTEGER NOT NULL, " +
                    Database.MEZO_SZOBAK_EMELET + " VARCHAR(20) NOT NULL, " +
                    Database.MEZO_SZOBAK_MAXVENDEG + " INTEGER NOT NULL, " +
                    Database.MEZO_SZOBAK_LEIRAS + " VARCHAR(250) NOT NULL, " +
                    Database.MEZO_SZOBAK_ERKELY + " DECIMAL(0,1) NOT NULL, " +
                    Database.MEZO_SZOBAK_DOHANYZO + " DECIMAL(0,1) NOT NULL "
                    + ")"
            );
        }
        catch (SQLException e){
            System.out.println("HIBA A SZOBA TÁBLA LÉTREHOZÁSÁNÁL: " + e.getMessage());
        }
        finally {
            try {
                statement.close();
                conn.close();
            } catch (SQLException e) {
                System.out.println("HIBA: " + e.getMessage());
            }
        }
    }
    //endregion

    //region Számla tábla
    /*SzobaSzamla tábla mezői*/
    public static final String TABLA_SZOBASZAMLAK = "szobaSzamlak";
    public static final String MEZO_SZOBASZAMLAK_ID = "id";
    public static final String MEZO_SZOBASZAMLAK_FOGYASZTASDATUM = "fogyasztasDatum";
    public static final String MEZO_SZOBASZAMLAK_FOGLALASID = "foglalasid";
    public static final String MEZO_SZOBASZAMLAK_SZOLGALTATASID = "szolgaltatasid";
    public static final String MEZO_SZOBASZAMLAK_OSSZEG = "osszeg";

    public static void CreateSzobaSzamla() {

        Connection conn = null;
        Statement statement = null;

        try {
            conn = DBConnection.Open();
            statement = conn.createStatement();

            statement.execute( "CREATE TABLE IF NOT EXISTS " + Database.TABLA_SZOBASZAMLAK + " (" +
                    Database.MEZO_SZOBASZAMLAK_ID + " INTEGER PRIMARY KEY, " +
                    Database.MEZO_SZOBASZAMLAK_FOGYASZTASDATUM + " DATE NOT NULL, " +
                    Database.MEZO_SZOBASZAMLAK_FOGLALASID + " INTEGER NOT NULL, " +
                    Database.MEZO_SZOBASZAMLAK_SZOLGALTATASID + " INTEGER NOT NULL, " +
                    Database.MEZO_SZOBASZAMLAK_OSSZEG + " REAL NOT NULL, "+
                    " FOREIGN KEY (" + Database.MEZO_SZOBASZAMLAK_SZOLGALTATASID + ")" +
                    " REFERENCES " + Database.TABLA_SZOLGALTATASOK + "(" + Database.MEZO_SZOLGALTATASOK_ID +"), "+

                    " FOREIGN KEY (" + Database.MEZO_SZOBASZAMLAK_FOGLALASID + ")" +
                    " REFERENCES " + Database.TABLA_FOGALASOK + "(" + Database.MEZO_FOGLALASOK_ID +")"
                    + ")"
            );
        }
        catch (SQLException e){

            System.out.println("HIBA A SZOBASZÁMLA TÁBLA LÉTREHOZÁSÁNÁL: " + e.getMessage());
        }
        finally {
            try {
                statement.close();
                conn.close();
            } catch (SQLException e) {
                System.out.println("HIBA: " + e.getMessage());
            }
        }
    }
    //endregion

    //region Szolgáltatások tábla
    /*Szolgáltatások tábla mezői*/
    public static final String TABLA_SZOLGALTATASOK = "szolgaltatasok";
    public static final String MEZO_SZOLGALTATASOK_ID = "id";
    public static final String MEZO_SZOLGALTATASOK_SZOLTIPUS = "szolgtipus";
    public static final String MEZO_SZOLGALTATASOK_AFAKULCS = "afaKulcs";

    public static void CreateSzolgaltatasok() {

        Connection conn = null;
        Statement statement = null;

        try {
            conn = DBConnection.Open();
            statement = conn.createStatement();

            statement.execute( "CREATE TABLE IF NOT EXISTS " + Database.TABLA_SZOLGALTATASOK + " (" +
                    Database.MEZO_SZOLGALTATASOK_ID + " INTEGER PRIMARY KEY, " +
                    Database.MEZO_SZOLGALTATASOK_SZOLTIPUS + " VARCHAR(100) NOT NULL, " +
                    Database.MEZO_SZOLGALTATASOK_AFAKULCS + " REAL NOT NULL "
                    + ")"
            );
        }
        catch (SQLException e){

            System.out.println("HIBA A SZOLGÁLATÁSOK TÁBLA LÉTREHOZÁSÁNÁL: " + e.getMessage());
        }
        finally {
            try {
                statement.close();
                conn.close();
            } catch (SQLException e) {
                System.out.println("HIBA: " + e.getMessage());
            }
        }
    }
    //endregion

    //region Adminok tábla
    public static final String TABLA_ADMINOK = "adminok";
    public static final String MEZO_ADMINOK_ID = "id";
    public static final String MEZO_ADMINOK_FELHASZNALONEV = "felhasznaloNev";
    public static final String MEZO_ADMINOK_JELSZO = "jelszo";

    public static void CreateAdminok() {
        Connection conn = null;
        Statement statement = null;

        try {
            conn = DBConnection.Open();
            statement = conn.createStatement();

            statement.execute( "CREATE TABLE IF NOT EXISTS " + Database.TABLA_ADMINOK + " (" +
                    Database.MEZO_ADMINOK_ID + " INTEGER PRIMARY KEY, " +
                    Database.MEZO_ADMINOK_FELHASZNALONEV + " VARCHAR(100) NOT NULL, " +
                    Database.MEZO_ADMINOK_JELSZO + " VARCHAR (50) NOT NULL "
                    + ")"
            );
        }
        catch (SQLException e){

            System.out.println("HIBA AZ ADMINOK TÁBLA LÉTREHOZÁSÁNÁL: " + e.getMessage());
        }
        finally {
            try {
                statement.close();
                conn.close();
            } catch (SQLException e) {
                System.out.println("HIBA: " + e.getMessage());
            }
        }
    }
    //endregion
}
