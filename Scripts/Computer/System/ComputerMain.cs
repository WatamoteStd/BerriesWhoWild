using Godot;
using System;
using System.Collections.Generic;

public partial class ComputerMain : PanelContainer
{

	public event Action OnCameraButtonPressed;
	
	[Export] private Button _startTaskButton;
	[Export] private ProgressBar _taskProgress;
	[Export] private Label _taskNameLabel;
	[Export] private StateLabel _taskAction;


	[Export] private Godot.Collections.Array<NightTask> _tasks;
	[Export] private Button _openCameraButton;


	// ====================== TASK PROGRESS VALUES =======================
	private int _currentTaskIndex = 0;
	private NightTask _currentTask;



	public bool IsOpen = false;
	private bool _isActiveProgress = false;
	private float _rawProgress = 0f;


	// =============== FAULTH ==============
	private float _timeToFault = 0f;


	public override void _Ready()
	{
		
		_startTaskButton.Toggled += OnStartButtonToggled;
		_openCameraButton.Pressed += () =>
		{
			OnCameraButtonPressed?.Invoke();
			IsOpen = false;
		};

		// ========================== TASKS ========================
		_currentTask = _tasks[_currentTaskIndex];

		_taskProgress.MaxValue = _currentTask.TargetProgress;
		_taskProgress.Value = 0;

		_taskNameLabel.Text = _currentTask.Name;

	}

	public override void _Process(double delta)
	{
		
		if (!_isActiveProgress) return;

		if (!IsOpen)
		{
			
			_timeToFault -= (float)delta;
			if (_timeToFault <= 0)
			{
				TriggerFaulth();
				return;
			}

			_rawProgress += _currentTask.DefaulthSpeed * (float)delta;

		}

		else
		{
			
			_rawProgress += _currentTask.ActiveSpeed * (float)delta;

		}

		_taskProgress.Value = Mathf.Floor(_rawProgress / 10f) * 10f;

		if (_rawProgress >= _taskProgress.MaxValue)
		{
			
			LoadNextTask();

		}

	}


	private void OnStartButtonToggled(bool isPressed)
	{

		_isActiveProgress = isPressed;

		if (isPressed)
		{
			_timeToFault = (float)GD.RandRange(2.0f, 12.0f);
			_taskAction.ChangeState(StateLabel.State.Progress);
		}
		else
		{
			_taskAction.ChangeState(StateLabel.State.Stoped);
		}

	}

	private void LoadNextTask()
	{
		
		if (_currentTaskIndex + 1 < _tasks.Count)
		{
			
			_currentTaskIndex++;
			_currentTask = _tasks[_currentTaskIndex];

			_taskProgress.MaxValue = _currentTask.TargetProgress;

			_taskProgress.Value = 0;
			_rawProgress = 0f;

			_taskNameLabel.Text = _currentTask.Name;

			_startTaskButton.ButtonPressed = false;

		}
		else
		{
			
			_taskNameLabel.Text = "YOU WIN!";
			_isActiveProgress = false;

		}

	}

	private void TriggerFaulth()
	{
		
		_startTaskButton.ButtonPressed = false;

	}


}
