using Godot;
using System;

public partial class WalkState : State
{

	private const float Speed = 100.0f;


	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
		GD.Print("Walk Intialised");
	}

	
	public override void Enter() 
	{
		GD.Print("Entering WalkState");
		parent.sprite.Play("Walk");
	}

	public override void Update(float delta)
	{

	}

	public override void PhysicsUpdate(float delta)
	{
		Vector2 newVelocity = parent.Velocity;

		Vector2 direction = Input.GetVector("moveLeft", "moveRight", "moveUp", "moveDown");

	



		if (direction.X > 0)
		{
			parent.sprite.FlipH = false;
		}
		if (direction.X < 0)
		{
			parent.sprite.FlipH = true;
		}
		


		if (direction != Vector2.Zero)
		{
			newVelocity.X = direction.X * Speed;
		}
		else
		{
			fsm.StateTransition("Idle");
		}


		parent.Velocity = newVelocity;
		parent.MoveAndSlide();
	}
}
