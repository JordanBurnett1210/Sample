using System;
using Microsoft.Xna.Famework;
using Microsoft.Xna.
using Sample.View;

namespace Sample.Model
{
	public class Player
	{
		// Animation representing the player
		public Animation PlayerAnimation;
		private int score;
		private bool active;
		private int health;

		public Texture2D PlayerTexture;

		public Vector2 Position;

		public bool Active 
		{
			get{ return active; }
			set{ active = value; }
		}

		public int Health
		{
			get{ return health; }
			set{ health = value; }
		}
			
		public int Width 
		{
			get{ return PlayerTexture.Width; }
		}

		public int Height 
		{
			get{ return PlayerTexture.Height; }
		}

		public int Score 
		{
			get { return score; }
			set { score = value; }
		}

		public void Initialize(Animation animation, Vector2 position)
		{
			this.PlayerAnimation = animation;

			// Set the starting position of the player around the middle of the screen and to the back
			this.Position = position;

			// Set the player to be active
			this.Active = true;

			// Set the player health
			this.Health = 100;
		}

		// Update the player animation
		public void Update(GameTime gameTime)
		{
			PlayerAnimation.Position = Position;
			PlayerAnimation.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(PlayerTexture, Position, null, ConsoleColor.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}
	}
}

