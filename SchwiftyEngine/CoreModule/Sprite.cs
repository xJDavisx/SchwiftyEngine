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
using static SDL2.SDL;
using Color = SDL2.SDL.SDL_Color;

namespace SchwiftyEngine.CoreModule
{
	public class Sprite : Behaviour
	{
		private Color _boundsColor = new Color(255, 255, 255, 255);
		private int _height;
		private Vector2 _origin;
		private Renderer _renderer;
		private float _scaleX = 1;
		private float _scaleY = 1;
		private Texture _texture;
		private int _width;

		~Sprite()
		{
		}

		public bool DrawBounds
		{
			get; set;
		}

		public int Height
		{
			get
			{
				return _height;
			}

			private set
			{
				_height = value;
			}
		}

		public Vector2 Origin
		{
			get
			{
				return _origin;
			}
		}

		public float ScaleX
		{
			get
			{
				return _scaleX;
			}

			set
			{
				_scaleX = value;
			}
		}

		public float ScaleY
		{
			get
			{
				return _scaleY;
			}

			set
			{
				_scaleY = value;
			}
		}

		public int Width
		{
			get
			{
				return _width;
			}

			private set
			{
				_width = value;
			}
		}

		private void Draw()
		{
			float zoom = Camera.main.zoom;
			//TODO: fix this shit!
			//this is the position and size of the image on the screen. use this to scale.
			SDL_Rect DestinationRect = new SDL_Rect() { x = (int)(transform.PositionScreen.X - _origin.X * _scaleX * zoom), y = (int)(transform.PositionScreen.Y - _origin.Y * _scaleY * zoom), w = (int)(48 * _scaleX * zoom), h = (int)(50 * _scaleY * zoom) };

			//this is the rect that determines what portion of the texture to show. think choosing an animation frame from a spritemap.
			SDL_Rect SourceRect = new SDL_Rect() { x = 0, y = 0, w = 48, h = 50 };

			_renderer.DrawTexture(
				_texture.TexturePointer,
				SourceRect,
				DestinationRect);
			if (DrawBounds)
			{
				_renderer.DrawRect(DestinationRect, _boundsColor);
			}
		}

		private void Start()
		{
			_renderer = Engine.Window.Renderer;
		}

		public void LoadTexture(string fileName)
		{
			_texture = new Texture();
			_texture.LoadTexture(fileName);

			_origin = new Vector2(48 * .5f, 50 * .5f);
		}
	}
}