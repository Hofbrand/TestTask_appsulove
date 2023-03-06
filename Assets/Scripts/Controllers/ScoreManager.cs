
using System;
using Views;

namespace Controllers
{
    public class ScoreManager
    {
        public Action<int> OnScoreChanged;
        public Action<float> OnDistanceChanged;
        public Action<SaveData> OnDataChanged;

        private int _score = 0;
        private float _distance = 0;
        private ScoreView scoreView;

        public ScoreManager(ScoreView view)
        {
            scoreView = view;
            OnScoreChanged += scoreView.UpdateScore;
            OnDistanceChanged += scoreView.UpdateDistance;
            OnDistanceChanged.Invoke(0);
            OnScoreChanged.Invoke(0);
        }
        public void UpdatePoints(int points)
        {
            _score += points;
            OnScoreChanged.Invoke(_score);
            OnDataChanged.Invoke(new SaveData(_distance, _score));
        }

        public void UpdateDistance(float distance)
        {
            _distance += distance;
            OnDistanceChanged.Invoke(_distance);
            OnDataChanged.Invoke(new SaveData(_distance, _score));
        }

        public void UpdateData(SaveData data)
        {
            UpdatePoints(data.points);
            UpdateDistance(data.distance);
        }
    }
}
