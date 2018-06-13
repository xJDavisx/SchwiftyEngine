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

namespace SchwiftyEngine
{
	public struct Vector2
	{
		private float x;
		private float y;

		public Vector2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public static Vector2 Down
		{
			get
			{
				return new Vector2(0, -1);
			}
		}

		public static Vector2 Left
		{
			get
			{
				return new Vector2(-1, 0);
			}
		}

		public static Vector2 Right
		{
			get
			{
				return new Vector2(1, 0);
			}
		}

		public static Vector2 Up
		{
			get
			{
				return new Vector2(0, 1);
			}
		}

		public static Vector2 Zero
		{
			get
			{
				return new Vector2(0, 0);
			}
		}

		public float DirectionDegrees
		{
			get
			{
				return (float)(DirectionRadians * 180 / Math.PI);
			}
		}

		public float DirectionRadians
		{
			get
			{
				return (float)Math.Atan(x / y);
			}
		}

		public float Magnitude
		{
			get
			{
				return (float)Math.Sqrt((x * x) + (y * y));
			}
		}

		public Vector2 Normalized
		{
			get
			{
				return this / Magnitude;
			}
		}

		public float X
		{
			get
			{
				return x;
			}

			set
			{
				x = value;
			}
		}

		public float Y
		{
			get
			{
				return y;
			}

			set
			{
				y = value;
			}
		}

		public static float Distance(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x - b.x, a.y - b.y).Magnitude;
		}

		/// <summary>
		/// Linearly Interpolates a Vector2 over time.
		/// </summary>
		/// <param name="destination">The destination, or goal, Vector2.</param>
		/// <param name="current">The current Vector2.</param>
		/// <param name="time">
		/// The time, or smoothness, of the interpolation. Smaller values yield a smoother result.
		/// Value must be between 0 and 1.0f.
		/// </param>
		/// <returns>Lerped Vector2.</returns>
		public static Vector2 Lerp(Vector2 destination, Vector2 current, float deltaTime)
		{
			if (deltaTime > 1)
				deltaTime = 1;
			else if (deltaTime < 0)
				deltaTime = 0;

			return (1 - deltaTime) * current + (deltaTime * destination);
		}

		public static Vector2 operator -(Vector2 x, Vector2 y)
		{
			return new Vector2(x.x - y.x, x.y - y.y);
		}

		public static Vector2 operator -(Vector2 x)
		{
			return new Vector2(-x.x, -x.y);
		}

		public static bool operator !=(Vector2 x, Vector2 y)
		{
			if (x.x == y.x && x.y == y.y)
				return false;
			return true;
		}

		public static Vector2 operator *(Vector2 x, Vector2 y)
		{
			return new Vector2(x.x * y.x, x.y * y.y);
		}

		public static Vector2 operator *(Vector2 x, float y)
		{
			return new Vector2(x.x * y, x.y * y);
		}

		public static Vector2 operator *(float y, Vector2 x)
		{
			return new Vector2(x.x * y, x.y * y);
		}

		public static Vector2 operator /(Vector2 x, float y)
		{
			return new Vector2(x.x / y, x.y / y);
		}

		public static Vector2 operator /(Vector2 x, Vector2 y)
		{
			return new Vector2(x.x / y.x, x.y / y.y);
		}

		public static Vector2 operator +(Vector2 x, float y)
		{
			return new Vector2(x.x + y, x.y + y);
		}

		public static Vector2 operator +(Vector2 x, Vector2 y)
		{
			return new Vector2(x.x + y.x, x.y + y.y);
		}

		public static bool operator ==(Vector2 x, Vector2 y)
		{
			if (x.x == y.x && x.y == y.y)
				return true;
			return false;
		}

		public float Distance(Vector2 other)
		{
			return new Vector2(x - other.x, y - other.y).Magnitude;
		}

		public Vector2 SwapCoordinates()
		{
			return new Vector2(y, x);
		}
	}
}