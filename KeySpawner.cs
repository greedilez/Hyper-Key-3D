using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeySpawner : MonoBehaviour 
{
    [SerializeField] private Transform keySpawnOrigin;

    [SerializeField] private GameObject keyPrefab;

    [SerializeField] private Vector3 defaultSpawnOriginPosition;

    [SerializeField] private GameObject platformPrefab;

    private float xSpawnIndent;

    private Quaternion keyRotation;

    private Vector3 platformSpawnPosition;

    private int keyStackLength = 2;

    private void Awake(){
        InitializeFields();
        SpawnKeyStack();
        SetRightKey();
    }

    private void Update(){
        SyncCameraWithKeySpawnOrigin();
    }

    private protected void InitializeFields(){
        platformSpawnPosition = GameObject.Find("Platform").transform.position;
        keyRotation = Quaternion.Euler(-44f, 0, 0);
        xSpawnIndent = keySpawnOrigin.position.x;
    }

    private protected void SpawnKeyStack(){
        keyStackLength = Random.Range(2, 4);
        for (int i = 0; i < keyStackLength; i++)
        {
            if(keyStackLength > 2){
                keySpawnOrigin.position -= new Vector3(0.1f, 0, 0); // Alightment to center
            }
            SpawnObject(new Vector3(xSpawnIndent, keySpawnOrigin.position.y, keySpawnOrigin.position.z), keyRotation, keyPrefab, keySpawnOrigin);
            xSpawnIndent += 0.22f;
        }
    }

    public void SpawnKeyStackForNextStep(){
        ClearKeysOnScene();
        MoveSpawnOriginToNextStep();
        SpawnKeyStack();
        SetRightKey();
    }

    public void MoveSpawnOriginToNextStep(){
        keySpawnOrigin.position = new Vector3(defaultSpawnOriginPosition.x, keySpawnOrigin.position.y, keySpawnOrigin.position.z);
        keySpawnOrigin.position += new Vector3(0, 0, 25);
        xSpawnIndent = keySpawnOrigin.position.x;
    }

    public void ReturnToMenuOnLose() => StartCoroutine(BackToMenuDelay());

    private protected IEnumerator BackToMenuDelay(){
        yield return new WaitForSeconds(2.75f);{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void OpenCurrentDoor(){
        foreach (var door in FindObjectsOfType<Door>())
        {
            door.OpenDoor();
        }
    }

    public void WrongOpenForCurrentDoor(){
        foreach (var door in FindObjectsOfType<Door>())
        {
            door.WrongOpen();
        }
    }

    private protected void SetRightKey(){
        GameObject[] keys = GetObjectsOnScene("Key");
        int rightKeyIndex = Random.Range(0, keys.Length);
        keys[rightKeyIndex].GetComponent<Key>().CanOpenDoor = true;
        Debug.Log($"Right key index is {rightKeyIndex}");
    }

    private protected void ClearKeysOnScene(){
        foreach (var key in GetObjectsOnScene("Key"))
        {
            DestroyImmediate(key);
        }
    }

    public void SyncCameraWithKeySpawnOrigin(){
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, keySpawnOrigin.position.z - 1.5f);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, Time.smoothDeltaTime * 8f);
    }

    public GameObject[] GetObjectsOnScene(string tag){
        GameObject[] objectsOnScene = GameObject.FindGameObjectsWithTag(tag);
        return objectsOnScene;
    }

    public void SpawnPlatformForNextStep(){
        platformSpawnPosition += new Vector3(0, 0, 25);
        SpawnObject(platformSpawnPosition, Quaternion.identity, platformPrefab, null);
    }

    private protected void SpawnObject(Vector3 position, Quaternion rotation, GameObject objectToSpawn, Transform parent) => Instantiate(objectToSpawn, position, rotation, parent);
}
