using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPauseBehaviour : ButtonMenuBehaviour, IButtonMenuBehaviour
{
	public KeyCode pauseKey;
	public float musicReverbDry, musicReverbRoom, musicReverbRoomHF;
	private void Update()
	{
		if (Input.GetKeyDown(pauseKey))
		{
			gameObject.GetComponent<Button>().onClick.Invoke();
		}
	}
	public override void OnClickAction()
	{
		base.OnClickAction();
		ChangeMusicReverb();
		PauseTheGame();
	}
	 void ChangeMusicReverb()
	{
		SoundManager.Instance.ApplyReverbToMusic(musicReverbDry, musicReverbRoom, musicReverbRoomHF);

	}
	void PauseTheGame()
	{
			Time.timeScale = 0;
	}
}
