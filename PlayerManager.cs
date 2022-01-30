using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public float jumpForce;
    
    public bool isJumping;
    public bool isGrounded;
    public bool isClimbing;

    public Transform checkGroundLeft;
    public Transform checkGroundRight;
    // Update is called once per frame
    private float horizontalMovement;
    private float verticalMovement;

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(checkGroundLeft.position, checkGroundRight.position);
        verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            isJumping = true;
        }
            
        MovePlayer(horizontalMovement,verticalMovement);

    }
    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if(!isClimbing)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);
            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else
        {
            Vector3 targetVelocity = new Vector2(rb.velocity.x, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);
        }
        
    }
}
