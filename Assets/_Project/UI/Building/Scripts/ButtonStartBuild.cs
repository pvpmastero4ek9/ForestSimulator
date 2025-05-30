using Core.Building;
using Data.Building;
using UnityEngine;
using Zenject;

namespace UI.Building
{
    public class ButtonStartBuild : MonoBehaviour, IBuildButton
    {
        [SerializeField] private string _buildingName;

        private IResourceChecker _resourcesChecker;
        private IBuildingStateManager _handlerInfo;

        [Inject]
        public void Construct(IResourceChecker resourcesChecker, IBuildingStateManager handlerInfo)
        {
            _resourcesChecker = resourcesChecker;
            _handlerInfo = handlerInfo;
        }

        public void OnClick()
        {
            if (_resourcesChecker == null || _handlerInfo == null)
            {
                Debug.LogError("Dependencies not injected for ButtonStartBuild");
                return;
            }

            BuildingState currentState = _handlerInfo.GetCurrentState(_buildingName);

            if (_resourcesChecker.HasEnoughResources(_buildingName, currentState))
            {
                _handlerInfo.ChangeState(_buildingName);
            }
            else
            {
                Debug.Log("Not enough resources to build or repair");
            }
        }
    }
}