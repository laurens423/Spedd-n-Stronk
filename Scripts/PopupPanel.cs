using Godot;
using System;

public class PopupPanel : Godot.PopupPanel
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    RichTextLabel textLabel;
    public string text = "Test blah blah blah blah";
    char[] data;
    int i;
    float lps = 0.1f, dDelta;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        textLabel = GetChild<RichTextLabel>(0);    
        data = text.ToCharArray();
        i = 0;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(dDelta >= lps){
            dDelta = 0;
            if(!(i==data.Length)){
                textLabel.Text += data[i];
                i++;
            }else{
                QueueFree();
            }
        }else{
            dDelta+=delta;
        }
                
    }
}
