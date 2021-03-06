﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Reports.Services.Reports
{
	public class IdGenerator : IIdGenerator
	{
		private const string validIdChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		private readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

		public string GetNewId(int idLength = 6)
		{
			var id = new StringBuilder();

			for (var i = 0; i < idLength; i++)
			{
				var b = new byte[4];

				rng.GetBytes(b);

				var bInt = Math.Abs(BitConverter.ToInt32(b, 0));
				var charIndex = bInt % validIdChars.Length;

				id.Append(validIdChars[charIndex]);
			}

			return id.ToString();
		}
	}
}
