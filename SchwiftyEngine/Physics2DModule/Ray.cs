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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchwiftyEngine.Physics2DModule
{
	/// <summary>
	/// Representation of rays. A ray is an infinite line starting at origin and going in some direction.
	/// </summary>
	public struct Ray
	{
		private Vector2 _direction;
		private Vector2 _origin;

		public Ray(Vector2 direction, Vector2 origin)
		{
			_direction = direction.Normalized;
			_origin = origin;
		}

		/// <summary>The direction of the ray.
		///Direction is always a normalized vector.
		///If you assign a vector of non unit length, it will be normalized.
		/// </summary>
		/// <value>
		/// The direction.
		/// </value>
		public Vector2 direction
		{
			get
			{
				return _direction;
			}

			set
			{
				_direction = value.Normalized;
			}
		}

		/// <summary>
		/// The origin point of the ray.
		/// </summary>
		/// <value>The origin.</value>
		public Vector2 origin
		{
			get
			{
				return _origin;
			}

			set
			{
				_origin = value;
			}
		}

		/// <summary>
		/// Returns a point at distance units along the ray.
		/// </summary>
		/// <param name="distance">The distance.</param>
		/// <returns>a point at distance units along the ray.</returns>
		public Vector2 GetPoint(float distance)
		{
			return origin + (direction * distance);
		}
	}
}