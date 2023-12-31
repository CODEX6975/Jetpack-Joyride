using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour{

    public float jumpforce;
    Rigidbody2D body;
  
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();                 //Reference:discussions.unity.com/t/get-rigidbody2d-component-in-script-c/134164/2
    }

    // FixedUpdate is linked with the physics engine instead of graphics engine(just googled it)
    void FixedUpdate(){

    if(gameOver){
        
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("SampleScene");          //reset game
        }
        return;
    }
    
    if(Input.GetKey(KeyCode.Space)) {                        //using 'GetKey' instead of 'GetKeyDown' as we need the player to keep moving up(learned thhis in class)
        body.velocity = Vector3.up * jumpforce;              //Reference:www.youtube.com/watch?v=j111eKN8sJw      
        }
    }
    void OnTriggerEnter2D(Collider2D other) {                
        gameOver = true;
        body.isKinematic = true;
    }
}
