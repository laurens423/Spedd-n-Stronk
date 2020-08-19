using Godot;
using System;

public class Interactable : StaticBody2D
{
    [Signal]
    public delegate void withinReach(bool withinReach);

    Sprite e;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        e = GetChild<Sprite>(FindNode("E").GetIndex());
        e.Hide();
    }
    public void _on_Reach_body_entered(PhysicsBody2D body){
        e.Show();
        EmitSignal("withinReach",true);
    }
    public void _on_Reach_body_exited(PhysicsBody2D body){
        e.Hide();
        EmitSignal("withinReach",false);
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
