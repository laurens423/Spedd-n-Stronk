using Godot;
using System;
using Godot.Collections;

public class Load : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        File saveGame = new File();
        if (saveGame.FileExists("user://savegame.save"))
        {
            Set("disabled", false);
        }
    }

    public void _on_Load_pressed(){
        File saveGame = new File();
        Dictionary saveFile;

        saveGame.Open("user://savegame.save", File.ModeFlags.Read);
        saveFile = (Dictionary) JSON.Parse(saveGame.GetAsText()).Result;
        GetTree().ChangeScene(""+saveFile["Scene"]);
        saveGame.Close();

    }
}
