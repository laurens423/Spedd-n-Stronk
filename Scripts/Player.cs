using Godot;
using System;
using Godot.Collections;

public class Player : KinematicBody2D
{
	[Export]
	public int moveSpeed = 250;
	[Export]
	public int attackDamage = 100;

	private AnimatedSprite animation = new AnimatedSprite();

	private Vector2 motion = new Vector2();
	private Vector2 oldMotion = new Vector2();
	KinematicCollision2D collision;
	[Export]
	Dictionary reachableBodies = new Dictionary();
	Area2D reach;
	Polygon2D test;
	bool attacking;
	public override void _Ready(){
		animation = GetChild<AnimatedSprite>(FindNode("Animation").GetIndex());
		reach = GetChild<Area2D>(FindNode("Reach").GetIndex());
		test = GetChild<Polygon2D>(FindNode("Test").GetIndex());

	}
		
	public override void _Process(float delta){
		
	}
	public void _on_Reach_body_entered(PhysicsBody2D body){
		if(body != this){
			if(!reachableBodies.Contains(body.Name.ToString())){
				reachableBodies.Add(body.Name.ToString(),reachableBodies.Count);

			}
		}
	}
	public void _on_Reach_body_exited(PhysicsBody2D body){
		reachableBodies.Remove(body.Name.ToString());
	}
	public void _on_Animation_animation_finished(){
		if(!animation.Animation.Contains("Walk")){
			attacking = false;
			animation.Animation="Idle";
		}
	}
	public override void _Input(InputEvent inputEvent){
		if(inputEvent is InputEventMouseMotion mouseMotion){
			//TODO: nog te verbeteren
			float angle = (Position+reach.Position).AngleToPoint(mouseMotion.Position)+(float)Math.PI;
			reach.Rotation=angle;
			test.Rotation=angle;
		}
		if(inputEvent.IsActionPressed("attack")&& !attacking){
			animation.Animation="AttackPlaceholder";
			attacking = true;
			foreach(string body in reachableBodies.Keys){
				GetNode<Destructable>("/root/Node2D/Scene/"+body).Hit(attackDamage);

			}
			//GetChild<Destructable>(FindNode(collision.Collider.Get("name").ToString()).GetIndex()
			

		}
	}
	
	public override void _PhysicsProcess(float delta) {
		motion.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		motion.y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
		//			-2
		//		-3		-1
		//	 4		P		0
		//		 3		 1
		//			 2
		if(motion!= oldMotion){
			switch((int)(motion.Angle()/(2*Math.PI)*360)/45){
				case 0:
					if(motion.x>0){
						animation.Play("WalkRight");
					}else{
						animation.Animation="Idle";
					}
				break;
				case 1:
				break;
				case 2:					
					animation.Play("WalkDown");
				break;
				case 3:
				break;
				case 4:
					animation.Play("WalkLeft");
				break;
				case -1:
				break;
				case -2:
					animation.Play("WalkUp");
				break;
				case -3:
				break;
			}
		}
		ZIndex=Mathf.CeilToInt(Position.y);
		oldMotion=motion;
		collision = MoveAndCollide(motion.Normalized() * moveSpeed * delta);
	}
}

