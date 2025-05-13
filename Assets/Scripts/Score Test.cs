using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreTest : MonoBehaviour
{
    private const string KEY = "HighScore";


    public static int Load(int stage)
    {
        return PlayerPrefs.GetInt(KEY + "_" + stage, 0);
    }
    
    public static void TrySet(int stage, int newScore)
    {
        if (newScore <= Load(stage))
            return;


        PlayerPrefs.SetInt(KEY + "_" + stage, newScore);
        PlayerPrefs.Save();


    }
   

    public TextMeshProUGUI stage1;
    public TextMeshProUGUI stage2;
    public TextMeshProUGUI stage3;
    public TextMeshProUGUI stage4;
    public TextMeshProUGUI stage5;
    private void Start()
    {
        stage1.text = "STAGE 1 :" + HighScore.Load(1).ToString();
        stage2.text = "STAGE 2 :" + HighScore.Load(2).ToString();
        stage3.text = "STAGE 3 :" + HighScore.Load(3).ToString();
        stage4.text = "STAGE 4 :" + HighScore.Load(4).ToString();   
        stage4.text = "STAGE 5 :" + HighScore.Load(5).ToString();
       
    }
}
