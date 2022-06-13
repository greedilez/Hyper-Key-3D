using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyCountText;

    private static int moneyCount = 0;

    public static int MoneyCount{ get => moneyCount; }

    private bool canStartGame = true;

    private void Awake() => LoadParameters();

    public static void LoadParameters(){
        if(PlayerPrefs.HasKey("MoneyCount")) moneyCount = PlayerPrefs.GetInt("MoneyCount", 0);
    }

    public static void SaveParameters(){
        if(PlayerPrefs.HasKey("MoneyCount")) PlayerPrefs.SetInt("MoneyCount", moneyCount);
    }

    private void Update(){
        UpdateMoneyText();
        CheckForTapToStart();
    }

    private protected void CheckForTapToStart(){
        if(Input.touchCount > 0){
            if(canStartGame){
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began) LoadGame();
            }
        }
    }

    private protected void LoadGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    private protected void UpdateMoneyText() => moneyCountText.text = $"Money: {moneyCount}$";
}
