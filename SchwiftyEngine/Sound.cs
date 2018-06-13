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

namespace SchwiftyEngine
{
	public class Sound
	{
		#region Private Fields

		private int channel = -1;
		private IntPtr sound;

		#endregion Private Fields

		#region Public Constructors

		public Sound(string path)
		{
			sound = AudioEngine.LoadSound(path);
		}

		#endregion Public Constructors

		#region Private Properties

		private bool IsPlaying
		{
			get
			{
				int i = AudioEngine.IsChannelPlaying(channel);
				if (i == 0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		#endregion Private Properties

		#region Public Methods

		/// <summary>
		/// Play sound in a loop on any free channel.
		/// </summary>
		/// <param name="loopCount">-1 for infinite loop. 0 for once. 1 for twice, etc...</param>
		public void PlayLoop(int loopCount)
		{
			if (channel > -1)
			{
				Stop();
			}
			channel = AudioEngine.PlaySound(sound, loopCount);
		}

		/// <summary>
		/// Play sound in a loop on chosen channel.
		/// </summary>
		/// <param name="channel">channel to play on.</param>
		/// <param name="loopCount">-1 for infinite loop. 0 for once. 1 for twice, etc...</param>
		public void PlayLoop(int channel, int loopCount)
		{
			if (channel > -1)
			{
				Stop();
			}
			channel = AudioEngine.PlaySound(channel, sound, loopCount);
		}

		/// <summary>
		/// Play sound once on any free channel.
		/// </summary>
		public void PlayOnce()
		{
			if (channel > -1)
			{
				Stop();
			}
			channel = AudioEngine.PlaySound(sound, 0);
		}

		/// <summary>
		/// Play sound once on chosen channel.
		/// </summary>
		/// <param name="channel">channel to play sound on.</param>
		public void PlayOnce(int channel)
		{
			if (channel > -1)
			{
				Stop();
			}
			channel = AudioEngine.PlaySound(channel, sound, 0);
		}

		public void Stop()
		{
			if (channel == -1)
			{
				Console.WriteLine("Sound has to play to be stopped!");
				return;
			}
			if (channel != -1 && IsPlaying)
			{
				AudioEngine.StopSound(channel);
			}
		}

		#endregion Public Methods
	}
}