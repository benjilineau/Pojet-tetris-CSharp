using System;
using System.Drawing;

namespace Tetris
{
    static class ShapesHandler
    {
        private static Shape[] shapesArray;
        
        // static constructor : No need to manually initialize
        static ShapesHandler()
        {
            // Create shapes add into the array.
            shapesArray = new Shape[]
                {
                    new Shape {
                        Width = 2,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 1, 1 },
                            { 1, 1 }
                        },
                        Color = Brushes.Yellow
                    },
                    new Shape {
                        Width = 1,
                        Height = 4,
                        Dots = new int[,]
                        {
                            { 2 },
                            { 2 },
                            { 2 },
                            { 2 }
                        },
                        Color = Brushes.Cyan
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 3, 0 },
                            { 3, 3, 3 }
                        },
                        Color = Brushes.Purple
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 0, 4 },
                            { 4, 4, 4 }
                        },
                        Color = Brushes.Orange
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 5, 0, 0 },
                            { 5, 5, 5 }
                        },
                        Color = Brushes.Blue
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 6, 6, 0 },
                            { 0, 6, 6 }
                        },
                        Color = Brushes.Red
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 7, 7 },
                            { 7, 7, 0 }
                        },
                        Color = Brushes.Green
                    }
                };
        }
        
        // Get a shape form the array in a random basis
        public static Shape GetRandomShape()
        {
            var shape = shapesArray[new Random().Next(shapesArray.Length)];

            return shape;
        }
    }
}
