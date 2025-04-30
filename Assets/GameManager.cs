using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    //pREFABS
    [SerializeField] private GameObject crab1Prefab;
    [SerializeField] private GameObject crab2Prefab;
    [SerializeField] private GameObject octoPrefab1;
    [SerializeField] private GameObject octoPrefab2;
    [SerializeField] private GameObject squidPrefab;
    [SerializeField] private GameObject UfoPrefab;
    [SerializeField] private List<GameObject> ENEMYlist=new List<GameObject>();
    [SerializeField] public int enemyCount = 55;
    //[SerializeField] private int crabNum = 10;
   // [SerializeField] private int octoNum = 10;
    private float distanceEachRight = 0.564727f;
    private float distanceEachDown = 0.646f;
    private float currentDistanceCrab1;
    private float currentDistanceCrab2;
    private float currentDistanceOcto1;
    private float currentDistanceOcto2;


    public GameObject[,] enemigosListaBD = new GameObject[5, 11];   
    public GameObject[] enemigosPuedenDisparar = new GameObject[11];   
    public bool PlayerKill = false;
    public bool PlayerHit = false;
    public bool MoveRigth;
    public bool MoveLeft;
    public bool MoveDown;
    public bool CanMoveDown;
    public float enemyVelocity= .0003f;
    public bool EnemyKill = false;
    public bool canUFO;
    public float nextUFO;
    //ENEMYSHOOTING


   // public int LastRowCount;
    [SerializeField] private int squidNum = 10;

    private float currentDistanceSquid;

    //SCORE
    public int Score = 0;
    public int HighScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextUFO = 0;
        EnemyKill = false;
        PlayerKill = false;
        MoveLeft = true;
        for(int i=0; i<5; i++)
        {
            for(int j=0; j < 11; j++)
            {
                if (i == 0)
                {
                   
                    Vector3 newSquid = new Vector3(squidPrefab.transform.position.x + currentDistanceSquid, squidPrefab.transform.position.y, squidPrefab.transform.position.z);
                   // Instantiate(squidPrefab, newSquid, Quaternion.identity);
                   currentDistanceSquid += distanceEachRight;
                    //enemigosListaBD[i, j] = squidPrefab;
                   
                    GameObject newEnemy = Instantiate(squidPrefab, newSquid, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = false; // Activa o desactiva según corresponda
                        //Debug.Log("enemyGun Activado");
                    }
                    else
                    {
                        Debug.Log("enemyGun no encontrado en el objeto");
                    }
                    //enemy.coord=new Vector2(i, j);
                }
                else if (i == 1)
                {
                   
                    Vector3 newCrab1 = new Vector3(crab1Prefab.transform.position.x + currentDistanceCrab1, crab1Prefab.transform.position.y, crab1Prefab.transform.position.z);
                   // Instantiate(crab1Prefab, newCrab1, Quaternion.identity);
                    currentDistanceCrab1 += distanceEachRight;
                   // enemigosListaBD[i, j] = crab1Prefab;
                    GameObject newEnemy = Instantiate(crab1Prefab, newCrab1, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = false; // Activa o desactiva según corresponda
                        //Debug.LogError("enemyGun Activado");
                    }
                    else
                    {
                        Debug.LogError("enemyGun no encontrado en el objeto");
                    }
                    // enemy.coord = new Vector2(i, j);
                }
                else if(i == 2)
                {
               
                    Vector3 newCrab2 = new Vector3(crab2Prefab.transform.position.x + currentDistanceCrab2, crab2Prefab.transform.position.y, crab2Prefab.transform.position.z);
                   // Instantiate(crab2Prefab, newCrab2, Quaternion.identity);
                    currentDistanceCrab2 += distanceEachRight;
                   // enemigosListaBD[i, j] = crab2Prefab;
                    GameObject newEnemy = Instantiate(crab2Prefab, newCrab2, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = false; // Activa o desactiva según corresponda
                        //Debug.LogError("enemyGun Activado");
                    }
                    else
                    {
                        Debug.LogError("enemyGun no encontrado en el objeto");
                    }
                    // enemy.coord = new Vector2(i, j);
                }
                else if(i == 3)
                {
                
                    Vector3 newOcto1 = new Vector3(octoPrefab1.transform.position.x + currentDistanceOcto1, octoPrefab1.transform.position.y, octoPrefab1.transform.position.z);
                    //Instantiate(octoPrefab1, newOcto1, Quaternion.identity);
                    currentDistanceOcto1 += distanceEachRight;
                    GameObject newEnemy = Instantiate(octoPrefab1, newOcto1, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = false; // Activa o desactiva según corresponda
                       // Debug.Log("enemyGun Activado");
                    }
                    else
                    {
                        Debug.LogError("enemyGun no encontrado en el objeto");
                    }
                    // enemy.coord = new Vector2(i, j);

                }
                else if(i == 4)
                {
                 
                    Vector3 newOcto2 = new Vector3(octoPrefab2.transform.position.x + currentDistanceOcto2, octoPrefab2.transform.position.y, octoPrefab2.transform.position.z);
                  //  Instantiate(octoPrefab2, newOcto2, Quaternion.identity);
                    currentDistanceOcto2 += distanceEachRight;
                    GameObject newEnemy = Instantiate(octoPrefab2, newOcto2, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = true; // Activa o desactiva según corresponda
                        Debug.Log("enemyGun Activado");
                    }
                    else
                    {
                        Debug.LogError("enemyGun no encontrado en el objeto");
                    }

                }
            }
        }

    }
    public void CanShootStart()
    {

    }
    public void PuedenDispararActual()
    {
        {
            // Reinicia la lista de enemigos que pueden disparar
            for (int col = 0; col < 11; col++)
            {
                enemigosPuedenDisparar[col] = null; // Limpia la referencia de enemigos en esta columna

                // Recorre de abajo hacia arriba en la columna
                for (int row = 4; row >= 0; row--)
                {
                    if (enemigosListaBD[row, col] != null) // Si hay un enemigo en esta posición
                    {
                        enemigosPuedenDisparar[col] = enemigosListaBD[row, col];
                        break; // Encuentra el primero desde abajo
                    }
                }
            }

            // Opcional: Activar o desactivar el componente de disparo (enemyGun)
            for (int col = 0; col < 11; col++)
            {
                for (int row = 0; row < 5; row++)
                {
                    var enemigo = enemigosListaBD[row, col];
                    if (enemigo != null)
                    {
                        var gun = enemigo.GetComponent<enemyGun>();
                        if (gun != null)
                        {
                            gun.enabled = (enemigo == enemigosPuedenDisparar[col]); // Solo habilita si es el último de la columna
                        }
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void NextWave()
    {
             currentDistanceCrab1=0;
      currentDistanceCrab2=0;
      currentDistanceOcto1=0;
      currentDistanceOcto2=0;
        currentDistanceSquid = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (i == 0)
                {

                    Vector3 newSquid = new Vector3(squidPrefab.transform.position.x + currentDistanceSquid, squidPrefab.transform.position.y, squidPrefab.transform.position.z);
                    // Instantiate(squidPrefab, newSquid, Quaternion.identity);
                    currentDistanceSquid += distanceEachRight;
                    //enemigosListaBD[i, j] = squidPrefab;

                    GameObject newEnemy = Instantiate(squidPrefab, newSquid, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = false; // Activa o desactiva según corresponda
                        //Debug.Log("enemyGun Activado");
                    }
                    else
                    {
                        Debug.Log("enemyGun no encontrado en el objeto");
                    }
                    //enemy.coord=new Vector2(i, j);
                }
                else if (i == 1)
                {

                    Vector3 newCrab1 = new Vector3(crab1Prefab.transform.position.x + currentDistanceCrab1, crab1Prefab.transform.position.y, crab1Prefab.transform.position.z);
                    // Instantiate(crab1Prefab, newCrab1, Quaternion.identity);
                    currentDistanceCrab1 += distanceEachRight;
                    // enemigosListaBD[i, j] = crab1Prefab;
                    GameObject newEnemy = Instantiate(crab1Prefab, newCrab1, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = false; // Activa o desactiva según corresponda
                        //Debug.LogError("enemyGun Activado");
                    }
                    else
                    {
                        Debug.LogError("enemyGun no encontrado en el objeto");
                    }
                    // enemy.coord = new Vector2(i, j);
                }
                else if (i == 2)
                {

                    Vector3 newCrab2 = new Vector3(crab2Prefab.transform.position.x + currentDistanceCrab2, crab2Prefab.transform.position.y, crab2Prefab.transform.position.z);
                    // Instantiate(crab2Prefab, newCrab2, Quaternion.identity);
                    currentDistanceCrab2 += distanceEachRight;
                    // enemigosListaBD[i, j] = crab2Prefab;
                    GameObject newEnemy = Instantiate(crab2Prefab, newCrab2, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = false; // Activa o desactiva según corresponda
                        //Debug.LogError("enemyGun Activado");
                    }
                    else
                    {
                        Debug.LogError("enemyGun no encontrado en el objeto");
                    }
                    // enemy.coord = new Vector2(i, j);
                }
                else if (i == 3)
                {

                    Vector3 newOcto1 = new Vector3(octoPrefab1.transform.position.x + currentDistanceOcto1, octoPrefab1.transform.position.y, octoPrefab1.transform.position.z);
                    //Instantiate(octoPrefab1, newOcto1, Quaternion.identity);
                    currentDistanceOcto1 += distanceEachRight;
                    GameObject newEnemy = Instantiate(octoPrefab1, newOcto1, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = false; // Activa o desactiva según corresponda
                                             // Debug.Log("enemyGun Activado");
                    }
                    else
                    {
                        Debug.LogError("enemyGun no encontrado en el objeto");
                    }
                    // enemy.coord = new Vector2(i, j);

                }
                else if (i == 4)
                {

                    Vector3 newOcto2 = new Vector3(octoPrefab2.transform.position.x + currentDistanceOcto2, octoPrefab2.transform.position.y, octoPrefab2.transform.position.z);
                    //  Instantiate(octoPrefab2, newOcto2, Quaternion.identity);
                    currentDistanceOcto2 += distanceEachRight;
                    GameObject newEnemy = Instantiate(octoPrefab2, newOcto2, Quaternion.identity); // Instanciamos el enemigo
                    enemigosListaBD[i, j] = newEnemy; // Guardamos la referencia del enemigo en el array

                    // Ahora obtenemos los componentes del objeto instanciado
                    crabMovement enemy = newEnemy.GetComponent<crabMovement>();
                    enemyGun gun = newEnemy.GetComponent<enemyGun>();

                    if (gun != null)
                    {
                        gun.enabled = true; // Activa o desactiva según corresponda
                        Debug.Log("enemyGun Activado");
                    }
                    else
                    {
                        Debug.LogError("enemyGun no encontrado en el objeto");
                    }

                }
            }
        }
    }
    private void Update()
    {
        nextUFO += Time.deltaTime;
        SpawnUfo();
        if (enemyCount >= 53)
        {
            enemyVelocity = .0004f;
        }
        else if (enemyCount >= 50)
        {
            enemyVelocity = .0005f;
        }
        else if (enemyCount >= 45)
        {
            enemyVelocity = .0007f;
        }
        else if (enemyCount >= 40)
        {
            enemyVelocity = .0008f;
        }
        else if (enemyCount >= 35)
        {
            enemyVelocity = .0009f;
        }
        else if (enemyCount >= 30)
        {
            enemyVelocity = .001f;
        }
        else if (enemyCount >= 25)
        {
            enemyVelocity = .0011f;
        }
        else if (enemyCount >= 20)
        {
            enemyVelocity = .0012f;
        }
        else if (enemyCount >= 15)
        {
            enemyVelocity = .0013f;
        }
        else if (enemyCount >= 10)
        {
            enemyVelocity = .0013f;
        }
        else if (enemyCount >= 8)
        {
            enemyVelocity = .0015f;
        }
        else if (enemyCount >= 5)
        {
            enemyVelocity = .0019f;
        }
        else if (enemyCount >= 1)
        {
            enemyVelocity = .002f;
        }
        else if (enemyCount == 0)
        {
            StartCoroutine(NextStage());
            enemyVelocity = 0;
        }

    }
    IEnumerator NextStage()
    {
        enemyCount = 55;
        NextWave();
        yield return new WaitForSeconds(5f);

    }
    void SpawnUfo()
    {
        if (nextUFO > 10)
        {
            int rnd = Random.Range(0, 20);
            if (rnd == 5)
            {
                Vector3 newUFO = new Vector3(UfoPrefab.transform.position.x, UfoPrefab.transform.position.y, UfoPrefab.transform.position.z);
                GameObject newEnemy=Instantiate(UfoPrefab,newUFO,Quaternion.identity);
                nextUFO = 0;
            }
        }
    }
}