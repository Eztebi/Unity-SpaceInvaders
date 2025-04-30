using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] List<GameObject> bulletList=new List<GameObject>();
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootingPosition;
    [SerializeField] Vector3 shootingPositionVector;
     private float timer;
    [SerializeField] private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (GameManager.instance.PlayerKill == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && timer >= cooldown)
        {
            //timer += Time.deltaTime;
           
            if (CanCreateBala() == true)
            {
                CrearBala();
            }
            else
            {
                Disparar();
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
        for (int j = 0;j<bulletList.Count;j++)
        {
            if (bulletList[j].activeSelf == false)
            {
                bulletList[j].transform.position = shootingPosition.position;
                bulletList[j].SetActive(true);
                break;
            }
           
        }
    }
}
