using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

	public GameObject particleEffect;

	private void Start()
	{
		particleEffect = Instantiate(particleEffect, this.transform.position, this.transform.rotation);
		particleEffect.transform.SetParent(this.transform);
	}
	
	 
	
}
