using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private TextMeshProUGUI distance;
    
        public void UpdateScore(int newScore)
        {
            score.SetText(newScore.ToString());
        }
    }
}
