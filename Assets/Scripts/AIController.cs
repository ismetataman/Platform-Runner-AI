using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public PlayerController playercontroller;

    //AI
    public NavMeshAgent agent;


    //AI Movement
    public float limitX;
    public float currentRunningSpeed;
    public Vector3 finish;

    private Rigidbody _rb;
    private Animator _anim;


    void Start() 
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

    }

    void Update()
    {
        float newX = 0f;
        newX = Mathf.Clamp(newX,-limitX,limitX); 
        if(playercontroller.gameStart == true)
        {
            
            Vector3 newPosition = new Vector3(newX,transform.position.y,transform.position.z + currentRunningSpeed * Time.deltaTime);
            transform.position = newPosition;
            _anim.SetBool("AIRun",true);
            agent.SetDestination(finish);
            if(agent.transform.position.z == finish.z)
            {
                _anim.SetBool("AIRun",false);
                Debug.Log("AI Stoped");
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
         if(other.gameObject.CompareTag("obstacle"))
        {
            //_rb.isKinematic = true;
            Debug.Log("AI Died");
        }
    }
}
