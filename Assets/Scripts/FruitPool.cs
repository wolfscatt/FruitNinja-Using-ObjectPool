using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FruitPool : MonoBehaviour
{
    public ObjectPool<Fruit> fruitPool;
    [SerializeField] private Fruit[] fruitPrefabs;
    public int minAmountPool = 10;
    public int maxAmountPool = 20;

    private void Start() {
        fruitPool = new ObjectPool<Fruit>(
            CreateRandomFruit, 
            OnGetFruit, 
            OnPutBackPool,
            OnDestroyFruit, 
            false , 
            minAmountPool, 
            maxAmountPool);
    }
    private Fruit CreateRandomFruit(){
        // Rastgele bir meyve seç
        var randomRange = Random.Range(0, fruitPrefabs.Length);

        // Seçilen meyveyi oluştur
        var fruit = Instantiate(fruitPrefabs[randomRange]);
       
        return fruit;
    }
    private void OnDestroyFruit(Fruit fruit){
        Destroy(fruit);
    }
    private void OnGetFruit(Fruit fruit){
        fruit.SetActive(true)
        .SetTransformParent(transform)
        .SetLocalPosition(transform.position)
        .SetRigidbodyVelocity(Vector3.zero);
    }
    private void OnPutBackPool(Fruit fruit){
        fruit.SetActive(false)
        .SetTransformParent(transform)
        .SetLocalPosition(transform.position)
        .SetRigidbodyVelocity(Vector3.zero);
    }
}
