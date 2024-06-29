using Godot;
using System;

[GlobalClass]
public partial class CardClickedState : CardState
{
	public override void enter(){
		cardUI.colour.Color = Colors.Orange;
		cardUI.state.Text = "CLICKED";
		cardUI.dropPointDetector.Monitoring = true;
	}
	
	public override void _Input(InputEvent @event){
		if (@event is InputEventMouseMotion mouseMotion){
			EmitSignal(CardState.SignalName.transitionRequested, this, Variant.From(CardState.State.DRAGGING));
		}
	}
}
