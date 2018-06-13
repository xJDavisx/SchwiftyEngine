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
	/// Useful methods when working with <c>Array</c> types.
	/// </summary>
	public static class ArrayExtentionMethods
	{
		/// <summary>
		/// Adds the specified element to the end of the array.
		/// </summary>
		/// <typeparam name="T">The Type of the array.</typeparam>
		/// <param name="source">The source array.</param>
		/// <param name="element">The element to add to the array.</param>
		public static T[] Add<T>(this T[] source, T element)
		{
			T[] temp = new T[source.Length + 1];
			source.CopyTo(temp, 0);
			temp[temp.Length - 1] = element;
			return temp;
		}

		/// <summary>
		/// Determines whether the array contains the specified element.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source array.</param>
		/// <param name="element">The element to check for.</param>
		/// <returns><c>true</c> if the array contains the specified element; otherwise, <c>false</c>.</returns>
		public static bool Contains<T>(this T[] source, T element)
		{
			return source.IndexOf(element) >= 0;
		}

		/// <summary>
		/// Determines the index the specified element.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source array.</param>
		/// <param name="element">The element to check for.</param>
		/// <returns>The index of the element.</returns>
		/// <exception cref="Exception">Thrown if the element is not in the array.</exception>
		public static int IndexOf<T>(this T[] source, T element)
		{
			for (int i = 0; i < source.Length; i++)
			{
				if (source[i].Equals(element))
				{
					return i;
				}
			}
			throw new Exception("Element not found in array!");
		}

		/// <summary>
		/// Removes the specified element from the array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source array.</param>
		/// <param name="element">The element to remove.</param>
		public static T[] Remove<T>(this T[] source, T element)
		{
			source = source.RemoveAt(source.IndexOf(element));
			return source;
		}

		/// <summary>
		/// Removes the element from the array at index.
		/// </summary>
		/// <typeparam name="T">The Type of the array.</typeparam>
		/// <param name="source">The source array.</param>
		/// <param name="index">The index of the element to remove.</param>
		/// <exception cref="IndexOutOfRangeException">
		/// Thrown if the index is out of the arrays index range.
		/// </exception>
		public static T[] RemoveAt<T>(this T[] source, int index)
		{
			if (index < 0 || index >= source.Length)
			{
				throw new IndexOutOfRangeException("Index out of bounds! Index must be greater than zero and less than the Length of the array.\r\nIndex value: " + index + "\r\nArray Length: " + source.Length);
			}
			T[] dest = new T[source.Length - 1];
			if (index > 0)
				Array.Copy(source, 0, dest, 0, index);

			if (index < source.Length - 1)
				Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

			return dest;
		}
	}
}