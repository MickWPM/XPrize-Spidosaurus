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

    Vector3 newPos;
    private void Update()
    {
        RaycastHit hit;
        Vector3 rayOrigin = DesiredWorldPos + transform.up;
        Vector3 rayDirection = -transform.up;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, 2f, footPlacementLayerMask))
        {
            Debug.Log($"Hit {hit.collider.gameObject.name}");
            newPos = hit.point; 
            transform.position = newPos;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(newPos, Vector3.one * 0.1f);
    }
}
