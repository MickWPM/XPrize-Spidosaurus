using UnityEngine;

public class BodyTargetSetter : MonoBehaviour
{
    [SerializeField] private float targetVerticalOffset = 1f;
    [SerializeField] private Transform[] feet;
    void LateUpdate()
    {
        var tgtPos = GetFeetAverage();
        tgtPos += Vector3.up * targetVerticalOffset;
        transform.position = tgtPos;
    }

    private Vector3 GetFeetAverage()
    {
        Vector3 runningPos = Vector3.zero;
        for (int i = 0; i < feet.Length; i++)
        {
            runningPos += feet[i].position;
        }
        runningPos /= feet.Length;
        return runningPos;
    }
}
