using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySelecter : MonoBehaviour
{
    [SerializeField] private float rayDistance = 5f;

    private KeySpawner spawner;

    private GUI gui;

    private LevelNumberMover levelNumberMover;

    private bool isLose = false;

    private void Awake(){
        spawner = Camera.main.GetComponent<KeySpawner>();
        gui = FindObjectOfType<GUI>();
        levelNumberMover = FindObjectOfType<LevelNumberMover>();
    }

    private void Update(){
        if(Input.touchCount > 0 && !isLose){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                KeyRaycastDetection(touch);
            }
        }
    }

    private protected void KeyRaycastDetection(Touch touch){
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green, rayDistance);
        if(Physics.Raycast(ray, out hit, rayDistance)){
            if(hit.collider.tag == "Key"){
                DetectIfKeyCanOpenDoor(hit.collider);
            }
        }
    }

    private protected void DetectIfKeyCanOpenDoor(Collider keyCol){
        if(keyCol.GetComponent<Key>().CanOpenDoor){
            Win();
        }
        else{
            Lose();
        }
    }

    private protected void Win(){
        Debug.Log("Win!");
        levelNumberMover.ChangeLevelStateOnWin();
        spawner.OpenCurrentDoor();
        spawner.SpawnKeyStackForNextStep();
        spawner.SpawnPlatformForNextStep();
        gui.MoveTextOnWin();
    }

    private protected void Lose(){
        isLose = true;
        Debug.Log("Lose.");
        spawner.WrongOpenForCurrentDoor();
        spawner.ReturnToMenuOnLose();
        gui.MoveTextOnLose();
    }
}
