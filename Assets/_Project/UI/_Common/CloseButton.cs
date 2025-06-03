using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject _closedObject;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(CloseObject);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(CloseObject);
    }

    private void CloseObject()
    {
        Destroy(_closedObject);
    }
}
