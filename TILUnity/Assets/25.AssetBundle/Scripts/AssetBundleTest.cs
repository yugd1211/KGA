using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleTest : MonoBehaviour
{
	private void Start()
	{
		string bundlePath = "./Bundle";
		string targetBundle = "prefabs/bat";
		string assetName = "Bat";
		
		// 어셋 번들을 로드. 어셋 번들은 번들 단위로 통채로만 로드할 수 있음
		// LoadFromFile : 실제 파일이 있는 시스템 경로를 참조해야함.
		AssetBundle assetBun = AssetBundle.LoadFromFile($"{bundlePath}/{targetBundle}");

		if (assetBun == null)
		{
			Debug.LogError("어셋 번들 참조 실패!");
			return;
		}
		// 에셋 번들의 단점 : 종속성이 있는 번들을 로드하지 않으면 참조되지 않을 수 있다.
		AssetBundle.LoadFromFile($"{bundlePath}/material/monster");
		AssetBundle.LoadFromFile($"{bundlePath}/model/bat");
		// AssetBundle.LoadFromFile($"{bundlePath}/material/");
		
		GameObject batPrefab = assetBun.LoadAsset<GameObject>(assetName);
		Instantiate(batPrefab);
	}
}
