using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kraktu.Languages
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizeTM : LocalizeBase
    {
        TextMeshProUGUI text;

        protected override void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            base.Start();
        }

        public override void UpdateLocale()
        {
            if (!text) return;
            if (!System.String.IsNullOrEmpty(localizationKey) && Locale.CurrentLanguageStrings.ContainsKey(localizationKey))
                text.SetText(Locale.CurrentLanguageStrings[localizationKey].Replace(@"\n", "" + '\n'));
        }

    }
}