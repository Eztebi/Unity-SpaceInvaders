using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mov = new Vector3(gameObject.transform.position.x - 0.0015f, gameObject.transform.position.y, gameObject.transform.position.z);
        transform.position = mov;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mov = new Vector3(gameObject.transform.position.x - 0.0015f, gameObject.transform.position.y, gameObject.transform.position.z);
        transform.position = mov;
    }
}
