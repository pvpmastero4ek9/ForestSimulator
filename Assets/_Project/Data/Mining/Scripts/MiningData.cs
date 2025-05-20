using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Data.Mining
{
    [CreateAssetMenu(fileName = "MiningData", menuName = "Mining/MiningData")]
    public class MiningData : ScriptableObject
    {
        [SerializeField] private List<Tool> _toolsList;
        public List<Tool> ToolsList => _toolsList.ToList();
    }
}
