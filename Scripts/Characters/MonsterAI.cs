using Godot;
using System;

public partial class MonsterAI : Node3D
{
	
	[Export] private Godot.Collections.Array<MonsterPoint> _movePoints;
	[Export] private AnimationPlayer _animator;
	private int _currentPointIndex = 0;

	public override void _Ready()
	{
		
		
		GlobalTransform = _movePoints[_currentPointIndex].GlobalTransform;
		EmitAnimation();

	}

	private void EmitAnimation()
	{
		
		_animator.Play(_movePoints[_currentPointIndex].AnimationName);

	}


}
