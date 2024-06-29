using Godot;
using System;

[GlobalClass]
public partial class CardDraggingState : CardState
{
	public override void enter(){
		var uiLayer = GetTree().GetFirstNodeInGroup("uiLayer");
		if (uiLayer != null){
			cardUI.Reparent(uiLayer);
		}
		
		cardUI.colour.Color = Colors.NavyBlue;
		cardUI.state.Text = "DRAGGING";
	}
	
	public override void _Input(InputEvent @event){
		bool cancel = @event.IsActionPressed("right_mouse");
		bool confirm = @event.IsActionPressed("left_mouse") | @event.IsActionReleased("left_mouse");
		
		if (@event is InputEventMouseMotion mouseMotion){
			cardUI.GlobalPosition = cardUI.GetGlobalMousePosition() - cardUI.PivotOffset;
		}
		
		if (cancel){
			EmitSignal(CardState.SignalName.transitionRequested, this, Variant.From(CardState.State.BASE));
		}
		else if (confirm) {
			GetViewport().SetInputAsHandled();
			EmitSignal(CardState.SignalName.transitionRequested, this, Variant.From(CardState.State.RELEASED));
		}
		
	}
}
