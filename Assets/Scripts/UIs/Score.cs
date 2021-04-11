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
    public class Score : MonoBehaviour
    {
        private Text scoreTxt;
        private int currentScore;

        private void Start() => scoreTxt = GetComponent<Text>();

        public void UpdateScore()
        {
            currentScore ++;
            scoreTxt.text = currentScore.ToString();
        }

        public void ResetScore() => currentScore = 0;

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}