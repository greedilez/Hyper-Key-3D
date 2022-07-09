using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winOrLoseText, levelNumberText;

    public TextMeshProUGUI LevelNumberText{ get => levelNumberText; }

    public void MoveTextOnWin(){
        winOrLoseText.text = "Win! Next level!";
        MoveTextOnEvent();
    }

    public void MoveTextOnLose(){
        winOrLoseText.text = "Lose! Move to menu!";
        MoveTextOnEvent();
    }

    public void MoveTextOnEvent() => winOrLoseText.GetComponent<Animator>().SetTrigger("OnWinOrLoseMove");
}
