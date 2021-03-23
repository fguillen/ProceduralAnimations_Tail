using UnityEngine;

public class RotateTowardsTargetController : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _speed;

    void Update()
    {
        Vector2 direction = _target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speed * Time.deltaTime);
    }
}
