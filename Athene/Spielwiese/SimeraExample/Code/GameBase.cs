﻿using Lib.Visuals.Graphics;
using OpenTK;
using OpenTK.Input;
using System;
using Lib.Input;
using System.Collections.Generic;

namespace SimeraExample
{
	public class GameBase
	{
		private PreparedGameWindow Window { get; }
		private Input InputActions { get; set; }

		private SpriteAnimated AnimTest { get; set; }
		private SpriteStatic SpriteTest { get; set; }

		private Random Rand { get; set; }

		private List<Vector2> Objects { get; set; }
		private Vector2 PlayerPosition { get; set; }
		

        public GameBase()
		{
			InputActions = new Input();
			var layout = new InputLayout<Input>(InputActions);
			layout.AddMappingGamePad(0, pad => pad.ThumbSticks.Left, inp => inp.Vertical, inval => inval.Length > 0.01 ? inval.Y : 0);
			layout.AddMappingGamePad(0, pad => pad.ThumbSticks.Left, inp => inp.Horizontal, inval => inval.Length > 0.01 ? inval.X : 0);
			
			layout.AddMappingKeyboard(Key.Left, inp => inp.Horizontal, val => val ? -1 : 0);
			layout.AddMappingKeyboard(Key.Right, inp => inp.Horizontal, val => val ? 1 : 0);
			layout.AddMappingKeyboard(Key.Up, inp => inp.Vertical, val => val ? 1 : 0);
			layout.AddMappingKeyboard(Key.Down, inp => inp.Vertical, val => val ? -1 : 0);
			

			Window = new PreparedGameWindow();
			Rand = new Random();

			Window.Load += Window_Load;
			Window.UpdateFrame += Window_UpdateFrame;
			Window.RenderFrame += Window_RenderFrame;
            Window.Run(60);
           
        }

		private void Window_Load(object sender, EventArgs e)
		{

			AnimTest = new SpriteAnimated();
			AnimTest.AddAnimation("Pics/Worm/idle", 1000);
			AnimTest.AddAnimation("Pics/Worm/walk", 1000);
			AnimTest.StartAnimation("idle");

			SpriteTest = new SpriteStatic("Pics/trophy.png");

			Objects = new List<Vector2>();
			for (int i = 0; i < 1000; i++)
			{
				Objects.Add(new Vector2(Rand.Next(-50, 50), Rand.Next(-50, 50)));
			}
			PlayerPosition = Vector2.Zero;
		}

		private void Window_UpdateFrame(object sender, FrameEventArgs e)
		{
			//fake player
			var x = PlayerPosition.X + InputActions.Horizontal / 5;
			var y = PlayerPosition.Y + InputActions.Vertical / 5;
			PlayerPosition = new Vector2(x, y);

			//offset for the camera for a better view
			float maxOffset = 5.5f;

			x = PlayerPosition.X + (maxOffset * InputActions.Horizontal);
			y = PlayerPosition.Y + (maxOffset * InputActions.Vertical);

			//setting the camera
			Window.GameCamera.MoveTo(new Vector2(x, y));
		}

		private void Window_RenderFrame(object sender, FrameEventArgs e)
		{
			foreach (var obj in Objects)
			{
				AnimTest.Draw(obj, Vector2.One);
			}

			SpriteTest.Draw(PlayerPosition, Vector2.One);
		}
	}
}