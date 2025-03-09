using Assets.Scripts.General;
using UnityEngine;
using UnityEngine.UI;

public class EndGameButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDestroy()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnRestartButtonClick()
    {
        _restartButton.interactable = false;
        _exitButton.interactable = false;
        SceneChangerSingleton.Instance.LoadScene(Scenes.Game.ToString());
    }

    private void OnExitButtonClick()
    {
        _restartButton.interactable = false;
        _exitButton.interactable = false;
        SceneChangerSingleton.Instance.LoadScene(Scenes.Menu.ToString());
    }
}
