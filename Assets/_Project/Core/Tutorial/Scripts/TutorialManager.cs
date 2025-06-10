using UnityEngine;
using Core.Pointer;
using Data.PlayerInventory;
using AYellowpaper.SerializedCollections;
using System;
using Zenject;
using Core.Wallets;

namespace Core.Tutorial
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private InventoryData _inventoryData;

        [SerializedDictionary("DestinationName", "GameObject")]
        [SerializeField] SerializedDictionary<GameObjectDestinationName, GameObject> _objectsTutotialDictionary;

        [Inject] private Wallet _wallet;

        private int _elementsTutorialIndex;

        private GameObject _stone;
        private GameObject _tree;

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
                _stone = _objectsTutotialDictionary[GameObjectDestinationName.Stone];
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
                _tree = _objectsTutotialDictionary[GameObjectDestinationName.Tree];
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

            }
            else if (_elementsTutorialIndex == 9)
            {

            }
            else if (_elementsTutorialIndex == 10)
            {

            }
            else if (_elementsTutorialIndex == 11)
            {

            }
        }

        private enum GameObjectDestinationName
        {
            PickAxe,
            Axe,
            Stone,
            Tree,
        }
    }
}