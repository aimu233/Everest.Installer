﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MonoMod.Installer {
    public static class ProgressShapes {

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Init() {
            // no-op. We just need the class constructor to run.
        }

        public static DrawableMulti Backup = DrawablePath.FromDotgridSVG(
            Properties.Resources.shape_backup,
            pen: new Pen(Color.FromArgb(255, 255, 255, 255))
        ).ToMulti(new Func<DrawablePath.MultiGen>(() => {
            float[][] timings = new float[][] {
                                new float[] { 0.0f, 0.2f }, // O out
                                new float[] { 0.0f, 0.2f }, // I top right
                                new float[] { 0.0f, 0.2f }, // I left
                                new float[] { 0.1f, 0.1f }, // O in
            };
            return (i, path, brush, pen, closed) => {
                return new DrawablePolygonAnimSegment {
                    Polygon = new DrawablePolygon {
                        Points = path.PathPoints,
                        Brush = brush,
                        Pen = pen,
                        PenClosed = closed
                    }.RemoveDupes(),
                    Timing = timings[i],
                    TimeScale = 1f
                };
            };
        })());

        public static DrawableMulti Download = DrawablePath.FromDotgridSVG(
            Properties.Resources.shape_download,
            pen: new Pen(Color.FromArgb(255, 255, 255, 255))
        ).ToMulti(new Func<DrawablePath.MultiGen>(() => {
            float[][] timings = new float[][] {
                new float[] { 0.0f, 1.0f },
            };
            return (i, path, brush, pen, closed) => {
                return new DrawablePolygonAnimSegment {
                    Polygon = new DrawablePolygon {
                        Points = path.PathPoints,
                        Brush = brush,
                        Pen = pen,
                        PenClosed = closed
                    }.RemoveDupes(),
                    Fade = null,
                    Timing = timings[i],
                    TimeScale = 1f
                };
            };
        })());

        public static DrawableMulti MonoMod = DrawablePath.FromDotgridSVG(
            Properties.Resources.shape_monomod,
            pen: new Pen(Color.FromArgb(255, 255, 255, 255))
        ).ToMulti(new Func<DrawablePath.MultiGen>(() => {
            float[][] timings = new float[][] {
                new float[] { 0.0f, 0.7f }, // - top left
                new float[] { 0.0f, 0.3f }, // - bottom left
                new float[] { 0.4f, 0.7f }, // | top right
                new float[] { 0.0f, 0.3f }, // O
                new float[] { 0.2f, 0.5f }, // | left
                new float[] { 0.3f, 0.7f }, // - bottom right
                new float[] { 0.7f, 0.3f }, // - top right
                new float[] { 1.0f, 0.3f }, // | bottom right
                new float[] { 0.6f, 0.2f }, // U top right
                new float[] { 0.7f, 0.4f }, // U main
                new float[] { 1.0f, 0.2f }, // U top right
            };
            return (i, path, brush, pen, closed) => {
                return new DrawablePolygonAnimSegment {
                    Polygon = new DrawablePolygon {
                        Points = path.PathPoints,
                        Brush = brush,
                        Pen = pen,
                        PenClosed = closed
                    }.RemoveDupes(),
                    Timing = timings[i],
                    TimeScale = 0.5f
                };
            };
        })());

        public static DrawableMulti Done = DrawablePath.FromDotgridSVG(
            Properties.Resources.shape_done,
            pen: new Pen(Color.FromArgb(255, 255, 255, 255))
        ).ToMulti(new Func<DrawablePath.MultiGen>(() => {
            float[][] timings = new float[][] {
                        new float[] { 0.1f, 0.2f }, // V
                        new float[] { 0.0f, 0.3f }, // O
            };
            return (i, path, brush, pen, closed) => {
                return new DrawablePolygonAnimSegment {
                    Polygon = new DrawablePolygon {
                        Points = path.PathPoints,
                        Brush = brush,
                        Pen = pen,
                        PenClosed = closed
                    }.RemoveDupes(),
                    Timing = timings[i],
                    TimeScale = 1f
                };
            };
        })());

        public static DrawableMulti Error = DrawablePath.FromDotgridSVG(
            Properties.Resources.shape_error,
            pen: new Pen(Color.FromArgb(255, 255, 255, 255))
        ).ToMulti(new Func<DrawablePath.MultiGen>(() => {
            float[][] timings = new float[][] {
                                new float[] { 0.2f, 0.08f }, // ! I
                                new float[] { 0.28f, 0.12f }, // ! .
                                new float[] { 0.0f, 0.2f }, // A
            };
            return (i, path, brush, pen, closed) => {
                return new DrawablePolygonAnimSegment {
                    Polygon = new DrawablePolygon {
                        Points = path.PathPoints,
                        Brush = brush,
                        Pen = pen,
                        PenClosed = closed
                    }.RemoveDupes(),
                    Timing = timings[i],
                    TimeScale = 1f
                };
            };
        })());

    }
}
