using SpaceShip;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private int damage;
   [SerializeField] private float speed;
   [SerializeField] private Rigidbody2D rigidbody2D;

   public void Init()
   {
      Move();
   }

   private void Awake()
   {
      Debug.Assert(rigidbody2D != null, " rigidbody2D cannot be null");
   }

   private void Move()
   {
      rigidbody2D.velocity = Vector2.up * speed;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      var target = other.gameObject.GetComponent<IDamagable>();
      target?.TakeHit(damage);
   }
}
