using System;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using UIKit;

namespace TechEd.iPhone
{
    public class StoryboardContainer : MvxTouchViewsContainer
    {
        protected override IMvxTouchView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            return (IMvxTouchView)UIStoryboard.FromName("StoryboardViews", null)
                                              .InstantiateViewController(viewType.Name);
        }
    }
}
