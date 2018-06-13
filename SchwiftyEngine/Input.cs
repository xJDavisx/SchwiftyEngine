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

using System.Collections.Generic;
using static SDL2.SDL;

namespace SchwiftyEngine
{
	public enum MouseButton
	{
		Left = 1,
		Middle = 2,
		Right = 3,
		X1 = 4,
		X2 = 5
	}

	public static class Input
	{
		private static List<SDL_Keycode> keyDownList = new List<SDL_Keycode>();
		private static List<SDL_Keycode> keyPressedList = new List<SDL_Keycode>();
		private static List<SDL_Keycode> keyUpList = new List<SDL_Keycode>();

		private static List<byte> mouseButtonDownList = new List<byte>();
		private static List<byte> mouseButtonPressedList = new List<byte>();
		private static List<byte> mouseButtonUpList = new List<byte>();

		private static Vector2 mousePos = Vector2.Zero;
		private static Vector2 mouseScrollWheel = Vector2.Zero;

		public static Vector2 MousePosition
		{
			get
			{
				return mousePos;
			}
		}

		internal static void Update(SDL_Event[] events)
		{
			keyUpList.Clear();
			keyDownList.Clear();

			mouseButtonDownList.Clear();
			mouseButtonUpList.Clear();
			mouseScrollWheel = Vector2.Zero;

			foreach (SDL_Event e in events)
			{
				if (e.type == SDL_EventType.SDL_KEYDOWN)
				{
					if (!keyPressedList.Contains(e.key.keysym.sym))
					{
						keyDownList.Add(e.key.keysym.sym);
						if (!keyPressedList.Contains(e.key.keysym.sym))
							keyPressedList.Add(e.key.keysym.sym);
					}
				}
				else if (e.type == SDL_EventType.SDL_KEYUP)
				{
					keyUpList.Add(e.key.keysym.sym);
					keyPressedList.Remove(e.key.keysym.sym);
				}
				else if (e.type == SDL_EventType.SDL_MOUSEMOTION)
				{
					mousePos = new Vector2(e.motion.x, e.motion.y);
				}
				else if (e.type == SDL_EventType.SDL_MOUSEBUTTONUP)
				{
					byte b = e.button.button;
					mouseButtonUpList.Add(b);
					mouseButtonPressedList.Remove(b);
				}
				else if (e.type == SDL_EventType.SDL_MOUSEBUTTONDOWN)
				{
					byte b = e.button.button;
					mouseButtonDownList.Add(b);
					if (!mouseButtonPressedList.Contains(b))
					{
						mouseButtonPressedList.Add(b);
					}
				}
				else if (e.type == SDL_EventType.SDL_MOUSEWHEEL)
				{
					mouseScrollWheel = new Vector2(e.wheel.x, e.wheel.y);
				}
			}
		}

		/// <summary>
		/// True if key was pressed down this frame.
		/// </summary>
		/// <param name="key">The key to check.</param>
		/// <returns>True if key was pressed this frame. False if key is held or is up.</returns>
		public static bool KeyDown(SDL_Keycode key)
		{
			if (keyDownList.Contains(key))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// True if key is held down for more than one frame.
		/// </summary>
		/// <param name="key">The key to check.</param>
		/// <returns>True if key is held down for more than one frame. False if key is up.</returns>
		public static bool KeyPressed(SDL_Keycode key)
		{
			if (keyPressedList.Contains(key))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Checks if key was let up after being pressed this frame.
		/// </summary>
		/// <param name="key">The key to check.</param>
		/// <returns>True if key was let up this frame. False if key is down.</returns>
		public static bool KeyUp(SDL_Keycode key)
		{
			if (keyUpList.Contains(key))
			{
				return true;
			}
			return false;
		}

		public static bool MouseButtonDown(MouseButton mouseButton)
		{
			if (mouseButtonDownList.Contains((byte)mouseButton))
			{
				return true;
			}
			return false;
		}

		public static bool MouseButtonPressed(MouseButton mouseButton)
		{
			if (mouseButtonPressedList.Contains((byte)mouseButton))
			{
				return true;
			}
			return false;
		}

		public static bool MouseButtonUp(MouseButton mouseButton)
		{
			if (mouseButtonUpList.Contains((byte)mouseButton))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// True if the mouse scroll wheel was scrolled.
		/// </summary>
		/// <param name="scrollWheel">
		/// Outs a Vector2 where positive x is scroll right, negative x is scroll left, positive y is
		/// scroll up, negative y is scroll down.
		/// </param>
		/// <returns>True if the mouse scroll wheel was scrolled.</returns>
		public static bool MouseScrollWheel(out Vector2 scrollWheel)
		{
			scrollWheel = mouseScrollWheel;
			if (mouseScrollWheel != Vector2.Zero)
			{
				return true;
			}
			return false;
		}
	}
}