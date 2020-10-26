using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kraktu.Languages
{
    [RequireComponent(typeof(Text))]
    public class Localize : LocalizeBase
    {
        private Text text;

        public override void UpdateLocale()
        {
            if (!text) return; 
            if (!string.IsNullOrEmpty(localizationKey) && Locale.CurrentLanguageStrings.ContainsKey(localizationKey))
                text.text = Locale.CurrentLanguageStrings[localizationKey].Replace(@"\n", "" + '\n'); ;
        }

        protected override void Start()
        {
            text = GetComponent<Text>();
            base.Start();
        }

    }
}