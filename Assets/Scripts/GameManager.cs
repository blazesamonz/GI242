using System;
using System.Collections.Generic;
using SpaceShip;
using UIs;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [Header("HUD")]
        [SerializeField] private StartDialog startDialog;
        [SerializeField] private Score scoreHUD;
        [SerializeField] private RestartDialog restartDialog;

        [Header("Game Objects")]
        [SerializeField] private PlayerSpaceShip player;
        [SerializeField] List<EnemySpaceShip> enemies = new List<EnemySpaceShip>(1);

        private void Start()
        {
            restartDialog.CloseDialog();
            scoreHUD.Hide();

            startDialog.Clicked.AddListener(StartGame);
            restartDialog.Clicked.AddListener(ResetGameplay);
        }

        private void StartGame()
        {
            Debug.Log("Start the game");
            scoreHUD.Show();
            SpawnPlayerSpaceShip();
            SpawnEnemySpaceShip();
        }

        private void SpawnPlayerSpaceShip()
        {
            var spaceShip = Instantiate(player);
            spaceShip.Exploded.AddListener(OnPlayerSpaceShipExploded);
        }

        private void SpawnEnemySpaceShip()
        {
            var spaceShip = Instantiate(enemies[0]);
            spaceShip.Exploded.AddListener(OnEnemySpaceShipExploded);
        }

        private void OnPlayerSpaceShipExploded()
        {
            Restart();
        }

        private void OnEnemySpaceShipExploded()
        {
            scoreHUD.UpdateScore();
            Restart();
        }

        private void ResetGameplay()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void Restart()
        {
            restartDialog.ShowDialog();
        }
    }
}
