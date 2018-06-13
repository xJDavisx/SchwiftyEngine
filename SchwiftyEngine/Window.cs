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

using SDL2;
using System;
using static SDL2.SDL;

namespace SchwiftyEngine
{
	public class Window
	{
		private Renderer _renderer;
		private IntPtr _window = IntPtr.Zero;
		private SDL_WindowFlags flags;
		private IntPtr handle = IntPtr.Zero;
		private int height;
		private bool isFullScreen = false;
		private string title;
		private int width;
		private int x;
		private int y;

		internal Window(string title = "New SDL Window", int x = 0, int y = 0, int width = 600, int height = 600, SDL.SDL_WindowFlags flags = SDL_WindowFlags.SDL_WINDOW_SHOWN)
		{
			this.title = title;
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
			this.flags = flags;
		}

		~Window()
		{
			DestroySDLWindow();
		}

		internal IntPtr WindowPointer
		{
			get
			{
				return _window;
			}

			private set
			{
				_window = value;
			}
		}

		public SDL_WindowFlags Flags
		{
			get
			{
				return flags;
			}

			set
			{
				flags = value;
				if (_window == IntPtr.Zero)
					return;
			}
		}

		public int Height
		{
			get
			{
				return height;
			}

			set
			{
				height = value;
				if (_window == IntPtr.Zero)
					return;
				SDL_SetWindowSize(_window, width, height);
			}
		}

		public bool IsFullScreen
		{
			get
			{
				return isFullScreen;
			}

			set
			{
				if (isFullScreen != value)
				{
					if (value)
					{
						SDL_SetWindowFullscreen(_window, (uint)SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP);
						SDL_GetWindowSize(_window, out width, out height);
					}
					else
					{
						SDL_SetWindowFullscreen(_window, (uint)SDL_WindowFlags.SDL_WINDOW_SHOWN);
						SDL_GetWindowSize(_window, out width, out height);
					}
				}
				isFullScreen = value;
			}
		}

		public Renderer Renderer
		{
			get
			{
				return _renderer;
			}
			set
			{
				Renderer = value;
			}
		}

		public int Width
		{
			get
			{
				return width;
			}

			set
			{
				width = value;
				if (_window == IntPtr.Zero)
					return;
				SDL_SetWindowSize(_window, width, height);
			}
		}

		public IntPtr WindowHandle
		{
			get
			{
				return handle;
			}

			private set
			{
				handle = value;
			}
		}

		public string WindowTitle
		{
			get
			{
				return title;
			}

			set
			{
				title = value;
				if (_window == IntPtr.Zero)
					return;

				SDL.SDL_SetWindowTitle(_window, title);
			}
		}

		public int X
		{
			get
			{
				return x;
			}

			set
			{
				x = value;
				if (_window == IntPtr.Zero)
					return;
				SDL_SetWindowPosition(_window, x, y);
			}
		}

		public int Y
		{
			get
			{
				return y;
			}

			set
			{
				y = value;
				if (_window == IntPtr.Zero)
					return;
				SDL_SetWindowPosition(_window, x, y);
			}
		}

		internal void Create()
		{
			if (_window != IntPtr.Zero)
			{
				DestroySDLWindow();
			}
			//Set up the screen
			WindowPointer = SDL_CreateWindow(title, x, y, width, height, flags);
			_renderer = new Renderer(this);
			// Get the Win32 HWND from the SDL2 window
			SDL_SysWMinfo info = new SDL.SDL_SysWMinfo();
			SDL_GetWindowWMInfo(WindowPointer, ref info);
			handle = info.info.win.window;
		}

		internal void DestroySDLWindow()
		{
			SDL_DestroyWindow(_window);
			_window = IntPtr.Zero;
			handle = IntPtr.Zero;
			if (_renderer == null)
				return;
			_renderer.Destroy();
		}

		internal void Render()
		{
			_renderer.Render();
		}
	}
}