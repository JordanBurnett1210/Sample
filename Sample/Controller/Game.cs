using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Sample.Model;
using Sample.View;

namespace Sample
{
	public class Game : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private Player player;
		// Keyboard states used to determine key presses
		private KeyboardState currentKeyboardState;
		private KeyboardState previousKeyboardState;

		// Gamepad states used to determine button presses
		private GamePadState currentGamePadState;
		private GamePadState previousGamePadState;

		private float playerMoveSpeed;

		private ParallaxingBackground bgLayer1;
		private ParallaxingBackground bgLayer2;

		// A movement speed for the player
		float playerMoveSpeed;

		public Game()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
		}


		protected override void Initialize()
		{
			player = new Player ();

			// Set a constant player move speed
			playerMoveSpeed = 8.0f;

			//Enable the FreeDrag gesture.
			TouchPanel.EnabledGestures = GestureType.FreeDrag;

			base.Initialize ();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);

			// Load the player resources
			// Load the player resources
			Animation playerAnimation = new Animation();
			Texture2D playerTexture = Content.Load<Texture2D>("shipAnimation");
			playerAnimation.Initialize(playerTexture, Vector2.Zero, 115, 69, 8, 30, Color.White, 1f, true);

			Vector2 playerPosition = new Vector2 (GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y
				+ GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
			player.Initialize(playerAnimation, playerPosition);


		}

		private void UpdatePlayer(GameTime gameTime)
		{

			// Get Thumbstick Controls
			player.Position.X += currentGamePadState.ThumbSticks.Left.X *playerMoveSpeed;
			player.Position.Y -= currentGamePadState.ThumbSticks.Left.Y *playerMoveSpeed;

			// Use the Keyboard / Dpad
			if (currentKeyboardState.IsKeyDown(Keys.Left) ||
				currentGamePadState.DPad.Left == ButtonState.Pressed)
			{
				player.Position.X -= playerMoveSpeed;
			}
			if (currentKeyboardState.IsKeyDown(Keys.Right) ||
				currentGamePadState.DPad.Right == ButtonState.Pressed)
			{
				player.Position.X += playerMoveSpeed;
			}
			if (currentKeyboardState.IsKeyDown(Keys.Up) ||
				currentGamePadState.DPad.Up == ButtonState.Pressed)
			{
				player.Position.Y -= playerMoveSpeed;
			}
			if (currentKeyboardState.IsKeyDown(Keys.Down) ||
				currentGamePadState.DPad.Down == ButtonState.Pressed)
			{
				player.Position.Y += playerMoveSpeed;
			}

			// Make sure that the player does not go out of bounds
			player.Position.X = MathHelper.Clamp(player.Position.X, 0,GraphicsDevice.Viewport.Width - player.Width);
			player.Position.Y = MathHelper.Clamp(player.Position.Y, 0,GraphicsDevice.Viewport.Height - player.Height);
		}

		private void AddFlamethrower(Vector2 position)
		{
			Flamethrower fireBall = new Flamethrower ();

		}

		protected override void Update(GameTime gameTime)
		{
			#if !__IOS__ &&  !__TVOS__
			if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown()
			{

				// Save the previous state of the keyboard and game pad so we can determinesingle key/button presses
				previousGamePadState = currentGamePadState;
				previousKeyboardState = currentKeyboardState;

				// Read the current state of the keyboard and gamepad and store it
				currentKeyboardState = Keyboard.GetState();
				currentGamePadState = GamePad.GetState(PlayerIndex.One);
			}

			//Update the player
			UpdatePlayer(gameTime);
			
			bgLayer1.Update();
			bgLayer2.Update();
			
			base.Update (gameTime);
		}
	}
}

