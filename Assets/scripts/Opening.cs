using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    [SerializeField]
    private float forcePush;
    void Start(){}
    private void OnControllerColliderHit(ControllerColliderHit coll)
    {
        Rigidbody rigidbody = coll.collider.attachedRigidbody;
        if (rigidbody != null)
        {
            Vector3 push = coll.gameObject.transform.position - transform.position;
            push.y = 0;
            push.Normalize();
            rigidbody.AddForceAtPosition(push * forcePush, transform.position, ForceMode.Impulse);
        }
    }
}
