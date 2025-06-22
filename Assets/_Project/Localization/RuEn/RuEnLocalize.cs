using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using YG;
using System.Collections;
using TMPro;

public class RuEnLocalize : MonoBehaviour
{
    [SerializeField] private Button _localizationToggleButton;
    [SerializeField] private Sprite _englishIcon;
    [SerializeField] private Sprite _russianIcon;

    private Image _buttonImage;
    private int _currentLanguageIndex;

    private void Start()
    {
        StartCoroutine(InitializeLocalization());
    }

    private IEnumerator InitializeLocalization()
    {
        yield return LocalizationSettings.InitializationOperation;

        _buttonImage = _localizationToggleButton.GetComponent<Image>();

        _currentLanguageIndex = GetCurrentLocaleIndex();
        SafeSetLocale(_currentLanguageIndex);

        UpdateButtonIcon(_currentLanguageIndex);

        _localizationToggleButton.onClick.AddListener(ToggleLocalization);
    }

    private void ToggleLocalization()
    {
        _currentLanguageIndex = (_currentLanguageIndex == 0) ? 1 : 0;

        SafeSetLocale(_currentLanguageIndex);

        UpdateButtonIcon(_currentLanguageIndex);

        StartCoroutine(UpdateLocale());
    }

    private void SafeSetLocale(int languageIndex)
    {
        int localeCount = LocalizationSettings.AvailableLocales.Locales.Count;
        if (languageIndex < 0 || languageIndex >= localeCount)
        {
            languageIndex = 1;
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
    }

    private void UpdateButtonIcon(int languageIndex)
    {
        _buttonImage.sprite = (languageIndex == 0) ? _englishIcon : _russianIcon;
    }

    private int GetCurrentLocaleIndex()
    {
        Locale selectedLocale = LocalizationSettings.SelectedLocale;
        var locales = LocalizationSettings.AvailableLocales.Locales;

        for (int i = 0; i < locales.Count; i++)
        {
            if (locales[i] == selectedLocale)
            {
                return i;
            }
        }

        return -1; 
    }

    private IEnumerator UpdateLocale()
    {
        yield return LocalizationSettings.InitializationOperation;

        var tmpTexts = FindObjectsByType<TMP_Text>(FindObjectsSortMode.None);
        foreach (var tmpText in tmpTexts)
        {
            tmpText.text = tmpText.text;
        }
    }
}
