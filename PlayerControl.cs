using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShip
{
   public class PlayerControl : MonoBehaviour
   {
      [SerializeField] private float playerShipSpeed = 10;
      [SerializeField] private Transform enemy;


      private Vector2 movementInput = Vector2.zero;
      private ShipInputActions inputActions;
      private PlayerSpaceShip playerSpaceShip;
      [SerializeField] private SpriteRenderer spriteRenderer;
      [SerializeField] private SpriteRenderer enemySpriteRenderer;

      private float minX;
      private float maxX;
      private float minY;
      private float maxY;

      private void Awake()
      {
         InitInput();

         CreateMomentBoundary();
      }

      private void InitInput() 
      {
         inputActions = new ShipInputActions();
         inputActions.Player.Move.performed += OnMove;
         inputActions.Player.Move.canceled += OnMove;
         inputActions.Player.Fire.performed += OnFire;
         inputActions.Player.Move.actionMap.actionTriggered += OnMove;
      }

      private void OnFire(InputAction.CallbackContext obj) 
      {
         playerSpaceShip.Fire();

      }

      private void OnMove(InputAction.CallbackContext obj)
      {
         if (obj.performed)
         {
            movementInput = obj.ReadValue<Vector2>();
         }

         if (obj.canceled)
         {
            movementInput = Vector2.zero;
         }
      }

      private void CreateMomentBoundary()
      {
         var mainCamera = Camera.main;

         minX = mainCamera.ViewportToWorldPoint(mainCamera.rect.min).x + 0.5f;
         maxX = mainCamera.ViewportToWorldPoint(mainCamera.rect.max).x - 0.5f;
         minY = mainCamera.ViewportToWorldPoint(mainCamera.rect.min).y + 0.5f;
         maxY = mainCamera.ViewportToWorldPoint(mainCamera.rect.max).y - 0.5f;
      }


      private void Update()
      {
         Move();

      }

      private void Move()
      {
         var inputVelocity = movementInput * playerShipSpeed;

         var newPosition = transform.position;

         newPosition.x = transform.position.x + inputVelocity.x * Time.smoothDeltaTime;
         newPosition.y = transform.position.y + inputVelocity.y * Time.smoothDeltaTime;

         // Clamp to boundary
         newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
         newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

         transform.position = newPosition;
      }

      private void OnEnable()
      {
         inputActions.Enable();
      }
      private void OnDisable()
      {
         inputActions.Disable();
      }

      private void OnDrawGizmos()
      {

         if (IsCollided(spriteRenderer.bounds, enemySpriteRenderer.bounds))
         {
            Gizmos.color = Color.red;
         }
         else 
         {
             Gizmos.color = Color.white;
         }
         

         Gizmos.DrawWireCube(spriteRenderer.bounds.center, spriteRenderer.bounds.size);
         Gizmos.DrawWireCube(enemySpriteRenderer.bounds.center, enemySpriteRenderer.bounds.size);

      }

      private bool IsCollided(Bounds firstObj, Bounds secondObj)
      {
         return (firstObj.min.x <= secondObj.max.x && firstObj.max.x >= secondObj.min.x) &&
                (firstObj.min.y <= secondObj.max.y && firstObj.max.y >= secondObj.min.y) &&
                (firstObj.min.z <= secondObj.max.z && firstObj.max.z >= secondObj.min.z);
      }
   }
}
