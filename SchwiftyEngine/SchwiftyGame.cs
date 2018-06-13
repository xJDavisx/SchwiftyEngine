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

namespace SchwiftyEngine.CoreModule
{
	public abstract class SchwiftyGame : Object
	{
		public int height = 720;
		public int positionX = 0;
		public int positionY = 0;
		public int width = 1280;
		public string windowTitle = "";

		public SchwiftyGame(string title = "", int positionX = 0, int positionY = 0, int width = 1280, int height = 720)
		{
			windowTitle = title;
			this.positionX = positionX;
			this.positionY = positionY;
			this.width = width;
			this.height = height;
		}

		public SchwiftyGame()
		{
		}

		~SchwiftyGame()
		{
		}

		public void StartGame()
		{
			Engine._game = this;
			//Initialize the Engine and do any setup work.
			Engine.Initialize(this, windowTitle, positionX, positionY, width, height);
			//Run the game. this is the game loop function for the engine.
			Engine.Run();

			//Game and Engine are shutdown and the program is ready for termination.
			//Console.WriteLine("Game exited");
			//Console.WriteLine("press any key to continue...");
			//Console.ReadKey();
		}
	}
}