using Godot;
using System;

public partial class CameraPanel : PanelContainer
{
	
	public event Action OnBackButtonPressed;


	[Export] private Button _backButton;
	[Export] private Godot.Collections.Array<Button> _cameraButtons;

	[Export] private SubViewport _viewport;
	private CameraManager _renderCamera;
	[Export] private Label _camNameLabel;

	public override void _Ready()
	{
		_backButton.Pressed += () => {OnBackButtonPressed?.Invoke();};


		CallDeferred(MethodName.SetupCamera);

		for (int i = 0; i < _cameraButtons.Count; i++)
		{
			int index = i;
			_cameraButtons[i].Pressed += () =>
			{
				SwitchCamera(index);
			};

		}

	}

	private void SwitchCamera(int index)
	{
		
		_renderCamera.SwitchToPoint(index);
		switch(index)
		{
			
			case 0:
				_camNameLabel.Text = "КАМЕРА: УЛИЦА_1";
			break;
			case 1:
				_camNameLabel.Text = "КАМЕРА: УЛИЦА_2";
			break;

		}

	}
	private void SetupCamera()
	{
		
		_renderCamera = GetTree().GetFirstNodeInGroup("render_camera") as CameraManager;
		_renderCamera.Reparent(_viewport);


	}


}
