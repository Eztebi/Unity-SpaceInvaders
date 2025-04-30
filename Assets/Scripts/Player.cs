using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator animatorplayer;
    [SerializeField] public int life = 3;
    Vector2 respawn=new Vector2(-2.24099994f, -1.49300003f);
    Collider2D playerCollider;
    SpriteRenderer spriteRenderer;
    [SerializeField]public TextMeshProUGUI lifeDisplay;
    [SerializeField]GameObject lifeIMG1;
    [SerializeField]GameObject lifeIMG2;
    private bool isRunning;
    //[SerializeField] private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       playerCollider = GetComponent<Collider2D>();
        animatorplayer = GetComponent<Animator>();
        lifeDisplay.text = life.ToString();
        lifeIMG1.SetActive(true);
        lifeIMG2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        lifeDisplay.text = life.ToString();
        if (life == 2)
        {
            lifeIMG1.SetActive(false);
        }
        if (life == 1) {
            lifeIMG2.SetActive(false);
        }
        
        if (GameManager.instance.PlayerHit == true)
        {
            if (life >=1)
            {
                playerCollider.enabled = false;
                if (isRunning == false)
                {
                    StartCoroutine(PlayerHit());
                }
            }
            else {
                playerCollider.enabled=false;
                StartCoroutine(PlayerDeath());
                GameManager.instance.PlayerKill = true;
            }
        }
        
          
        
        if(GameManager.instance.PlayerHit==false)
        {
            PlayerMovement();
        }
    }

    void PlayerMovement()
    {
        float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        transform.localPosition = new Vector2(transform.localPosition.x + speed, transform.localPosition.y);
    }
    IEnumerator PlayerHit()
    {
        isRunning=true; 
        animatorplayer.SetBool("isDead", true);
        yield return new WaitForSeconds(3f);
        animatorplayer.SetBool("isDead",false);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(1f);
        transform.localPosition = respawn;
        spriteRenderer.enabled = true;
        playerCollider.enabled = true;
        GameManager.instance.PlayerHit = false;
        isRunning = false;
     
    }
    IEnumerator PlayerDeath()
    {

        animatorplayer.SetBool("isDead", true);
        yield return new WaitForSeconds(3f);
        animatorplayer.SetBool("isDead", false);
        spriteRenderer.enabled = false;
        GameManager.instance.PlayerKill= true;
    }
}
