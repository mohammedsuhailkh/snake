using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        instantiateFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateFood(){
        float randomX = Random.Range(-7.5f,7.5f);
        float randomY = Random.Range(-4f,4f);
        Instantiate(food,new Vector2(randomX,randomY),Quaternion.identity);
    }

    
}
