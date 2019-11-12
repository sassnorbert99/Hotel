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

        Parent root = FXMLLoader.load(getClass().getResource("sample.fxml"));
        primaryStage.setTitle("Hello World");
        primaryStage.setScene(new Scene(root, 300, 275));
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
