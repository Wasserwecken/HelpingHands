﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Input.Mapping;
using Lib.Level.Base;
using Lib.Tools;
using Lib.Visuals.Graphics;
using OpenTK;

namespace Lib.Level.Items
{
    public class Checkpoint : LevelItemBase, IDrawable, IInteractable, IIntersectable
    {

        /// <summary>
        /// Destination of the checkpoint
        /// </summary>
        public Vector2 DestinationPosition { get; set; }

        /// <summary>
        /// Range where the checkpoint will be react
        /// </summary>
        public float InteractionRadius { get; set; }


        
        
        /// <summary>
        /// Initialises a checkpoint
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="destinationPosition"></param>
        /// <param name="sprite"></param>
        public Checkpoint(Vector2 startPosition, Vector2 destinationPosition, ISprite sprite)
            : base(startPosition, new Vector2(0.75f, 0.75f))
        {
            DestinationPosition = destinationPosition;
            InteractionRadius = 1f;
            Sprite = sprite;
        }


        /// <summary>
        /// Draws the checkpoint on the screen
        /// </summary>
        public void Draw()
        {
            Sprite.Draw(HitBox.Position, new Vector2(0.8f));
        }


        /// <summary>
        /// Interacts with incoming items
        /// </summary>
        /// <param name="interactableItem"></param>
        public void HandleInteractions(List<IInteractable> interactableItem) { }

        /// <summary>
        /// Reacts to intersections with items
        /// </summary>
        /// <param name="intersectingItems"></param>
        public void HandleCollisions(List<IIntersectable> intersectingItems) { }
    }
}
