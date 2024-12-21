using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject firecrackerPrefab;
    public Transform postSpawn;

    private void Start()
    {
        Invoke(nameof(HandleFire), 2);
      
    }

   

 
    private void HandleFire()
    {
        var tempObj = Instantiate(firecrackerPrefab);
        tempObj.transform.position = postSpawn.position;
       
    }
}
