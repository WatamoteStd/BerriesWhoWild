using Godot;
using System;
using System.Threading;
using System.Threading.Tasks;

public partial class Player : Node3D
{

	public enum States {Defaulth, PC}
	public States CurrentState = States.Defaulth;

	[Export] private Camera3D _camera;
	[Export] private RayCast3D _raycast;
	[Export] private SpotLight3D _flashlight;
	[Export] private float _sensativity = 0.003f;
	[Export] private AudioStreamPlayer3D _flashlight_off;
	[Export] private AudioStreamPlayer3D _flashlight_on;

	private CancellationTokenSource _flashlightCts;
	
	private float _rotationCap;
	private float _targetRotationY = 0f;


	private IInteractable _currentInteractable;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		_rotationCap = Mathf.DegToRad(80);

		Engine.MaxFps = 60;

	}


	public override void _UnhandledInput(InputEvent @event)
	{
		
		if (CurrentState == States.Defaulth)
		{
			
			if (@event is InputEventMouseMotion mouseMotion)
			{
			
				float relX = mouseMotion.Relative.X;

				_targetRotationY -= relX * _sensativity;
				_targetRotationY = Mathf.Clamp(_targetRotationY, -_rotationCap, _rotationCap);

				Rotation = new Vector3(Rotation.X,  _targetRotationY, Rotation.Z);

			}

			if (@event.IsActionPressed("FlashlightAction"))
			{
				
				_flashlightCts?.Cancel();
				_flashlightCts?.Dispose();
				_flashlightCts = new CancellationTokenSource();

				ToggleFlashlightAsync(true, _flashlightCts.Token);

			}
			if (@event.IsActionReleased("FlashlightAction"))
			{
				
				_flashlightCts?.Cancel();
				_flashlightCts?.Dispose();
				_flashlightCts = new CancellationTokenSource();

				ToggleFlashlightAsync(false, _flashlightCts.Token);

			}
			if (@event.IsActionPressed("InteractAction") )
			{
			
				_raycast.ForceRaycastUpdate();
				var collision = _raycast.GetCollider();

				if (collision is IInteractable interactable)
				{
				
					interactable.Interact(this);
					_currentInteractable = interactable;

				}

			}
		}

		// ====================== FOR PC STATE ===========================
		if (@event.IsActionPressed("ui_cancel") && CurrentState == States.PC)
		{
			
			_currentInteractable?.ExitInteract(this);
			_currentInteractable = null;
		}

	}

	public void ChangeState(States state)
	{
		
		CurrentState = state;

		if (CurrentState == States.PC)
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
			_flashlight.Visible = false;

		}
		else if (CurrentState == States.Defaulth)
		{
			Input.MouseMode = Input.MouseModeEnum.Captured;

		}

	}



	private async void ToggleFlashlightAsync(bool turnOn, CancellationToken ct)
	{
		if (turnOn)
		{
			_flashlight_on.PitchScale = (float)GD.RandRange(0.95, 1.1);
			_flashlight_on.VolumeDb = (float)GD.RandRange(-1.0, 1.0f);
			_flashlight_on.Play();

			try
			{
				await Task.Delay(100, ct); 
			}
			catch (OperationCanceledException) 
			{
				return; 
			}

			_flashlight.Visible = true;
		}
		else
		{
			_flashlight.Visible = false;

			_flashlight_off.PitchScale = (float)GD.RandRange(0.95, 1.1);
			_flashlight_off.VolumeDb = (float)GD.RandRange(-1.0, 1.0f);
			_flashlight_off.Play();
		}
	}

	
}
