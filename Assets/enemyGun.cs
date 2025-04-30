using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGun : MonoBehaviour
{
    [SerializeField] List<GameObject> bulletList = new List<GameObject>();
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootingPosition;
    private bool canShoot=true;
    private float timer;
    [SerializeField] private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        timer =0;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.instance.PlayerKill == true || GameManager.instance.EnemyKill == true || GameManager.instance.PlayerHit==true)
        {
            return;
        }
        timer += Time.deltaTime;
        //timer += Time.deltaTime;
        if (timer > 1f)
        {
            
            int randomInt = Random.Range(1, 10);
            if (randomInt == 3 )
            {
               
                if (CanCreateBala() == true)
                {
                    CrearBala();
                }
                else
                {
                    Disparar();
                }
            }
            timer = 0;
        }
        

    }


    bool CanCreateBala()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (bulletList[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }
    private void CrearBala()
    {
        GameObject bala = Instantiate(bulletPrefab);
        bala.transform.position = shootingPosition.position;

        bulletList.Add(bala);

        Disparar();
    }

    private void Disparar()
    {
        for (int j = 0; j < bulletList.Count; j++)
        {
            if (bulletList[j].activeSelf == false)
            {
                bulletList[j].transform.position = shootingPosition.position;
                bulletList[j].SetActive(true);
                canShoot = false;
                StartCoroutine(WaitBullet());
                
                //timer = 0;
                
                break;
            }

        }
    }
    IEnumerator WaitBullet()
    {
        yield return new WaitForSeconds(1f);
        canShoot=true;
    }
}


