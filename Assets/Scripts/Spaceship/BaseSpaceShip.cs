using System;
using System.Collections;
using System.Collections.Generic;
using Damage;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShip
{
    public abstract class BaseSpaceShip : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] protected Bullet bullet;
        [SerializeField] protected Transform gunPosition;

        [Space]
        public UnityEvent Exploded;

        protected int hp = 100;
        protected float speed = 10f;

        public float Speed { get => speed; }

        public abstract void Fire();
        public abstract void Move(Vector2 direction);

        public void Init(int hp, float speed)
        {
            this.hp = hp;
            this.speed = speed;
        }

        public void ChangeWeapon(Bullet bullet)
        {
            this.bullet = bullet;
        }

        public void OnExploded()
        {
            Exploded?.Invoke();
        }
    }
}
