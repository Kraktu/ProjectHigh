using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PercentTextSceneLoaderBehaviour : ComponentSceneLoaderBehaviour
{
	Text loadingTextPercent;

	public override void LoadMyComponent()
	{
		base.LoadMyComponent();
		loadingTextPercent = GetComponent<Text>();
	}


	public override IEnumerator DoingComponentAction()
	{
		while (loadingAsyncOperation.progress / 0.9f < 1)
		{
			loadingTextPercent.text = Mathf.Round((Mathf.Clamp01(loadingAsyncOperation.progress / 0.9f)) * 100) + " %";
			yield return null;
		}
		EndComponentAction();
	}
	public override void EndComponentAction()
	{
		base.EndComponentAction();
		loadingTextPercent.text = "100 %";
	}

}
