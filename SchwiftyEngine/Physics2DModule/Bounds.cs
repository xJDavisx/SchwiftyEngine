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

namespace SchwiftyEngine.Physics2DModule
{
	/// <summary>
	/// Represents an axis aligned bounding box.
	/// </summary>
	/// <remarks>
	/// An axis-aligned bounding box, or AABB for short, is a box aligned with coordinate axes and
	/// fully enclosing some object. Because the box is never rotated with respect to the axes, it
	/// can be defined by just its center and extents, or alternatively by min and max points.
	/// </remarks>
	public struct Bounds
	{
		private Vector2 _center;
		private Vector2 _size;

		public Bounds(Vector2 center, Vector2 size)
		{
			_center = center;
			_size = size;
		}

		public Vector2 center
		{
			get
			{
				return _center;
			}

			set
			{
				_center = value;
			}
		}

		public Vector2 extents
		{
			get
			{
				return _size / 2;
			}
		}

		public Vector2 max
		{
			get
			{
				return center + extents;
			}
		}

		public Vector2 min
		{
			get
			{
				return center - extents;
			}
		}

		public Vector2 size
		{
			get
			{
				return _size;
			}

			set
			{
				_size = value;
			}
		}

		/// <summary>
		/// The closest point on the bounding box. If the point is inside the bounding box,
		/// unmodified point position will be returned.
		/// </summary>
		/// <param name="point">The point.</param>
		/// <returns>The point on the bounding box or inside the bounding box.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public Vector2 ClosestPoint(Vector2 point)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Is point contained in the bounding box?
		///If the point passed into Contains is inside the bounding box a value of True is returned.
		///Note: If Bounds.extents contains a negative value in any coordinate then Bounds.Contains will always return False.
		/// </summary>
		/// <param name="point">The point.</param>
		/// <returns>
		///   <c>true</c> if the point is inside the bounds; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="NotImplementedException"></exception>
		public bool Contains(Vector2 point)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Grows the bounds to encapsulate a point.
		/// </summary>
		/// <param name="point">The point to encapsulate.</param>
		public void Encapsulate(Vector2 point)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Expand the bounds by increasing its size by amount along each side. Negative values
		/// contract the sides.
		/// </summary>
		/// <param name="amount">The amount.</param>
		public void Expand(Vector2 amount)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Does <paramref name="ray"/> intersect this <see cref="Bounds"/>?
		/// </summary>
		/// <param name="ray">The ray.</param>
		/// <returns>
		/// <c>true</c> if the <paramref name="ray"/> intesects this <see cref="Bounds"/>; otherwise, <c>false</c>.
		/// </returns>
		public bool IntersectRay(Ray ray)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets the bounds to the min and max value of the box. Using this function is faster than
		/// assigning min and max separately.
		/// </summary>
		/// <param name="min">The minimum.</param>
		/// <param name="max">The maximum.</param>
		public void SetMinMax(Vector2 min, Vector2 max)
		{
			throw new NotImplementedException();
		}
	}
}