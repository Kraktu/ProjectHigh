using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TypeOfScreenOption
{
	FullScreen,
	Borderless,
	Windowed
}

public class ScreenOptionMenu : OptionMenuBehaviour
{
	TypeOfScreenOption currentScreenOption;
	FullScreenMode currentTypeOfFullScreenMode;

	public override int CalculateEnumLength()
	{
		//base.CalculateMaxEnumState();
		return Enum.GetNames(typeof(TypeOfScreenOption)).Length;

	}
	public override void GetStartingEnumState()
	{
		base.GetStartingEnumState();
		currentTypeOfFullScreenMode = Screen.fullScreenMode;
		switch (currentTypeOfFullScreenMode)
		{
			case FullScreenMode.ExclusiveFullScreen:
				myCurrentEnumState = 0;
				break;
			case FullScreenMode.FullScreenWindow:
				myCurrentEnumState = 1;
				break;
			case FullScreenMode.Windowed:
				myCurrentEnumState = 2;
				break;
			default:
				myCurrentEnumState = 0;
				break;
		}
	}
	public override void SwitchOptionState()
	{
		base.SwitchOptionState();
		currentScreenOption = (TypeOfScreenOption)myCurrentEnumState;
		switch (currentScreenOption)
		{
			case TypeOfScreenOption.Windowed:
				ChangeScreenOption("screenModeWindowed",FullScreenMode.Windowed);
				break;
			case TypeOfScreenOption.FullScreen:
				ChangeScreenOption("screenModeFullScreen", FullScreenMode.ExclusiveFullScreen);
				break;
			case TypeOfScreenOption.Borderless:
				ChangeScreenOption("screenModeBorderless", FullScreenMode.FullScreenWindow);
				break;
			default:
				break;
		}
		myLocalize.UpdateLocale();
	}

	void ChangeScreenOption(string newKey,FullScreenMode newScreenMode)
	{
		myLocalize.localizationKey = newKey;
		Screen.fullScreenMode = newScreenMode;
	}
}
