using Godot;
using System;

[GlobalClass]
public partial class CardStateMachine : Node
{	
	[Export] CardState initialState {get; set;}

	private CardState currentState {get; set;}
	private Godot.Collections.Dictionary<CardState.State, CardState> states = new Godot.Collections.Dictionary<CardState.State, CardState>();
	
	public void init(CardUI card){
		foreach(CardState child in GetChildren(true)){
			if (child is CardState){
				states[child.state] = child;
				child.transitionRequested += onTransitionRequested;
				child.cardUI = card;
			}
			
			if (initialState != null){
				initialState.enter();
				currentState = initialState;
			}
		}
	}
	
	public override void _Input(InputEvent @event){
		if (currentState != null){
			currentState._Input(@event);
		}
	}
	
	public void onGUIInput(InputEvent @event){
		if (currentState != null){
			currentState.onGUIInput(@event);
		}
	}
	
	public void onMouseEntered(){
		if (currentState != null){
			currentState.onMouseEntered();
		}
	}
	
	public void onMouseExited(){
		if (currentState != null){
			currentState.onMouseExited();
		}
	}
	
	public void onTransitionRequested(CardState from, CardState.State to){
		if (from != currentState){
			return;
		}
		
		CardState newState = states[to];
		if (newState == null){
			return;
		}
		
		if (currentState != null){
			currentState.exit();
		}
		
		newState.enter();
		currentState = newState;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
