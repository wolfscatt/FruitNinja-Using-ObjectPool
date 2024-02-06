using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;
    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;
    public float minAngle = -15f;
    public float maxAngle = 15f;
    public float minForce = 19f;
    public float maxForce = 24f;
    public float lifeTime = 5f;
    public FruitPool FruitPool;
    private void Start()
    {
        spawnArea = GetComponent<Collider>();
        FruitPool = GetComponent<FruitPool>();
    }

    private void OnEnable()
    {
        //StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update() {
        //StartCoroutine(Spawn());
        Debug.Log(FruitPool.fruitPool.CountAll);
    }


 /* 
    private IEnumerator Spawn()
    {
       
        while (enabled) // enabled
        {
            Debug.Log(FruitPool.fruitPool.CountAll);
            yield return new WaitForSeconds(2f);
            var fruit = FruitPool.fruitPool.Get();
            
            fruit.SetActive(true)
            .SetTransformParent(transform)
            .SetLocalPosition(GetRandomPosition())
            .SetLocalRotation(GetRandomRotation())
            .SetRigidbodyVelocity(GetRandomForce(fruit), ForceMode.Impulse);

            Debug.Log(fruit);

            StartCoroutine(DeactiveFruit(fruit));

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
        */

    private IEnumerator DeactiveFruit(Fruit fruit)
    {
        yield return new WaitForSeconds(lifeTime);
        FruitPool.fruitPool.Release(fruit);
    }
    private Vector3 GetRandomForce(Fruit fruit)
    {
        var force = Random.Range(minForce, maxForce);
        return force * fruit.transform.up;
    }

    private Quaternion GetRandomRotation()
    {
        var rotation = Quaternion.Euler(0, 0, Random.Range(minAngle, maxAngle));
        return rotation;
    }
    private Vector3 GetRandomPosition()
    {
        var positon = new Vector3();
        positon.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        positon.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        positon.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
        return positon;
    }
}
