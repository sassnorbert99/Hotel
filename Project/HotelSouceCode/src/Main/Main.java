package Main;

import DataSource.Entry;
import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Stage;

import java.io.IOException;

public class Main extends Application {

    public static Stage stage;
    public static Stage Loginer;

    public static void Login() throws IOException {

        Stage login = new Stage();
        Loginer=login;
        login.setResizable(false);
        Parent loginer = FXMLLoader.load(Main.class.getResource("login.fxml"));
        login.setTitle("HotelLite®");
        login.setScene(new Scene(loginer, 600, 400));
        login.show();

    }




    @Override
    public void start(Stage primaryStage) throws Exception {
        stage=primaryStage;


       // primaryStage.hide();
        Login();
        //Entry.Success(primaryStage);



        Parent root = FXMLLoader.load(getClass().getResource("view.fxml"));
        primaryStage.setTitle("HotelLite®");
        primaryStage.setScene(new Scene(root, 600, 400));
        //primaryStage.show();


    }


    public static void main(String[] args) throws IOException {
        launch(args);
    }
}
