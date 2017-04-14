﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Simuals.Graphics
{
	/// <summary>
	/// Static spricte with no "texture" animation
	/// </summary>
	public class SpriteStatic
		: SpriteBase, ISprite
    {
		/// <summary>
		/// Texture that will be used for the sprite
		/// </summary>
		public Texture SpriteTexture { get; set; }

        /// <summary>
        /// Initialises a sprite
        /// </summary>
        public SpriteStatic(string path)
		{
			SpriteTexture = TextureManager.GetTexture(path);
		}

		/// <summary>
		/// Draws the sprite on the screen
		/// </summary>
		/// <param name="position"></param>
		/// <param name="scale"></param>
		public void Draw(Vector2 position, Vector2 scale)
		{
			base.Draw(position, scale, SpriteTexture);
		}
	}
}
