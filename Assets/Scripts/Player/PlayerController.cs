using System;
using System.Threading.Tasks;
using SpaceShip;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerSpaceShip))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerSpaceShip playerSpaceShip;
        private PlayerControls controls;

        private Vector2 direction;
        private bool isFiring;

        public readonly struct Boundary
        {
            public float MinX { get; }
            public float MaxX { get; }
            public float MinY { get; }
            public float MaxY { get; }

            public Boundary(float minX, float maxX, float minY, float maxY)
            {
                this.MinX = minX;
                this.MaxX = maxX;
                this.MinY = minY;
                this.MaxY = maxY;
            }
        }

        private Boundary boundary;

        private void Awake()
        {
            InitInput();
            CreateMomentBoundary();
        }

        private void Update() => playerSpaceShip.Move(direction, boundary);

        private void OnEnable()
        {
            controls.Enable();
        }
        private void OnDisable()
        {
            controls.Disable();
        }
        private void Start() => playerSpaceShip = GetComponent<PlayerSpaceShip>();

        private void InitInput()
        {
            controls = new PlayerControls();

            controls.Player.Move.performed += OnMove;
            controls.Player.Move.canceled += OnMove;

            controls.Player.Fire.performed += OnFire;
            controls.Player.Fire.canceled += OnFire;
        }

        private void OnFire(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed:
                    playerSpaceShip.Fire();
                    break;
            }
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed:
                    direction = ctx.ReadValue<Vector2>();
                    break;
                case InputActionPhase.Canceled:
                    direction = Vector2.zero;
                    break;
            }
        }

        private void CreateMomentBoundary()
        {
            var mainCamera = Camera.main;

            boundary = new Boundary(
                        mainCamera.ViewportToWorldPoint(mainCamera.rect.min).x + 0.5f,
                        mainCamera.ViewportToWorldPoint(mainCamera.rect.max).x - 0.5f,
                        mainCamera.ViewportToWorldPoint(mainCamera.rect.min).y + 0.5f,
                        mainCamera.ViewportToWorldPoint(mainCamera.rect.max).y - 0.5f
            );
        }
    }
}
