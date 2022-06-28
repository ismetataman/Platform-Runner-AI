using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Ranking ranking;
    public SoundManager soundmanager;
    //Player Movement
    public float currentRunningSpeed;
    public float limitX;
    public float xSpeed;
    private float _lastTouchedX;

    private Rigidbody _rb;
    private Animator _anim;
    //Checking if game started or finished
    public bool gameStart;
    public bool gameFinished;

    public GameObject TapToPlay;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        gameStart = false ;
        gameFinished = false;
        
    }


    void Update()
    {
        float newX = 0;
        float touchXDelta = 0;
        if(gameFinished == false)
        {
            if(Input.touchCount > 0) //Touch controll
            {
                gameStart = true;
                TapToPlay.SetActive(false);

                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {    
                    _lastTouchedX = Input.GetTouch(0).position.x;
                    _anim.SetBool("canRun",true);

                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    touchXDelta = 5 * (Input.GetTouch(0).position.x - _lastTouchedX) / Screen.width;
                    _lastTouchedX = Input.GetTouch(0).position.x;
                }
                
            } 
            else if(Input.GetMouseButton(0)) //Mouse controll
            {
                gameStart = true;
                TapToPlay.SetActive(false);
                touchXDelta = Input.GetAxis("Mouse X");
                _anim.SetBool("canRun",true);
            }
                newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
                newX = Mathf.Clamp(newX,-limitX,limitX); 
                if(gameStart == true)
                {
                    Vector3 newPosition = new Vector3(newX,transform.position.y,transform.position.z + currentRunningSpeed * Time.deltaTime);
                    transform.position = newPosition;
                }
        }

    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("obstacle"))
        {
            soundmanager.DeadPlayerSound();
            Vector3 startAgain = new Vector3(0,0.05457385f,-3.5f); //Restart player position
            transform.position = startAgain;
            Debug.Log("Player Died");
        }
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            gameStart = false;
            _anim.SetBool("canRun",false);
            gameFinished = true;
            soundmanager.FinishSound();
            ranking.ranking.gameObject.SetActive(false);
            ranking.CurrentRankText.SetActive(false);
            ranking.FinishButton.SetActive(true);
            ranking.CongratsText.SetActive(true);
        }
    }


}
