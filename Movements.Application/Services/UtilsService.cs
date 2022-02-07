using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Template.Application.ViewModels.Users;
using Template.CrossCutting.ExceptionHandler.Extensions;

namespace Template.Application.Services
{
    public static class UtilsService
	{
		public static string EncryptPassword(string password)
		{
			HashAlgorithm sha = new SHA1CryptoServiceProvider();

			byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

			StringBuilder stringBuilder = new StringBuilder();
			foreach (var caracter in encryptedPassword)
			{
				stringBuilder.Append(caracter.ToString("X2"));
			}

			return stringBuilder.ToString();
		}

		internal static string GenerateCode(int length)
		{
			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}

		internal static string GenerateURL(string code, string email, string host)
		{
			if (!host.Contains("http"))
				host = "https://" + host;

			return string.Concat(host, "/api/users/activate/", email, "/", code);
		}

		internal static string GenerateReleaseNumber(List<MovementViewModel> productMovementList, int year, int month)
		{
			var productMovementListFiltered = productMovementList.Where(s => s.Year == year && s.Month == month).ToList();
			int lastEntryNumber;
			string newEntryNumber;


			if (productMovementListFiltered.Any())
			{
				lastEntryNumber = productMovementListFiltered.LastOrDefault().EntryNumber;
				newEntryNumber = (lastEntryNumber + 1).ToString();

				return newEntryNumber;
			}
            else
            {
				newEntryNumber = "0";

				return newEntryNumber;
			}
		}

		

		public static bool IsAdmin(string profile)
        {
			return profile == "1";
        }
    }
}
