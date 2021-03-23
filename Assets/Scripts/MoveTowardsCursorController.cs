using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCursorController : MonoBehaviour
{
    [SerializeField] float _speed;

    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.MoveTowards(transform.position, cursorPosition, _speed * Time.deltaTime);
    }
}
