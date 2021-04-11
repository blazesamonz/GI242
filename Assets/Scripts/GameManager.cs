using System;
using SpaceShip;
using UnityEngine;
using UnityEngine.UIElements;

namespace Manager
{
   public class GameManager : MonoBehaviour
   {
       [SerializeField] private Button startButton;
       [SerializeField] private RectTransform dialog;
       [SerializeField] private PlayerSpaceShip playerSpaceShip;
       [SerializeField] private EnemySpaceShip enemySpaceShip;
       [SerializeField] private ScoreManager scoreManager;

       public event Action OnRestarted;
       [SerializeField] private int playerSpaceShipHp;
       [SerializeField] private int playerSpaceShipMoveSpeed;
       [SerializeField] private int enemySpaceShipHp;
       [SerializeField] private int enemySpaceShipMoveSpeed;

       private void OnStartButtonClicked() 
       {
           dialog.gameObject.SetActive(false);
           StartGame();
       }

       private void StartGame()
       {
           scoreManager.Init(this);
           SpawnPlayerSpaceShip();
           SpawnEnemySpaceShip();
       }

       private void SpawnPlayerSpaceShip()
       {
           var spaceShip = Instantiate(playerSpaceShip);
           spaceShip.Init(playerSpaceShipHp, playerSpaceShipMoveSpeed);
           spaceShip.OnExploded += OnPlayerSpaceShipExploded;
       }

       private void OnPlayerSpaceShipExploded()
       {
           Restart();
       }

       private void SpawnEnemySpaceShip() 
       {
           var spaceShip = Instantiate(enemySpaceShip);
           spaceShip.Init(enemySpaceShipHp, enemySpaceShipMoveSpeed);
           spaceShip.OnExploded += OnEnemySpaceShipExploded;
       }

       private void OnEnemySpaceShipExploded() 
       {
           scoreManager.SetScore(1);
       }

      private void Restart()
      {
          dialog.gameObject.SetActive(true);
          OnRestarted?.Invoke();
      }
   }
}
