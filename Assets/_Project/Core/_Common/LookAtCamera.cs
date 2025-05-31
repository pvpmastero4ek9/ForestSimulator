using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Start()
    {
        transform.LookAt(Camera.main.transform);
    }
}
