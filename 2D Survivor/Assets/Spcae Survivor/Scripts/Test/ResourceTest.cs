using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{
    // Resources 폴더 : 프로젝트의 Atsstes폴더 내의 Resource라는 이름의 폴더를 생성할 경우
    // 해당 폴더 내의 파일 중 유니티 리소스로 활용 가능한 (Sprite, Texture, Mesh, Prefab 등) 파일을 미리 메모리에 로드하여 런타임에서 생성할 수 있도록 하는 폴더
    // 장점 : 미리 씬에서 해당 리소스를 바인딩 하지 않아도 런타임에서 로드가 가능하다.
    //        로드 속도도 빠르다.
    // 단점 : 경우에 따라 불필요한 리소스가 메모리를 점유하고 있을 수 있으며, 개발자가 직접 제어하기가 어렵다.
    //        파일 이름을 문자열로 입력하기 때문에 수정이 어렵고, 오타가 발생하기 쉽다.
    // 빠르게 파일들을 로드하거나 활용할 수 있으므로, 작은 프로젝트나 프로토타이핑에 주로 쓰이며, 라이브 서비스 게임에서는 사용을 기피한다.
    // 대체 파일 시스템 : Asset Bundle // 예전 모바일 게임에 많이 사용됨
    // 요즘 파일 시스템 : Addressable Assets -> 레퍼런스가 많지 않고 신경써야할 설정이 많아서 아직 점유율이 높지 않다.

    // Resources 폴더를 생성하는 방법 : 경로 무관하게 Assets 폴더 어디든 생성할 수 있으며 하위 폴더를 "/"로 구분하여 경로를 참조한다.
    // 절대 경로 : Assets/Textures/Resources/PlayerSprites/player1.png
    // Resources.Load("PlayerSprites/player1") -> 확장자를 빼고 경로를 입력한다.
    public SpriteRenderer sp1;
    public SpriteRenderer sp2;

    public Texture texture;

    private void Start()
    {
        Sprite sprite1 = Resources.Load<Sprite>("Sprite 1");
        Sprite sprite2 = Resources.Load<Sprite>("Sprite 2");

        texture = Resources.Load<Texture>("Sprite 1");
        GameObject enemyResource = Resources.Load<GameObject>("Prefabs/EnemyResource");

        sp1.sprite = sprite1;
        sp2.sprite = sprite2;

        Instantiate(enemyResource);
    }
}
