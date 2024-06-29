using Godot;

[GlobalClass]
public partial class PauseMenu : Control
{
	private bool pauseToggle = false;
	private Control pauseMenu {get; set;}
	private CanvasLayer menu {get; set;}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pauseMenu = GetNode<Control>("PauseMenu");
		menu = GetNode<CanvasLayer>("CanvasLayer");
		menu.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		togglePause();
	}
	
	private void togglePause(){
		if (Input.IsActionJustPressed("pause")){
			pauseToggle = !pauseToggle;
			if (pauseToggle)		
				pause();
			else	
				unpause();	
		}	
	}
	
	private void onResumePressed(){
		unpause();
	}
	

	private void onQuitPressed(){
		GetTree().Quit();
	}
	
	private void pause(){
		Input.MouseMode = Input.MouseModeEnum.Visible;
		GetTree().Paused = true;
		menu.Show();
	}
	
	private void unpause(){
		Input.MouseMode = Input.MouseModeEnum.Captured;		
		GetTree().Paused = false;
		menu.Hide();	
	}
}

