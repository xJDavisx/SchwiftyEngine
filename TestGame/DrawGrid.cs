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
using System.Text;
using SchwiftyEngine;
using SchwiftyEngine.CoreModule;
using SDL2;
using static SDL2.SDL;
using Color = SDL2.SDL.SDL_Color;

namespace TestGame
{
	public class DrawGrid : GameBehaviour
	{
		private int distance = 1000;
		private int lineLength;
		private Renderer r;
		private int unitLength = 50;
		private Color xColor = new Color(255, 0, 0, 255);
		private Color xColorFaded = new Color(255, 0, 0, 50);
		private Color yColor = new Color(0, 255, 0, 255);
		private Color yColorFaded = new Color(0, 255, 0, 50);

		private void Draw()
		{
			float zoom = Camera.main.zoom;
			Vector2 screenPos = transform.PositionScreen;
			r.DrawColor = xColor;
			r.DrawLine(screenPos + Vector2.Left * lineLength * zoom, screenPos + Vector2.Right * lineLength * zoom);
			r.DrawColor = xColorFaded;
			for (int i = 0; i < distance; i++)
			{
				r.DrawLine((screenPos + Vector2.Left * lineLength * zoom) + (Vector2.Up * (i * unitLength * zoom)), (screenPos + Vector2.Right * lineLength * zoom) + (Vector2.Up * (i * unitLength) * zoom));
				r.DrawLine((screenPos + Vector2.Left * lineLength * zoom) + (Vector2.Down * (i * unitLength * zoom)), (screenPos + Vector2.Right * lineLength * zoom) + (Vector2.Down * (i * unitLength) * zoom));
			}

			r.DrawColor = yColor;
			r.DrawLine(screenPos + Vector2.Up * lineLength * zoom, screenPos + Vector2.Down * lineLength * zoom);
			r.DrawColor = yColorFaded;
			for (int i = 0; i < distance; i++)
			{
				r.DrawLine((screenPos + Vector2.Up * lineLength * zoom) + (Vector2.Left * (i * unitLength) * zoom), (screenPos + Vector2.Down * lineLength * zoom) + (Vector2.Left * (i * unitLength) * zoom));
				r.DrawLine((screenPos + Vector2.Up * lineLength * zoom) + (Vector2.Right * (i * unitLength) * zoom), (screenPos + Vector2.Down * lineLength * zoom) + (Vector2.Right * (i * unitLength) * zoom));
			}
		}

		private void Start()
		{
			r = Engine.Window.Renderer;
			lineLength = unitLength * distance;
		}
	}
}