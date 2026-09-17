using Godot;
using System;

public partial class Player : Node3D
{

	public enum States {Defaulth, PC}
	public States CurrentState = States.Defaulth;

	[Export] private Camera3D _camera;
	[Export] private RayCast3D _raycast;
	[Export] private SpotLight3D _flashlight;
	[Export] private float _sensativity = 0.003f;
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
				_flashlight.Visible = true;
			}
			if (@event.IsActionReleased("FlashlightAction"))
			{
				_flashlight.Visible = false;
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





}
