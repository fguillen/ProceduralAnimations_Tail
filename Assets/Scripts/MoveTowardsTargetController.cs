using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTargetController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Transform _target;

    void Update()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.position = newPosition;
    }
}
