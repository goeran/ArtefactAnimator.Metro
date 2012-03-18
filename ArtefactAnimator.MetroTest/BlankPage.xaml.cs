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
    public sealed partial class BlankPage : Page
    {
        private static readonly UIElement[] Items = new UIElement[25];
        readonly Random rnd = new Random();

        public BlankPage()
        {
            this.InitializeComponent();

            Loaded += BlankPage_Loaded;
        }

        void BlankPage_Loaded(object sender, RoutedEventArgs e)
        {
            PointerMoved += BlankPage_PointerMoved;


            for (var i = 0; i < Items.Length; i++)
            {
                var g = new Grid { Width = 30, Height = 30 };
                var ball = new Ellipse { Fill = new SolidColorBrush(Colors.Red), Opacity = .2 };
                var tb = new TextBlock { Text = "" + i, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };

                Canvas.SetLeft(g, 0D);
                Canvas.SetTop(g, 0D);

                Items[i] = g;

                g.Children.Add(ball);
                g.Children.Add(tb);
                g.RenderTransformOrigin = new Point(.5, .5);
                //g.Effect = new DropShadowEffect();

                LayoutRoot.Children.Add(g);
            }

            CompositionTarget.Rendering += (s, args) =>
            {
                //countTxt.Text = "EaseObjects in memory = " + EaseObject.EaseObjectRunningCount;
            };
        }

        void BlankPage_PointerMoved(object sender, PointerEventArgs e)
        {
            UpdatePosition(e);
        }

        private void UpdatePosition(PointerEventArgs e)
        {
            double x = e.GetCurrentPoint(this).Position.X - (30 / 2);
            double y = e.GetCurrentPoint(this).Position.Y - (30 / 2);

            for (int n = 0; n < Items.Length; n++)
            {
                UIElement ball = Items[n];

                double size = 20 + (rnd.NextDouble() * 150);
                double delay = (n * .01) + 0;

                //  DEPENDENCY PROPERTY
                //  ArtefactAnimator.AddEase(ball, new[] { Canvas.LeftProperty, Canvas.TopProperty }, new[] { x, y }, 2, AnimationTransitions.ElasticEaseOut, delay);

                //  STRINGS
                ball.DimensionsTo(size, size, 3, AnimationTransitions.ElasticEaseOut, 0);
                EaseObject eo = ball.SlideTo(x + (size / 2), y + (size / 2), 1, AnimationTransitions.CubicEaseOut, delay);
                ArtefactAnimator.AddEase(ball, RenderTransformProperty, new CompositeTransform { Rotation = rnd.NextDouble() * 360 }, 4, AnimationTransitions.ElasticEaseOut, 0);
            }
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
