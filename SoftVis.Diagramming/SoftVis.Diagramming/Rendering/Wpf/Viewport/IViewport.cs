﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Codartis.SoftVis.Rendering.Wpf.Viewport
{
    /// <summary>
    /// Viewport is the visible part of the diagram. 
    /// </summary>
    public interface IViewport : IAnimatable
    {
        double MinZoom { get; }
        double MaxZoom { get; }
        double Zoom { get; }
        Rect ViewportInScreenSpace { get; }
        Rect ViewportInDiagramSpace { get; }
        Rect ContentInDiagramSpace { get; }
        Cursor Cursor { get; set; }

        void MoveCenterInDiagramSpace(Point newCenterInDiagramSpace);
        void MoveCenterInScreenSpace(Point newCenterInScreenSpace);
        void ResizeInScreenSpace(Size newSizeInScreenSpace);
        void ZoomTo(double newZoom);
        void ZoomWithCenterInScreenSpace(double newZoom, Point zoomCenterInScreenSpace);
    }
}
