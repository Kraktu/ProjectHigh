using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenuBehaviour : MonoBehaviour, IButtonMenuBehaviour
{
	public virtual void OnClickAction()
	{
		PlayButtonSoundEffet();
		
	}

	protected virtual void PlayButtonSoundEffet()
	{
		SoundManager.Instance.PlaySoundEffect("MainMenuButtonClickSound", UnityEngine.Random.Range(0.9f, 1.1f));
	}

}
