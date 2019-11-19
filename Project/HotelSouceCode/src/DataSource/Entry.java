package DataSource;

import javafx.scene.control.TextField;

public class Entry {
public  boolean Correct=false;
private String Username="Hotel";
private Integer Password=1281629883;


//region Setters and Getters
public String getUsername(){
    return Username;
}

public Integer getPassword(){
    return Password;
}

//endregion

    public void OK(TextField username,TextField pw){

    if(username.getText().matches(getUsername()) && pw.getText().hashCode()==getPassword()){
        Correct=true;
    }
    else{
        Correct=false;
    }


}



}
