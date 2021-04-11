using SpaceShip;
using UnityEngine;

namespace Damage
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private float speed = 10f;
        [SerializeField] private Rigidbody2D rb;

        public void Init()
        {
            rb = GetComponent<Rigidbody2D>();
            Move();
        }

        private void Move()
        {
            rb.velocity = Vector2.up * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.gameObject.GetComponent<IDamagable>();
            target?.TakeHit(damage);
        }
    }
}
