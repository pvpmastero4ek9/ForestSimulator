using System;
using Core.Building;
using UnityEngine.UIElements;

public interface IBuildingSelectionService
{
    event Action<DataBuilding> OnBuildingSelected;
}
