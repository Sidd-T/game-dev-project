using Godot;
using System;

[GlobalClass]
public partial class CardBaseState : CardState
{	
	public async override void enter(){
		if (!cardUI.IsNodeReady()){
			await ToSignal(cardUI, SignalName.Ready);
		}
		
		cardUI.EmitSignal(CardUI.SignalName.reparentRequested, cardUI);
		cardUI.colour.Color = Colors.WebGreen;
		cardUI.state.Text = "BASE";
		cardUI.PivotOffset = Vector2.Zero;
	}
	
	public override void onGUIInput(InputEvent @event){
		if (@event.IsActionPressed("left_mouse")){
			cardUI.PivotOffset = cardUI.GetGlobalMousePosition() - cardUI.GlobalPosition;
			EmitSignal(CardState.SignalName.transitionRequested, this, Variant.From(CardState.State.CLICKED));
		}
	}
}
