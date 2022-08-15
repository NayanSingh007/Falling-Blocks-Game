using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 10;
	public event System.Action OnPlayerDeath;
	
	float screenHalfwayWidth;
	
    void Start()
    {
		float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfwayWidth = Camera.main.aspect*Camera.main.orthographicSize + halfPlayerWidth;
    }

  
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
		float velocity = inputX*speed;
		transform.Translate(Vector2.right*velocity*Time.deltaTime);
		
		if(transform.position.x < -screenHalfwayWidth){
			transform.position = new Vector2(screenHalfwayWidth,transform.position.y);
		}
		else if (transform.position.x > screenHalfwayWidth){
			transform.position = new Vector2(-screenHalfwayWidth,transform.position.y);
		}
    }
	
	void OnTriggerEnter2D(Collider2D triggerCollider){
		if(triggerCollider.tag == "Falling Block"){
			if(OnPlayerDeath !=null){
				OnPlayerDeath(); 
			}
			//FindObjectOfType<GameOver>().OnGameOver();
			Destroy (gameObject);  
		}
	}
}
