package DataSource;

import java.sql.*;

public class DBConnection {

    private static Connection conn;
    /*Connection Method*/
    public static Connection getConnection(){
        String OSName = System.getProperty("os.name").toLowerCase();

        try {

            if (OSName.contains("win")){
                conn = DriverManager.getConnection(Database.CONNECTION_STRING_WIN);
            }
            else if(OSName.contains("mac")){
                conn = DriverManager.getConnection(Database.CONNECTION_STRING_MAC);
            }



        }
        catch (SQLException e){
            conn = null;
            System.out.println(e.getMessage());
        }

        return conn;

    }

}
