using Godot;
using System;
using Godot.Collections;

public class FileSaver : Node
{
    Dictionary saveFile;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        File saveGame = new File();
        saveGame.Open("user://savegame.save", File.ModeFlags.Read);

        saveFile = (Dictionary)JSON.Parse(saveGame.GetAsText()).Result;
        saveFile["Scene"] = GetTree().CurrentScene.Filename.Remove(0,13);
        saveGame.Close();
        Directory dir = new Directory();
        dir.Remove("user://savegame.save");
        saveGame.Open("user://savegame.save", File.ModeFlags.Write);
        saveGame.StoreLine(JSON.Print(saveFile));
        saveGame.Close();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
