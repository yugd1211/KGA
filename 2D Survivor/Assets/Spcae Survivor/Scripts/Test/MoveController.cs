using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MoveController : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed = 3f;

    private void Update()
    {
        // 전처리 지시문 if : 컴파일 단계에서 정의된 심볼에 따라 일부 코드를 완전히 무시하고 컴파일함.
#if UNITY_STANDALONE_WIN
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
#elif UNITY_ANDROID
        float x = joystick.x;
        float y = joystick.y;
#endif

        Vector2 dir = new Vector2(x, y);
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    public void Move(Vector2 dir)
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime);

    }
}
