using SquadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using WaveSystem;

namespace Game
{
    public class GameRestarter : MonoBehaviour
    {
        private WaveGenerator _waveGenerator;

        private void Awake()
        {
            _waveGenerator = FindObjectOfType<WaveGenerator>();
        }

        private void OnEnable()
        {
            _waveGenerator.SquadCreated += OnSquadCreated;
        }

        private void OnDisable()
        {
            _waveGenerator.SquadCreated -= OnSquadCreated;
        }

        private void OnSquadCreated(Squad squad)
        {
            squad.SquadDestroyed += OnSquadDestroyed;
        }

        private void OnSquadDestroyed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}