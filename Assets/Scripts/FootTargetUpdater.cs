using UnityEngine;

public class FootTargetUpdater : MonoBehaviour
{
    [Header("Foot Target setup")]
    [SerializeField] private FootTargetUpdater[] oppositeFeet;
    [SerializeField] private Transform footTarget;
    private ObjectController controller;

    [Header("Movement Tuning Parameters")]
    [SerializeField] public float moveDistanceThreshold = 0.3f;
    [SerializeField] private Vector2 distanceThresholdShrinkRateRange = new Vector2(0.005f, 0.2f);
    [SerializeField] private float totalAnimTime = 0.15f;
    private float distThresholdToUse;


    public bool IsInMoveState { get => moving; private set => moving = value; }
    bool moving = false;

    private void Awake()
    {    
        controller = gameObject.transform.root.GetComponentInChildren<ObjectController>();
    }

    private void Update()
    {
        if (IsInMoveState) return;

        StaticStateUpdate();
    }

    private void StaticStateUpdate()
    {
        if (controller.Moving)
        {
            distThresholdToUse = moveDistanceThreshold;
        }
        else
        {
            var moveThisFrame = Random.Range(distanceThresholdShrinkRateRange.x, distanceThresholdShrinkRateRange.y);
            distThresholdToUse = Mathf.Max(0.05f, distThresholdToUse - Time.deltaTime * moveThisFrame);
        }

        if (ShouldMove() == false) return;

        _ = MoveFoot();
    }


    private bool ShouldMove()
    {
        bool grounded = true;
        for (int i = 0; i < oppositeFeet.Length; i++)
        {
            if (oppositeFeet[i].IsInMoveState)
            {
                grounded = false; 
                break;
            }
        }
        return grounded && Vector3.Distance(transform.position, footTarget.position) > distThresholdToUse;
    }


    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.DrawWireSphere(footTarget.position, distThresholdToUse);
        } else
        {
            Gizmos.DrawWireSphere(footTarget.position, moveDistanceThreshold);
        }
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < oppositeFeet.Length; i++)
        {
            Gizmos.DrawLine(transform.position, oppositeFeet[i].transform.position);
        }
    }

    async Awaitable MoveFoot()
    {
        IsInMoveState = true;

        if (Vector3.Distance(transform.position, footTarget.position) < 0.05f)
        {
            MoveComplete();
            return;
        }

        float partialAnimTime = totalAnimTime / 3f;
        Vector3 midPoint = transform.position + 0.5f * (footTarget.position - transform.position) + Vector3.up * 0.5f;

        Vector3 halfMid = 0.5f * (midPoint - transform.position) + transform.position;
        transform.position = halfMid;
        await Awaitable.WaitForSecondsAsync(partialAnimTime);

        transform.position = midPoint;
        await Awaitable.WaitForSecondsAsync(partialAnimTime);
        
        Vector3 threeQuarterMid = 0.5f * (footTarget.position - midPoint ) + midPoint;
        transform.position = threeQuarterMid;
        await Awaitable.WaitForSecondsAsync(partialAnimTime);
        
        transform.position = footTarget.position;
        
        MoveComplete();
    }


    private void MoveComplete()
    {
        IsInMoveState = false;
    }

}
