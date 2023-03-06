using TMPro;
using UnityEngine;

namespace Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private TextMeshProUGUI distance;
    
        public void UpdateScore(int newScore)
        {
            score.SetText(newScore.ToString());
        }

        public void UpdateDistance(float obj)
        {
            distance.SetText(obj.ToString());
        }
    }
}
