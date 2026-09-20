using Godot;
using System;
using System.Collections.Generic;

public partial class SceneManager : Node
{
	
	public static SceneManager Instance {get; private set;}
	private int _currentNight;
	[Export] private Godot.Collections.Array<NightTask> _night1Tasks;
	

	public override void _Ready()
	{
		if (Instance != null)
		{
			QueueFree();
		}
		else
		{
			Instance = this;
		}
	}

	public void RegisterComputer(ComputerMain comp)
	{
		comp.OnLvlWin -= HandleNightWin;
		comp.OnLvlWin += HandleNightWin;
	}
	public void UnregisterComputer(ComputerMain comp)
	{
		comp.OnLvlWin -= HandleNightWin;
	}

	private void HandleNightWin()
	{
		
		GetTree().ChangeSceneToFile($"res://Scenes/Menu/Menu.tscn");
		
	}


}
