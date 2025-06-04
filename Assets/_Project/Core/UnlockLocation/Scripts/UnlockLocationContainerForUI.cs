using System;
using UnityEngine;

namespace Core.UnlockLocations
{
    public class UnlockLocationContainerForUI : MonoBehaviour
    {
        public InfoUnlockLocation InfoUnlockLocation { get; private set; }
        public Action FunctionCreateLocation { get; private set; }
        public delegate void InitedHandler();
        public event InitedHandler Inited;

        public UnlockLocationContainerForUI Init(InfoUnlockLocation infoUnlockLocation, Action functionCreateLocation)
        {
            InfoUnlockLocation = infoUnlockLocation;
            FunctionCreateLocation = functionCreateLocation;

            Inited?.Invoke();
            return this;
        }
    }
}
