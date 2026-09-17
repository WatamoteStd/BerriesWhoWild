using Godot;
using System;

public partial class MonsterPoint : Marker3D
{
	
	[Export] public string AnimationName {get; private set;} = "Idle";
	[Export] public bool IsScreamerPoint {get; private set;} = false;

}
