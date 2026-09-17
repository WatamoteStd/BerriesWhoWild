using Godot;
using System;

public partial class StateLabel : Label
{
	
	public enum State { Progress, Stoped};
	public State CurrentState = State.Stoped;
	[Export] private float _animationChangeSpeed = 0.7f;

	private float _timeFromLastChange;
	private int _dotsCount;
	private string _baseText = "";

	public override void _Process(double delta)
	{
		
		if (CurrentState == State.Stoped) return;

		_timeFromLastChange += (float)delta;
		if (_timeFromLastChange >= _animationChangeSpeed)
		{
			_timeFromLastChange = 0.0f;

			_dotsCount = (_dotsCount + 1) % 4;

			Text = _baseText + new string('.', _dotsCount);

		}

	}


	public void ChangeState(State state)
	{
		
		CurrentState = state;
		_timeFromLastChange = 0.0f;

		if (state == State.Progress)
		{
			_baseText = "В работе";
			Text = _baseText;
		}
		else
		{
			_baseText = "Процесс приостановлен";
			Text = _baseText;
		}

	}

}
