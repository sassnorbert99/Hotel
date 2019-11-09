/*SQL database*/

package DataSource;

import java.io.Console;
import java.sql.*;

public class DBConnection {

    private static Connection conn;
    /*Connection Method*/
    public static Connection getConnection(){
        String OSName = System.getProperty("os.name").toLowerCase();

        try {
            /*connection_string_win method*/
            if (OSName.contains("win")){
                conn = DriverManager.getConnection(Database.CONNECTION_STRING_WIN);
            }
            /*connection_string_mac method*/
            else {
                conn = DriverManager.getConnection(Database.CONNECTION_STRING_MAC);
            }

        }
        catch (SQLException e){
            conn = null;

            System.out.println( "HIBA: " + e.getMessage());
        }

        return conn;

    }

}
