using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button goToMenuButton;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    [SerializeField] private GameObject gameOverScreen;

    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindAnyObjectByType<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
