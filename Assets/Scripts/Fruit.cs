using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Fruit : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public IObjectPool<Fruit> PoolParent { get; set; }

    public Fruit SetActive(bool value)
    {
        gameObject.SetActive(value);
        return this;
    }
    public Fruit SetTransformParent(Transform parent)
    {
        transform.SetParent(parent);
        return this;
    }
    public Fruit SetLocalPosition(Vector3 localPos)
    {
        transform.position = localPos;
        return this;
    }
    public Fruit SetLocalRotation(Quaternion localRot)
    {
        transform.rotation = localRot;
        return this;
    }
    public Fruit SetRigidbodyVelocity(Vector3 force, ForceMode forceMode = ForceMode.Impulse)
    {
        rb.AddForce(force, forceMode);
        return this;
    }
}
