using UnityEngine;

public class CameraDetach : MonoBehaviour
{
    void Start()
    {
        transform.parent = null;
    }
}
