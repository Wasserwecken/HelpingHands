﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SimeraExample
{
	public class Camera
	{
		/// <summary>
		/// Current position of the camera
		/// </summary>
		public Vector2 Position { get; set; }

		/// <summary>
		/// Rotation of the camera, negative values gonne rotate clockwise
		/// </summary>
		public float Rotation { get; set; }

		/// <summary>
		/// Zoom of the camera. 1 is standard
		/// </summary>
		public float Zoom { get; set; }
		
		/// <summary>
		/// Initialises the view
		/// </summary>
		public Camera(Vector2 startPosition, float startZoom, float startRotation)
		{
			Position = startPosition;
			Rotation = startRotation;
			Zoom = startZoom;
		}

		/// <summary>
		/// Applies the proteries of the view to the camera
		/// </summary>
		public void ApplyTransform(int axisSize, float aspectRatio)
		{
			var transform = Matrix4.Identity;

			transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-Position.X / aspectRatio, -Position.Y, 0));
			transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ(-Rotation));
			transform = Matrix4.Mult(transform, Matrix4.CreateScale(Zoom, Zoom, 1));

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			GL.MultMatrix(ref transform);
			GL.Ortho(-axisSize * aspectRatio, axisSize * aspectRatio, -axisSize, axisSize, -1f, 1f);
		}
	}
}
