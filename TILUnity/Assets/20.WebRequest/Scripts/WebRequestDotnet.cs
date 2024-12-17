using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WebRequestDotnet : MonoBehaviour
{
	public string imageUrl = "https://picsum.photos/500";
	public Image targetImage;
	public RawImage targetRawImage;

	private async void Start()
	{
		await GetTexture(imageUrl);
		print("GetTexture 호출했음");
	}

	private async Task GetTexture(string url)
	{
		using (HttpClient client = new HttpClient())
		{
			
			// 비동기로 이미지를 받아오기 위해 Task 객체를 받아옴
			// task 객체를 await 키워드를 통해 비동기로 대기
			// await 키워드가 있어서 여기서 리턴이 반환 될 때까지 비동기 상태로 대기
			byte[] response = await client.GetByteArrayAsync(url);

			Texture2D texture = new Texture2D(1, 1);
			texture.LoadImage(response);
			targetRawImage.texture = texture;
			print("Texture Download 완료");

		}
	}	
	// private void Start()
	// {
	// 	GetTexture(imageUrl);
	// 	print("GetTexture 호출했음");
	// }
	//
	// private async void GetTexture(string url)
	// {
	// 	using (HttpClient client = new HttpClient())
	// 	{
	// 		
	// 		// 비동기로 이미지를 받아오기 위해 Task 객체를 받아옴
	// 		// task 객체를 await 키워드를 통해 비동기로 대기
	// 		// await 키워드가 있어서 여기서 리턴이 반환 될 때까지 비동기 상태로 대기
	// 		byte[] response = await client.GetByteArrayAsync(url);
	//
	// 		Texture2D texture = new Texture2D(1, 1);
	// 		texture.LoadImage(response);
	// 		targetRawImage.texture = texture;
	// 		print("Texture Download 완료");
	//
	// 	}
	// }
	
}
