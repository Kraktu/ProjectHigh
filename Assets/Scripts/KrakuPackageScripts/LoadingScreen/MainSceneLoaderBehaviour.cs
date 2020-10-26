using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneLoaderBehaviour : MonoBehaviour
{
	public Image fadeScreenObject;
	public float fadeTime=1;
	[HideInInspector]
	public string sceeneToLoad;
	[HideInInspector]
	public AsyncOperation loadingAsyncOperation;
	Coroutine detectLoadingCompleteCoroutine;

	public void loadIndexedScene(int index)
	{
		loadingAsyncOperation = SceneManager.LoadSceneAsync(index);

		ComponentSceneLoaderBehaviour[] _componentLoaderInScene = FindObjectsOfType<ComponentSceneLoaderBehaviour>();
		for (int i = 0; i < _componentLoaderInScene.Length; i++)
		{
			_componentLoaderInScene[i].StartComponentAction();
		}
		detectLoadingCompleteCoroutine = StartCoroutine(DetectLoadingComplete());
	}
	public void loadNamedScene(string _sceneName)
	{
		loadingAsyncOperation = SceneManager.LoadSceneAsync(_sceneName);

		ComponentSceneLoaderBehaviour[] _componentLoaderInScene = FindObjectsOfType<ComponentSceneLoaderBehaviour>();
		for (int i = 0; i < _componentLoaderInScene.Length; i++)
		{
			_componentLoaderInScene[i].StartComponentAction();
		}
		detectLoadingCompleteCoroutine = StartCoroutine(DetectLoadingComplete());
	}

	IEnumerator DetectLoadingComplete()
	{
		loadingAsyncOperation.allowSceneActivation = false;
		while (loadingAsyncOperation.progress / 0.9f < 1)
		{
			yield return null;
		}
		LoadingComplete();
	}

	void LoadingComplete()
	{
		if (detectLoadingCompleteCoroutine != null)
		{
			StopCoroutine(detectLoadingCompleteCoroutine);
		}
		StartCoroutine(FadeToNewScene());
	}
	IEnumerator FadeToNewScene()
	{
		float _time = 0;
		float tRatio;
		while (_time<=fadeTime)
		{
			tRatio = _time / fadeTime;
			fadeScreenObject.color = new Color(fadeScreenObject.color.r,fadeScreenObject.color.g,fadeScreenObject.color.b, Mathf.Lerp(0, 1, tRatio));
			_time += Time.deltaTime;
			 
			yield return null;
		}
		GoToNextScene();
	}

	void GoToNextScene()
	{
		loadingAsyncOperation.allowSceneActivation = true;
	}

}
