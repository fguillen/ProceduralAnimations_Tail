using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTestController : MonoBehaviour
{
    [SerializeField] Collider2D _collider;
    ContactPoint2D[] contacts = new ContactPoint2D[10];

    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown("k"))
        {
            ToggleCollider();
        }

        if(Input.GetKeyDown("p"))
        {
            PrintColliderInfo();
        }
    }

    void ToggleCollider()
    {
        _collider.enabled = !_collider.enabled;
    }

    void PrintColliderInfo()
    {
        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int contactCount = _collider.GetContacts(contacts);
        print($"contactCount: {contactCount}");

        for ( int i = 0; i < contactCount; i++ )
        {
            var contact = contacts[i];
            print(contact.point);
        }


    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     print("OnTriggerEnter2D");


    //     int count = other.GetContacts(contacts);
    //     print($"count: {count}");
    //     foreach (ContactPoint2D contact in contacts)
    //     {
    //         print(contact);
    //     }


    // }

    // void OnTriggerStay2D(Collider2D other)
    // {
    //     print("OnTriggerStay2D");


    //     int count = other.GetContacts(contacts);
    //     print($"count: {count}");
    //     foreach (ContactPoint2D contact in contacts)
    //     {
    //         print(contact);
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        print("OnCollisionEnter2D");
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        print("OnCollisionStay2D");



    }

    void OnDrawGizmos()
    {
        // Gizmos.color = Color.red;

        // foreach (ContactPoint2D contact in contacts)
        // {
        //     Vector2 hit = contact.point;
        //     Gizmos.DrawSphere(contact.point, 0.1f);
        // }

        // Collider2D grab = GetComponent<Collider2D>();
        // ContactFilter2D filter = new ContactFilter2D();
        // filter.useTriggers = true;
        // filter.useLayerMask = true;
        // filter.layerMask = LayerMask.NameToLayer("Playspace (Center)");

        // ContactPoint2D[] contacts = new ContactPoint2D[10];
        // int contactCount = _collider.GetContacts(contacts);

        // for ( int i = 0; i < contactCount; i++ )
        // {
        //     var contact = contacts[i];
        //     print(contact.point);
        // }

        // return false;
    }
}
