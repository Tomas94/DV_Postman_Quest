using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public  bool levelComplete=false;
    public List<GameObject> NPCspots;
    public int currentNPCSpot = 0;

    public int stampsCollected;
    public TextMeshProUGUI stampsAmountText;
    public PlayerStats player;

    public bool dashLearned = false;
    public bool attackLearned = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else Destroy(gameObject);
    }

    public void NextScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.B))
        {
            RestartGame();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        stampsAmountText.text = stampsCollected.ToString();
    }


}
