using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

	public GameObject movementEffect;
	public GameObject explosionEffect;
	public float explosionRadius;
	public float flyingSpeed;

	private GameObject movementEffectClone;

	private void Start()
	{
		// Init special effect, make it move with object
		movementEffectClone = Instantiate(movementEffect, this.transform.position, this.transform.rotation);
		movementEffectClone.transform.SetParent(this.transform);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Collider2D[] enemies = Physics2D.OverlapCircleAll(this.transform.position, explosionRadius);
		for (int i = 0; i < enemies.Length; i++)
		{
			if (enemies[i].tag.Equals("Enemy"))
			{
				Destroy(enemies[i].transform.gameObject);
			}
		}
//		for (int i = 0; i < enemies.Length; i++)
//		{
//			Debug.Log(enemies[i]);
//		}
		
		
		// Make explosion effect and then destroy gameobject.
		Destroy(movementEffectClone);
		GameObject explosionEffectClone = Instantiate(explosionEffect, this.transform.position, this.transform.rotation);
		Destroy(explosionEffectClone, 1);
		Destroy(this.gameObject);
	}
}
