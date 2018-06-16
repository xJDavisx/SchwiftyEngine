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
using System.Collections.Generic;
using System;
using SchwiftyEngine.CoreModule;

using SDL2;
using System;
using System.Collections.Generic;

using static SDL2.SDL;

namespace SchwiftyEngine.UI
{
	public class RenderedText : Behaviour
	{
		private SDL_Color color;
		private string fontName;
		private IntPtr fontTexture;
		private IntPtr surface;
		private string text;

		public static Dictionary<string, Font> Fonts = new Dictionary<string, Font>();

		public RenderedText(string text, string fontName) : base()
		{
			this.fontName = fontName;
			if (!Fonts.ContainsKey(fontName))
			{
				throw new Exception("Font name " + fontName + " does not exist in the collection! Make sure to call RenderedText.AddFont() before creating a RenderedText object!");
			}
			color = new SDL_Color(255, 255, 255, 255);
			this.Text = text;
		}

		public SDL_Color Color
		{
			get
			{
				return color;
			}

			set
			{
				color = value;
				Refresh();
			}
		}

		public SDL_Color Color1
		{
			get
			{
				return color;
			}

			set
			{
				color = value;
			}
		}

		public string Text
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
				Refresh();
			}
		}

		private void Refresh()
		{
			surface = SDL_ttf.TTF_RenderText_Blended_Wrapped(Fonts[fontName].FontPointer, text, color, 800);

			SDL_DestroyTexture(fontTexture);
			fontTexture = SDL_CreateTextureFromSurface(Engine.Window.Renderer.RendererPointer, surface);
			//sprite = new Sprite(fontTexture);
			SDL_FreeSurface(surface);
		}

		internal override void ComponentAdded()
		{
		}

		public static void AddFont(string name, Font f)
		{
			if (!Fonts.ContainsKey(name))
			{
				Fonts.Add(name, f);
			}
		}

		public static void RemoveFont(string name)
		{
			if (Fonts.ContainsKey(name))
			{
				Fonts[name].Dispose();
				Fonts.Remove(name);
			}
		}

		public override string ToString()
		{
			return text;
		}
	}
}