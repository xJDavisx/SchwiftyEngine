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

using SchwiftyEngine.CoreModule;

namespace SchwiftyEngine.Physics2DModule
{
	/// <summary>
	/// </summary>
	/// <seealso cref="SchwiftyEngine.CoreModule.Component"/>
	public class Rigidbody2D : Component
	{
		private float _angularDrag;
		private float _angularVelocity;
		private int _attachedColliderCount;
		private RigidbodyType2D _bodyType;
		private Vector2 _centerOfMass;
		private Collider2D _collider;
		private CollisionDetectionMode2D _collisionDetectionMode;
		private RigidbodyConstraints2D _constraints = RigidbodyConstraints2D.None;
		private float _drag;
		private bool _freezeRotation = false;
		private float _gravityScale = 1f;
		private float _inertia;
		private bool _isKinematic = false;
		private float _mass = 1f;
		private bool _simulated;
		private RigidbodySleepMode2D _sleepMode = RigidbodySleepMode2D.StartAwake;
		private bool _useAutoMass = false;
		private bool _useFullKinematicContacts = false;
		private Vector2 _velocity = Vector2.Zero;

		/// <summary>
		/// Coefficient of angular drag.
		/// </summary>
		/// <value>Coefficient of angular drag.</value>
		/// <remarks>
		/// Drag is the tendency of an object to slow down due to friction with the air or water that
		/// surrounds it. The angular drag applies to rotational movement and is set up separately
		/// from the linear drag that affects positional movement. A higher value of angular drag
		/// will cause an object's rotation to come to rest more quickly following a collision or torque.
		/// </remarks>
		/// <seealso cref="angularVelocity"/>
		public float angularDrag
		{
			get
			{
				return _angularDrag;
			}

			set
			{
				_angularDrag = value;
			}
		}

		/// <summary>
		/// Angular velocity in degrees per second.
		/// </summary>
		/// <value>Angular velocity in degrees per second.</value>
		/// <remarks>
		/// Unlike a 3D Rigidbody, a Rigidbody2D can only rotate around one axis (perpendicular to
		/// the plane) so the angular velocity is just a float value rather than a vector. Typically,
		/// the value of this property is not set directly but rather by applying torques to the
		/// rigidbody. The angular velocity will also decrease automatically under the effect of
		/// angular drag.
		/// </remarks>
		/// <seealso cref="angularDrag"/>
		public float angularVelocity
		{
			get
			{
				return _angularVelocity;
			}

			set
			{
				_angularVelocity = value;
			}
		}

		/// <summary>
		/// Gets or sets the attached collider count.
		/// </summary>
		/// <value>The attached collider count.</value>
		public int attachedColliderCount
		{
			get
			{
				return _attachedColliderCount;
			}

			set
			{
				_attachedColliderCount = value;
			}
		}

		/// <summary>
		/// The physical behaviour type of the Rigidbody2D.
		/// </summary>
		/// <value>The physical behaviour type of the Rigidbody2D.</value>
		/// <seealso cref="RigidbodyType2D"/>
		public RigidbodyType2D bodyType
		{
			get
			{
				return _bodyType;
			}

			set
			{
				_bodyType = value;
			}
		}

		/// <summary>
		/// Gets or sets the center of mass.
		/// </summary>
		/// <value>The center of mass.</value>
		public Vector2 CenterOfMass
		{
			get
			{
				return _centerOfMass;
			}

			set
			{
				_centerOfMass = value;
			}
		}

		public Collider2D Collider
		{
			get
			{
				return _collider;
			}

			set
			{
				_collider = value;
			}
		}

		/// <summary>
		/// The method used by the physics engine to check if two objects have collided.
		/// </summary>
		/// <value>The collision detection mode.</value>
		/// <seealso cref="CollisionDetectionMode2D"/>
		public CollisionDetectionMode2D collisionDetectionMode
		{
			get
			{
				return _collisionDetectionMode;
			}

			set
			{
				_collisionDetectionMode = value;
			}
		}

		/// <summary>
		/// Controls which degrees of freedom are allowed for the simulation of this <see cref="Rigidbody2D"/>.
		/// </summary>
		/// <value>The constraints.</value>
		/// <remarks>
		/// By default this is set to RigidbodyConstraints2D.None, allowing rotation and movement
		/// along all axes. In some cases, you may want to constrain a Rigidbody2D to only move or
		/// rotate along some axes.You can use the bitwise OR operator to combine multiple constraints.
		/// </remarks>
		/// <seealso cref="RigidbodyConstraints2D"/>
		public RigidbodyConstraints2D constraints
		{
			get
			{
				return _constraints;
			}

			set
			{
				_constraints = value;
			}
		}

		/// <summary>
		/// Coefficient of drag.
		/// </summary>
		/// <value>The drag.</value>
		/// <remarks>
		/// Drag is the tendency of an object to slow down due to friction with the air or water that
		/// surrounds it. The linear drag applies to positional movement and is set up separately
		/// from the angular drag that affects rotational movement. A higher value of drag will cause
		/// an object's rotation to come to rest more quickly following a collision or force.
		/// </remarks>
		public float drag
		{
			get
			{
				return _drag;
			}

			set
			{
				_drag = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [freeze rotation].
		/// </summary>
		/// <value><c>true</c> if [freeze rotation]; otherwise, <c>false</c>.</value>
		public bool freezeRotation
		{
			get
			{
				return _freezeRotation;
			}

			set
			{
				_freezeRotation = value;
			}
		}

		/// <summary>
		/// The degree to which this object is affected by gravity.
		/// </summary>
		/// <value>The gravity scale.</value>
		/// <remarks>
		/// In 2D physics, the gravity is a global setting in the Physics2D class but you can also
		/// control the proportion of that gravity applied to each object individually using
		/// gravityScale. For example, it may be easier to implement a flying character by turning
		/// off its gravity rather than simulating the forces that keep it aloft.
		/// </remarks>
		/// <seealso cref="Physics2D.gravity"/>
		public float gravityScale
		{
			get
			{
				return _gravityScale;
			}

			set
			{
				_gravityScale = value;
			}
		}

		/// <summary>
		/// The rigidBody rotational inertia.
		/// </summary>
		/// <value>The inertia.</value>
		public float inertia
		{
			get
			{
				return _inertia;
			}

			internal set
			{
				_inertia = value;
			}
		}

		/// <summary>
		/// Should this rigidbody be taken out of physics control?
		/// </summary>
		/// <value><c>true</c> if this rigidbody is kinematic; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// If this property is set to true then the rigidbody will stop reacting to collisions and
		/// applied forces. This can be useful when an object should usually be controlled
		/// "kinematically" (ie, non-physically) but then sometimes needs physics for realism. For
		/// example, a human character is usually not implemented using physics but may sometimes be
		/// thrown through the air and collide with objects as the result of an impact or explosion.
		/// </remarks>
		public bool isKinematic
		{
			get
			{
				return _isKinematic;
			}

			set
			{
				_isKinematic = value;
			}
		}

		/// <summary>
		/// Mass of the <see cref="Rigidbody2D"/>.
		/// </summary>
		/// <remarks>
		/// The mass is given in arbitrary units, but the basic physical principles of mass apply.
		/// Newton's classic equation `force = mass x acceleration`, demonstrates that the larger an
		/// object's mass, the more force it requires to accelerate it to a given velocity. Mass also
		/// affects momentum, which is significant during collisions; an object with large mass will
		/// be moved less by a collision than an object with lower mass.
		/// </remarks>
		public float mass
		{
			get
			{
				return _mass;
			}

			set
			{
				_mass = value;
			}
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public Vector2 position
		{
			get
			{
				return transform.Position;
			}

			set
			{
				transform.Position = value;
			}
		}

		/// <summary>
		/// Gets or sets the rotation of this <see cref="Rigidbody2D"/> in degrees.
		/// </summary>
		/// <value>The rotation.</value>
		public float rotation
		{
			get
			{
				return transform.rotationInDegrees;
			}

			set
			{
				transform.rotationInDegrees = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Rigidbody2D"/> is simulated.
		/// </summary>
		/// <value><c>true</c> if simulated; otherwise, <c>false</c>.</value>
		public bool simulated
		{
			get
			{
				return _simulated;
			}

			set
			{
				_simulated = value;
			}
		}

		/// <summary>
		/// Gets or sets the sleep mode.
		/// </summary>
		/// <value>The sleep mode.</value>
		public RigidbodySleepMode2D sleepMode
		{
			get
			{
				return _sleepMode;
			}

			set
			{
				_sleepMode = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [use automatic mass].
		/// </summary>
		/// <value><c>true</c> if [use automatic mass]; otherwise, <c>false</c>.</value>
		public bool useAutoMass
		{
			get
			{
				return _useAutoMass;
			}

			set
			{
				_useAutoMass = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [use full kinematic contacts].
		/// </summary>
		/// <value><c>true</c> if [use full kinematic contacts]; otherwise, <c>false</c>.</value>
		public bool useFullKinematicContacts
		{
			get
			{
				return _useFullKinematicContacts;
			}

			set
			{
				_useFullKinematicContacts = value;
			}
		}

		/// <summary>
		/// Linear velocity of the rigidbody.
		/// </summary>
		/// <value>The velocity.</value>
		/// <remarks>
		/// The velocity is specified as a <see cref="Vector2"/> with components in the X and Y
		/// directions. The value is not usually set directly but rather by using forces. Set <see
		/// cref="drag"/> to 0 to stop the gradual decay of the velocity.
		/// </remarks>
		/// <seealso cref="drag"/>
		/// <seealso cref="angularVelocity"/>
		public Vector2 velocity
		{
			get
			{
				return _velocity;
			}

			set
			{
				_velocity = value;
			}
		}

		internal override void ComponentAdded()
		{
			Physics2D._rigidBodies.Add(this);
		}

		internal void UpdatePhysics()
		{
			//TODO: Fix Physics!
			_velocity += Physics2D.gravity * Time.deltaTime;
			if ((transform.Position).y < 0)
			{
				_velocity = new Vector2(_velocity.x, 0);
				transform.Position = new Vector2(transform.Position.x, 0);
			}
			transform.Position += _velocity;
		}
	}
}