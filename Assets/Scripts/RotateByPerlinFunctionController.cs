using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByPerlinFunctionController : MonoBehaviour
{

    [Range(-100, 100)][SerializeField] float _rotationMin;
    [Range(-100, 100)][SerializeField] float _rotationMax;
    [SerializeField] float _variationSpeed;

    float _perlinOffset;

    LinearProportionConverter _magnitudeConverter;


    void Start()
    {
        _magnitudeConverter = new LinearProportionConverter(0.0f, 1.0f, _rotationMin, _rotationMax);
        _perlinOffset = Random.Range(0, 10000);
    }
    // Update is called once per frame
    void Update()
    {
        float perlinValue = Mathf.PerlinNoise((Time.time + _perlinOffset) * _variationSpeed, 0.0f);
        float angle = _magnitudeConverter.CalculateDimension2Value(perlinValue);
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.localRotation = rotation;
    }
}
