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

namespace SchwiftyEngine.CoreModule
{
	/// <summary>
	/// A <see cref="Behaviour"/> is a <see cref="Component"/> that can be enabled and disabled.
	/// </summary>
	/// <seealso cref="SchwiftyEngine.CoreModule.Component"/>
	public abstract class Behaviour : Component
	{
		private const string _OnDisabled = "OnDisabled";
		private const string _OnEnabled = "OnEnabled";
		private bool _enabled = false;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Behaviour"/> is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		public bool enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				if (_enabled != value)
				{
					_enabled = value;
					CallMethod(_enabled ? _OnEnabled : _OnDisabled);
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="Behaviour"/> is active and enabled.
		/// </summary>
		/// <value>
		/// <c>true</c> if this <see cref="Behaviour"/> is active and enabled; otherwise, <c>false</c>.
		/// </value>
		public bool isActiveAndEnabled
		{
			get
			{
				return entity.activeInHierarchy && enabled;
			}
		}
	}
}