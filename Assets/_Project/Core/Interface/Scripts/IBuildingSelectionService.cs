using System;
using Core.Building;
using UnityEngine.UIElements;
using Data.Building;

public interface IBuildingSelectionService
{
    event Action<DataBuilding> OnBuildingSelected;
}
