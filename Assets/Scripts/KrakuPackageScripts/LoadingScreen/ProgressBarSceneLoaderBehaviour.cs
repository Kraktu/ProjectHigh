using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBarSceneLoaderBehaviour : ComponentSceneLoaderBehaviour
{

	Slider loadingSlider;

	public override void LoadMyComponent()
	{
		base.LoadMyComponent();
		loadingSlider = GetComponent<Slider>();
	}


	public override IEnumerator DoingComponentAction()
	{
		while (loadingAsyncOperation.progress / 0.9f < 1)
		{
			loadingSlider.value = Mathf.Clamp01(loadingAsyncOperation.progress / 0.9f);
			yield return null;
		}
		EndComponentAction();
	}
	public override void EndComponentAction()
	{
		base.EndComponentAction();
		loadingSlider.value = 1;
	}
}
