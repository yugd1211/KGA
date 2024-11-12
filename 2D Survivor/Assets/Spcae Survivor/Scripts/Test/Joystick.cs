using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform background;
    public Transform handle;

    private const float MAX_DISTANCE = 110f; // handle max distance from background center

    public float x => handle.localPosition.x / MAX_DISTANCE;
    public float y => handle.localPosition.y / MAX_DISTANCE;

    private void Start()
    {
        background.gameObject.SetActive(false);


#if UNITY_EDITOR
        Input.simulateMouseWithTouches = true;
#endif
    }

    private void Update()
    {
        print(Input.touchCount);
        // ?怨쀭뒄??낆젾??揶쎛?館釉??遺얠뺍??곷뮞(????뽰읅??곗쨮 ??살춳?紐낅？)???怨쀭뒄 ??낆젾????됱뱽 野껋럩??
        // ?????怨쀭뒄 揶쏆뮇??筌띾슦寃?燁삳똻???

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // touchcount???????紐꾩쁽????덉뵬


            switch (touch.phase)
            {
                case TouchPhase.Began:
                    background.gameObject.SetActive(true);
                    background.position = touch.position;
                    break;
                case TouchPhase.Moved:
                    handle.position = touch.position;
                    handle.localPosition = Vector3.ClampMagnitude(handle.localPosition, MAX_DISTANCE);
                    //if (handle.localPosition.x > MAX_DISTANCE)
                    //    handle.localPosition = new Vector2(MAX_DISTANCE, handle.localPosition.y);
                    //if (handle.localPosition.x < -MAX_DISTANCE)
                    //    handle.localPosition = new Vector2(-MAX_DISTANCE, handle.localPosition.y);
                    //if (handle.localPosition.y > MAX_DISTANCE)
                    //    handle.localPosition = new Vector2(handle.localPosition.x, MAX_DISTANCE);
                    //if (handle.localPosition.y < -MAX_DISTANCE)
                    //    handle.localPosition = new Vector2(handle.localPosition.x, -MAX_DISTANCE);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    handle.localPosition = Vector3.zero;
                    background.gameObject.SetActive(false);
                    break;
            }

        }
    }
}
