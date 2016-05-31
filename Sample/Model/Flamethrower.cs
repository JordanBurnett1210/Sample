using System;

namespace Sample
{
	public class Flamethrower
	{

		private Texture2D texture;
		private int damage;
		private float fireSpeed;
		private Vector2 position;

		public Texture2D Texture
		{
			get{ return texture; }
			set{ texture = value; }
		}

		public int Damage
		{
			get{ return damage; }
			set{ damage = value; }
		}

		public Vector2 Position
		{
			get{ return position; }
			set{ position = value; }
		}

		public void Inialize(Texture2D texture, Vector2 position)
		{
			this.texture = texture;
			this.position = position;
			this.damage = 50000;
			this.fireSpeed = .2;
		}

		public void Update()
		{
			position.X += fireSpeed;
			position.Y += .1;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, null, Color.Red, position.Y * 3, Vector2.Zero, 2f, SpriteEffects.None, 0f);
		}
	}
}

