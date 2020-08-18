using Godot;
using System;

public class GUI : Container
{
	Label fps;


	PackedScene slotScene = (PackedScene) ResourceLoader.Load("res://Scenes//Slot.tscn");
	Node grid;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	  fps = GetChild<Label>(FindNode("FPS").GetIndex());
	  MarginRight = OS.GetScreenSize().x;
	  MarginBottom = OS.GetScreenSize().y;
	  grid = GetChild(FindNode("HUD").GetIndex()).GetChild(FindNode("HotBar").GetIndex());
	  setStandard(this);
	  //For Grid type inventory:
	//   for(int x=0; x<5; x++){
	// 	for(int y=0; y<5; y++){
	// 	  grid.AddChild(slotScene.Instance());

	// 	}
	//   }
	}
	
	public void _on_Destroyed(string destructable_material){
	  foreach(Node node in grid.GetChildren()){
		  
		if(node.Name.Contains("Box")){
			Sprite material = node.GetChild(FindNode("Material").GetIndex()) as Sprite;
			Sprite box = node.GetChild(FindNode("Box").GetIndex()) as Sprite;
			Sprite numberSlot = node.GetChild(FindNode("NumberSlot").GetIndex()) as Sprite;
		  	Vector2 slotSize = ((Vector2)node.Get("rect_size"));
			if(((Slot)node).material == destructable_material){
		  		Texture number = ResourceLoader.Load("res://Sprites/Numbers/"+ ++((Slot)node).amount + ".png") as Texture;
		  		numberSlot.GetChild(0).Set("texture",number);
		  		break;
			}
			else if (((Slot)node).material == ""){
		  		((Slot)node).material = destructable_material;
		  		((Slot)node).amount++;
		  		Texture texture = ResourceLoader.Load("res://Sprites/Items/Materials/"+ destructable_material +".png") as Texture;
		  		Texture number = ResourceLoader.Load("res://Sprites/Numbers/1.png") as Texture;
		  		material.Set("texture",texture);
		  		numberSlot.GetChild(0).Set("texture",number);
		  		break;
			}
		}
	  }
	  
	}

    public override void _Notification(int what)
    {
        if(what==NotificationSortChildren)
        {
          foreach(Node node in GetChildren())
          {
			  setStandard(node);
          }
        }
    }
  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
	  fps.Text = ""+Engine.GetFramesPerSecond();
	}
	
	private void setStandard(Node node){
		node.Set("margin_left", 0.0);
		node.Set("margin_right", 0.0); 
		node.Set("margin_top", 0.0); 
		node.Set("margin_bottom", 0.0);  
	}
}
