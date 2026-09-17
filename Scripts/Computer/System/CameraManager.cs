using Godot;
using System;

public partial class CameraManager : Camera3D
{
	
	[Export] private Godot.Collections.Array<Marker3D> _cameraPoints;

	public void SwitchToPoint(int index)
	{
		
		GlobalTransform = _cameraPoints[index].GlobalTransform;

	}

}
