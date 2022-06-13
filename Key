using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private bool canOpenDoor = false;
    
    public bool CanOpenDoor{ get => canOpenDoor; set => canOpenDoor = value; }

    [SerializeField] private Material[] keyMaterials = new Material[5];

    private void Start() => SelectRandomColor();

    private protected void SelectRandomColor(){
        int randomIndex = Random.Range(0, keyMaterials.Length);
        GetComponent<MeshRenderer>().material = keyMaterials[randomIndex];
    }
}
