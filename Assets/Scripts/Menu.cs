using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private RectTransform _menuPanel;
    [SerializeField] private RectTransform _hudPanel;
    [SerializeField] private FollowCamera _followCamera;

    private void Start()
    {
        _hudPanel.gameObject.SetActive(false);
    }
    public void Play()
    {
        _hudPanel.gameObject.SetActive(true);
        _menuPanel.gameObject.SetActive(false);
        _followCamera.GameStart = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
