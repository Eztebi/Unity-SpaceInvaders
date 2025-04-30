using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer escudoRenderer;
    private void Start()
    {
        SpriteRenderer escudo = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))

        {
            gameObject.SetActive(false);
            Player player = collision.collider.GetComponent<Player>();
            player.life -= 1;
            GameManager.instance.PlayerHit=true;
        }
        if (collision.collider.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Escudo"))
        {
            // collision.gameObject.SetActive(false);

            gameObject.SetActive(false);
        }
        if(collision.collider.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - .005f);
    }
}
