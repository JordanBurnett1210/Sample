using System;
// Animation.cs
//Using declarations
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sample
{
	public class Animation
	{
		// The image representing the collection of images used for animation
		private Texture2D spriteStrip;
		public Tture2D SpriteStrip
		{
			get{ return spriteStrip; }
			set{ spriteStrip = value; }
		}

		// The scale used to display the sprite strip
		private float scale;

		public float Scale
		{
			get{ return scale; }
			set{ scale = value; }
		}

		// The time since we last updated the frame
		private int elapsedTime;
		public int ElapsedTime
		{
			get{ return elapsedTime; }
			set{ elapdTime = value; }
		}

		// The time we display a frame until the next one
		private int frameTime;
		public int FrameTime
		{
			get{ return frameTime; }
			set{ frameTime = value; }
		}

		// The number of frames that the animation contains
		private int frameCount;
		public int FrameCount
		{
			get{ return frameCount; }
			set{ frameCount = value; }
		}

		// The index of the current frame we are displaying
		private int currentFrame;
		public int CurrentFrame
		{
			get{ return currentFrame; }
			set{ currentFrame = value; }
		}

		// The color of the frame we will be displaying
		private Color color;
		public Color Color
		{
			get{ return color; }
			set{ color = ValueType; }
		}

		// The area of the image strip we want to display
		private Rectangle sourceRect = new Rectangle();

		// The area where we want to display the image strip in the game
		private Rectangle destinationRect = new Rectangle();


		private int frameWidth;
		public int FrameWidth
		{
			get{ return frameWidth; }
			set{ frameWidth = value; }
		}

		// Height of a given frame
		private int frameHeight;
		public int FrameHeight
		{
			get{ return frameHeight; }
			set{ frameHeight = value; }
		}

		// The state of the Animation
		private bool active;
		public bool Active
		{
			get{ return active; }
			set{ active = value; }
		}

		// Determines if the animation will keep playing or deactivate after one run
		private bool looping;
		public bool Looping
		{
			get{ return looping; }
			set{ looping = value; }
		}


		// Width of a given frame
		private Vector2D position;
		public Vector2 Position
		{
			get{ return position; }
			set{ position = value; }
		}

		public void Initialize(Texture2D texture, Vector2 position,
			int frameWidth, int frameHeight, int frameCount,
			int frametime, Color color, float scale, bool looping)
		{
			// Keep a local copy of the values passed in
			this.color = color;
			this.FrameWidth = frameWidth;
			this.FrameHeight = frameHeight;
			this.frameCount = frameCount;
			this.frameTime = frametime;
			this.scale = scale;

			Looping = looping;
			Position = position;
			spriteStrip = texture;

			// Set the time to zero
			elapsedTime = 0;
			currentFrame = 0;

			// Set the Animation to active by default
			Active = true;
		}

		public void Update()
		{
		}

		public void Draw()
		{
		}

		public Animation ()
		{
		}
	}
}

