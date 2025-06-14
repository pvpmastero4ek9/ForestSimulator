using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using YG;

namespace LocalizationSwitch
{
    public class LocalizationSwitcher : MonoBehaviour
    {
        private void Awake()
        {
            SetLocale(YG2.lang);
        }

        private void OnEnable()
        {
            YG2.onCorrectLang += SetLocale;
        }

        private void OnDisable()
        {
            YG2.onCorrectLang -= SetLocale;
        }

        public void SetLocale(string localeCode)
        {
            CheckLanguage(localeCode);
            StartCoroutine(SerLocaleCouroutine(localeCode));
        }

        private void CheckLanguage(string lang)
        {
            if (lang != "ru" && lang != "en")
            {
                YG2.lang = "en";
            }
        }

        private IEnumerator SerLocaleCouroutine(string localeCode)
        {
            yield return LocalizationSettings.InitializationOperation;

            var locales = LocalizationSettings.AvailableLocales.Locales;

            foreach (var locale in locales)
            {
                if (locale.Identifier.Code == localeCode)
                {
                    LocalizationSettings.SelectedLocale = locale;
                    break;
                }
            }
        }
    }
}
