using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Image Panel;
    [SerializeField] private Image GameOverText;
    [SerializeField] private Image Button;
    public GameObject Score;
    

    private void Awake(){

        if(instance == null){

            instance = this;
        }

        Time.timeScale = 1f;
    }

    public void GameOver(){

        _currentScoreText.gameObject.SetActive(false);
        _highScoreText.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(true);
        Panel.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
        Score.GetComponent<Score>().Medals();

        Time.timeScale= 0f;
    }

    public void RestarteGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }
    
}
