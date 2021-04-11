using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShip
{
   public class PlayerSpaceShip : BaseSpaceShip, IDamagable
   {

      public event Action OnExploded;


      public void Init(int hp, float speed)
      {
         base.Init(hp, speed, defaultBullet);
      }

      public override void Fire()
      {
         var bullet = Instantiate(defaultBullet, gunPosition.position, Quaternion.identity);
         bullet.Init();

      }

      public void TakeHit(int damage)
      {
         Hp -= damage;

         if (Hp > 0)
         {
            return;
         }

         Explode();
      }

      private void Explode()
      {
          
      }

      void IDamagable.Explode()
      {
          
      }
   }
}
