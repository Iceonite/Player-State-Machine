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

	public override void HandleInput(InputEvent @event) 
	{
		if (@event.IsActionPressed("moveLeft") || @event.IsActionPressed("moveRight"))
		{
			fsm.StateTransition("Walk");
		}
	} 

}
