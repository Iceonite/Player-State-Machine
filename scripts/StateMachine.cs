using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{

	[Export] public NodePath intialState; // Assign Intial State in the inspector

	private Dictionary<string, State> _states; // Name of Node is key, State instance is value
	private State _currentState; 

	public void Begin(Player parent)
	{
		// Gather all states and save them
		_states = new Dictionary<string, State>();
		foreach (Node node in GetChildren()) 
		{
			if (node is State state)
			{
				_states[node.Name] = state;
				state.fsm = this;
				state.Ready();
				state.parent = parent; 
				state.Exit(); 
				GD.Print(node.Name);
			}
		}	

		// Enter intial state
		_currentState = GetNode<State>(intialState);
		_currentState.Enter();
	}

	// ----- Proccessors and Update Methods -----
	public override void _Process(double delta)
	{
		_currentState.Update((float) delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		_currentState.PhysicsUpdate((float) delta);
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		_currentState.HandleInput(@event);
	}

	public void StateTransition(string key)
	{
		// States exists + Not all ready state
		if (!_states.ContainsKey(key) || _currentState == _states[key])
		{
			return;
		}

		// Exit current state and go into the next
		_currentState.Exit();
		_currentState = _states[key];
		_currentState.Enter();
	}
}