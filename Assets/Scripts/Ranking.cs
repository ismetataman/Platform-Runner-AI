using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    public PlayerController playercontroller;
    public Vector3 relativePosition  = new Vector3 ();
    public Transform Player;  //Player Car 
    public Transform[] Target;  // AI cars
    public Text ranking;
    public GameObject CurrentRankText;

    //UI Elements
    public GameObject FinishButton;
    public GameObject CongratsText;
    public Text RankText;
    
    public void Update() 
    {
        int numberOfFrontCars = 0;
        for(int i = 0; i< 10 ; i++){
         
         Vector3 relativePosition = transform.InverseTransformPoint (Target[i].transform.position); 
        // calculates relative pos of  player car and AI cars
        if(relativePosition.z < 0)
        {
            // Debug.Log ("Front of AI ");
            ranking.text = numberOfFrontCars++.ToString();
            RankText.text = ranking.text;
            
        }
        //Debug.Log ("Current Rank ::  "+(11-numberOfFrontCars));
        ranking.text = (11-numberOfFrontCars).ToString();
        RankText.text = ranking.text;

    }
    }
    public void RestartGame()
    {
        playercontroller.gameFinished = false;
        SceneManager.LoadScene(0);
    }
    
    
}
