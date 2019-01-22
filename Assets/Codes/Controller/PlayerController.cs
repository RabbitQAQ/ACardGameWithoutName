using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public GameObject bullet;
	public float bulletSpeed;

	public float moveSpeed;
	public Rigidbody2D player;
	private Vector2 movement;

	private void Start()
	{
		
	}

	private void FixedUpdate()
	{
		float inputY = Input.GetAxis("Vertical") * moveSpeed;
		float inputX = Input.GetAxis("Horizontal") * moveSpeed;
		movement = new Vector2(inputX, inputY);
		player.velocity = movement * moveSpeed;
	}

}
