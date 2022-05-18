using UnityEngine;
using UnityEngine.UI;

namespace ScoreSystem
{
    [RequireComponent(typeof(Text))]
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private string _format;
        
        private Text _score;

        private void Awake()
        {
            _score = GetComponent<Text>();
        }

        public void UpdateScore(int score)
        {
            _score.text = _format + score.ToString();
        }
        
    }
}