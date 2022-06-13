using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNumberMover : MonoBehaviour
{
    private static int level = 1;

    public static int Level{ get => level; }

    private GUI gui;

    private void Awake(){
        level = PlayerPrefs.GetInt("level", 1);
        gui = FindObjectOfType<GUI>();
    }

    private void LateUpdate(){
        gui.LevelNumberText.text = $"Level: {level.ToString()}";
    }

    public void ChangeLevelStateOnWin(){
        level++;
        SaveLevelState();
    }

    private protected void SaveLevelState() => PlayerPrefs.SetInt("level", level);
}
