using Godot;
using System;

public class Destructable : StaticBody2D
{
    [Signal]
    public delegate void Destroyed(string destructable_material);

   	[Export]
    public string destructable_material = "";
    [Export]
    public int hp = 1000;
    private int maxHP;
    private ProgressBar HPSprite;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        HPSprite = GetChild<ProgressBar>(FindNode("HP").GetIndex());
        HPSprite.Hide();
        maxHP = hp;
    }
    
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }

    public void Hit(int damage){
        HPSprite.Show();
        hp -= damage;
        HPSprite.Set("value", ((double)hp/maxHP)*100);
        if(hp <= 0){
            EmitSignal("Destroyed", destructable_material);
            QueueFree();
        }
    }
    
}
