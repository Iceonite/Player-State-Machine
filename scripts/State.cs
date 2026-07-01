using Godot;
using System;


// Meant to define the structure of a state
public partial class State : Node
{
	public StateMachine fsm; // Parent State Machine instance reference
	public Player parent; // Overall Parent Node

	public virtual void Enter() {}// When state is entered
	public virtual void Exit() {} // When state is exited

	public virtual void Ready() {} // Initilisation of the state
	public virtual void Update(float delta) {} // Process routine
	public virtual void PhysicsUpdate(float delta) {} // Physics routine
	public virtual void HandleInput(InputEvent @event) {} // Input
}