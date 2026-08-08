using UnityEngine;
using UnityEngine.Animations.Rigging;

public class LegVisualiser : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform root, mid, tip;
    private Vector3[] positions = new Vector3[3];

    private void Awake()
    {
        lineRenderer.positionCount = 3;
    }

    [ContextMenu("Update positions")]
    private void UpdateLegPositionArray()
    {
        positions = new Vector3[3];
        lineRenderer.positionCount = 3; 
        positions[0] = root.position;
        positions[1] = mid.position;
        positions[2] = tip.position;
    }

    private void Update()
    {
        UpdateLegPositionArray();
        lineRenderer.SetPositions(positions);
    }

    [ContextMenu("Setup feet")]
    private void SetupFeet()
    {
        var ik = gameObject.GetComponent<TwoBoneIKConstraint>();
        tip.position = ik.data.target.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(root.position, mid.position);
        Gizmos.DrawLine (mid.position, tip.position);
    }
}
