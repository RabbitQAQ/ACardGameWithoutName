using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCaster : MonoBehaviour
{
    public GameObject cardFireBall;
    public float cardSpeed;

    public void cast(Vector2 position, string cardName)
    {
        // TODO: add some if statement here to cast different cards
        // Init Fireball (velocity & direction)
        GameObject cardClone =
            Instantiate(cardFireBall, this.transform.position, this.transform.rotation) as GameObject;
        cardClone.GetComponent<Rigidbody2D>()
            .AddForce((position - new Vector2(this.transform.position.x, this.transform.position.y)).normalized *
                      cardSpeed);
        // If not ignore collision between card and player, they will hit each other when casting
        Physics2D.IgnoreCollision(cardClone.transform.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    }
}