using Godot;
using System;

[GlobalClass]
public partial class CardState : Node
{
	public enum State {
		BASE,
		CLICKED,
		DRAGGING,
		AIMING,
		RELEASED
	}
	
	[Signal]
	public delegate void transitionRequestedEventHandler(CardState from, State to);
	
	[Export] public State state {get; set;}
	
	public CardUI cardUI;
	
	public virtual void enter(){
		return;
	}
	
	public virtual void exit(){
		return;
	}
	
	public override void _Input(InputEvent @event){
		return;
	}
	
	public virtual void onGUIInput(InputEvent @event){
		return;
	}
	
	public void onMouseEntered(){
		return;
	}
	
	public void onMouseExited(){
		return;
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
