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
using System.Collections.Generic;
using System.Reflection;
using static SDL2.SDL;

namespace SchwiftyEngine.CoreModule
{
	/// <summary>
	/// The brain for the Shwifty Engine, created by Jesse Davis on June 5th, 2018 at 9:00 AM Central Time.
	/// </summary>
	public static class Engine
	{
		private static int FPS_CAP = 5;
		private static Window window;
		internal static SchwiftyGame _game;
		internal static SDL_Event systemEvent;
		private static bool isRunning = true;

		/// <summary>
		/// Gets or sets a value indicating whether this instance is full screen.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is full screen; otherwise, <c>false</c>.
		/// </value>
		public static bool IsFullScreen
		{
			get
			{
				return window.IsFullScreen;
			}

			set
			{
				window.IsFullScreen = value;
			}
		}

		/// <summary>
		/// Gets the window.
		/// </summary>
		/// <value>
		/// The window.
		/// </value>
		public static Window Window
		{
			get
			{
				return window;
			}

			private set
			{
				window = value;
			}
		}
		
		static void PollEvents()
		{
			List<SDL_Event> events = new List<SDL_Event>();
			while (SDL_PollEvent(out systemEvent) != 0)
			{
				events.Add(systemEvent);
			}
			Input.Update(events.ToArray());
			events.Clear();
		}

		/// <summary>
		/// Exits the game and closes the came window.
		/// </summary>
		public static void Exit()
		{
			isRunning = false;
		}


		/// <summary>
		/// Initializes the specified game.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="title">The title.</param>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <param name="flags">The flags.</param>
		public static void Initialize(SchwiftyGame game, string title = "", int x = 0, int y = 0, int width = 1280, int height = 720, SDL.SDL_WindowFlags flags = SDL_WindowFlags.SDL_WINDOW_SHOWN)
		{
			Resource.StartupCheck();
			SDL_Init(SDL_INIT_VIDEO);

			if (title == "")
				title = Assembly.GetExecutingAssembly().GetName().FullName;

			window = new Window(title, x, y, width, height, flags);
			window.Create();
			IsFullScreen = false;

			//initialize audio engine.
			AudioEngine.Init();

			SDL_ttf.TTF_Init();
			_game = game;
		}

		/// <summary>
		/// Runs the game loop
		/// </summary>
		public static void Run()
		{
			if (_game == null)
			{
				throw new Exception("Game variable must not be null! Be sure to pass it in on Instantiate!");
			}
			_game.CallMethod("LoadResources");
			Entity.CallMethodInComponents("Start");

			while (isRunning)
			{
				//update the Time class
				Time.Tick();

				//poll for SDL events.
				PollEvents();

				//invoke update events
				Entity.CallMethodInComponents("Update");
				Entity.CallMethodInComponents("LateUpdate");

				//clear the renderer
				Window.Renderer.Clear();

				//invoke draw events
				Entity.CallMethodInComponents("Draw");

				//finally, render the screen.
				Window.Render();
			}
			Entity.CallMethodInComponents("End");

			window.DestroySDLWindow();
			window = null;
			SDL_Quit();
		}
	}
}