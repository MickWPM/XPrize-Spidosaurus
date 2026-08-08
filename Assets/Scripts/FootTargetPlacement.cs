using UnityEngine;

public class FootTargetPlacement : MonoBehaviour
{
    private Vector3 localTargetOffset;
    private Transform footParent;
    [SerializeField] private LayerMask footPlacementLayerMask;
    private void Awake()
    {
        localTargetOffset = transform.localPosition;
        footParent = transform.parent;
    }

    private Vector3 DesiredWorldPos { get
        {
            return footParent.TransformPoint(localTargetOffset);
        }
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 rayOrigin = DesiredWorldPos + transform.up;
        Vector3 rayDirection = -transform.up;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, 2f, footPlacementLayerMask))
        { 
            transform.position = hit.point;
        }
    }

}
