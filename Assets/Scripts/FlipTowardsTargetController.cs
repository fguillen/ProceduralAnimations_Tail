using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTowardsTargetController : MonoBehaviour
{
    [SerializeField] Transform _target;

    void Update()
    {
        if(
            (_target.position.x < transform.position.x && transform.localScale.y > 0) ||
            (_target.position.x > transform.position.x && transform.localScale.y < 0)
        )
        {
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }
    }
}
