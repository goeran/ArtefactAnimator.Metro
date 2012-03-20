using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Artefact.Animation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ArtefactAnimatorMetroTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Movement : Page
    {
        public Movement()
        {
            this.InitializeComponent();

            this.Loaded += Movement_Loaded;
        }

        void Movement_Loaded(object sender, RoutedEventArgs e)
        {
            var ballDimension = 30;
            var ball = CreateBall(ballDimension, ballDimension);
            PointerMoved += (o, args) =>
            {
                var pt = args.GetCurrentPoint(null).Position;
                Debug.WriteLine("Pointer moved: X:{0}, Y:{1}", pt.X, pt.Y);
                var x = pt.X - (ballDimension / 2);
                var y = pt.Y - (ballDimension / 2);

                ball.SlideTo(x, y, 1.2, AnimationTransitions.CubicEaseOut, 0);
            };

            layoutRoot.Children.Add(ball);
        }

        private static Grid CreateBall(double width, double height)
        {
            var g = new Grid { Width = width, Height = height };
            var ball = new Ellipse { Fill = new SolidColorBrush(Colors.Red), Opacity = .2 };
            var tb = new TextBlock { Text = "0", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            Canvas.SetLeft(g, 0D);
            Canvas.SetTop(g, 0D);
            g.Children.Add(ball);
            g.Children.Add(tb);
            g.RenderTransformOrigin = new Point(.5, .5);
            return g;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
