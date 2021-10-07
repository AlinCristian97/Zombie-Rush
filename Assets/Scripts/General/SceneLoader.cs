using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private float _waitingTime;
        private int _currentSceneIndex;

        [Header("Visual Fade Transition")]
        private Animator _transition;
        [SerializeField] private float _timeAfterEnd;
        [SerializeField] private float _timeBeforeStart;

        [Header("Audio Fade Transition")]
        [SerializeField] private float _fadeDuration;

        private void Awake()
        {
            if (GetComponentInChildren<Animator>() != null)
            {
                _transition = GetComponentInChildren<Animator>();
            }
        }
        
        public void LoadGameScene()
        {
            StartCoroutine(LoadScene("Sandbox"));
        }

        private IEnumerator Start()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (_currentSceneIndex == 0)
            {
                _transition.SetTrigger("End");
                StartCoroutine(WaitForTime());
            }
            else
            {
                // yield return StartCoroutine(AudioManager.Instance.StartFade(0.0001f, 0.0001f));
            
                // StartCoroutine(AudioManager.Instance.StartFade(_fadeDuration, 1f));

                yield return new WaitForSeconds(_timeBeforeStart);
                _transition.SetTrigger("End"); 
            }
        }

        private IEnumerator WaitForTime()
        {
            yield return new WaitForSeconds(_waitingTime);
            LoadMainMenu();
        }
    
        public void LoadMainMenu()
        {
            StartCoroutine(LoadScene("MainMenuScene"));
        }

        public void RestartScene()
        {
            StartCoroutine(LoadScene(_currentSceneIndex));
        }

        public void LoadNextScene()
        {
            if (_currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                StartCoroutine(LoadScene(_currentSceneIndex + 1));
            }
            else
            {
                Debug.Log("There are no more scenes!");
                StartCoroutine(LoadScene("MainMenuScene"));
            }
        }

        private IEnumerator LoadScene(int sceneIndex)
        {
            _transition.SetTrigger("Start");

            // StartCoroutine(AudioManager.Instance.StartFade(_fadeDuration, 0.0001f));
            yield return new WaitForSeconds(_timeAfterEnd);

            SceneManager.LoadScene(sceneIndex);
        }
        
        private IEnumerator LoadScene(string sceneName)
        {
            _transition.SetTrigger("Start");

            // StartCoroutine(AudioManager.Instance.StartFade(_fadeDuration, 0.0001f));
            yield return new WaitForSeconds(_timeAfterEnd);

            SceneManager.LoadScene(sceneName);
        }

        private IEnumerator QuitGameCoroutine()
        {
            _transition.SetTrigger("Start");

            // StartCoroutine(AudioManager.Instance.StartFade(_fadeDuration, 0.0001f));
            yield return new WaitForSeconds(_timeAfterEnd);

            Application.Quit();
        }

        public void QuitGame()
        {
            Debug.Log("Quitting game...");
            StartCoroutine(QuitGameCoroutine());
        }
    }
}
