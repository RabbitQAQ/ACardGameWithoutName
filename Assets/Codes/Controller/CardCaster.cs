using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCaster : MonoBehaviour
{
    public GameObject card;
    public float cardSpeed;

    public void cast(Vector2 position, string cardName)
    {
        GameObject bulletClone = Instantiate(card, this.transform.position, this.transform.rotation) as GameObject;
        bulletClone.GetComponent<Rigidbody2D>().AddForce((position - new Vector2(this.transform.position.x, this.transform.position.y)).normalized * cardSpeed);
        Physics2D.IgnoreCollision(bulletClone.transform.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
