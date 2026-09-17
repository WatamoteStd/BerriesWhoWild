using Godot;
using System;

public partial interface IInteractable
{
	
	void Interact(Player player);
	void ExitInteract(Player player);

}
