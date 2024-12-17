using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WebRequestTest : MonoBehaviour
{
	public string imageUrl = "https://picsum.photos/500";
	public Image targetImage;
	public RawImage targetRawImage;

	private void Start()
	{
		_ = StartCoroutine(GetWebTexture(imageUrl));
	}

	IEnumerator GetWebTexture(string url)
	{
		// http로 웹 요청(Request)을 보낼 객체 생성
		UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
		
		// 코루틴을 통해 웹으로부터 요청에 대한 응답(Response)을 받을 때 까지 비동기로 대기하는 객체를 받아옴
		UnityWebRequestAsyncOperation operation = www.SendWebRequest();
		yield return operation;
		
		if (www.result != UnityWebRequest.Result.Success)
		{
			Debug.LogError($"HTTP 통신 실패 : {www.error}");
		}
		else
		{
			print($"HTTP 통신 성공 : {www.downloadHandler.text}");

			// 받아온 응답(Response)을 텍스쳐로 변환
			Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
			// 텍스처를 런타임에서 Sprite로 변환
			Sprite sprite = Sprite.Create(
				(Texture2D)texture, 
				new Rect(0, 0, texture.width, texture.height), 
				new Vector2(0.5f, 0.5f));
			// image의 sprite 교체
			targetImage.sprite = sprite;
			
			targetRawImage.texture = texture;
		}
	}
}
