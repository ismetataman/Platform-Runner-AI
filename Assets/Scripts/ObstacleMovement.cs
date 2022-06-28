using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
  private Vector3 dir = Vector3.left;
  public float speed;


    void Update()
    {
      transform.Translate(dir*speed*Time.deltaTime);
 
      if(transform.position.x <= -2)
      {
        dir = Vector3.right;
      }
      else if(transform.position.x >= 2)
      {
        dir = Vector3.left;
      }
    
    }

   
}
