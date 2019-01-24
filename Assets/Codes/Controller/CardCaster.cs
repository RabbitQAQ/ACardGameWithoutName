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
        if (cardName.Equals("FireBall"))
        {
            // Init Fireball (velocity & direction)
            GameObject cardFireBallClone =
                Instantiate(cardFireBall, this.transform.position, this.transform.rotation) as GameObject;
            cardFireBallClone.GetComponent<Rigidbody2D>()
                .AddForce((position - new Vector2(this.transform.position.x, this.transform.position.y)).normalized *
                          cardFireBallClone.GetComponent<Fireball>().flyingSpeed);
            // If not ignore collision between card and player, they will hit each other when casting
            Physics2D.IgnoreCollision(cardFireBallClone.transform.GetComponent<CircleCollider2D>(),
                GetComponent<CircleCollider2D>());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    }
}