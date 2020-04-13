using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnim;
    public float forceMultiplier;
    public float gravityMultiplier;
    public bool isOnGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // game over if the player hits an obstacle
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            isOnGround = false;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
        // set on ground state to true if we hit the ground
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

    }
}
