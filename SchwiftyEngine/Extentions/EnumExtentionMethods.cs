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

namespace SchwiftyEngine.Extentions
{
	/// <summary>
	/// Useful methods when working with enums.
	/// </summary>
	public static class EnumExtentionMethods
	{
		/// <summary>
		/// Adds a flag to an enum.
		/// </summary>
		/// <param name="flag">The flag to add.</param>
		public static void AddFlag<T>(this T flags, T flag) where T : struct, IConvertible
		{
			int flagsValue = (int)(object)flags;
			int flagValue = (int)(object)flag;

			if (!flags.ContainsFlag(flag))
				flags = (T)(object)(flagsValue | flagValue);
		}

		/// <summary>
		/// Checks if the enum contains a specific flag.
		/// </summary>
		/// <param name="flag">The flag to check for.</param>
		/// <returns></returns>
		public static bool ContainsFlag<T>(this T flags, T flag) where T : struct, IConvertible
		{
			int flagsValue = (int)(object)flags;
			int flagValue = (int)(object)flag;

			return (flagsValue & flagValue) != 0;
		}

		public static int Count<T>(this T soure) where T : struct, IConvertible//enum
		{
			if (!typeof(T).IsEnum)
				throw new ArgumentException("T must be an enumerated type");

			return Enum.GetNames(typeof(T)).Length;
		}

		/// <summary>
		/// Removes a flag from an enum.
		/// </summary>
		/// <param name="flag">The flag to remove.</param>
		public static void RemoveFlag<T>(this T flags, T flag) where T : struct, IConvertible
		{
			int flagsValue = (int)(object)flags;
			int flagValue = (int)(object)flag;

			if (flags.ContainsFlag(flag))
				flags = (T)(object)(flagsValue & (~flagValue));
		}

		/// <summary>
		/// Converts the string representation of a number to an integer.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">T must be an enumerated type</exception>
		public static int ToInt<T>(this T source) where T : struct, IConvertible//enum
		{
			if (!typeof(T).IsEnum)
				throw new ArgumentException("T must be an enumerated type");

			return (int)(IConvertible)source;
		}
	}
}