using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type_map : MonoBehaviour
{
    //khai báo biến
    public GameObject[] tilePrefab;
    private Transform playerTransform;
    private float tileLength = 10.0f;
    private float spawnZ = 0.0f;

    private int TilesOnScreen = 3;
    private float safeZone = 15f;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;



    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i<TilesOnScreen;i++){
            if(i <2){
                SpawnTile(0);

            }else{
                SpawnTile();
            }
        }
    
    }
    private void SpawnTile(int prefabIndex=-1){
        GameObject go;
        if(prefabIndex == -1){
            go = Instantiate(tilePrefab[RaDomPrefabIndex()]) as GameObject;

        }else{
             go = Instantiate(tilePrefab[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position  = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void deleteTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RaDomPrefabIndex(){
        if(tilePrefab.Length <= 1){
            return 0 ;
        }
        int radomIndex = lastPrefabIndex;

        while (radomIndex == lastPrefabIndex)
        {
            radomIndex = Random.Range(0,tilePrefab.Length);
        }
        lastPrefabIndex = radomIndex;
        return radomIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if((playerTransform.position.z - safeZone) > (spawnZ - TilesOnScreen*tileLength)){
            SpawnTile();
            deleteTile();
        }
    }
}
