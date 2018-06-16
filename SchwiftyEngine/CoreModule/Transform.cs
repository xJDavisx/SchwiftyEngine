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

namespace SchwiftyEngine.CoreModule
{
	public class Transform : Component
	{
		private Vector2 _positionWorld = Vector2.Zero;
		private float _rotationInDegrees = 0;

		/// <summary>
		/// Gets or sets the position in world space.
		/// </summary>
		/// <value>The position in world space.</value>
		public Vector2 Position
		{
			get
			{
				return _positionWorld;
			}

			set
			{
				_positionWorld = value;
			}
		}

		public Vector2 PositionScreen
		{
			get
			{
				Vector2 camPos = Camera.main.transform.Position;
				int ppu = Camera.main.PixelsPerUnit;

				return new Vector2((Engine.Window.Width * .5f) - ((camPos.x - transform.Position.x) * ppu),
					(Engine.Window.Height * .5f) + ((camPos.y - transform.Position.y) * ppu));
			}
		}

		public float rotationInDegrees
		{
			get
			{
				return _rotationInDegrees;
			}

			set
			{
				_rotationInDegrees = value;
				if (_rotationInDegrees < 0)
				{
					_rotationInDegrees += 360f;
				}
				else if (_rotationInDegrees > 360f)
				{
					_rotationInDegrees -= 360f;
				}
			}
		}

		public float rotationInRadians
		{
			get
			{
				return _rotationInDegrees * ((float)Math.PI / 180);
			}
			set
			{
				rotationInDegrees = value * (180 / (float)Math.PI);
			}
		}

		internal override void ComponentAdded()
		{
		}

		public void LookAt(Vector2 target)
		{
		}

		public void Translate(Vector2 newPos)
		{
			_positionWorld.x += newPos.x;
			_positionWorld.y += newPos.y;
		}
	}
}