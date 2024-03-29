package Main;

import Crypting.MD5;
import DataSource.DBConnection;
import DataSource.Database;
import DataSource.Entry;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.MenuItem;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import java.net.URL;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ResourceBundle;
import javax.swing.*;

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
    private  TextField userFiled;
    @FXML
    private TextField pwField;


    @FXML
    private Button login;
    @FXML
    private MenuItem ExitButton;
    private MenuItem Logouter;
    private MenuItem Creators;

    public void Exit(){
        System.exit(0);
    }

    private String creatorsMessage="Készítették:\n- Oravecz Zsolt\n- Gyarmati- Sass Norbert\n- Deák Ádám\n- Járomi Dávid\n- Nagy Bálint";
    public void CreatorsList(){

        JOptionPane.showMessageDialog(null,creatorsMessage);
    }


    public void Logout(){
        Main.stage.hide();
        Main.Loginer.show();

        JOptionPane.showMessageDialog(null,"Sikeres kijelentkezés!");
    }



    public void OnClickLogin(){

        System.out.println("Logging In...");


        Entry entry1=new Entry();
        entry1.OK(userFiled,pwField);


        if (entry1.Correct){
            Main.Loginer.hide();
            pwField.clear();
            Main.stage.show();
            Main.stage.setResizable(false);
            Main.stage.setMaximized(true);

        }
        else {

            pwField.clear();
            JOptionPane.showMessageDialog(null,"Hibás bejelentkezési adatok!");
        }

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
