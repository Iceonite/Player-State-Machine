using Godot;
using System;

public partial class IdleState : State
{
	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
		GD.Print("Idle Intialised");
	}

	public override void Enter()
	{
		GD.Print("Entered IdleState");
		parent.sprite.Play("Idle");
	}

	public override void PhysicsUpdate(float delta)
	{
		Vector2 direction = Input.GetVector("moveLeft", "moveRight", "moveUp", "moveDown");
		if (direction != Vector2.Zero)
		{
			fsm.StateTransition("Walk");
		}

	}

}
