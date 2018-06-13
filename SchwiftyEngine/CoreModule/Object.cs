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
using System.Reflection;

namespace SchwiftyEngine.CoreModule
{
	/// <summary>
	/// </summary>
	public abstract class Object
	{
		private const string _OnDestroy = "OnDestroy";
		private static int idPool = 0;

		public Object(string name = "", HideFlags flags = HideFlags.None)
		{
			Initialize(name, flags);
		}

		~Object()
		{
		}

		private static int IDPool
		{
			get
			{
				idPool++;
				return idPool;
			}
		}

		public HideFlags hideFlags
		{
			get; internal set;
		}

		/// <summary>
		/// The instance id of the object.
		/// </summary>
		public int instanceID
		{
			get;
			private set;
		}

		/// <summary>
		/// The name of the object.
		/// </summary>
		public string name
		{
			get;
			protected set;
		}

		private void Initialize(string name, HideFlags flags)
		{
			instanceID = IDPool;
			this.name = name == "" ? GetType().Name + instanceID : name;
			hideFlags = flags;
		}

		/// <summary>
		/// Calls a method.
		/// </summary>
		/// <param name="methodName">Name of the method.</param>
		/// <returns></returns>
		internal object CallMethod(string methodName)
		{
			MethodInfo mInfo = GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			object result = null;
			if (mInfo == null)
			{
				return null;
			}
			ParameterInfo[] parameterInfos = mInfo.GetParameters();

			if (parameterInfos.Length == 0)
			{
				result = mInfo.Invoke(this, null);
			}
			else
			{
				object[] parametersArray = new object[parameterInfos.Length];
				for (int i = 0; i < parameterInfos.Length; i++)
				{
					Type t = parameterInfos[i].ParameterType;
					if (t == typeof(string))
					{
						parametersArray[i] = "parameter is a string!";
					}
				}

				result = mInfo.Invoke(this, parametersArray);
			}
			return result;
		}

		/// <summary>
		/// Removes an entity, component, or asset.
		/// </summary>
		/// <remarks>
		/// The object obj will be destroyed now or if a time is specified t seconds from now. If obj
		/// is a Component it will remove the component from the GameObject and destroy it. If obj is
		/// a GameObject it will destroy the GameObject, all its components and all transform
		/// children of the GameObject. Actual object destruction is always delayed until after the
		/// current Update loop, but will always be done before rendering.
		/// </remarks>
		public static void Destroy(Object obj, float time = 0.0f)
		{
			obj.CallMethod(_OnDestroy);
			if (obj.GetType() == typeof(Component))
			{
				Component c = obj as Component;
				c.entity.RemoveComponent(c);
			}
			else if (obj.GetType() == typeof(Entity))
			{
			}
		}

		/// <summary>
		/// Makes the object target not be destroyed automatically when loading a new scene.
		/// </summary>
		/// <param name="target">The object which is not destroyed on scene change.</param>
		public static void DontDestroyOnLoad(Object target)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns the first active loaded object of Type T.
		/// </summary>
		/// <returns>
		/// This returns the Object that matches the specified type. It returns null if no Object
		/// matches the type.
		/// </returns>
		public static T FindObjectOfType<T>() where T : Object
		{
			if (typeof(GameBehaviour).IsAssignableFrom(typeof(T)))
			{
				foreach (Entity e in Entity.entities)
				{
					foreach (Component c in e._components)
					{
						if (c.GetType() == typeof(T))
						{
							return c as T;
						}
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Returns a list of all active loaded objects of Type T.
		/// </summary>
		/// <returns>The array of objects found matching the type specified.</returns>
		public static T[] FindObjectsOfType<T>() where T : Object
		{
			List<T> objects = new List<T>();
			if (typeof(GameBehaviour).IsAssignableFrom(typeof(T)))
			{
				foreach (Entity e in Entity.entities)
				{
					objects.AddRange(e._components.OfType<T>());
				}
			}
			if(objects.Count > 0)
			{
				return objects.ToArray();
			}
			return null;
		}

		public static implicit operator bool(Object o)
		{
			return !(o is null);
		}

		/// <summary>
		/// Clones the object original and returns the clone.
		/// </summary>
		/// <param name="original">An existing object that you want to make a copy of.</param>
		/// <returns>The instantiated clone.</returns>
		public static Object Instantiate(Object original)
		{
			throw new NotImplementedException();
			if (original.GetType() == typeof(Entity))
			{
			}
		}

		/// <summary>
		/// Clones the object original and returns the clone.
		/// </summary>
		/// <param name="original">An existing object that you want to make a copy of.</param>
		/// <param name="parent">Parent that will be assigned to the new object.</param>
		/// <returns>The instantiated clone.</returns>
		public static Object Instantiate(Object original, Transform parent)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Clones the object original and returns the clone.
		/// </summary>
		/// <param name="original">An existing object that you want to make a copy of.</param>
		/// <param name="parent">Parent that will be assigned to the new object.</param>
		/// <param name="instantiateInWorldSpace">
		/// Pass true when assigning a parent Object to maintain the world position of the Object,
		/// instead of setting its position relative to the new parent. Pass false to set the
		/// Object's position relative to its new parent.
		/// </param>
		/// <returns>The instantiated clone.</returns>
		public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Clones the object original and returns the clone.
		/// </summary>
		/// <param name="original">An existing object that you want to make a copy of.</param>
		/// <param name="position">Position for the new object.</param>
		/// <param name="rotationDeg">Orientation of the new object.</param>
		/// <returns>The instantiated clone.</returns>
		public static Object Instantiate(Object original, Vector2 position, float rotationDeg)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Clones the object original and returns the clone.
		/// </summary>
		/// <param name="original">An existing object that you want to make a copy of.</param>
		/// <param name="position">Position for the new object.</param>
		/// <param name="rotationDeg">Orientation of the new object.</param>
		/// <param name="parent">Parent that will be assigned to the new object.</param>
		/// <returns>The instantiated clone.</returns>
		public static Object Instantiate(Object original, Vector2 position, float rotationDeg, Transform parent)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Compares if two objects refer to a different object.
		/// </summary>
		/// <returns>True if the two objects refer to a different object.</returns>
		public static bool operator !=(Object x, Object y)
		{
			if (x is null)
			{
				return !(y is null);
			}
			return !x.Equals(y);
		}

		public static bool operator ==(Object x, Object y)
		{
			if (x is null)
			{
				return y is null;
			}
			return x.Equals(y);
		}

		public override bool Equals(object obj)
		{
			var @object = obj as Object;
			return @object != null &&
				   instanceID == @object.instanceID;
		}

		public override int GetHashCode()
		{
			return 1862927415 + instanceID.GetHashCode();
		}

		/// <summary>
		/// Returns the instance id of the object.
		/// </summary>
		/// <returns>The instance id of the object. It is always guaranteed to be unique.</returns>
		public int GetInstanceID()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Returns the name of the Object.
		/// </summary>
		public override string ToString()
		{
			return name;
		}
	}
}