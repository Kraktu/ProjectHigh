using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Kraktu.Languages;
public class OptionMenuBehaviour : MonoBehaviour, IOptionMenuBehaviour
{
	protected int myCurrentEnumState=0;
	protected int myMaxEnumState;
	protected Text optionDisplayText;
	protected Localize myLocalize;


	private void Start()
	{
		myMaxEnumState = CalculateEnumLength()-1;
		optionDisplayText = GetComponent<Text>();
		myLocalize = GetComponent<Localize>();
		GetStartingEnumState();
		SwitchOptionState();
	}

	public virtual void GetStartingEnumState()
	{

	}
	public void RequestOptionStateChange(bool isGoingForward)
	{
		SoundManager.Instance.PlaySoundEffect("MainMenuButtonClickSound",UnityEngine.Random.Range(0.9f,1.1f));
		myCurrentEnumState = CalculateNewOptionState(isGoingForward, myMaxEnumState, myCurrentEnumState);
		SwitchOptionState();
	}
	public int CalculateNewOptionState(bool isGoingForward, int enumLength, int currentEnumState)
	{
		if (isGoingForward)
		{
			currentEnumState++;
			if (currentEnumState > enumLength)
			{
				currentEnumState = 0;
			}
		}
		else
		{
			currentEnumState--;
			if (currentEnumState < 0)
			{
				currentEnumState = enumLength;
			}
		}
		return currentEnumState;
	}

	public virtual int CalculateEnumLength()
	{
		return 0;
	}
	public virtual void SwitchOptionState()
	{

	}

}
