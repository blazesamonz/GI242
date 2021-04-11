using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShip
{

   public class EnemyController : MonoBehaviour
   {
       [SerializeField] private float chasingThresoldDistance = 1;

       private void Update() 
       {
           MoveToPlayer();
       }

       private void MoveToPlayer() 
       {
           
       }
   }
}
