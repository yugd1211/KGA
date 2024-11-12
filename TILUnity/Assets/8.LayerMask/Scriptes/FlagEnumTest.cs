using System;
using UnityEngine;

// enum : int와 밀접한 관계가 있음
public enum State
{
	None = 0,
	Idle = 1,
	Move = 2,
	Jump = 3,
	Attack = 4,
	Damage = 5,
	Die = 6
}

// Enum 앞에 Flags Attribute를 붙이면, 해당 Enum은 비트 플래그로 사용할 수 있음
// 주의 : Flags Attribute가 부착된 Enum의 각 항목의 값은
// 1에 한번만 비트 연산 한 값이 아닐 경우 정상 작동하지 않음 예) 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 or 1 << 0, 1 << 1, 1 << 2, 1 << 3, 1 << 4, 1 << 5, 1 << 6, 1 << 7, 1 << 8, 1 << 9, 1 << 10

//[Flags]
//public enum Debuff
//{
//	None = 0,
//	Poison = 1,
//	Stun = 2,
//	Freeze = 4,
//	Weak = 8,
//	Burn = 16
//}

[Flags]
public enum Debuff
{
	None = 0,
	Poison = 1 << 0,    //1
	Stun = 1 << 1,      //2
	Freeze = 1 << 2,    //4
	Weak = 1 << 3,      //8
	Burn = 1 << 4,      //16
	Every = -1,
}

namespace MyProject
{
	public class FlagEnumTest : MonoBehaviour
	{
		public State state;
		public Debuff debuff;

		private void Start()
		{
			//print($"{state} : {(int)state}");

			print($"{debuff} value : {(int)debuff}");
			print($"{debuff.HasFlag(Debuff.Poison)}");

			Debuff playerDebuff = (int)Debuff.Poison + Debuff.Stun;

			Debuff cure = Debuff.Poison;

			int playerDebuffInt = (int)playerDebuff;
			int curedDebuffInt = playerDebuffInt | (int)cure;

			print($"{playerDebuffInt}, {curedDebuffInt}");
			Debuff a = playerDebuff & cure;
			print($"debuff = {playerDebuff ^ cure}");
			if ((playerDebuff & cure) == Debuff.None)
			{
				print($"debuff = {playerDebuff ^ cure}");
			}
		}
	}
}
