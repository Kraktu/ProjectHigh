using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpinningObjectSceneLoaderBehaviour : ComponentSceneLoaderBehaviour
{
	public Vector3 rotationAxis=Vector3.one;
	public float completeRotationTime;
	public Color endingColor;
	public override IEnumerator DoingComponentAction()
	{
		while (loadingAsyncOperation.progress / 0.9f < 1)
		{
			gameObject.transform.Rotate(new Vector3(360*rotationAxis.x, 360*rotationAxis.y, 360*rotationAxis.z) * (Time.deltaTime / completeRotationTime));
			yield return null;
		}
		EndComponentAction();
	}
	public override void EndComponentAction()
	{
		base.EndComponentAction();
		//gameObject.transform.rotation = Quaternion.identity;
		Image _myImage;
		_myImage = GetComponent<Image>();
		if (_myImage!=null)
		{
			_myImage.color = endingColor;
		}
		
	}
}
