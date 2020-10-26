using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestartSceneBehaviour : ButtonMenuBehaviour, IButtonMenuBehaviour
{
	public MainSceneLoaderBehaviour mainSceneLoader;
	public override void OnClickAction()
	{
		base.OnClickAction();
		RestartScene();
	}
	void RestartScene()
	{
		mainSceneLoader = Instantiate(mainSceneLoader);
		mainSceneLoader.loadIndexedScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
		SoundManager.Instance.ApplyReverbToMusic();
	}
}
