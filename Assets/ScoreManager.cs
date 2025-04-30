using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Referencia al TextMesh Pro
    [SerializeField] private TextMeshProUGUI HiScoreText; // Referencia al TextMesh Pro
    private int currentScore = 0; // Puntaje inicial
    private int maxScore;   
    private void Start()
    {
        UpdateScoreText(); // Actualiza el texto al inicio
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }

    public void AddScore(int amount)
    {
        currentScore += amount; // Incrementa el puntaje
        UpdateScoreText(); // Actualiza el texto
    }
    private void UpdateMaxScore()
    {
       HiScoreText.text =  maxScore.ToString("D4");
    }
    private void UpdateScoreText()
    {
        // Actualiza el texto con ceros iniciales (formato "D4" = 4 dígitos)
        scoreText.text = currentScore.ToString("D4");
    }
    private void Update()
    {
        currentScore = GameManager.instance.Score;
        UpdateScoreText();
        UpdateMaxScore();
        //Cambiar maxScore
        if (currentScore > maxScore)
        {
            maxScore = currentScore;
            // Guardar el nuevo maxScore en PlayerPrefs
            PlayerPrefs.SetInt("MaxScore", maxScore);
            PlayerPrefs.Save();
        }
    }
}