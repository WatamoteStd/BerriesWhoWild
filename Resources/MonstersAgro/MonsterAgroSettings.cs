using Godot;
using System;

[GlobalClass]
public partial class MonsterAgroSettings : Resource
{
	
	[Export] public float Hearhtbeat {get; set;} = 7f;

	[Export(PropertyHint.Range, "1, 50")]
	public int AggroLevel {get; set;} = 1;
	[Export] public float TimeBeforeJumpScare {get; set;} = 5f;
	[Export] public float CooldownTime {get; set;} = 5f;

}
