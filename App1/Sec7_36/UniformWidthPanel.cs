﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace Sec7_36
{
    public class UniformWidthPanel : Panel
    {
        public UniformWidthPanel()
        {

        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size newSize = new Size();
            if (double.IsInfinity(availableSize.Width) == false)
                newSize.Width = availableSize.Width;

            if (double.IsInfinity(availableSize.Height) == false)
                newSize.Height = availableSize.Height;

            double NumChildren = this.Children.Count;

            if(NumChildren > 0)
            {
                Size childSize = availableSize;
                childSize.Width /= NumChildren;
                for (int i = 0; i < NumChildren; i++)
                {
                    var child = this.Children[i];
                    child.Measure(childSize);

                    if (child.DesiredSize.Height > newSize.Height)
                        newSize.Height = child.DesiredSize.Height;
                }

            }

            return newSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double numChildren = this.Children.Count;
            if (numChildren > 0)
            {
                var newLeft = 0;
                for (int i = 0; i < numChildren; i++)
                {
                    var newRight = (int)Math.Round(finalSize.Width / numChildren * (i + 1));
                    var newWidth = newRight - newLeft;
                    var child = this.Children[i];
                    Rect childRect = new Rect(newLeft, 0, newWidth, finalSize.Height);
                    child.Arrange(childRect);
                    newLeft += newWidth;
                }

                return finalSize;
            }
            else
                return new Size();
        }
    }
}
