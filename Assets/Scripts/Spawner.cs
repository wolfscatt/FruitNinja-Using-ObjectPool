using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private Queue<Fruit> fruitQueue;
    public Fruit[] fruitPrefabs;
    public GameObject bombPrefab;
    public float bombChance = 0.05f;

    [SerializeField] private int amount = 10;
    public float spawnRate = 1f;
    private static Spawner instance;
    public static Spawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Spawner>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        fruitQueue = new Queue<Fruit>();
    }
    private void Start()
    {
        //CreateFruitPool();
        CreateFruitPool();
        Debug.Log(fruitQueue.Count);
        StartCoroutine(StartSpawning());

    }

    private void CreateFruitPool()
    {
        for (int i = 0; i < amount; i++)
        {
            var fruit = CreateRandomFruit();
            fruitQueue.Enqueue(fruit);
            fruit.gameObject.SetActive(false);
        }
    }

    private Fruit CreateRandomFruit()
    {
        var randomRange = Random.Range(0, fruitPrefabs.Length);
        var fruit = Instantiate(fruitPrefabs[randomRange], transform.position, Quaternion.identity);
        return fruit;
    }
    public void Spawn()
    {
        if (fruitQueue.Count <= 0)
        {
            CreateFruitPool();
        }
        var fruit = fruitQueue.Dequeue();
        fruit.gameObject.SetActive(true);
        if (Random.value < bombChance){
            var bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }

    }

    public void Despawn(Fruit fruit)
    {
        fruitQueue.Enqueue(fruit);
        fruit.gameObject.SetActive(false);
    }

    private IEnumerator StartSpawning()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
