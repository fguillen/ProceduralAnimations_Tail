using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    [SerializeField] Transform end_1;
    [SerializeField] Transform end_2;
    [SerializeField] Transform target;

    [Range(0.1f, 3.0f)][SerializeField] float speed;
    [Range(0.1f, 1f)][SerializeField] float speedNoise;

    [SerializeField] int numLinePoints;

    LineRenderer lineRenderer;
    Vector3[] linePoints;

    float maxDistance;
    float minDistance;

    Transform head;
    Transform tail;


    enum MoveKind {
        MovingHead,
        MovingTail
    }

    MoveKind moveKind;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numLinePoints;

        linePoints = new Vector3[numLinePoints];

        speed = speed + Random.Range(-speedNoise, speedNoise);
    }

    // Start is called before the first frame update
    void Start()
    {
        maxDistance = Vector3.Distance(end_1.position, end_2.position);
        minDistance = maxDistance / 3.0f;
        moveKind = MoveKind.MovingHead;
    }

    // Update is called once per frame
    void Update()
    {
        SetHeadAndTail();
        MoveHeadAndTail();
        // MoveCenter();

        DrawLine();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void SetHeadAndTail()
    {
        head = GetClosestEndToTarget();
        tail = GetFarestEndToTarget();
    }

    void MoveHeadAndTail()
    {
        if(moveKind == MoveKind.MovingHead)
        {
            head.position = Vector3.MoveTowards(head.position, target.position, speed * Time.deltaTime);

            if(IsMaxDistanceBetweenEndsReached()){
                SwitchMoveKind();
            }
        }

        if(moveKind == MoveKind.MovingTail)
        {
            tail.position = Vector3.MoveTowards(tail.position, head.position, speed * Time.deltaTime);

            if(IsMinDistanceBetweenEndsReached()){
                SwitchMoveKind();
            }
        }
    }

    float GetDistanceBetweenHeadAndTail()
    {
        return Vector3.Distance(end_1.position, end_2.position);
    }

    // void MoveCenter()
    // {
    //     float a = maxDistance / 2.0f;
    //     float b = GetDistanceBetweenHeadAndTail() / 2.0f;
    //     float c = Mathf.Sqrt(Mathf.Pow(a, 2.0f) - Mathf.Pow(b, 2.0f));

    //     Vector3 headTailCenterPosition = (head.position + tail.position) / 2.0f;
    //     Vector3 centerTargetPosition = new Vector3(headTailCenterPosition.x, headTailCenterPosition.y + c, headTailCenterPosition.z);

    //     center.position = Vector3.MoveTowards(center.position, centerTargetPosition, speed * Time.deltaTime);
    // }

    void SwitchMoveKind()
    {
        if(moveKind == MoveKind.MovingHead)
            moveKind = MoveKind.MovingTail;
        else
            moveKind = MoveKind.MovingHead;
    }

    bool IsMaxDistanceBetweenEndsReached()
    {
        return (GetDistanceBetweenHeadAndTail() >= maxDistance);
    }

    bool IsMinDistanceBetweenEndsReached()
    {
        return (GetDistanceBetweenHeadAndTail() <= minDistance);
    }

    Transform GetClosestEndToTarget()
    {
        if(Vector3.Distance(end_1.position, target.position) < Vector3.Distance(end_2.position, target.position))
            return end_1;
        else
            return end_2;
    }

    Transform GetFarestEndToTarget()
    {
        if(Vector3.Distance(end_1.position, target.position) < Vector3.Distance(end_2.position, target.position))
            return end_2;
        else
            return end_1;
    }

    void DrawLine()
    {
        lineRenderer.SetPositions(CalculateBezierPoints());
    }

    Vector3 CalculateBezierControl1()
    {
        return new Vector3(end_1.position.x, end_1.position.y + ((maxDistance - GetDistanceBetweenHeadAndTail()) / 2.0f), end_1.position.z);
    }

    Vector3 CalculateBezierControl2()
    {
        return new Vector3(end_2.position.x, end_2.position.y + ((maxDistance - GetDistanceBetweenHeadAndTail()) / 2.0f), end_2.position.z);
    }

    Vector3[] CalculateBezierPoints()
    {
        Vector3[] points = new Vector3[numLinePoints];

        Vector3 bezierControl1 = CalculateBezierControl1();
        Vector3 bezierControl2 = CalculateBezierControl2();

        var bezierCalculator = new BezierCalculator(end_1.position, bezierControl1, bezierControl2, end_2.position);

        points[0] = end_1.position;
        for (int i = 1; i < numLinePoints - 1; i++)
        {
            points[i] = bezierCalculator.calculate(((float)1 / numLinePoints) * i);
        }
        points[numLinePoints - 1] = end_2.position;

        return points;
    }

    void OnDrawGizmos()
    {
        Vector3 bezierControl1 = CalculateBezierControl1();
        Vector3 bezierControl2 = CalculateBezierControl2();

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(bezierControl1, 0.1f);
        Gizmos.DrawSphere(bezierControl2, 0.1f);

        Vector3[] points = CalculateBezierPoints();
        Gizmos.color = Color.red;
        foreach (var point in points)
        {
            Gizmos.DrawSphere(point, 0.1f);
        }

    }
}
