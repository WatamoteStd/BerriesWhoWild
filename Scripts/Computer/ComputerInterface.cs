using Godot;
using System;

public partial class ComputerInterface : Control
{
	
	[Export] private LoadScreen _loadScreen;
	[Export] private ComputerMain _workWindow;
	[Export] private CameraPanel _cameraWindow;


	public override void _Ready()
	{
		_workWindow.OnCameraButtonPressed += () =>
		{
			_cameraWindow.Visible = true;
			CloseInterface();
		};
		_cameraWindow.OnBackButtonPressed += () =>
		{
			_cameraWindow.Visible = false;
			OpenInterface();
		};
	}


	public void OpenInterface()
	{
		
		_workWindow.Visible = true;
		_workWindow.IsOpen = true;

	}
	public void CloseInterface()
	{
		
		_workWindow.Visible = false;
		_workWindow.IsOpen = false;

	}


}
