using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOptionMenuBehaviour
{
	void RequestOptionStateChange(bool isGoingForward);
	void SwitchOptionState();
	int CalculateEnumLength();
	void GetStartingEnumState();
	int CalculateNewOptionState(bool isGoingForward,int enumLength,int currentEnumState);
}
