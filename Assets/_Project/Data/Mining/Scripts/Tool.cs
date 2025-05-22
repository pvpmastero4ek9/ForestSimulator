using System;
using UnityEngine;

namespace Data.Mining
{
    [Serializable]
    public class Tool
    {
        public string ToolName;
        public GameObject Tool_PREFAB;
        public LayerMask LayerMask;
        public Sprite Icon;
    }
}
