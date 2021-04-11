using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceShip
{
   public abstract class BaseSpaceShip : MonoBehaviour
   {
      [SerializeField] protected Bullet defaultBullet;
      [SerializeField] protected Transform gunPosition;

      public int Hp { get; protected set; }

      public float Speed { get; private set; }

      public Bullet Bullet { get; private set; }

      protected void Init(int hp, float speed, Bullet bullet)
      {
          Hp = hp;
          Speed = speed;
          Bullet = bullet;
      }

      public abstract void Fire();
   }
}
