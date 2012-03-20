using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Artefact.Animation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ArtefactAnimatorMetroTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArtefactAnimatorPage : Page
    {
        public ArtefactAnimatorPage()
        {
            this.InitializeComponent();
            this.Loaded += ArtefactAnimatorPage_Loaded;
        }

        void ArtefactAnimatorPage_Loaded(object sender, RoutedEventArgs e)
        {
            btnFadeIn.Click += btnFadeIn_Click;
            btnFadeOut.Click += btnFadeOut_Click;

            layoutRoot.PointerMoved += (o, args) =>
            {
                var pt = args.GetCurrentPoint(null).Position;
                Debug.WriteLine("Pointer moved: X:{0}, Y:{1}", pt.X, pt.Y);
                var x = pt.X - (rectangle.Width / 2);
                var y = pt.Y - (rectangle.Height / 2);

                rectangle.SlideTo(x, y, 0.3, AnimationTransitions.CubicEaseOut, 0);
            };
        }

        void btnFadeOut_Click(object sender, RoutedEventArgs e)
        {
            var easeObject = rectangle.AlphaTo(0, 0.5, null, 0);
        }

        void btnFadeIn_Click(object sender, RoutedEventArgs e)
        {
            rectangle.AlphaTo(1, 0.5, null, 0);
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
