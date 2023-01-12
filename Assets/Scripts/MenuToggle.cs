using UnityEngine;
using VRTK;
public class MenuToggle : MonoBehaviour 
{
	public VRTK_ControllerEvents controllerEvents;
	public GameObject menu;

	private VRTK_Pointer pointer;
	bool menuState = false;


	void start()
	{
		pointer.enabled = false;
	}

	void OnEnable()
	{
		controllerEvents.ButtonTwoReleased += ControllerEvents_ButtonTwoReleased;
		pointer.enabled = true;
	}

	void OnDisable()
	{
		controllerEvents.ButtonTwoReleased -= ControllerEvents_ButtonTwoReleased;
		pointer.enabled = false;
	}

	
	private void ControllerEvents_ButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
	{
		menuState = !menuState;
		menu.SetActive(menuState);

	}

	
	
}
