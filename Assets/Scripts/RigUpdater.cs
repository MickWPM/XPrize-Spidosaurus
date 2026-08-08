using UnityEngine;

public class RigUpdater : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;

    void LateUpdate()
    {
        if (cameraTarget != null)
        {
            transform.position = cameraTarget.position;
            transform.rotation = cameraTarget.rotation;
        }
    }
}
