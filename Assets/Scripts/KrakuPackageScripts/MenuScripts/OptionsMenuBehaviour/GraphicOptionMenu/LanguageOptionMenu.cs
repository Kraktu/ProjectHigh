using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Kraktu.Languages;

public enum TypeOfLanguages
{
	English,
	French
}
public class LanguageOptionMenu : OptionMenuBehaviour
{

	TypeOfLanguages currentLanguage;
	string currentSystemLanguage;
	public override int CalculateEnumLength()
	{
		//base.CalculateMaxEnumState();
		return Enum.GetNames(typeof(TypeOfLanguages)).Length;

	}
	public override void GetStartingEnumState()
	{
		base.GetStartingEnumState();
		currentSystemLanguage = Locale.CurrentLanguage;
		switch (currentSystemLanguage)
		{
			case "English":
				myCurrentEnumState = 0;
				break;
			case "French":
				myCurrentEnumState = 1;
				break;
			default:
				myCurrentEnumState = 0;
				break;
		}
	}
	public override void SwitchOptionState()
	{
		base.SwitchOptionState();

		currentLanguage = (TypeOfLanguages)myCurrentEnumState;
		switch (currentLanguage)
		{
			case TypeOfLanguages.English:
				ChangeLanguageOption("languageEnglish", SystemLanguage.English);
				break;
			case TypeOfLanguages.French:
				ChangeLanguageOption("languageFrench", SystemLanguage.French);
				break;
			default:
				break;
		}
		myLocalize.UpdateLocale();
	}
	void ChangeLanguageOption(string newKey, SystemLanguage newLanguage)
	{
		myLocalize.localizationKey = newKey;
		LocalizeBase.SetCurrentLanguage(newLanguage);
	}
}
