using Godot;
using System;

public partial class Monster : StaticBody3D
{
	
	[Export] protected Godot.Collections.Array<MonsterMoveTarget> _moveMarkers;
	[Export] protected MonsterAgroSettings _agroSettings;
	[Export] protected Timer _hearthTimer;

	protected int _currentAgroLevel;
	protected int _currentPointIndex = 0;

	public override void _Ready()
	{

		_currentAgroLevel = _agroSettings.AggroLevel;
		GlobalTransform = _moveMarkers[_currentPointIndex].GlobalTransform;
		
		_hearthTimer.WaitTime = _agroSettings.Hearhtbeat;
		_hearthTimer.Timeout += HearhtBeat;

	}

	protected virtual void MakeAction()
	{
		
		MoveToNextPoint();

	}

	protected virtual void MoveToNextPoint()
	{
		
		if (_currentPointIndex >= _moveMarkers.Count - 1)
		{
			GD.Print("Mob catch you!");
			return;
		}

		_currentPointIndex++;
		GlobalTransform = _moveMarkers[_currentPointIndex].GlobalTransform;
		GD.Print($"Mob move to position index:{_currentPointIndex}");

	}

	protected virtual void HearhtBeat()
	{
		
		int rand = GD.RandRange(1, 66);

		if (rand >= _currentAgroLevel)
		{
			
		}
		else
		{
			MakeAction();
		}


	}



}
