using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Start game Variables
    public Button startButton;
    public GameObject startScreen;
    public bool isGameActive;
    public GameObject gameScreen;
    public Slider marbleSlider;
    public TextMeshProUGUI marbleCount;

    //End Game Variables
    public GameObject endScreen;
    public TextMeshProUGUI endTime;
    public Button restartbutton;

    //Pause Variables
    public GameObject pauseScreen;
    public Button unPauseButton;
    public Button pauseScreenResetButton;

    // Timer Variables
    public TextMeshProUGUI timerText;
    private string time;
    public float timeValue = 0;
    private float minuteValue;
    private float secondValue;

    //Spawn Variable
    private float xTopSpawn = 25.0f;
    private float xBottomSpawn = -10.0f;
    private float zTopSpawn = 18.0f;
    private float zBottomSpawn = -29.0f;
    public GameObject target;
    private  int targetCount;
    void Update()
    {
       targetCount = FindObjectsOfType<TargetControl>().Length;
       if(targetCount < 1 && isGameActive)
       {
        EndGame();
       }
       Debug.Log(time);
    }
    public void StartGame()
    {
        isGameActive = true;
        startScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
        StartCoroutine(StartTime());
        SpawnTarget();
    }
    public void EndGame()
    {
        endTime.text = "Time: " + time;
        endScreen.gameObject.SetActive(true);
        gameScreen.gameObject.SetActive(false);
        isGameActive = false;
    }
    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);
        gameScreen.gameObject.SetActive(false);
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
    }
    IEnumerator StartTime()
    {
        while(isGameActive)
        {
        yield return new WaitForSeconds(1);
        DisplayTime(timeValue += 1);
        }
    }
        public void DisplayTime(float timeValue)
    {
        minuteValue = Mathf.FloorToInt(timeValue / 60);
        secondValue = Mathf.FloorToInt(timeValue % 60);
        time = string.Format("{0:00}:{1:00}", minuteValue, secondValue);
        timerText.text = "Time: " + time;
    }
    private void SpawnTarget()
    {   
        for(int i = 0; i < marbleSlider.value;i++)
        {
        Instantiate(target,GenerateSpawnPosition(), gameObject.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = UnityEngine.Random.Range(xBottomSpawn, xTopSpawn);
        float spawnPosZ = UnityEngine.Random.Range(zBottomSpawn, zTopSpawn);
        Vector3 radomPos = new Vector3(spawnPosX,10,spawnPosZ);
        return radomPos;
    }
}
