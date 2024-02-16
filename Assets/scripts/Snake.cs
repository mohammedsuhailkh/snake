using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;
    FoodSpawner foodSpawner;
    private List<Transform> snakeSpawn;
    public Transform snakePrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed,0);
        foodSpawner = FindObjectOfType<FoodSpawner>();

        snakeSpawn = new List<Transform>();
        snakeSpawn.Add(this.transform);
      
    }

    // Update is called once per frame
    void Update()
    {
        snakeMovement();
    }

    void FixedUpdate() {
        for(int i = snakeSpawn.Count - 1; i > 0; i--){
            snakeSpawn[i].position = snakeSpawn[i - 1].position;
        }
    }

    void grow(){
        Transform Spawn = Instantiate(this.snakePrefab);
        Spawn.position = snakeSpawn[snakeSpawn.Count - 1].position;

        snakeSpawn.Add(Spawn); 
    }

    void snakeMovement(){
        if(Input.GetKey(KeyCode.UpArrow)){
            rb.velocity = new Vector2(0,moveSpeed);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            rb.velocity = new Vector2(0,-moveSpeed);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(moveSpeed,0);
        }
         if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-moveSpeed,0);
        }
        
        

    }

    void switchScene(){
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Food")){
            // Debug.Log("collided");
            grow();
            Destroy(other.gameObject);
            foodSpawner.instantiateFood();
        }

       
    }

    private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.CompareTag("Respawn")){
            rb.isKinematic = true;
            Invoke("switchScene",2f);

        }
    }
}
