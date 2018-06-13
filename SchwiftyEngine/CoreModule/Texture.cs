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
using System.IO;
using System.Linq;
using System.Text;
using static SDL2.SDL;

namespace SchwiftyEngine.CoreModule
{
	public class Texture
	{
		private int _height;
		private int _textureAccess;
		private uint _textureFormat;
		private IntPtr _texturePointer;
		private int _width;

		~Texture()
		{
			SDL_DestroyTexture(_texturePointer);
			_texturePointer = IntPtr.Zero;
		}

		public SDL_Rect DestinationRect
		{
			get; set;
		}

		public int Height
		{
			get
			{
				return _height;
			}

			set
			{
				_height = value;
			}
		}

		public int TextureAccess
		{
			get
			{
				return _textureAccess;
			}

			set
			{
				_textureAccess = value;
			}
		}

		public uint TextureFormat
		{
			get
			{
				return _textureFormat;
			}

			set
			{
				_textureFormat = value;
			}
		}

		public IntPtr TexturePointer
		{
			get
			{
				return _texturePointer;
			}
		}

		public int Width
		{
			get
			{
				return _width;
			}

			set
			{
				_width = value;
			}
		}

		private void GetTextureData()
		{
			SDL_QueryTexture(_texturePointer, out _textureFormat, out _textureAccess, out _width, out _height);
		}

		public void LoadTexture(string fileName)
		{
			if (!File.Exists(fileName))
			{
				throw new Exception("File " + fileName + "not found!");
			}
			if (_texturePointer != IntPtr.Zero)
			{
				SDL_DestroyTexture(_texturePointer);
			}
			_texturePointer = Engine.Window.Renderer.LoadTexture(fileName);
			GetTextureData();
		}
	}
}