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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SchwiftyUI
{
	public partial class Form1 : Form
	{
		// These are the variables you care about.

		#region Private Fields

		private IntPtr gameWindow; // For FNA, this is Game.Window.Handle

		private Clear glClear;

		private ClearColor glClearColor;

		private IntPtr glContext;

		private Viewport glViewport;

		// IGNORE MEEEEE
		private Random random;

		#endregion Private Fields

		#region Public Constructors

		public Form1()
		{
			InitializeComponent();
			// This is what we're going to attach the SDL2 window to

			// Make the WinForms window
			FormClosing += new FormClosingEventHandler(WindowClosing);
			button.Text = "Whatever";
			button.Click += new EventHandler(ClickedButton);

			// IGNORE MEEEEE
			random = new Random();
			SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
			CreateSDLWindow();
		}

		#endregion Public Constructors

		#region Private Delegates

		private delegate void Clear(uint flags);

		private delegate void ClearColor(float r, float g, float b, float a);

		private delegate void Viewport(int x, int y, int width, int height);

		#endregion Private Delegates

		#region Private Methods

		[DllImport("user32.dll")]
		private static extern IntPtr SetParent(IntPtr child, IntPtr newParent);

		[DllImport("user32.dll")]
		private static extern IntPtr SetWindowPos(
			IntPtr handle,
			IntPtr handleAfter,
			int x,
			int y,
			int cx,
			int cy,
			uint flags
		);

		[DllImport("user32.dll")]
		private static extern IntPtr ShowWindow(IntPtr handle, int command);

		private void ClickedButton(object sender, EventArgs e)
		{
			//glClearColor(
			//	(float)random.NextDouble(),
			//	(float)random.NextDouble(),
			//	(float)random.NextDouble(),
			//	1.0f
			//);
			//glClear(0x4000); // GL_COLOR_BUFFER_BIT
			//SDL.SDL_GL_SwapWindow(gameWindow);
		}

		private void CreateSDLWindow()
		{
			gameWindow = SDL.SDL_CreateWindow(
							String.Empty,
							0,
							0,
							gamePanel.Size.Width,
							gamePanel.Size.Height,
							SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS
						);
			SetGLContext();

			// Get the Win32 HWND from the SDL2 window
			SDL.SDL_SysWMinfo info = new SDL.SDL_SysWMinfo();
			SDL.SDL_GetWindowWMInfo(gameWindow, ref info);
			IntPtr winHandle = info.info.win.window;

			// Move the SDL2 window to 0, 0
			SetWindowPos(
				winHandle,
				Handle,
				0,
				0,
				0,
				0,
				0x0401 // NOSIZE | SHOWWINDOW
			);

			// Attach the SDL2 window to the panel
			SetParent(winHandle, gamePanel.Handle);
			ShowWindow(winHandle, 1); // SHOWNORMAL
		}

		private void DestroySDLWindow()
		{
			glClear = null;
			glClearColor = null;
			glViewport = null;
			SDL.SDL_GL_DeleteContext(glContext);
			glContext = IntPtr.Zero;
			SDL.SDL_DestroyWindow(gameWindow);
			gameWindow = IntPtr.Zero;
		}

		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
			DestroySDLWindow();
			CreateSDLWindow();
			int w, h;
			SDL.SDL_GetWindowSize(gameWindow, out w, out h);

			label1.Text = "SDL_Window Size : \r\n\tWidth: " + w + "\r\n\tHeight: " + h;
		}

		private void SetGLContext()
		{
			//if (glContext != IntPtr.Zero)
			//	SDL.SDL_GL_DeleteContext(glContext);
			//glContext = SDL.SDL_GL_CreateContext(gameWindow);
			//glViewport = (Viewport)Marshal.GetDelegateForFunctionPointer(
			//	SDL.SDL_GL_GetProcAddress("glViewport"),
			//	typeof(Viewport)
			//);
			//glClearColor = (ClearColor)Marshal.GetDelegateForFunctionPointer(
			//	SDL.SDL_GL_GetProcAddress("glClearColor"),
			//	typeof(ClearColor)
			//);
			//glClear = (Clear)Marshal.GetDelegateForFunctionPointer(
			//	SDL.SDL_GL_GetProcAddress("glClear"),
			//	typeof(Clear)
			//);
			//glViewport(0, 0, gamePanel.Size.Width, gamePanel.Size.Height);
			//glClearColor(1.0f, 0.0f, 0.0f, 1.0f);
			//glClear(0x4000);
			//SDL.SDL_GL_SwapWindow(gameWindow);
		}

		private void WindowClosing(object sender, FormClosingEventArgs e)
		{
			DestroySDLWindow();
			SDL.SDL_Quit();
		}

		#endregion Private Methods
	}
}