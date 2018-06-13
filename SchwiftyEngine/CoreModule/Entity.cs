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

using SchwiftyEngine.Extentions;
using System;
using System.Collections.Generic;

namespace SchwiftyEngine.CoreModule
{
	/// <summary>
	/// Basically a GameObject from Unity.
	/// </summary>
	public sealed class Entity : Object
	{
		private static Entity[] _entities = new Entity[0];
		private bool _activeSelf = false;
		private Transform _transform;
		internal Component[] _components = new Component[1];

		private Entity(string name) : base(name)
		{
			Init();
		}

		internal static Entity[] entities
		{
			get
			{
				return _entities;
			}

			private set
			{
				_entities = value;
			}
		}

		/// <summary>
		/// Defines whether the Entity is active in the Scene.
		/// </summary>
		public bool activeInHierarchy
		{
			get
			{
				return _activeSelf && parentsActive();
			}
		}

		public bool activeSelf
		{
			get
			{
				return _activeSelf;
			}

			set
			{
				_activeSelf = value;
			}
		}

		public Transform transform
		{
			get
			{
				return _transform;
			}
		}

		private void Init(params Component[] components)
		{
			_transform = new Transform();
			if (components != null)
			{
				_components = new Component[components.Length + 1];
				components.CopyTo(_components, 1);
			}
			_transform.entity = this;
			_components[0] = _transform;
		}

		private bool parentsActive()
		{
			return true;
		}

		internal static void CallMethodInComponents(string methodName)
		{
			foreach (Entity e in _entities)
			{
				foreach (Component c in e._components)
				{
					c.CallMethod(methodName);
				}
			}
		}

		/// <summary>
		/// Adds the entity to an array of entities in the game.
		/// </summary>
		/// <param name="entity">The entity to add.</param>
		/// <returns>The added entity.</returns>
		public static Entity AddEntity(string name)
		{
			Entity e = new Entity(name);
			_entities = _entities.Add(e);
			return e;
		}

		public T AddComponent<T>() where T : Component, new()
		{
			T c = new T();
			_components = _components.Add(c);
			c.entity = this;
			return c;
		}

		/// <summary>
		/// Calls the method named <paramref name="methodName"/> on every <see cref="GameBehaviour"/>
		/// in this <see cref="Entity"/> or any of its children.
		/// </summary>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="parameter">The parameter.</param>
		/// <param name="options">The options.</param>
		public void BroadcastMessage(string methodName, object parameter = null, SendMessageOptions options = SendMessageOptions.RequireReceiver)
		{
		}

		public void RemoveComponent(Component c)
		{
			if (_components.Contains(c))
			{
				_components = _components.Remove(c);
				c.entity = null;
			}
		}
	}
}