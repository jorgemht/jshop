namespace Jshop.iOS.Renderers
{
    using System.ComponentModel;
    using CoreGraphics;
    using Jshop.CustomControl;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    public class MaterialFrameRenderer : FrameRenderer
    {
        public static void Initialize()
        {
            // empty, but used for beating the linker
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;
            UpdateShadow();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Elevation")
            {
                UpdateShadow();
            }
        }

        private void UpdateShadow()
        {

            var materialFrame = (CardView)Element;

            // Update shadow to match better material design standards of elevation
            Layer.ShadowRadius = materialFrame.Elevation;
            Layer.ShadowColor = UIColor.Gray.CGColor;
            Layer.ShadowOffset = new CGSize(1, 1);
            Layer.ShadowOpacity = 0.1f;
            Layer.ShadowPath = UIBezierPath.FromRect(Layer.Bounds).CGPath;
            Layer.MasksToBounds = false;

        }
    }
}
