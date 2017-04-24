﻿using OpenTK;

namespace Lib.LevelLoader.LevelItems
{
	public class LevelItemPhysicBodyProperties
	{
		/// <summary>
		/// Interia of the object. 1 is for instant movment, as higher the value more "sliding"
		/// </summary>
		public Vector2 Momentum { get; set; }

		/// <summary>
		/// Mass of the object
		/// </summary>
		public float Mass { get; set; }

        /// <summary>
        /// Movement speed of the object in the environment
        /// </summary>
        public float MovementSpeed { get; set; }

	    /// <summary>
	    /// Initialises the properties
	    /// </summary>
	    /// <param name="momentumHorizontal"></param>
	    /// <param name="momentumVertical"></param>
	    /// <param name="movementSpeed"></param>
	    /// <param name="mass"></param>
	    public LevelItemPhysicBodyProperties(float momentumHorizontal, float momentumVertical, float movementSpeed, float mass)
		{
			Momentum = new Vector2(momentumHorizontal, momentumVertical);
			Mass = mass;
            MovementSpeed = movementSpeed;
		}
	}
}
