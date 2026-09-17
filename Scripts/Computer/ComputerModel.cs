using Godot;
using System;

public partial class ComputerModel : StaticBody3D, IInteractable
{
	[Export] public ComputerCanvas ComputerManageer;

	public void Interact(Player player)
	{
		
		player.ChangeState(Player.States.PC);
		ComputerManageer.OpenInterface();
		GetViewport().SetInputAsHandled();

	}
	public void ExitInteract(Player player)
	{
		player.ChangeState(Player.States.Defaulth);
		ComputerManageer.CloseInterface();
		GetViewport().SetInputAsHandled();

	}

}
