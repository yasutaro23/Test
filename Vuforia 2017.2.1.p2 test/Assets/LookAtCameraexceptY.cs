using UnityEngine;

public class LookAtCameraexceptY : MonoBehaviour
{
    public GameObject cameraman;

    void Update()
    {
        transform.LookAt(cameraman.transform);
        transform.Rotate(new Vector3(0, 1, 0), 180);
    }
}
