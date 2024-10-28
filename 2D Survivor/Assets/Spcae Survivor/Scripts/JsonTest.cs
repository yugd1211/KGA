using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;


public class JsonTest : MonoBehaviour
{
	public EnemyDataSO testData;

	public EnemyData loadedData;

	public void Save()
	{
		string json = JsonUtility.ToJson(testData);
		// ?ㅼ젣 媛믪쓣 ?곗씠?고솕 ??臾몄옄?댁쓣 ?듯빐 ?뺤씤?????덉쓬
		// 媛앹껜???낅젰??媛믪씠 紐⑤몢 string?쇰줈 蹂???섎?濡? ?쎄퀬 ?곕뒗 怨쇱젙???⑥쑉?곸씠吏??딅떎.
		string path = $"{Application.streamingAssetsPath}/{testData.name}.json";
		File.WriteAllText(path, json);
	}

	public void Load()
	{
		// StreamingAssets 폴더 : 빌드 시 파일 포맷이 그대로 복사되어 빌드파일에 포함되어야 할 파일들을 넣어 두는 폴더
		// 포멧이 그대로 유지되고 그대로 로드되므로 빌드 후에도 값을 변경할 수 있음
		// 플레이어가 직접 값을 변경할 수 있는 것이 장점이자 단점이다.
		string path = $"{Application.streamingAssetsPath}/{testData.name}.json";
		string json = File.ReadAllText(path);
		//JsonUtility : c#?먯꽌 痍④툒?섎뒗 由ы꽣???곗씠?고??낆? ?遺遺?吏곷젹?붽? 媛?ν븯??
		// 諛곗뿴, 由ъ뒪???몄쓽 而щ젆??Hashtable, Dictinary ??? 吏곷젹?붽? 遺덇??ν븯??
		//loadedData = JsonUtility.FromJson<EnemyData>(json);
		print(loadedData.enemyName);
	}
}

// Json???듯빐 吏곷젹?? ??쭅?ы솕 ??媛앹껜
[Serializable]
public class EnemyData
{
	public string enemyName;
	public int level;
	public float hp;
	public float damage;
	public float moveSpeed;
}

