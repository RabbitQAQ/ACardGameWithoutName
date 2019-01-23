using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public float moveSpeed;
	public Rigidbody2D enemy;

	private GameObject player;

	private Vector2 movement;
	
	// Use this for initialization
	void Start () {
		player =  GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		movement = (player.transform.position - this.transform.position).normalized;
		enemy.velocity = movement * moveSpeed;
	}
}
