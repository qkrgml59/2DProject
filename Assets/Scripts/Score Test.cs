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
   

   
    private void Start()
    {
        
       
    }
}
