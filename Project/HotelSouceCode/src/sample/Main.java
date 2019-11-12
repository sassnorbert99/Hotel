package sample;

import DataSource.DBConnection;
import DataSource.Database;
import DataSource.Entry;
import com.sun.tools.javac.comp.Enter;
import javafx.application.Application;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Stage;

import java.io.IOException;
import java.sql.Connection;

public class Main extends Application {
    public static void Login() throws IOException {
        Stage login=new Stage();
        Parent loginer=FXMLLoader.load(Main.class.getResource("login.fxml"));
        login.setTitle("HotelLite®");
        login.setScene(new Scene(loginer, 600, 400));
        login.show();

    }




    @Override
    public void start(Stage primaryStage) throws Exception {
       // primaryStage.hide();
        Login();
        //Entry.Success(primaryStage);




        Parent root = FXMLLoader.load(getClass().getResource("view.fxml"));
        primaryStage.setTitle("HotelLite®");
        primaryStage.setScene(new Scene(root, 600, 400));
        //primaryStage.show();



        Database.CreateVendegek();
        Database.CreateSzobak();
        Database.CreateFoglalasok();
        Database.CreateSzobaSzamla();
        Database.CreateSzolgaltatasok();
    }




    public static void main(String[] args) throws IOException {
        launch(args);




    }
}
