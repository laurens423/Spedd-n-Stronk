using Godot;
using System;
using Godot.Collections;


public class StartNew : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_StartNew_pressed(){
        File saveGame = new File();
        saveGame.Open("user://savegame.save", File.ModeFlags.Write);
        string str = JSON.Print(SaveFileFormat.getFormat());
        GD.Print(str);
        saveGame.StoreLine(str);
        saveGame.Close();
        
        GetTree().ChangeScene("res://Scenes/TestScene.tscn");
    }
}
