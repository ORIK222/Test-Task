using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private DeathPanel _deathPanel;
    [SerializeField] private Character _player;

    private void OnEnable()
    {
        _player.DeadEvent += EnableDeathPanel;
    }
    private void OnDisable()
    {
        _player.DeadEvent -= EnableDeathPanel;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void EnableDeathPanel()
    {
        _deathPanel.gameObject.SetActive(true);
    }
}
