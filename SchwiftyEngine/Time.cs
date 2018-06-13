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
using static SDL2.SDL;

namespace SchwiftyEngine
{
	/// <summary>
	/// The <see cref="Time"/> class offers access to time related information, such as DeltaTime,
	/// FPS, etc...
	/// </summary>
	public static class Time
	{
		private static float _dTime = 0;
		private static UInt64 _endTicks = SDL_GetTicks();
		private static int _fps = 0;
		private static UInt64 _startTicks = SDL_GetTicks();

		/// <summary>
		/// Gets the delta time.
		/// </summary>
		/// <value>The delta time.</value>
		public static float deltaTime
		{
			get
			{
				return _dTime;
			}
		}

		/// <summary>
		/// Gets the FPS.
		/// </summary>
		/// <value>The FPS.</value>
		public static int FPS
		{
			get
			{
				return _fps;
			}
		}

		/// <summary>
		/// Call this in the game loop to update delta time and FPS.
		/// </summary>
		internal static void Tick()
		{
			_endTicks = _startTicks;
			_startTicks = SDL_GetPerformanceCounter();
			_dTime = ((_startTicks - _endTicks) * 1000f / SDL_GetPerformanceFrequency()) * 0.001f;
			if (_dTime != 0)
			{
				_fps = (int)(1f / _dTime);
			}
		}
	};
}