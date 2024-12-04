using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Spawn : MonoBehaviour
{
    //These values can be assigned and tampered with on the editor
    //GameObject the will be spawned
    //Postion where it will be spawned
    //Floats for time between spawns
    public GameObject Ant;
    public GameObject Worm;
    public GameObject Spider;
    public GameObject BugSpray;
    public Transform SpawnPosition;
    public Transform[] WormSpawnPositions = new Transform[3];
    public Transform[] BugSprayPositions = new Transform[2];
    public float timeUntilAntSpawn;
    public float timeUntilWormSpawn;
    public float timeUntilSpiderSpawn;
    public float timeUntilBugSpraySpawn;
    public float AntMin;
    public float AntMax;
    public float WormMin;
    public float WormMax;
    public float SpiderMin;
    public float SpiderMax;
    public float BugSprayMin;
    public float BugSprayMax;
    public float SpiderMaxLifetime;

    // List for grouping the spiders which spawned, and allow us to destroy the spiders at an individual level depending on their lifetime.
    public List<SpawnedSpider> SpawnedSpiders;

    public class SpawnedSpider
    {

        public SpawnedSpider(GameObject g)
        {
            gameObject = g;
            SpiderLifeTime = 0;
        }

        public GameObject gameObject;

        public float SpiderLifeTime;

        public bool Deleted = false;

        public void Update()
        {
            SpiderLifeTime += Time.deltaTime;
        }
    }

    //Used awake instead of start so it can be initialized when the scene first loads.
    void Awake()
    {
        SetTimeUntilAntSpawn();

        SetTimeUntilWormSpawn();

        SetTimeUntilSpiderSpawn();

        SetTimeUntilBugSpraySpawn();

        SpawnedSpiders = new List<SpawnedSpider>();
    }

    // If statement to check if spawn value reaches zero, allowing the next enemy to spawn
    void Update()
    {
        timeUntilAntSpawn = timeUntilAntSpawn - Time.deltaTime;
        if (timeUntilAntSpawn <= 0)
        {
            Instantiate(Ant, SpawnPosition.position, Quaternion.identity);
            SetTimeUntilAntSpawn();

        }

        timeUntilWormSpawn -= Time.deltaTime;
        if (timeUntilWormSpawn <= 0)
        {
            Instantiate(Worm, WormSpawnPositions[Random.Range(0, WormSpawnPositions.Length - 1)].position, Quaternion.identity);
            SetTimeUntilWormSpawn();
        }

        timeUntilSpiderSpawn -= Time.deltaTime;
        if (timeUntilSpiderSpawn <= 0)
        {
            SetTimeUntilSpiderSpawn();
           var spiderclone = Instantiate(Spider, SpawnPosition.position, Quaternion.identity);
            SpawnedSpiders.Add(new SpawnedSpider(spiderclone));
            
        }

        timeUntilBugSpraySpawn -= Time.deltaTime;
        if (timeUntilBugSpraySpawn <= 0)
        {
            Instantiate(BugSpray, BugSprayPositions[Random.Range(0, BugSprayPositions.Length)].position, Quaternion.identity);
            SetTimeUntilBugSpraySpawn();
        }


        // This code destroys each individual spider after a assigned max lifetime within the editor.
        foreach (SpawnedSpider s in SpawnedSpiders)
        {

            s.Update();

            if (s.SpiderLifeTime >= SpiderMaxLifetime)
            {
                GameObject.Destroy(s.gameObject);
                s.Deleted = true;
            }


        }     


        // This is a memory leak fix due to destroyed spiders.
        foreach (SpawnedSpider s in SpawnedSpiders)
        {
            if (s.Deleted)
            {
                SpawnedSpiders.Remove(s);
            }
        }

    }
    // All of these voids are to assign spawntimes for all the bugs, as well as the bugspray.
    public void SetTimeUntilAntSpawn()
    {
        timeUntilAntSpawn = Random.Range(AntMin, AntMax);
    }
    public void SetTimeUntilWormSpawn()
    {
        timeUntilWormSpawn = Random.Range(WormMin, WormMax);
    }
    public void SetTimeUntilSpiderSpawn()
    {
        timeUntilSpiderSpawn = Random.Range(SpiderMin, SpiderMax);
    }
    public void SetTimeUntilBugSpraySpawn()
    {
        timeUntilBugSpraySpawn = Random.Range(BugSprayMin, BugSprayMax);
    }
}
