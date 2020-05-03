using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;

    public float platformSpeed;
    public float spawnPlatformPerSecond;
    float ratio;
    private float timer;

    float lastRanPos = 0;
    float randomPos;
    int platformCount;

    void Awake()
    {
        //check if File exists.
        if (!File.Exists(Application.persistentDataPath + "/GameManagerData.json"))
        {
            //save current Values into an object.
            GameManagerData nGMD = new GameManagerData();
            nGMD.spawnPlatformPerSecond = spawnPlatformPerSecond;
            nGMD.platformSpeed = platformSpeed;
            //convert the object into JSON string.
            string jsonText = JsonUtility.ToJson(nGMD);

            //create a JSON file and save the the JSON string.
            File.WriteAllText(Application.persistentDataPath + "/GameManagerData.json", jsonText);
        }else
        {
            //Phrase the JSON file and apply the values to the GameManager.
            GameManagerData gMD = JsonUtility.FromJson<GameManagerData>(File.ReadAllText(Application.persistentDataPath + "/GameManagerData.json"));
            Platform.speed = gMD.platformSpeed;
            spawnPlatformPerSecond = gMD.spawnPlatformPerSecond;
        }
        ratio = Platform.speed / spawnPlatformPerSecond;
        timer = spawnPlatformPerSecond;
        CreatePlatform();
    }

    void Update()
    {
        
        print(Platform.speed / spawnPlatformPerSecond);
        timer -= Time.deltaTime;
        if (timer <= 1-(1/ spawnPlatformPerSecond))
        {
            CreatePlatform();
            spawnPlatformPerSecond += 0.01f;
            Platform.speed = spawnPlatformPerSecond * ratio;
            print(spawnPlatformPerSecond + " <sapwnRate  speed> " + Platform.speed);

            timer = 1;
        }
    }

    void CreatePlatform()
    {
         

        randomPos = Random.Range(-3.5f, 3.5f);
        float distance = Mathf.Abs(lastRanPos - randomPos);
        if (distance < 2)
        {
            CreatePlatform();
            return;

        }
        lastRanPos = randomPos;
        platformCount++;

        GameObject newPlatform = Instantiate(platformPrefab, new Vector3(randomPos, -7, 0), Quaternion.identity);
        newPlatform.GetComponent<Platform>().playerT = GameObject.FindObjectOfType<PlayerController>().transform;

        if (ScoreManager.highScore == platformCount+1)
        {
            foreach (MeshRenderer mR in newPlatform.GetComponentsInChildren<MeshRenderer>())
            {
                mR.material.color = Color.yellow;
            }

        }

    }
}

[System.Serializable]
class GameManagerData

{
    public float platformSpeed;
    public float spawnPlatformPerSecond;
}