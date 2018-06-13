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
using System.Linq;

namespace SchwiftyEngine.CoreModule
{
	/// <summary>
	/// Base class for everything attached to an Entity.
	/// </summary>
	public abstract class Component : Object
	{
		private const string _Awake = "Awake";

		private const string _End = "End";

		private const string _Start = "Start";

		private Entity _entity;
		private string _tag = "";

		internal Component(string name = "") : base(name)
		{
		}

		~Component()
		{
		}

		public Entity entity
		{
			get
			{
				return _entity;
			}
			internal set
			{
				_entity = value;
			}
		}

		/// <summary>
		/// The tag of the entity.
		/// </summary>
		/// <remarks>A tag can be used to identify an entity.</remarks>
		public string tag
		{
			get
			{
				return _tag;
			}

			set
			{
				_tag = value;
			}
		}

		/// <summary>
		/// The Transform attached to this entity.
		/// </summary>
		public Transform transform
		{
			get
			{
				return entity.transform;
			}
		}

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="parameters">The parameters.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public static void SendMessage(string methodName, params object[] parameters)
		{
		}

		/// <summary>
		/// Calls the method named methodName on every GameBehaviour in this entity or any of its children.
		/// </summary>
		/// <param name="methodName">Name of the method to call.</param>
		/// <param name="parameter">Optional parameter to pass to the method (can be any value).</param>
		/// <param name="options">
		/// Should an error be raised if the method does not exist for a given target object?
		/// </param>
		public void BroadcastMessage(string methodName, object parameter = null, SendMessageOptions options = SendMessageOptions.RequireReceiver)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Calls the method named methodName on every GameBehaviour in this entity or any of its children.
		/// </summary>
		/// <param name="methodName">Name of the method to call.</param>
		/// <param name="options">
		/// Should an error be raised if the method does not exist for a given target object?
		/// </param>
		public void BroadcastMessage(string methodName, SendMessageOptions options)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Is this entity tagged with tag?
		/// </summary>
		/// <param name="tag">the tag to compare.</param>
		public bool CompareTag(string tag)
		{
			return tag.Contains(tag);
		}

		/// <summary>
		/// Returns the component of Type T if the entity has one attached, null if it doesn't.
		/// </summary>
		/// <typeparam name="T">The type of Component to retrieve.</typeparam>
		/// <returns>A component of the matching type, if found.</returns>
		public T GetComponent<T>() where T : Component
		{
			List<T> cList = entity._components.OfType<T>().ToList();
			if (cList.Count != 0)
			{
				return cList[0];
			}
			return null;
		}

		/// <summary>
		/// Returns the component of Type T in the entity or any of its children using depth first search.
		/// </summary>
		/// <typeparam name="T">The type of Component to retrieve.</typeparam>
		/// <returns>A component of the matching type, if found.</returns>
		/// <remarks>https://www.wikiwand.com/en/Depth-first_search</remarks>
		public Component GetComponentInChilderen<T>() where T : Component
		{
			throw new NotImplementedException();
		}

		public Component GetComponentInParent()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="value">The value.</param>
		public void SendMessage(string methodName, object value)
		{
		}

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="value">The value.</param>
		/// <param name="options">The options.</param>
		public void SendMessage(string methodName, object value, SendMessageOptions options)
		{
		}

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="options">The options.</param>
		public void SendMessage(string methodName, SendMessageOptions options)
		{
		}

		/// <summary>
		/// Calls the method named methodName on every GameBehaviour in this entity and on every
		/// ancestor entity of the behaviour.
		/// </summary>
		/// <param name="methodName">Name of method to call.</param>
		/// <param name="options">
		/// Should an error be raised if the method does not exist on the target object?
		/// </param>
		public void SendMessageUpwards(string methodName, SendMessageOptions options)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Calls the method named methodName on every GameBehaviour in this entity and on every
		/// ancestor entity of the behaviour.
		/// </summary>
		/// <param name="methodName">Name of method to call.</param>
		/// <param name="value">Optional parameter value for the method.</param>
		/// <param name="options">
		/// Should an error be raised if the method does not exist on the target object?
		/// </param>
		public void SendMessageUpwards(string methodName, object value = null, SendMessageOptions options = SendMessageOptions.RequireReceiver)
		{
			throw new System.NotImplementedException();
		}
	}
}