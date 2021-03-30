using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSceneManagerController : MonoBehaviour
{
    [SerializeField] GameObject wormPrefab;
    [SerializeField] Transform target;


    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            SpawnWorm();
        }
    }

    void SpawnWorm()
    {
        Vector3 position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0.0f);

        var worm = Instantiate(wormPrefab, position, Quaternion.identity);
        worm.GetComponent<WormController>().SetTarget(target);
    }
}
