using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabScript : MonoBehaviour
{
    [SerializeField] private GameObject crabPrefab;
    [SerializeField] private int crabNum=11;
    [SerializeField] private float distanceEach = 0.564727f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < crabNum; i++)
        {
            Vector3 newCrab = new Vector3(crabPrefab.transform.position.x + distanceEach, crabPrefab.transform.position.y, crabPrefab.transform.position.z);
            Instantiate(crabPrefab,newCrab, Quaternion.identity);
            distanceEach += distanceEach;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
