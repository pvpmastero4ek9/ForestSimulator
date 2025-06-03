using Core.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class SettingsOpenButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private SettingsUI _settingsPanel_PREFAB;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private SettingsLogic _settingsLogic;

        private void OnEnable()
        {
            _button.onClick.AddListener(CreateSettingsPanel);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(CreateSettingsPanel);
        }

        private void CreateSettingsPanel()
        {
            Instantiate(_settingsPanel_PREFAB, _canvas.transform).Init(_settingsLogic);
        }
    }
}
