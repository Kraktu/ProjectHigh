using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kraktu.Languages;

public class SentencesTextSceneLoaderBehaviour : ComponentSceneLoaderBehaviour
{
	Localize myLocalization;
	public List<string> localizationLoadingKeys,localizationEndLoadingKeys ;
	public float timeBetweenSentencesSwitch;
	List<string> usedLoadingKeys = new List<string>();

	public override void LoadMyComponent()
	{
		base.LoadMyComponent();
		myLocalization = GetComponent<Localize>();
	}


	public override IEnumerator DoingComponentAction()
	{
		int _keyIndex;
		float _time=9999999;
		while (loadingAsyncOperation.progress / 0.9f < 1)
		{
			if (_time>=timeBetweenSentencesSwitch)
			{
				if (localizationLoadingKeys.Count == 0)
				{
					if (usedLoadingKeys.Count == 0)
					{
						break;
					}
					for (int i = 0; i < usedLoadingKeys.Count; i++)
					{
						localizationLoadingKeys.Add(usedLoadingKeys[i]);
					}
					usedLoadingKeys.Clear();
				}
				_keyIndex = Random.Range(0, localizationLoadingKeys.Count);
				myLocalization.localizationKey = localizationLoadingKeys[_keyIndex];
				usedLoadingKeys.Add(localizationLoadingKeys[_keyIndex]);
				localizationLoadingKeys.Remove(localizationLoadingKeys[_keyIndex]);
				myLocalization.UpdateLocale();
				_time = 0;
			}

			_time += Time.deltaTime;
			yield return null;
		}
		EndComponentAction();
	}
	public override void EndComponentAction()
	{
		base.EndComponentAction();
		myLocalization.localizationKey = localizationEndLoadingKeys[Random.Range(0, localizationEndLoadingKeys.Count)];
		myLocalization.UpdateLocale();
	}

}
