﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Codartis.SoftVis.UI.Wpf.Animations;

namespace Codartis.SoftVis.UI.Wpf.View
{
    /// <summary>
    /// A canvas with an additional Transform that is animated for each change.
    /// </summary>
    internal class AnimatedTransformCanvas : TransformCanvas
    {
        static AnimatedTransformCanvas()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimatedTransformCanvas),
                new FrameworkPropertyMetadata(typeof(AnimatedTransformCanvas)));
        }

        public static readonly DependencyProperty AnimatedTransformProperty =
            DependencyProperty.Register("AnimatedTransform", typeof(Transform), typeof(AnimatedTransformCanvas),
                new FrameworkPropertyMetadata(Transform.Identity, OnTransformChanged));

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration), typeof(AnimatedTransformCanvas),
                new PropertyMetadata(new Duration(TimeSpan.Zero)));

        public static readonly DependencyProperty EasingFunctionProperty =
            DependencyProperty.Register("EasingFunction", typeof(EasingFunctionBase), typeof(AnimatedTransformCanvas));

        public AnimatedTransformCanvas()
        {
            Transform = new MatrixTransform();
        }

        public Transform AnimatedTransform
        {
            get { return (Transform)GetValue(AnimatedTransformProperty); }
            set { SetValue(AnimatedTransformProperty, value); }
        }

        public Duration Duration
        {
            get { return (Duration)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public EasingFunctionBase EasingFunction
        {
            get { return (EasingFunctionBase)GetValue(EasingFunctionProperty); }
            set { SetValue(EasingFunctionProperty, value); }
        }

        private static void OnTransformChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AnimatedTransformCanvas)d).AnimateTransform((Transform)e.OldValue, (Transform)e.NewValue);
        }

        private void AnimateTransform(Transform oldValue, Transform newValue)
        {
            var matrixAnimation = new MatrixAnimation(oldValue.Value, newValue.Value, Duration)
            {
                EasingFunction = EasingFunction,
                FillBehavior = FillBehavior.HoldEnd
            };

            Transform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation, HandoffBehavior.SnapshotAndReplace);
        }
    }
}