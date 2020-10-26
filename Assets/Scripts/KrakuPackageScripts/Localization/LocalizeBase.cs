using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kraktu.Languages
{
    public abstract class LocalizeBase : MonoBehaviour
    {
     
        public string localizationKey;
        public abstract void UpdateLocale();

		public void  UpdateAllVisibleText()
		{
			SetCurrentLanguage(Locale.PlayerLanguage);
		}
        protected virtual void Start()
        {

            if (!Locale.currentLanguageHasBeenSet)
            {
                Locale.currentLanguageHasBeenSet = true;
                SetCurrentLanguage(Locale.PlayerLanguage);
            }
            UpdateLocale();
        }
     
        public static string GetLocalizedString(string key)
        {
            if (Locale.CurrentLanguageStrings.ContainsKey(key))
                return Locale.CurrentLanguageStrings[key];
            else
                return string.Empty;
        }
  
        public static void SetCurrentLanguage(SystemLanguage language)
        {
            Locale.CurrentLanguage = language.ToString();
            Locale.PlayerLanguage = language;
            Localize[] allTexts = GameObject.FindObjectsOfType<Localize>();
            LocalizeTM[] allTextsTM = GameObject.FindObjectsOfType<LocalizeTM>();
            for (int i = 0; i < allTexts.Length; i++)
                allTexts[i].UpdateLocale();
            for (int i = 0; i < allTextsTM.Length; i++)
                allTextsTM[i].UpdateLocale();
        }

    }
}