using System;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ExtensionMethod : MonoBehaviour
{
	// 확장 메서드 : 기존 클래스의 기능을 확장할 수 있는 기능
	// 특정 요소를 파라미터 대신 .앞에 참조하여 마치 해당 객체가 지닌 메소디인것 처럼 사용하는 방법

	private void Start()
	{
		StringHelper.StaticMethod();
		string a = StringHelper.Append("나", "너");
		print(a);
		string b = "나".Append("너");
		print(b);
		DateTime today = DateTime.Now;
		// DateTime nextWeek = DateTime.Parse("2024-11-2544");
		DateTime nextWeek = DateTime.Parse("2024년 11월 25일");
		// print(today.To(nextWeek));
	}
}

// static 클래스 : 따로 객체를 생성하지 않아도 data영역에 변수와 메서드의 정의를 지니고 있는 클래스
public static class StringHelper
{
	public static void StaticMethod()
	{
		
	}

	public static string /* prefix */ Append(this string prefix, string postfix)
	{
		return prefix + postfix;
	}
}

public static class DateTimeHelper
{
	public static TimeSpan To(this DateTime start, DateTime end)
	{
		return start - end;
		// long ticks = start.Ticks - end.Ticks;
		//
		// TimeSpan returnValue = TimeSpan.FromTicks(ticks);
		// return returnValue;
	}
}
