using System.Collections;
using UnityEngine;

namespace Core.Fishing
{
    public class CheckerClickInGameFishing
    {
        public delegate void ClickedHandler();
        public event ClickedHandler Clicked;

        public IEnumerator CheckClick()
        {
            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            Clicked?.Invoke();
        }
    }
}
