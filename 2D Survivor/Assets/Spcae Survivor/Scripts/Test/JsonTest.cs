using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;


public class JsonTest : MonoBehaviour
{
    public EnemyDataSO testData;

    public EnemyDataSO loadedData;

    public void Save()
    {
        string json = JsonUtility.ToJson(testData);
        string path = $"{Application.streamingAssetsPath}/{testData.name}.json";
        File.WriteAllText(path, json);
    }

    public void Load()
    {
        // StreamingAssets : 빌드후에도 직렬화하지않고 파일을 읽을 수 있는 폴더
        // 그만큼 유저가 변경할수도있기때문에 보안에 취약하다.
        string path = $"{Application.streamingAssetsPath}/{testData.name}.json";
        string json = File.ReadAllText(path);
        loadedData = JsonConvert.DeserializeObject<EnemyDataSO>(json);
        print(loadedData.enemyName);
    }
}

[Serializable]
public class EnemyData
{
    public string enemyName;
    public int level;
    public float hp;
    public float damage;
    public float moveSpeed;
}

