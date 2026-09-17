using Godot;
using System;

public partial class ComputerCanvas : CanvasLayer
{
	[Export] private ComputerInterface _interface;

	public override void _Ready()
	{
		Visible = false;
	}

	public void OpenInterface()
	{
		
		_interface.OpenInterface();
		Visible = true;

	}
	public void CloseInterface()
	{
		
		_interface.CloseInterface();
		Visible = false;

	}


}
