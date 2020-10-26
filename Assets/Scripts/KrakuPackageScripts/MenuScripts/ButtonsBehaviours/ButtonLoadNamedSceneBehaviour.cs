using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadNamedSceneBehaviour : ButtonMenuBehaviour, IButtonMenuBehaviour
{
	public MainSceneLoaderBehaviour mainSceneLoader;
	public string SceneToLoad;
	public override void OnClickAction()
	{
		base.OnClickAction();
		LoadChosenScene();
		ResetTimeScaleAndSound();
	}
	void LoadChosenScene()
	{
		mainSceneLoader = Instantiate(mainSceneLoader);
		mainSceneLoader.loadNamedScene(SceneToLoad);
	}
	void ResetTimeScaleAndSound()
	{
		Time.timeScale = 1;
		SoundManager.Instance.ApplyReverbToMusic();
	}
}
