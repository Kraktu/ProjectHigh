using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IComponentSceneLoaderBehaviour
{
	void AssignAsyncOp();
	void LoadMyComponent();
	void StartComponentAction();
	IEnumerator DoingComponentAction();
	void EndComponentAction();
	
}
