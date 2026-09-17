using Godot;
using System;

public partial class LoadScreen : PanelContainer
{

	/*&public event Action OnLoaded;
	
	[Export] private Label _startuplabel;
	[Export] private float _startupTime;
	[Export] private Label[] _logsArray;


	// FOR STARTUP TEXT
	private float _currentTimeGone;
	private bool _isLoadingUpLogs = true;
	private bool _isDotVisible = false;

	public override void _Ready()
	{
		
		GetTree().CreateTimer(_startupTime).Timeout += StartUp;


	}

	public override void _Process(double delta)
	{
		
		if (_isLoadingUpLogs)
		{
			
			_currentTimeGone += (float)delta;
			if (_currentTimeGone >= 1f)
			{
				
				if (_isDotVisible)
				{
					_startuplabel.Text = "System Starting..";
				}
				else
				{
					_startuplabel.Text = "System Starting...";
				}

				_isDotVisible = !_isDotVisible;
				_currentTimeGone = 0.0f;

			}

		}

	}


	private async void StartUp()
	{
		
		_isLoadingUpLogs = false;

		int linesPerBlock = 4;
		int totalBlocks = 3;

		for (int block = 0; block < totalBlocks; block++)
		{
			
			for (int line = 0; line < linesPerBlock; line++)
			{
				
				int index = block * linesPerBlock + line;

				_logsArray[index].Visible = true;

				await ToSignal(GetTree().CreateTimer(0.1f), SceneTreeTimer.SignalName.Timeout);


			}

			await ToSignal(GetTree().CreateTimer(0.6f), SceneTreeTimer.SignalName.Timeout);

		}

		await ToSignal(GetTree().CreateTimer(1.5f), SceneTreeTimer.SignalName.Timeout);

		OnLoaded?.Invoke();

	}*/


}
