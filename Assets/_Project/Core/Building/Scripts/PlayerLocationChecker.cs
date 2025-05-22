using UnityEngine;

namespace Core.Building
{
    public class PlayerLocationChecker : MonoBehaviour
    {
        [SerializeField] private float checkRadius = 3f;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private CreaterInterfaceUI interfaceCreator;

        private void Update()
        {
            //Collider[] hits = Physics.OverlapSphere(transform.position, checkRadius, playerLayer);
            //if (hits.Length > 0)
            //{
                //interfaceCreator.ShowInterface();
                //enabled = false;
            //}
        }
    }
}
