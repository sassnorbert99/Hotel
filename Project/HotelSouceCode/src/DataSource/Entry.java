package DataSource;

import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.Parent;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.stage.Stage;

public class Entry {

    @FXML
    static Button Enter;
    @FXML

    public static void Success(Stage Primary)
    {
        Enter.setOnAction(new EventHandler<ActionEvent>() {
            @Override public void handle(ActionEvent e) {

            }
        });

    }
}
