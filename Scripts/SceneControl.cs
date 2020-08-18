using Godot;
using System;

public class SceneControl : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        foreach(Node2D node in GetChildren()){
            GD.Print((int)node.Position.y);
            node.ZIndex=Mathf.CeilToInt(node.Position.y);
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
