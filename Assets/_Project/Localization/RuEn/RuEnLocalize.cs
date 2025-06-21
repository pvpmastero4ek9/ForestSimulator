using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using YG;
using System.Collections;
using TMPro;

public class RuEnLocalize : MonoBehaviour
{
    public Button localizationToggleButton;
    public Sprite englishIcon;
    public Sprite russianIcon;

    private Image buttonImage;
    private int currentLanguageIndex;

    private void Start()
    {
        StartCoroutine(InitializeLocalization());
    }

    private IEnumerator InitializeLocalization()
    {
        yield return LocalizationSettings.InitializationOperation;

        if (localizationToggleButton != null)
        {
            buttonImage = localizationToggleButton.GetComponent<Image>();
        }

        SafeSetLocale(currentLanguageIndex);

        UpdateButtonIcon(currentLanguageIndex);

        localizationToggleButton.onClick.AddListener(ToggleLocalization);
    }

    private void ToggleLocalization()
    {
        currentLanguageIndex = (currentLanguageIndex == 0) ? 1 : 0;

        SafeSetLocale(currentLanguageIndex);

        UpdateButtonIcon(currentLanguageIndex);

        StartCoroutine(UpdateLocale());
    }

    private void SafeSetLocale(int languageIndex)
    {
        var localeCount = LocalizationSettings.AvailableLocales.Locales.Count;
        if (languageIndex < 0 || languageIndex >= localeCount)
        {
            languageIndex = 1;
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
    }

    private void UpdateButtonIcon(int languageIndex)
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = (languageIndex == 0) ? englishIcon : russianIcon;
        }
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
