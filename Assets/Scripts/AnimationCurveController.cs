using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurveController : MonoBehaviour
{
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] private float speed = 100.0f;
    private float curveDeltaTime = 0.0f;




    void Start()
    {
        // Auto destroy object after 5 seconds
        // Destroy(gameObject, 15.0f);
        IniAnimationCurve();
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
            DebugCurve();

        if(Input.GetKeyDown("k"))
            ModifyKeyFrame();
    }

    void ModifyKeyFrame()
    {
        print("ModifyKeyFrame");
        Keyframe key = animationCurve.keys[1];
        key.value = 0.5f;
        animationCurve.MoveKey(1, key);
    }

    void DebugCurve()
    {
        var keys = animationCurve.keys;

        foreach (var key in keys)
        {
            print($"{key.time}, {key.value}, {key.inTangent}, {key.inWeight}, {key.outTangent}, {key.outWeight}, {key.weightedMode}");
        }

    }

    void IniAnimationCurve()
    {
        // 0, 0, 0, 0.3333333, 0, 0.5972586, Out
        // 0.5, 1, 0, 0.3333333, 0, 0.3333333, None
        // 1, 0, 0, 0.4793278, 0, 0, In

// Keyframe.Keyframe(float time, float value, float inTangent, float outTangent, float inWeight, float outWeight)
        Keyframe[] keys = new Keyframe[3];
        keys[0] = new Keyframe(0, 0, 0, 0, 0.33f, 0.59f);
        keys[1] = new Keyframe(0.5f, 1, 0, 0, 0.33f, 0.33f);
        keys[2] = new Keyframe(0, 0, 0, 0, 0.48f, 0.0f);

        for (int i = 0; i < animationCurve.length; i++)
            animationCurve.RemoveKey(0);

        foreach (var key in keys)
            animationCurve.AddKey(key);

    }

    // void Update()
    // {
    //     // Get the current position of the sphere
    //     Vector3 currentPosition = transform.position;
    //     currentPosition.x += speed * Time.deltaTime;
    //     // Call evaluate on that time
    //     curveDeltaTime+= Time.deltaTime;
    //     currentPosition.y = animationCurve.Evaluate(curveDeltaTime);
    //     // Update the current position of the sphere
    //     transform.position = currentPosition;

    // }
}
