using UnityEngine;
using Core.Pointer;
using Data.PlayerInventory;
using AYellowpaper.SerializedCollections;
using System;
using Zenject;
using Core.Wallets;
using Core.Building;
using Core.UnlockLocations;

namespace Core.Tutorial
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private InventoryData _inventoryData;

        [SerializedDictionary("DestinationName", "GameObject")]
        [SerializeField] SerializedDictionary<GameObjectDestinationName, GameObject> _objectsTutotialDictionary;

        [Inject] private Wallet _wallet;

        private int _elementsTutorialIndex;
        private bool _isBuildCreate = false;

        private ConstructBuilding _constructBuilding;
        private GameObject _stone;
        private GameObject _tree;
        private GameObject _build;
        private GameObject _location;

        private void Awake()
        {
            _tree = _objectsTutotialDictionary[GameObjectDestinationName.Tree];
            _stone = _objectsTutotialDictionary[GameObjectDestinationName.Stone];
            _build = _objectsTutotialDictionary[GameObjectDestinationName.Build];
            _constructBuilding = _build.GetComponent<ConstructBuilding>();
        }

        private void OnEnable()
        {
            _constructBuilding.CreatedBuilding += BuiuldChangeState;
        }

        private void OnDisable()
        {
            _constructBuilding.CreatedBuilding -= BuiuldChangeState;
        }

        private void BuiuldChangeState()
        {
            _isBuildCreate = true;
        }

        private void Update()
        {
            if (_elementsTutorialIndex == 0)
            {
                GameObject pickAxe = _objectsTutotialDictionary[GameObjectDestinationName.PickAxe];
                pickAxe.GetComponent<DisplayingPointerAnObject>().CreatePointer();
                pickAxe.GetComponent<BoxCollider>().isTrigger = false;
                _elementsTutorialIndex++;
            }
            else if (_elementsTutorialIndex == 1)
            {
                if (_inventoryData.IsToolInInventory("PickAxe"))
                {
                    _elementsTutorialIndex++;
                }
            }
            else if (_elementsTutorialIndex == 2)
            {
                _stone.GetComponent<DisplayingPointerAnObject>().CreatePointer();
                _elementsTutorialIndex++;
            }
            else if (_elementsTutorialIndex == 3)
            {
                if (_wallet.GetCurrency(CurrencyType.stone).Value > 0)
                {
                    _stone.GetComponent<DisplayingPointerAnObject>().DelitePointer();
                    _elementsTutorialIndex++;
                }
            }
            else if (_elementsTutorialIndex == 4)
            {
                GameObject axe = _objectsTutotialDictionary[GameObjectDestinationName.Axe];
                axe.GetComponent<DisplayingPointerAnObject>().CreatePointer();
                axe.GetComponent<BoxCollider>().isTrigger = false;
                _elementsTutorialIndex++;
            }
            else if (_elementsTutorialIndex == 5)
            {
                if (_inventoryData.IsToolInInventory("Axe"))
                {
                    _elementsTutorialIndex++;
                }
            }
            else if (_elementsTutorialIndex == 6)
            {
                _tree.GetComponent<DisplayingPointerAnObject>().CreatePointer();
                _elementsTutorialIndex++;
            }
            else if (_elementsTutorialIndex == 7)
            {
                if (_wallet.GetCurrency(CurrencyType.wood).Value > 0)
                {
                    _tree.GetComponent<DisplayingPointerAnObject>().DelitePointer();
                    _elementsTutorialIndex++;
                }
            }
            else if (_elementsTutorialIndex == 8)
            {
                _build.GetComponent<DisplayingPointerAnObject>().CreatePointer();
                _elementsTutorialIndex++;
            }
            else if (_elementsTutorialIndex == 9)
            {
                if (_build.GetComponent<PlayerLocationChecker>().IsPlayerInside)
                {
                    _build.GetComponent<DisplayingPointerAnObject>().DelitePointer();
                    _elementsTutorialIndex++;
                }
            }
            else if (_elementsTutorialIndex == 10)
            {
                if (_isBuildCreate)
                {
                    _elementsTutorialIndex++;
                }
            }
            else if (_elementsTutorialIndex == 11)
            {
                _location = _objectsTutotialDictionary[GameObjectDestinationName.Location];
                _location.GetComponent<DisplayingPointerAnObject>().CreatePointer();
                _elementsTutorialIndex++;
            }
            else if (_elementsTutorialIndex == 12)
            {
                if (_location.GetComponent<CheckerPlayerTouch>().IsPlayerTouch)
                {
                    _location.GetComponent<DisplayingPointerAnObject>().DelitePointer();
                    _elementsTutorialIndex++;
                }
            }
        }

        private enum GameObjectDestinationName
        {
            PickAxe,
            Axe,
            Stone,
            Tree,
            Build,
            Location
        }
    }
}