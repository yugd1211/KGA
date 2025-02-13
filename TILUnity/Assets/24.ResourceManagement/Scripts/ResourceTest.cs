using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{
    // public GameObject prefab;
    
    //
    
    private IEnumerator Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/TestPrefab");
        // ResourceRequest resourceRequest = Resources.LoadAsync<GameObject>("Prefabs/TestPrefab");

        GameObject instance = Instantiate(prefab);

        yield return new WaitForSeconds(3f);

        Material mat = Resources.Load<Material>("Materials/TestMaterial");
        
        instance.GetComponent<Renderer>().material = mat;
        yield return new WaitForSeconds(3f);
        Resources.UnloadAsset(mat);
        // Resources.UnloadAsset(prefab); // prefab은 명시적으로 언로드가 안되고
                                       // Resources.UnloadUnusedAssets();를 호출해야 언로드됨.
        // Resources.UnloadUnusedAssets(); 안쓰이는 모든 에셋을 언로드
        
        // Load 전에는 메타 정보만 로드되고 실제 에셋은 사용할 때 로드됨.
        // 
        
        // Resources 단점
        // 1. Load해두면 모든 데이터를 참조하는것과 똑같이 메모리에 잡아둔다.
        // 2. string으로 경로를 지정하기 때문에 오타 혹은 수정 시 런타임 에러가 발생함.
        
        // 어셋번들
        
        print("안쓰는 리소스 언로드가 완료되었음.");
    }

}
