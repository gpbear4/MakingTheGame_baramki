using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnim;
    public ParticleSystem obstacleExplosion;
    public ParticleSystem dirtSplatt;
    public AudioClip jumpSound;
    public AudioClip explosionSound;
    private AudioSource audioSource;
    public float forceMultiplier;
    public float gravityMultiplier;
    public bool isOnGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
            isOnGround = false;
            dirtSplatt.Stop();
            playerAnim.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // game over if the player hits an obstacle
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            dirtSplatt.Stop();
            gameOver = true;
            obstacleExplosion.Play();
            isOnGround = false;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(explosionSound, 1.0f);
        }
        // set on ground state to true if we hit the ground
        else if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtSplatt.Play();
        }

    }
}
