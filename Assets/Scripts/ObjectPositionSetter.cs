using UnityEngine;

public class ObjectPositionSetter : MonoBehaviour
{
    public Transform targetObject;
    void Update()
    {
        transform.position = targetObject.position;
        transform.rotation = targetObject.rotation;
    }
}
