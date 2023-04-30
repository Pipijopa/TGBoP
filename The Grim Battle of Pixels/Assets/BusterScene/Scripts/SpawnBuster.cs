using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuster : MonoBehaviour
{
    [SerializeField] GameObject[] arrayBuster = new GameObject[4];
    private GameObject busterObject = null, buster = null;
    private GameObject player1, player2;
    private SpawnHeroes spawnHeroes;
    private System.Random rnd = new System.Random();
    private int nForRandom = 0;
    private int timeSpawn = 10;
    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        player1 = GameObject.Find(spawnHeroes.GetNamePl1());
        player2 = GameObject.Find(spawnHeroes.GetNamePl2());
        Invoke("Spawn", timeSpawn);
    }

    private void Spawn()
    {
        if (busterObject != null)
        {
            Destroy(busterObject);
        }

        nForRandom = rnd.Next() % 4;
        buster = arrayBuster[nForRandom];

        nForRandom = rnd.Next() % 6;
        switch (nForRandom)
        {
            case 0:
                busterObject = Instantiate(buster, new Vector2(-2, -4.9f), Quaternion.identity);
                break;
            case 1:
                busterObject = Instantiate(buster, new Vector2(-7.87f, 1.77f), Quaternion.identity);
                break;
            case 2:
                busterObject = Instantiate(buster, new Vector2(7.87f, 1.77f), Quaternion.identity);
                break;
            case 3:
                busterObject = Instantiate(buster, new Vector2(0, -1.2f), Quaternion.identity);
                break;
            case 4:
                busterObject = Instantiate(buster, new Vector2(11, -4.9f), Quaternion.identity);
                break;
            case 5:
                busterObject = Instantiate(buster, new Vector2(-10.475f, -4.9f), Quaternion.identity);
                break;
        }


        Invoke("Spawn", timeSpawn);
    }
}
