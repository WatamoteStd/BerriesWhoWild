using Godot;
using System;

public partial class LedController : Node3D
{
	
	[Export] private SpotLight3D _light;

	private float _timeToTurnOff;
	private float _currentTime;
	private float _timeToTurnOn;
	private bool _isLightOn = true;

	public override void _Ready()
	{
		
		_timeToTurnOff = (float)GD.RandRange(1.0f, 3.0f);

	}


	public override void _Process(double delta)
	{
		
		_currentTime += (float)delta;

		if (_isLightOn && _currentTime >= _timeToTurnOff)
		{
			
			TurnOffLight();

		}
		else if (!_isLightOn && _currentTime >= _timeToTurnOn)
		{
			TurnOnLight();
		}
		

	}



	private void TurnOffLight()
	{
		_currentTime = 0.0f;
		_timeToTurnOn = (float)GD.RandRange(3.5f, 15.0f);
		_light.Visible = false;
		_isLightOn = false;
	}
	private void TurnOnLight()
	{
		_currentTime = 0.0f;
		_timeToTurnOff = (float)GD.RandRange(0.2f, 0.65f);
		_light.Visible = true;
		_isLightOn = true;

	}

}
