using Godot;
using System;

[GlobalClass]
public partial class CardUI : Control
{
	[Signal]
	public delegate void reparentRequestedEventHandler(CardUI whichCardUI);
	
	public ColorRect colour {get; set;}
	public Label state {get; set;} 
	public Area2D dropPointDetector {get; set;}
	public CardStateMachine cardStateMachine;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		colour = GetNode<ColorRect>("Colour");
		state = GetNode<Label>("StateLabel");
		dropPointDetector = GetNode<Area2D>("DropPointDetector");
		cardStateMachine = GetNode<CardStateMachine>("CardStateMachine");
		
		cardStateMachine.init(this);
	}
	
	public override void _Input(InputEvent @event){
		cardStateMachine._Input(@event);
	}
	
	public void onGUIInput(InputEvent @event){
		cardStateMachine.onGUIInput(@event);
	}
	
	public void onMouseEntered(){
		cardStateMachine.onMouseEntered();
	}
	
	public void onMouseExited(){
		cardStateMachine.onMouseExited();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
