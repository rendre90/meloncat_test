using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MelonCat.Test
{
	public class Question1 : MonoBehaviour
	{
		private const int a = 132;
		private const int b = 420;

		private void Start()
		{
			Debug.Log(HighCommonFactor(a, b));
		}

		private int HighCommonFactor(int a, int b)
		{
			int result = 0;
			int smallestInt = a < b ? a : b;
			
			for (int i = smallestInt; i > 0; i--)
			{
				if (smallestInt % i == 0 && b % i == 0)
				{
					result = i;
					break;
				}
			}
			return result;
		}
	}
}
