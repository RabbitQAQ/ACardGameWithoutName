using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D player;
    private Vector2 movement;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        // Movement control
        float inputY = Input.GetAxis("Vertical") * moveSpeed;
        float inputX = Input.GetAxis("Horizontal") * moveSpeed;
        movement = new Vector2(inputX, inputY);
        player.velocity = movement * moveSpeed;
    }
}