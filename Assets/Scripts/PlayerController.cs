using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float forceMultiplier;
    public float gravityMultiplier;
    public bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRigidbody.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
