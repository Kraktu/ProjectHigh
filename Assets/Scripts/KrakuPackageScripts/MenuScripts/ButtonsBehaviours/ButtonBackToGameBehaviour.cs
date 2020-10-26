using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBackToGameBehaviour : ButtonMenuBehaviour, IButtonMenuBehaviour
{
	public KeyCode unPauseKey;
	private void Update()
	{
		if (Input.GetKeyDown(unPauseKey))
		{
			gameObject.GetComponent<Button>().onClick.Invoke();
		}
	}
	public override void OnClickAction()
	{
		base.OnClickAction();
		ChangeMusicReverb();
		UnPauseTheGame();
	}
	void ChangeMusicReverb()
	{
		SoundManager.Instance.ApplyReverbToMusic();

	}
	void UnPauseTheGame()
	{
		Time.timeScale = 1;
	}
}
