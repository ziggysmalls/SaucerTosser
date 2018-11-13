using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour {

     // put the points from unity interface
     public Transform[] wayPointList;
 
     public int currentWayPoint = 0; 
     Transform targetWayPoint;
 
     public float speed = 4f;
 
     // Use this for initialization
     void Start () {
 
     }
     
     // Update is called once per frame
     void Update () {
         // check if we have somewere to walk
         if(currentWayPoint < this.wayPointList.Length)
         {
             if(targetWayPoint == null)
                 targetWayPoint = wayPointList[currentWayPoint];
             walk();
         }
     }
 
     void walk(){
        
         // move towards the target
         transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
 
         if(transform.position == targetWayPoint.position)
         {
             currentWayPoint ++ ;
            if (currentWayPoint >= wayPointList.Length)
            {
                currentWayPoint = 0;
            }
            targetWayPoint = wayPointList[currentWayPoint];
         }
        /*
       Vector3 newDir = Vector3.RotateTowards(transform.position, targetWayPoint.position, 1f,1f);
       transform.rotation = Quaternion.LookRotation(newDir);
       */
        transform.LookAt(targetWayPoint);
     } 
 }