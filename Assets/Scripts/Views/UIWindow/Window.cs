using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIWindow
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        
        [SerializeField] private Image _imageLeft;
        [SerializeField] private Image _imageRight;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestart);
            _exitButton.onClick.AddListener(OnExit);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }

        public void Show(Sprite player1, Sprite player2)
        {
            _imageLeft.sprite = player1;
            _imageRight.sprite = player2;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private void OnExit() => 
            Application.Quit();

        private void OnRestart() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}