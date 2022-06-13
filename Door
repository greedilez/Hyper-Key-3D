using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Door : MonoBehaviour
{
    [SerializeField] private Material[] doorMaterials = new Material[5];

    [SerializeField] private GameObject doorPanel;

    private Animator animator;

    private AudioSource source;

    [SerializeField] private AudioClip RightKeyDoorSound, WrongKeyDoorSound;

    private bool isDoorOpened = false;

    private void Awake(){
        isDoorOpened = false;
        PaintRandomColor();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void LateUpdate() => DestroyUselessPlatform();

    private protected void PaintRandomColor(){
        int colorIndex = Random.Range(0, doorMaterials.Length);
        doorPanel.GetComponent<MeshRenderer>().material = doorMaterials[colorIndex];
    }

    public void DestroyUselessPlatform(){
        if(isDoorOpened){
            Destroy(transform.parent.parent.gameObject, 5f);
        }
    }

    public void OpenDoor(){
        if(!isDoorOpened){
            Debug.Log("Door opening...");
            animator.SetBool("Open", true);
            source.PlayOneShot(RightKeyDoorSound);
            isDoorOpened = true;
        }
    }

    public void WrongOpen(){
        if(!isDoorOpened){
            animator.SetTrigger("WrongKey");
            source.PlayOneShot(WrongKeyDoorSound);
            Debug.LogWarning("Game over!");
            isDoorOpened = true;
        }
    }
}
