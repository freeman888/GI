using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly:ExportRenderer(typeof(GTXAM.GasControl.Control.Bubble),typeof(GTXAM.UWP.Renderers.BubbleRenderer))]
namespace GTXAM.UWP.Renderers
{
    public class BubbleRenderer: ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                Control.Style = GTXAM.UWP.Demo_Style.All_Styles.Bubble_Style;
        }

    }
}
