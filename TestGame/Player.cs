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
using static SDL2.SDL;

namespace TestGame
{
	public class Player : GameBehaviour
	{
		private Camera cam;
		private Vector2 gravity = new Vector2(0, 9.8f);
		private bool isGrounded = false;
		private Sprite playerSprite;
		private Sound s = new Sound(Resource.soundPath + "test.wav");
		private float speed = 60f;

		public bool IsGrounded
		{
			get
			{
				return isGrounded;
			}
			private set
			{
				isGrounded = value;
			}
		}

		private void Start()
		{
			cam = Camera.main;
			playerSprite = GetComponent<Sprite>();
		}

		private void Update()
		{
			if (Input.KeyUp(SDL_Keycode.SDLK_LSHIFT))
			{
				speed = 1000;
			}
			if (Input.KeyDown(SDL_Keycode.SDLK_LSHIFT))
			{
				speed = 240;
			}
			if (Input.KeyPressed(SDL_Keycode.SDLK_d))
			{
				transform.Translate(Vector2.Right * speed * Time.deltaTime);
			}
			if (Input.KeyPressed(SDL_Keycode.SDLK_a))
			{
				transform.Translate(Vector2.Left * speed * Time.deltaTime);
			}
			if (Input.KeyPressed(SDL_Keycode.SDLK_w))
			{
				transform.Translate(Vector2.Up * speed * Time.deltaTime);
			}
			if (Input.KeyPressed(SDL_Keycode.SDLK_s))
			{
				transform.Translate(Vector2.Down * speed * Time.deltaTime);
			}

			if (Input.KeyUp(SDL_Keycode.SDLK_p))
			{
				s.PlayOnce();
			}

			if (Input.KeyPressed(SDL_Keycode.SDLK_UP))
			{
				playerSprite.ScaleX += 5 * Time.deltaTime;
				playerSprite.ScaleY += 5 * Time.deltaTime;
			}

			if (Input.KeyUp(SDL_Keycode.SDLK_DOWN))
			{
				playerSprite.ScaleX = 1;
				playerSprite.ScaleY = 1;
			}

			if (Input.KeyUp(SDL_Keycode.SDLK_b))
			{
				playerSprite.DrawBounds = !playerSprite.DrawBounds;
			}

			//GameObject.Velocity = (new Vector2(x, y) + gravity) * Time.DeltaTime;
		}
	}
}