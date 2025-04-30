using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] GameObject destroyedWall;
    [SerializeField] private SpriteRenderer escudoRenderer;
    private void Start()
    {
        SpriteRenderer escudo = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Octopus2"))
        {
           // GameManager.instance.Row5++;
            gameObject.SetActive(false);
            crabMovement enemy =collision.collider.GetComponent<crabMovement>();
            GameManager.instance.EnemyKill=true;
            GameManager.instance.Score += 10;
            enemy.StartCoroutine(enemy.Death());
            
        }
        if (collision.collider.CompareTag("Octopus1"))
        {
            //GameManager.instance.Row4++;
            gameObject.SetActive(false);
            crabMovement enemy = collision.collider.GetComponent<crabMovement>();
            GameManager.instance.EnemyKill = true;
            GameManager.instance.Score += 10;
            enemy.StartCoroutine(enemy.Death());
           
        }
        if (collision.collider.CompareTag("Crab1"))
        {
           // GameManager.instance.Row2++;
            gameObject.SetActive(false);
            crabMovement enemy = collision.collider.GetComponent<crabMovement>();
            GameManager.instance.EnemyKill = true;
            enemy.StartCoroutine(enemy.Death());
            GameManager.instance.Score += 20;
        }
        if (collision.collider.CompareTag("Crab2"))
        {
           // GameManager.instance.Row3++;
            gameObject.SetActive(false);
            crabMovement enemy = collision.collider.GetComponent<crabMovement>();
            GameManager.instance.EnemyKill = true;
            enemy.StartCoroutine(enemy.Death());
            GameManager.instance.Score += 20;
        }
        if (collision.collider.CompareTag("Squid"))
        {
           // GameManager.instance.Row1++;
            gameObject.SetActive(false);
            crabMovement enemy = collision.collider.GetComponent<crabMovement>();
            GameManager.instance.EnemyKill = true;
            enemy.StartCoroutine(enemy.Death());
            GameManager.instance.Score += 30;
        }
        if (collision.collider.CompareTag("UFO"))
        {
            // GameManager.instance.Row1++;
            int rndPoint = Random.Range(80, 150);
            gameObject.SetActive(false);
           Destroy(collision.collider);
            GameManager.instance.Score += rndPoint;
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
        if (collision.collider.CompareTag("EnemyBullet"))
        {
            gameObject.SetActive(false);
        }
    }

   
    private void Update()
    {
        transform.position=new Vector2(transform.position.x, transform.position.y+.01f);
    }
}
