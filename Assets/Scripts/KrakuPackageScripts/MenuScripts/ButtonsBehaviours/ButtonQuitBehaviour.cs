using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuitBehaviour : ButtonMenuBehaviour, IButtonMenuBehaviour
{
	public override void OnClickAction()
	{
		base.OnClickAction();
		Application.Quit();
	}
}
