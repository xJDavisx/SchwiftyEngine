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

using SchwiftyEngine;
using SchwiftyEngine.CoreModule;

namespace TestGame
{
	public class Game : SchwiftyGame
	{
		private void LoadResources()
		{
			Entity grid = Entity.AddEntity("Grid");
			DrawGrid dg = grid.AddComponent<DrawGrid>();
			GameManager gm = grid.AddComponent<GameManager>();
			grid.activeSelf = true;
			dg.enabled = true;
			gm.enabled = true;

			Entity camEnt = Entity.AddEntity("Camera");
			Camera c = camEnt.AddComponent<Camera>();
			CameraController cc = camEnt.AddComponent<CameraController>();
			camEnt.activeSelf = true;
			c.enabled = true;
			cc.enabled = true;

			Entity player = Entity.AddEntity("Player");
			Player p = player.AddComponent<Player>();
			Sprite s = player.AddComponent<Sprite>();
			s.LoadTexture(Resource.texturePath + "player\\player-spritemap-v9.png");
			s.ScaleX = .1f;
			s.ScaleY = .1f;
			s.enabled = true;
			p.enabled = true;

			Entity player2 = Entity.AddEntity("Player2");
			Player p2 = player2.AddComponent<Player>();
			Sprite s2 = player2.AddComponent<Sprite>();
			s2.LoadTexture(Resource.texturePath + "player\\player-spritemap-v9.png");
			s2.ScaleX = .1f;
			s2.ScaleY = .1f;
			p2.playerNumber = 2;
			s2.enabled = true;
			p2.enabled = true;
		}
	}
}