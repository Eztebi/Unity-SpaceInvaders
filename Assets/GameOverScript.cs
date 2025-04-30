using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        GamePanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.PlayerKill == true)
        {
            GamePanel.SetActive(false);
            GameOverPanel.SetActive(true);
        }
    }
}
