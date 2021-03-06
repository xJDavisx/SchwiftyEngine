﻿/*|
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
		//distance the grid will draw from (0,0) in world units.
		private int distance = 1000;

		private Renderer r;

		//x colors
		private Color xColor = new Color(255, 0, 0, 255);

		private Color xColorFaded100s = new Color(255, 0, 0, 150);
		private Color xColorFaded10s = new Color(255, 0, 0, 100);
		private Color xColorFaded1s = new Color(255, 0, 0, 50);

		//y colors
		private Color yColor = new Color(0, 255, 0, 255);

		private Color yColorFaded100s = new Color(0, 255, 0, 100);
		private Color yColorFaded10s = new Color(0, 255, 0, 75);
		private Color yColorFaded1s = new Color(0, 255, 0, 50);

		private void Draw()
		{
			int ppu = Camera.main.PixelsPerUnit;
			int lineLength = ppu * distance;
			Vector2 screenPos = transform.PositionScreen;

			//draw the initial X line where X = 0
			r.DrawColor = xColor;
			r.DrawLine(screenPos + Vector2.Left * lineLength, screenPos + Vector2.Right * lineLength);

			//draw the initial Y line where Y = 0
			r.DrawColor = yColor;
			r.DrawLine(screenPos + Vector2.Up * lineLength, screenPos + Vector2.Down * lineLength);

			//loop through and draw the rest of the Y lines
			for (int i = 1; i < distance; i++)
			{
				r.DrawColor = yColorFaded1s;
				if (i % 10 == 0)
				{
					r.DrawColor = yColorFaded10s;
				}
				if (i % 100 == 0)
				{
					r.DrawColor = yColorFaded100s;
				}
				r.DrawLine((screenPos + Vector2.Up * lineLength) + (Vector2.Left * (i * ppu)), (screenPos + Vector2.Down * lineLength) + (Vector2.Left * (i * ppu)));
				r.DrawLine((screenPos + Vector2.Up * lineLength) + (Vector2.Right * (i * ppu)), (screenPos + Vector2.Down * lineLength) + (Vector2.Right * (i * ppu)));
			}

			//loop through and draw the rest of the X lines
			for (int i = 1; i < distance; i++)
			{
				r.DrawColor = xColorFaded1s;
				if (i % 10 == 0)
				{
					r.DrawColor = xColorFaded10s;
				}
				if (i % 100 == 0)
				{
					r.DrawColor = xColorFaded100s;
				}
				r.DrawLine((screenPos + Vector2.Left * lineLength) + (Vector2.Up * (i * ppu)), (screenPos + Vector2.Right * lineLength) + (Vector2.Up * (i * ppu)));
				r.DrawLine((screenPos + Vector2.Left * lineLength) + (Vector2.Down * (i * ppu)), (screenPos + Vector2.Right * lineLength) + (Vector2.Down * (i * ppu)));
			}
		}

		private void Start()
		{
			r = Engine.Window.Renderer;
		}
	}
}