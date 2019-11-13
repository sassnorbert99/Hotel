package Main;

import Crypting.MD5;
import DataSource.DBConnection;
import DataSource.Database;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import java.net.URL;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ResourceBundle;

public class Controller implements  Initializable {

    //region Ez a metódus 1x fut le a program betöltődésekor
    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
            Database.CreateAdminok();
            Database.CreateVendegek();
            Database.CreateSzobak();
            Database.CreateSzolgaltatasok();
            Database.CreateFoglalasok();
            Database.CreateSzobaSzamla();
    }
    //endregion


    @FXML
    private TextField userFiled;
    @FXML
    private TextField pwField;

    public void OnClickLogin(){
        System.out.println("Logging In...");
        Connection conn =  null;
        Statement statement = null;

        Stage window = null;
        Scene login = null;
        Scene view = null;

        try {
            conn = DBConnection.Open();
            statement = conn.createStatement();

            ResultSet reslts = statement.executeQuery("SELECT jelszo " +
                        " FROM adminok WHERE jelszo='" + MD5.Encrypt(pwField.getText())+"'");

            if (reslts.getString(Database.MEZO_ADMINOK_JELSZO).equals(MD5.Encrypt(pwField.getText()))){
                System.out.println("Sikeres");
                // TODO view betöltése!!!
            }
            else{
                System.out.println("Sikertelen");
            }

        } catch (SQLException e) {
            e.printStackTrace();
        } finally {
            try {
                statement.close();
                conn.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }

    }

}
