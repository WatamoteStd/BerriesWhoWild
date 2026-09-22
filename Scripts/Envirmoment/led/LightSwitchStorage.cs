using Godot;
using System;

public partial class LightSwitchStorage : Node3D, IInteractable
{
	[Export] private OmniLight3D _storageLight;
	[Export] private AudioStreamPlayer3D _audioPlayer;

	public void Interact(Player player)
	{
		
		_storageLight.Visible = !_storageLight.Visible;

		_audioPlayer.PitchScale = (float)GD.RandRange(0.95, 1.1);
		_audioPlayer.VolumeDb = (float)GD.RandRange(-1.0, 1);

		_audioPlayer.Play();

	}
	public void ExitInteract(Player player)
	{
		
		

	}

}
