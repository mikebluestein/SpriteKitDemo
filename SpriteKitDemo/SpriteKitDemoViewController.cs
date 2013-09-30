using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.SpriteKit;
using MonoTouch.UIKit;

namespace SpriteKitDemo
{
	public partial class SpriteKitDemoViewController : UIViewController
	{
		public SpriteKitDemoViewController ()
		{
		}

		public override void LoadView ()
		{
			base.LoadView ();

			View = new SKView {
				ShowsFPS = true,
				ShowsNodeCount = true,
				ShowsDrawCount = true
			};
		}

		public override void ViewWillLayoutSubviews ()
		{
			base.ViewWillLayoutSubviews ();

			var view = (SKView)View;

			if (view.Scene == null) {
				var scene = new MonkeyScene (View.Bounds.Size);
				scene.ScaleMode = SKSceneScaleMode.AspectFill;
				view.PresentScene (scene);
			}
		}

		public override bool PrefersStatusBarHidden ()
		{
			return true;
		}
	}
}

