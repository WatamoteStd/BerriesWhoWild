using Godot;
using System;

[GlobalClass]
public partial class NightTask : Resource
{
	
	[Export] public string Name {get; set;} = "Task";
	[Export] public float TargetProgress {get; set;} = 100f;
	[Export] public float ActiveSpeed {get; set;} = 2.5f;
	[Export] public float DefaulthSpeed {get; set;} = 0.5f;

}
