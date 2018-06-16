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
using static SDL2.SDL;
using Color = SDL2.SDL.SDL_Color;

namespace SchwiftyEngine
{
	public class Renderer
	{
		private SDL_BlendMode _blendMode;
		private Color _drawColor = new Color(255, 255, 255, 255);
		private IntPtr _rendererPointer = IntPtr.Zero;
		private Window _window;
		private SDL_RendererFlags flags;
		private int index;
		internal static Color _clearColor = new Color(0, 0, 0, 255);

		internal Renderer(Window window, int index = -1, SDL_RendererFlags flags = SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC)
		{
			_window = window;
			this.index = index;
			this.flags = flags;
			Create();
		}

		~Renderer()
		{
			Console.WriteLine("Renderer destructor called!");
			Destroy();
		}

		internal IntPtr RendererPointer
		{
			get
			{
				return _rendererPointer;
			}

			private set
			{
				_rendererPointer = value;
			}
		}

		/// <summary>
		/// Gets or sets the blend mode for the renderer.
		/// </summary>
		/// <value>The blend mode flag.</value>
		public SDL_BlendMode BlendMode
		{
			get
			{
				return _blendMode;
			}
			set
			{
				_blendMode = value;
				SDL_SetRenderDrawBlendMode(_rendererPointer, _blendMode);
			}
		}

		/// <summary>
		/// Gets or sets the color that the <see cref="Renderer"/> will draw with.
		/// </summary>
		/// <value>The color used when drawing.</value>
		public Color DrawColor
		{
			get
			{
				return _drawColor;
			}
			set
			{
				if (_drawColor != value)
				{
					_drawColor = value;
					SDL_SetRenderDrawColor(_rendererPointer, _drawColor);
				}
			}
		}

		public SDL_RendererFlags Flags
		{
			get
			{
				return flags;
			}

			internal set
			{
				flags = value;
			}
		}

		public int Index
		{
			get
			{
				return index;
			}

			internal set
			{
				index = value;
			}
		}

		private void Create()
		{
			if (_rendererPointer != IntPtr.Zero)
			{
				SDL_DestroyRenderer(_rendererPointer);
			}
			_rendererPointer = SDL_CreateRenderer(_window.WindowPointer, index, flags);
			BlendMode = SDL_BlendMode.SDL_BLENDMODE_BLEND;
		}

		internal void Clear()
		{
			SDL_SetRenderDrawColor(_rendererPointer, _clearColor);
			SDL_RenderClear(_rendererPointer);
			SDL_SetRenderDrawColor(_rendererPointer, DrawColor);
		}

		internal void Destroy()
		{
			Console.WriteLine("Renderer Destroy method called!");
			if (_rendererPointer == IntPtr.Zero)
				return;
			SDL_DestroyRenderer(_rendererPointer);
			_window = null;
		}

		internal void DrawTexture(IntPtr texture, SDL_Rect sourceRect, SDL_Rect destinationRect)
		{
			SDL_RenderCopy(_rendererPointer, texture, ref sourceRect, ref destinationRect);
		}

		internal void DrawTextureRotated(IntPtr texture, ref SDL_Rect sourceRect, ref SDL_Rect destinationRect, float angle, ref SDL_Point center, SDL_RendererFlip flip)
		{
			SDL_RenderCopyEx(_rendererPointer,
				texture,
				ref sourceRect,
				ref destinationRect,
				angle,
				ref center,
				flip);
		}

		internal IntPtr LoadTexture(string fileName)
		{
			return SDL_image.IMG_LoadTexture(_rendererPointer, fileName);
		}

		internal void Render()
		{
			SDL_RenderPresent(_rendererPointer);
		}

		/// <summary>
		/// Draws a line from the <paramref name="start"/><see cref="Vector2"/> to the <paramref
		/// name="end"/><see cref="Vector2"/> with the <see cref="SDL_Color"/><paramref
		/// name="color"/>. Automatically switches back to the <see cref="SDL_Color"/> set in <see
		/// cref="DrawColor"/> after the line is drawn.
		/// </summary>
		/// <param name="start">The start vector.</param>
		/// <param name="end">The end vector.</param>
		/// <param name="color">The color of the line.</param>
		public void DrawLine(Vector2 start, Vector2 end, Color color)
		{
			SDL_SetRenderDrawColor(_rendererPointer, color);
			SDL_RenderDrawLine(_rendererPointer, (int)start.x, (int)start.y, (int)end.x, (int)end.y);
			SDL_SetRenderDrawColor(_rendererPointer, DrawColor);
		}

		/// <summary>
		/// Draws a line from the <paramref name="start"/><see cref="Vector2"/> to the <paramref
		/// name="end"/><see cref="Vector2"/> with the <see cref="SDL_Color"/> set in <see cref="DrawColor"/>.
		/// </summary>
		/// <param name="start">The start vector.</param>
		/// <param name="end">The end vector.</param>
		public void DrawLine(Vector2 start, Vector2 end)
		{
			SDL_RenderDrawLine(_rendererPointer, (int)start.x, (int)start.y, (int)end.x, (int)end.y);
		}

		public int DrawRect(SDL_Rect rect)
		{
			return SDL_RenderDrawRect(_rendererPointer, ref rect);
		}

		public int DrawRect(SDL_Rect rect, Color color)
		{
			SDL_SetRenderDrawColor(_rendererPointer, color);
			int rValue = SDL_RenderDrawRect(_rendererPointer, ref rect);
			SDL_SetRenderDrawColor(_rendererPointer, DrawColor);
			return rValue;
		}

		public void DrawRectRotated(SDL_Rect rect, Vector2 origin, float angleInRadians, Color color)
		{
			SDL_Point topLeft = Vector2.RotateAroundPoint(new Vector2(rect.x, rect.y), angleInRadians, origin).ToSDL_Point();
			SDL_Point topRight = Vector2.RotateAroundPoint(new Vector2(rect.x + rect.w, rect.y), angleInRadians, origin).ToSDL_Point();
			SDL_Point bottomLeft = Vector2.RotateAroundPoint(new Vector2(rect.x, rect.y + rect.h), angleInRadians, origin).ToSDL_Point();
			SDL_Point bottomRight = Vector2.RotateAroundPoint(new Vector2(rect.x + rect.w, rect.y + rect.h), angleInRadians, origin).ToSDL_Point();
			SDL_Point[] points = new SDL_Point[]
			{
				topLeft,topRight,bottomRight,bottomLeft, topLeft
			};

			SDL_SetRenderDrawColor(_rendererPointer, color);
			SDL_RenderDrawLines(_rendererPointer, points, 5);

			SDL_SetRenderDrawColor(_rendererPointer, DrawColor);
		}
	}
}