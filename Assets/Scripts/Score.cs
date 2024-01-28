using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  
  public static Score instance;

  [SerializeField] private TextMeshProUGUI _currentScoreText;
  [SerializeField] private TextMeshProUGUI FScore;
  [SerializeField] private TextMeshProUGUI _highScoreText;
  [SerializeField] private Image Panel;
  [SerializeField] private Image BronzeMedal;
  [SerializeField] private Image SilverMedal;
  [SerializeField] private Image GoldMedal;
  [SerializeField] private Image PlatinumMedal;
  [SerializeField] private Image EmeraldMedal;
  [SerializeField] private Image RubiMedal;
  [SerializeField] private Image SapphireMedal;
  public GameObject bird;
  
  

  private int _score;

  private void Awake(){

    if (instance == null){

        instance = this;
    }
    
  }

  private void Start(){

    _currentScoreText.text = _score.ToString();

    _highScoreText.text= PlayerPrefs.GetInt("HighScore", 0).ToString();
    UpdateHighScore();
  }

  private void UpdateHighScore(){

    if(_score > PlayerPrefs.GetInt("HighScore")){

        PlayerPrefs.SetInt("HighScore", _score);
        _highScoreText.text = _score.ToString();
    }
  }


  public void UpdateScore(){

    _score++;
    _currentScoreText.text = _score.ToString();
    FScore.text = _score.ToString();
    UpdateHighScore();
    bird.GetComponent<FlyBehaviour>().pointSound();
  }

  public void Medals()
  {
    if (_score >= 10 && _score <25)
    {
      BronzeMedal.gameObject.SetActive(true);
    }else if (_score >= 25 && _score <50)
    {
      SilverMedal.gameObject.SetActive(true);
    }else if (_score >= 50 && _score <100)
    {
      GoldMedal.gameObject.SetActive(true);
    }else if (_score >= 100 && _score <150)
    {
      PlatinumMedal.gameObject.SetActive(true);
    }else if (_score >= 150 && _score <200)
    {
      EmeraldMedal.gameObject.SetActive(true);
    }else if (_score >= 200 && _score <250)
    {
      RubiMedal.gameObject.SetActive(true);
    }else if (_score >= 250)
    {
      SapphireMedal.gameObject.SetActive(true);
    }
  }
}
