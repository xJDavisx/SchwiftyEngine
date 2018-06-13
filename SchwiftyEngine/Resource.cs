/*|
|*|_____________________________________________________________________________________________________________________________
|*|  Schwifty Engine                                                                                                             |*|
|*|  GNU GPLv3 https://www.gnu.org/licenses/gpl-3.0.en.html                                                                     |*|
|*|                                                                                                                             |*|
|*|  Copyright © 2018 Jesse Davis                                                                                               |*|
|*|_____________________________________________________________________________________________________________________________|*|
|*|                                                                                                                             |*|
|*|  This software is provided 'as-is', without any express or implied warranty.                                                |*|
|*|  In no event will the authors be held liable for any damages arising from                                                   |*|
|*|  the use of this software.                                                                                                  |*|
|*|                                                                                                                             |*|
|*|  Permission is granted to anyone to use this software for any purpose,                                                      |*|
|*|  including commercial applications, and to alter it and redistribute it                                                     |*|
|*|  freely, subject to the following restrictions:                                                                             |*|
|*|                                                                                                                             |*|
|*|  1. The origin of this software must not be misrepresented; you must not                                                    |*|
|*|  claim that you wrote the original software. If you use this software in a                                                  |*|
|*|  product, an acknowledgment in the product documentation would be                                                           |*|
|*|  appreciated but is not required.                                                                                           |*|
|*|                                                                                                                             |*|
|*|  2. Altered source versions must be plainly marked as such, and must not be                                                 |*|
|*|  misrepresented as being the original software.                                                                             |*|
|*|                                                                                                                             |*|
|*|  3. This notice may not be removed or altered from any source distribution.                                                 |*|
|*|_____________________________________________________________________________________________________________________________|*|
|*|                                                                                                                             |*|
|*|  Created by Jesse Davis, hereto referred to as "I" or "me", unless stated elsewhere in the source code file or the license. |*|
|*|  Any alterations to source code made by other developers were done with respect to their license.                           |*|
|*|  Use of source code authored by other developers are subject to their respective licenses.                                  |*|
|*|_____________________________________________________________________________________________________________________________|*|
|*|                                                                                                                             |*|
|*|   Contact Info:                                                                                                             |*|
|*|      Github - xJDavisx                                                                                                      |*|
|*|      Discord - JesseD92                                                                                                     |*|
|*|_____________________________________________________________________________________________________________________________|*|
|*/

using System;
using System.IO;

namespace SchwiftyEngine
{
	public static class Resource
	{
		public const string fontPath = resourcePath + "font\\";
		public const string musicPath = resourcePath + "audio\\music\\";
		public const string resourcePath = "resource\\";
		public const string soundPath = resourcePath + "audio\\sound\\";
		public const string texturePath = resourcePath + "image\\texture\\";
		public const string videoPath = resourcePath + "video\\";

		private static bool YesNoQuestion(string question)
		{
			while (true)
			{
				Console.WriteLine();
				Console.WriteLine(question + "\r\nYes: Y\r\nNo:  N");
				ConsoleKeyInfo a = Console.ReadKey();
				if (a.Key == ConsoleKey.Y)
				{
					return true;
				}
				else if (a.Key == ConsoleKey.N)
				{
					return false;
				}
				Console.WriteLine();
				Console.WriteLine("Type Y for Yes or N for No.");
			}
		}

		internal static bool StartupCheck()
		{
			if (!Directory.Exists(resourcePath))
			{
				Debug.LogError("Resource path does not exist!");
				if (YesNoQuestion("Do you wish to create the paths for all resources?"))
				{
					Directory.CreateDirectory(fontPath);
					Directory.CreateDirectory(musicPath);
					Directory.CreateDirectory(soundPath);
					Directory.CreateDirectory(texturePath);
					Directory.CreateDirectory(videoPath);
				}
			}
			return true;
		}

		//public static T LoadResource<T>(string fileName)
		//{
		//}
	}
}