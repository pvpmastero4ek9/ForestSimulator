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

        public Tool GetTool(string toolName)
        {
            return _toolsList.FirstOrDefault(x => x.ToolName == toolName);
        }
    }
}
