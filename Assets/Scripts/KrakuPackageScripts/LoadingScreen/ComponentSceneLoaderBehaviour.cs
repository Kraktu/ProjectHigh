using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSceneLoaderBehaviour : MonoBehaviour, IComponentSceneLoaderBehaviour
{
	protected Coroutine myLoadingAnimationCoroutine;
	protected AsyncOperation loadingAsyncOperation;

	public virtual void LoadMyComponent()
	{
	}
	public void AssignAsyncOp()
	{
		loadingAsyncOperation = GetComponentInParent<MainSceneLoaderBehaviour>().loadingAsyncOperation;
	}

	public virtual void StartComponentAction()
	{
		AssignAsyncOp();
		LoadMyComponent();
		myLoadingAnimationCoroutine = StartCoroutine(DoingComponentAction());
	}
	public virtual IEnumerator DoingComponentAction()
	{
		while (loadingAsyncOperation.progress / 0.9f < 1)
		{
			yield return null;
		}
		EndComponentAction();
	}

	public virtual void EndComponentAction()
	{
		if (myLoadingAnimationCoroutine!=null)
		{
			StopCoroutine(myLoadingAnimationCoroutine);
		}
		
	}

}
