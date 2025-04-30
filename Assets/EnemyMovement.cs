using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class crabMovement : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    public Vector2 coord;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.EnemyKill == true || GameManager.instance.PlayerKill==true || GameManager.instance.PlayerHit == true)
        {
            StartCoroutine(WaitForKill());
            return;
        }
        if (GameManager.instance.MoveDown == true) 
        {
        StartCoroutine(MoveDown());
        }
        else if (GameManager.instance.MoveRigth == true)
        {
            StartCoroutine(MovementRight());
        }
        else
        {
            StartCoroutine(MovementLeft());
        }


    }

    private IEnumerator MovementRight()
    {
        if (enemyAnimator.GetBool("isMoving") == false)
        {
            enemyAnimator.SetBool("isMoving", true);
        }
        else
        {
            enemyAnimator.SetBool("isMoving", false);
        }
        yield return new WaitForSeconds(.1f);

        Vector3 mov = new Vector3(gameObject.transform.position.x + GameManager.instance.enemyVelocity, gameObject.transform.position.y, gameObject.transform.position.z);
        transform.position = mov;
    }
    private IEnumerator MovementLeft()
    {
        if (enemyAnimator.GetBool("isMoving") == false)
        {
            enemyAnimator.SetBool("isMoving", true);
        }
        else
        {
            enemyAnimator.SetBool("isMoving", false);
        }
        yield return new WaitForSeconds(.1f);

        Vector3 mov = new Vector3(gameObject.transform.position.x - GameManager.instance.enemyVelocity, gameObject.transform.position.y, gameObject.transform.position.z);
        transform.position = mov;
    }
    private IEnumerator MoveDown()
    {
        yield return new WaitForSeconds(.1f);
        Vector3 mov = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y-.002f, gameObject.transform.position.z);
        transform.position = mov;
        GameManager.instance.MoveDown=false;
    }
    public IEnumerator Death()
    {
        GameManager.instance.enemyCount-=1;
        enemyAnimator.SetBool("isDead", true);
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
        GameManager.instance.PuedenDispararActual();
        Debug.Log("morir");
    }
    public IEnumerator WaitForKill()
    {

        yield return new WaitForSeconds(.5f);
        GameManager.instance.EnemyKill = false;
        GameManager.instance.PuedenDispararActual();
    }
}
//}: MonoBehaviour
//{
//    [SerializeField] private Animator enemyAnimator;
//    [SerializeField] private GameObject projectilePrefab;
//    [SerializeField] private float shootDelay = 2f;
//    private bool canShoot = true;
//    //[SerializeField]private GameObject shootingPoint;
//    // Start is called before the first frame update
//    void Start()
//{
//        //shootingPoint=GetComponentInChildren<GameObject>();
//      enemyAnimator=GetComponent<Animator>();
//}

//    // Update is called once per frame
//    void Update()
//    {
//        if (GameManager.instance.EnemyKill == true)
//        {
//            StartCoroutine(WaitForKill());
//            return;
//        }
//        if (GameManager.instance.PlayerKill == true)
//        {
//            return;
//        }

//        if (GameManager.instance.MoveRigth == true)
//        {
//            StartCoroutine(MovementRight());
//        }
//        else
//        {
//            StartCoroutine(MovementLeft());
//        }
//    }

//    public void Shoot()
//    {
//        if (canShoot)
//        {
//            // Disparo el proyectil
//            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
//            canShoot = false;

//            // Esperar el intervalo de tiempo antes de poder disparar nuevamente
//            StartCoroutine(ResetShoot());
//        }
//    }

//    private IEnumerator ResetShoot()
//    {
//        yield return new WaitForSeconds(shootDelay);
//        canShoot = true;
//    }

//    private IEnumerator MovementRight()
//    {
//        if (enemyAnimator.GetBool("isMoving") == false)
//        {
//            enemyAnimator.SetBool("isMoving", true);
//        }
//        else
//        {
//            enemyAnimator.SetBool("isMoving", false);
//        }
//        yield return new WaitForSeconds(.1f);
//        Vector3 mov = new Vector3(transform.position.x + .0003f, transform.position.y, transform.position.z);
//        transform.position = mov;
//    }

//    private IEnumerator MovementLeft()
//    {
//        if (enemyAnimator.GetBool("isMoving") == false)
//        {
//            enemyAnimator.SetBool("isMoving", true);
//        }
//        else
//        {
//            enemyAnimator.SetBool("isMoving", false);
//        }
//        yield return new WaitForSeconds(.1f);
//        Vector3 mov = new Vector3(transform.position.x - .0003f, transform.position.y, transform.position.z);
//        transform.position = mov;
//    }

//    public IEnumerator Death()
//    {
//        enemyAnimator.SetBool("isDead", true);
//        yield return new WaitForSeconds(.5f);
//        Destroy(this.gameObject);
//    }

//    public IEnumerator WaitForKill()
//    {
//        yield return new WaitForSeconds(.5f);
//        GameManager.instance.EnemyKill = false;
//    }
//}