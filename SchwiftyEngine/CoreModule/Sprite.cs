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
		private SDL_Rect _destinationRect;
		private int _height;
		private SDL_Point _origin;
		private Renderer _renderer;
		private float _scaleX = 1;
		private float _scaleY = 1;
		private SDL_Rect _sourceRect;
		private Texture _texture;
		private int _width;

		~Sprite()
		{
		}

		public bool drawBounds
		{
			get; set;
		}

		public int height
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

		public SDL_Point origin
		{
			get
			{
				return _origin;
			}
		}

		public float scaleX
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

		public float scaleY
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

		public int width
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
			int ppu = Camera.main.PixelsPerUnit;
			//this is the position and size of the image on the screen. use this to scale.
			_destinationRect = new SDL_Rect() { x = (int)(transform.PositionScreen.x - (_origin.x * ppu) * _scaleX), y = (int)(transform.PositionScreen.y - (_origin.y * ppu) * _scaleY), w = (int)(48 * ppu * _scaleX), h = (int)(50 * ppu * _scaleY) };
			SDL_Point realOrigin = new SDL_Point(_destinationRect.w / 2, _destinationRect.h / 2);
			_renderer.DrawTextureRotated(_texture.TexturePointer,
				ref _sourceRect,
				ref _destinationRect,
				transform.rotationInDegrees,
				ref realOrigin,
				SDL_RendererFlip.SDL_FLIP_NONE);

			if (drawBounds)
			{
				//_renderer.DrawRect(_destinationRect, _boundsColor);
				_renderer.DrawRectRotated(_destinationRect, transform.PositionScreen, transform.rotationInRadians, _boundsColor);
			}
		}

		internal override void ComponentAdded()
		{
			_renderer = Engine.Window.Renderer;
		}

		public void loadTexture(string fileName)
		{
			_texture = new Texture();
			_texture.LoadTexture(fileName);

			_origin = new SDL_Point((int)(48 * .5f), (int)(50 * .5f));
			//this is the rect that determines what portion of the texture to show. think choosing an animation frame from a spritemap.
			_sourceRect = new SDL_Rect() { x = 0, y = 0, w = 48, h = 50 };
		}
	}
}