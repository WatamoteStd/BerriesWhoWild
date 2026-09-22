using Godot;
using System;
using System.Collections.Generic;

public partial class ComputerInterface : Control
{
	public enum WindowType { Main, Camera };
	
	[Export] private LoadScreen _loadScreen;
	[Export] private ComputerMain _workWindow;
	[Export] private CameraPanel _cameraWindow;

	private WindowType _lastOpenWindow;
	private Dictionary<WindowType, PanelContainer> _windows = new Dictionary<WindowType, PanelContainer>();


	public override void _Ready()
	{
		_workWindow.OnCameraButtonPressed += () =>
		{
			OpenWindow(WindowType.Camera);
		};
		_cameraWindow.OnBackButtonPressed += () =>
		{
			OpenWindow(WindowType.Main);
		};

		_windows[WindowType.Camera] = _cameraWindow;
		_windows[WindowType.Main] = _workWindow;


	}


	public void OpenInterface()
	{
		
		_windows[_lastOpenWindow].Visible = true;
		if (_lastOpenWindow == WindowType.Main) _workWindow.IsOpen = true;

	}
	public void CloseInterface()
	{
		
		_windows[_lastOpenWindow].Visible = false;
		if (_lastOpenWindow == WindowType.Main) _workWindow.IsOpen = false;

	}

	private void OpenWindow(WindowType window)
	{
		
		if (!_windows.TryGetValue(window, out var newWindow)) return;
		if (!_windows.TryGetValue(_lastOpenWindow, out var lastWindow)) return;

		if (lastWindow is ComputerMain comp) comp.IsOpen = false;

		lastWindow.Visible = false;
		newWindow.Visible = true;

		_lastOpenWindow = window;
		

	}


}
