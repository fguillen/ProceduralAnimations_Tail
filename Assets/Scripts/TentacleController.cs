using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleController : MonoBehaviour
{
    LineRenderer _lineRenderer;
    Vector3[] _segmentPositions;
    Vector3[] _segmentVelocities;
    float _segmentLength;

    [SerializeField] Transform _initialJoin;
    [SerializeField] int _numSegments;
    [SerializeField] float _totalLength;
    [SerializeField] float _smoothSpeed;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.positionCount = _numSegments;
        _segmentPositions = new Vector3[_numSegments];
        _segmentVelocities = new Vector3[_numSegments];

        _segmentLength = _totalLength / _numSegments;
    }

    void Update()
    {
        _segmentPositions[0] = _initialJoin.position;
        for (int i = 1; i < _numSegments; i++)
        {
            _segmentPositions[i] = Vector3.SmoothDamp(_segmentPositions[i], _segmentPositions[i - 1] + _segmentLength * _initialJoin.right, ref _segmentVelocities[i],  _smoothSpeed);
        }
        _lineRenderer.SetPositions(_segmentPositions);
    }
}
