#region metadata
/**
#PRODUCT# 
by #COMPANY#
repo: #REPOSITORY#

NOTE: 
    - Unity Version (#VERSION#), .NET 4.6, C# 8.0
**/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class StartDialog : MonoBehaviour
    {
        public Button.ButtonClickedEvent Clicked;

        private Button start;

        private void Awake()
        {
            start = GetComponentInChildren<Button>();
        }

        private void Start()
        {
            Clicked.AddListener(CloseDialog);
            start.onClick = Clicked;
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
