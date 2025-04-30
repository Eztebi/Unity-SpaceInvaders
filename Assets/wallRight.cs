using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRight : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Squid"))
        {
            GameManager.instance.MoveRigth=false;
            GameManager.instance.MoveLeft = true;
            GameManager.instance.MoveDown = true;
           
        }
        if (collision.CompareTag("Crab1"))
        {
            GameManager.instance.MoveRigth = false;
            GameManager.instance.MoveLeft = true;
            GameManager.instance.MoveDown = true;
        }
        if (collision.CompareTag("Crab2"))
        {
            GameManager.instance.MoveRigth = false;
            GameManager.instance.MoveLeft = true;
            GameManager.instance.MoveDown = true;
        }
        if (collision.CompareTag("Octopus1"))
        {
            GameManager.instance.MoveRigth = false;
            GameManager.instance.MoveLeft = true;
            GameManager.instance.MoveDown = true;
        }
    
        if (collision.CompareTag("Octopus2"))
        {
            GameManager.instance.MoveRigth = false;
            GameManager.instance.MoveLeft = true;
            GameManager.instance.MoveDown = true;
        }
    }
}
