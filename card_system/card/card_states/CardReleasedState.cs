using Godot;
using System;

[GlobalClass]
public partial class CardReleasedState : CardState
{
	public override void enter(){	
		cardUI.colour.Color = Colors.DarkViolet;
		cardUI.state.Text = "RELEASED";
	}
}
