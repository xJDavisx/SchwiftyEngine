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

using SchwiftyEngine;
using SchwiftyEngine.CoreModule;
using SchwiftyEngine.Physics2DModule;
using static SDL2.SDL;

namespace TestGame
{
	public class Player : GameBehaviour
	{
		private Camera cam;
		private Vector2 gravity = new Vector2(0, 9.8f);
		private Sprite playerSprite;
		private Rigidbody2D rb;
		private Sound s = new Sound(Resource.soundPath + "test.wav");
		private float speed = 0;
		public int playerNumber = 1;
		public float runSpeed = 10f;
		public float walkSpeed = 5f;

		private void Start()
		{
			cam = Camera.main;
			playerSprite = GetComponent<Sprite>();
			if (playerNumber == 1)
				transform.Position = Vector2.Zero;
			if (playerNumber == 2)
				transform.Position = Vector2.Right * 100;
			speed = walkSpeed;
			rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			if (playerNumber == 1 && Input.KeyUp(SDL_Keycode.SDLK_LSHIFT))
			{
				speed = walkSpeed;
			}
			if (playerNumber == 1 && Input.KeyDown(SDL_Keycode.SDLK_LSHIFT))
			{
				speed = runSpeed;
			}
			if (playerNumber == 1 && Input.KeyPressed(SDL_Keycode.SDLK_d))
			{
				transform.Translate(Vector2.Right * speed * Time.deltaTime);
			}
			if (playerNumber == 1 && Input.KeyPressed(SDL_Keycode.SDLK_a))
			{
				transform.Translate(Vector2.Left * speed * Time.deltaTime);
			}
			if (playerNumber == 1 && Input.KeyUp(SDL_Keycode.SDLK_w))
			{
				rb.velocity += Vector2.Up * 15;
			}
			if (playerNumber == 1 && Input.KeyPressed(SDL_Keycode.SDLK_s))
			{
				transform.Translate(Vector2.Down * speed * Time.deltaTime);
			}

			if (playerNumber == 1 && Input.KeyUp(SDL_Keycode.SDLK_p))
			{
				s.PlayOnce();
			}

			if (playerNumber == 1 && Input.KeyPressed(SDL_Keycode.SDLK_UP))
			{
				playerSprite.scaleX += .5f * Time.deltaTime;
				playerSprite.scaleY += .5f * Time.deltaTime;
			}

			if (playerNumber == 1 && Input.KeyUp(SDL_Keycode.SDLK_DOWN))
			{
				playerSprite.scaleX = .1f;
				playerSprite.scaleY = .1f;
			}

			if (playerNumber == 1 && Input.KeyPressed(SDL_Keycode.SDLK_LEFT))
			{
				transform.rotationInDegrees--;
			}

			if (playerNumber == 1 && Input.KeyPressed(SDL_Keycode.SDLK_RIGHT))
			{
				transform.rotationInDegrees++;
			}

			if (playerNumber == 1 && Input.KeyUp(SDL_Keycode.SDLK_b))
			{
				playerSprite.drawBounds = !playerSprite.drawBounds;
			}

			//GameObject.Velocity = (new Vector2(x, y) + gravity) * Time.DeltaTime;
		}
	}
}