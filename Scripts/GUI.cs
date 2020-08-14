using Godot;
using System;

public class GUI : Container
{
    Label fps;
    PopupPanel dialog;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
      if(GetTree().CurrentScene.Filename.Contains("Start")){
        
      }
      else
      {
        fps = GetChild<Label>(FindNode("FPS").GetIndex());
      }
    }

    public override void _Notification(int what)
    {
        if(what==NotificationSortChildren)
        {
            if(GetTree().CurrentScene.Filename.Contains("Start")){
              foreach(Node n in GetChildren())
              {
                if(n.Name == "Title")
                {
                    n.Set("anchor_left", 0.25);
                    n.Set("anchor_right", 0.75); 
                    n.Set("anchor_top", 0.1); 
                    n.Set("anchor_bottom", 0.25); 
                    setStandard(n);
                    foreach(Node c in n.GetChildren()){
                        c.Set("anchor_left", 0.0);
                        c.Set("anchor_right", 1.0); 
                        c.Set("anchor_top", 0.0); 
                        c.Set("anchor_bottom", 1.0);
                        setStandard(c);
                    }
                }
                if(n.Name == "StartNew")
                {
                    n.Set("anchor_left", 0.05);
                    n.Set("anchor_right", 0.40); 
                    n.Set("anchor_top", 0.75); 
                    n.Set("anchor_bottom", 0.65); 
                    setStandard(n);
                }
                if(n.Name == "Load")
                {
                    n.Set("anchor_left", 0.45);
                    n.Set("anchor_right", 0.95); 
                    n.Set("anchor_top", 0.75); 
                    n.Set("anchor_bottom", 0.65); 
                    setStandard(n);
                }
              }
            }
            else
            {
              foreach(Node n in GetChildren())
              {
                if(n.Name == "FPS")
                {
                  
                    n.Set("anchor_left", 0.25);
                    n.Set("anchor_right", 0.75); 
                    n.Set("anchor_top", 0.1); 
                    n.Set("anchor_bottom", 0.25);
                    n.Set("rect_min_size",new Vector2(300,100));
                    setStandard(n);
                }
              }
            }
        }
    }
  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
      if(GetTree().CurrentScene.Filename.Contains("Start")){

      }else{
        fps.Text = ""+Engine.GetFramesPerSecond();
      }
    }
    
    private void setStandard(Node node){
        node.Set("margin_left", 0.0);
        node.Set("margin_right", 0.0); 
        node.Set("margin_top", 0.0); 
        node.Set("margin_bottom", 0.0);  
        node.Set("theme", ResourceLoader.Load("Styles/MainTheme.tres"));
    }
}
