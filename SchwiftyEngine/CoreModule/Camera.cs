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

namespace SchwiftyEngine.CoreModule
{
	/// <summary>
	/// A <see cref="Camera"/> is a device through which the player views the world.
	/// </summary>
	/// <seealso cref="SchwiftyEngine.CoreModule.Behaviour"/>
	public class Camera : Behaviour
	{
		private static List<Camera> _cameras = new List<Camera>();
		private static Camera _main = null;
		private float _zoom = 1f;

		/// <summary>
		/// Initializes a new instance of the <see cref="Camera"/> class.
		/// </summary>
		public Camera() : base()
		{
			if (_cameras.Count == 0)
			{
				tag = "Main Camera";
				_main = this;
			}
			_cameras.Add(this);
		}

		/// <summary>
		/// Gets the first active <see cref="Camera"/> with the tag of "Main Camera".
		/// </summary>
		/// <value>The main camera.</value>
		public static Camera main
		{
			get
			{
				if (_main == null)
				{
					_main = _cameras.Where(c => c.enabled == true && c.tag == "Main Camera").First();
				}
				return _main;
			}
		}

		/// <summary>
		/// Gets or sets the zoom of the <see cref="Camera"/> instance.
		/// </summary>
		/// <value>The zoom.</value>
		public float zoom
		{
			get
			{
				return _zoom;
			}

			set
			{
				_zoom = value;
			}
		}

		private void OnDestroy()
		{
		}
	}
}