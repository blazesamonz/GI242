#region metadata
/**
#PRODUCT# 
by #COMPANY#
repo: #REPOSITORY#

NOTE: 
    - Unity Version (#VERSION#), .NET 4.6, C# 8.0
**/
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class RestartDialog : MonoBehaviour
    {
        public Button.ButtonClickedEvent Clicked;

        private Button restart;

        private void Awake()
        {
            restart = GetComponentInChildren<Button>();
        }

        private void Start()
        {
            Clicked.AddListener(CloseDialog);
            restart.onClick = Clicked;
        }

        public void CloseDialog()
        {
            gameObject.SetActive(false);
        }

        public void ShowDialog()
        {
            gameObject.SetActive(true);
        }
    }
}
