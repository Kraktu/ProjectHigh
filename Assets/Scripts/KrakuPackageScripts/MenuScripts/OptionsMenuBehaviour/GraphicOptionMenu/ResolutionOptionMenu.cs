using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TypeOfResolutions
{
	Low,
	HD,
	HDmore,
	FullHD,
	TwoK,
	FourK

}

public class ResolutionOptionMenu : OptionMenuBehaviour
{
	TypeOfResolutions currentScreenResolution;
	Vector2 currentResolution;
	public override int CalculateEnumLength()
	{
		//base.CalculateMaxEnumState();
		return Enum.GetNames(typeof(TypeOfResolutions)).Length;

	}
	public override void GetStartingEnumState()
	{
		base.GetStartingEnumState();
		currentResolution = new Vector2(Screen.width, Screen.height);
		switch (currentResolution.x)
		{
			case 720:
				myCurrentEnumState = 0;
				break;
			case 1280:
				myCurrentEnumState = 1;
				break;
			case 1600:
				myCurrentEnumState = 2;
				break;
			case 1920:
				myCurrentEnumState = 3;
				break;
			case 2048:
				myCurrentEnumState = 4;
				break;
			case 3840:
				myCurrentEnumState = 5;
				break;
			default:
				myCurrentEnumState = 0;
				break;
		}
	}
	public override void SwitchOptionState()
	{
		base.SwitchOptionState();
		currentScreenResolution = (TypeOfResolutions)myCurrentEnumState;
		switch (currentScreenResolution)
		{
			case TypeOfResolutions.Low:
				ChangeResolutionOption("screenResolutionLow", 720, 480);
				break;
			case TypeOfResolutions.HD:
				ChangeResolutionOption("screenResolutionHD", 1280, 720);
				break;
			case TypeOfResolutions.HDmore:
				ChangeResolutionOption("screenResolutionHDmore", 1600, 900);
				break;
			case TypeOfResolutions.FullHD:
				ChangeResolutionOption("screenResolutionFullHD", 1920, 1080);
				break;
			case TypeOfResolutions.TwoK:
				ChangeResolutionOption("screenResolutiontwoK", 2048, 1080);
				break;
			case TypeOfResolutions.FourK:
				ChangeResolutionOption("screenResolutionfourK", 3840, 2160);
				break;
			default:
				break;
		}
		myLocalize.UpdateLocale();

	}
	void ChangeResolutionOption(string newKey,int width,int height)
	{
		myLocalize.localizationKey = newKey;
		Screen.SetResolution(width, height, Screen.fullScreen);
	}
}
