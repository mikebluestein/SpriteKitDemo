using System;
using System.Drawing;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.SpriteKit;
using MonoTouch.UIKit;
using System.Linq;

namespace SpriteKitDemo
{
	public class MonkeyScene : SKScene
	{
		SKSpriteNode monkey;
		SKAction animate;

		public MonkeyScene (SizeF size) : base(size)
		{
			monkey = SKSpriteNode.FromImageNamed ("frame-1");
			monkey.Position = new PointF (Size.Width / 2, Size.Height / 2);
			AddChild (monkey);

			var textures = Enumerable.Range (1, 8).Select (
				(i) => SKTexture.FromImageNamed (String.Format ("frame-{0}", i))).ToArray ();

		 	animate = SKAction.RepeatActionForever (SKAction.AnimateWithTextures (textures, 0.1));
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);

			var touch = (UITouch)touches.AnyObject;

//			monkey.RunAction (SKAction.MoveTo (touch.LocationInNode (this), 1));

			AnimateMonkey (touch.LocationInNode (this));
		}

		void AnimateMonkey (PointF location)
		{
			monkey.RunAction (animate);

			monkey.RunAction (SKAction.MoveTo (location, 1), () => { 
				monkey.RemoveAllActions (); 
			});
		}
	}
}

