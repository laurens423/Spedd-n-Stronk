using Godot;
using System;

public class Destructable : StaticBody2D
{
   	[Export]
    public int hp = 1000;

    private Sprite HPSprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        HPSprite = GetChild<Sprite>(FindNode("HP").GetIndex());
        HPSprite.Hide();
    }
    public void Hit(int damage){
        HPSprite.Show();
        hp -= damage;
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }
}
