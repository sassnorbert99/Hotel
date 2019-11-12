package sample;

import DataSource.DBConnection;
import DataSource.Database;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.sql.Connection;

public class Main extends Application {




    @Override
    public void start(Stage primaryStage) throws Exception {
        Stage login=new Stage();
        Parent loginer=FXMLLoader.load(getClass().getResource("view.fxml"));
        login.setTitle("HotelLite®");
        login.setScene(new Scene(loginer, 600, 400));
        login.show();



        Parent root = FXMLLoader.load(getClass().getResource("view.fxml"));
        primaryStage.setTitle("HotelLite®");
        primaryStage.setScene(new Scene(root, 600, 400));
        primaryStage.show();



        Database.CreateVendégek();
        Database.CreateSzobak();
        Database.CreateFoglalasok();
        Database.CreateSzobaSzamla();
        Database.CreateSzolgáltatások();
    }




    public static void main(String[] args) {
        launch(args);
    }
}
