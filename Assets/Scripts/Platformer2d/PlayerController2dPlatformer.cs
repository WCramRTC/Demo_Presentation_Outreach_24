using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController2dPlatformer : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 2;
    public float speed = 2;
    public float secondJump = 1.5f;
    Rigidbody rb;

    bool canJump = true;

    public bool onGround;
    public int timesJumped;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float playerX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0,0,1 * playerX * speed * Time.deltaTime));

        // Jump
        if(Input.GetButtonDown("Jump") && canJump) {
            
            if(timesJumped == 1) {
                rb.AddForce(Vector3.up * jumpForce * secondJump, ForceMode.Impulse);
            }
            else {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            timesJumped++;
            if(timesJumped == 2) canJump = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.tag == "Ground") {
            onGround = true;
            canJump = true;
            timesJumped = 0;
        }
    }    

    private void OnCollisionExit(Collision other) {
        
        onGround = false;


    }

}
