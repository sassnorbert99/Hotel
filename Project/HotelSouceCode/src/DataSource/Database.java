package DataSource;

public class Database {

    public static final String DB_NAME = "Hotel.db";
    /*connect to windows*/
    public static final String CONNECTION_STRING_WIN = "jdbc:sqlite:..\\Database\\" + DB_NAME;
    /*connect to MacOS*/
    public static final String CONNECTION_STRING_MAC = "jdbc:sqlite:Project/Database/" + DB_NAME;
}
