using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kraktu.Languages;

public class DotsTextSceneLoaderBehaviour : ComponentSceneLoaderBehaviour
{
	Text loadingTextDots;
	Localize myLocalization;

	public float dotsAnimTimer=0.3f;

	public override void LoadMyComponent()
	{
		base.LoadMyComponent();
		loadingTextDots = GetComponent<Text>();
		myLocalization = GetComponent<Localize>();
	}


	public override IEnumerator DoingComponentAction()
	{
		float _timeSpentInLoading=0,currentDotsTimer=dotsAnimTimer;
		string displayedText = "" ;
		while (loadingAsyncOperation.progress / 0.9f < 1)
		{
			if (_timeSpentInLoading>currentDotsTimer)
			{
				displayedText += ".";
				currentDotsTimer += dotsAnimTimer;
				if (displayedText=="....")
				{
					displayedText = "";
				}
			}
			loadingTextDots.text = displayedText;
			_timeSpentInLoading += Time.deltaTime;
			yield return null;
		}
		EndComponentAction();
	}
	public override void EndComponentAction()
	{
		base.EndComponentAction();
		myLocalization.localizationKey = "dotsLoadingComplete";
		myLocalization.UpdateLocale();
	}
}
