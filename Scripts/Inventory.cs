using Godot;
using System;

public class Inventory : Container
{
    Node grid;
    PackedScene slotScene = (PackedScene) ResourceLoader.Load("res://Scenes//Slot.tscn");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        grid = GetChild(FindNode("Grid").GetIndex());
        Vector2 gridSize = ((Vector2)grid.Get("rect_size"));
        slotScene.Set("scale",new Vector2(((gridSize.x)/(slotScene.GetWidth())),((gridSize.y*0.25f)/(slotScene.GetHeight()))));

        for(int x=0; x<5; x++){
            for(int y=0; y<5; y++){
                grid.AddChild(slotScene.Instance());

            }
        }
    }
    public override void _Notification(int what)
    {
        if(what==NotificationSortChildren)
        {
            grid.Set("rect_size",new Vector2(((Vector2)Get("rect_size")).y,((Vector2)Get("rect_size")).y));
        }
    }
    public void _on_Destroyed(string destructable_material){
      foreach(Slot slot in grid.GetChildren()){
        if(slot.material == destructable_material){
          Vector2 slotSize = ((Vector2)slot.Get("rect_size"));
          Texture number = ResourceLoader.Load("res://Sprites/Numbers/"+ ++slot.amount + ".png") as Texture;
          number.Set("scale",new Vector2(((slotSize.x*0.25f)/(number.GetWidth())),((slotSize.y*0.25f)/(number.GetHeight()))));
          number.Set("offset",new Vector2(slotSize.x*0.75f,slotSize.y*0.75f));
          slot.GetChild(1).Set("texture",number);
          break;
        }
        else if (slot.material == ""){
          slot.material = destructable_material;
          slot.amount++;
          Texture texture = ResourceLoader.Load("res://icon.png") as Texture;
          Texture number = ResourceLoader.Load("res://Sprites/Numbers/1.png") as Texture;
          Vector2 slotSize = ((Vector2)slot.Get("rect_size"));
          texture.Set("scale",new Vector2(((slotSize.x)/(texture.GetWidth())),((slotSize.y)/(texture.GetHeight()))));
          number.Set("scale",new Vector2(((slotSize.x*0.25f)/(number.GetWidth())),((slotSize.y*0.25f)/(number.GetHeight()))));
          slot.GetChild(1).Set("offset",new Vector2(slotSize.x*0.75f,slotSize.y*0.75f));
          slot.GetChild(0).Set("texture",texture);
          slot.GetChild(1).Set("texture",number);
          break;
        }
      }
      
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
