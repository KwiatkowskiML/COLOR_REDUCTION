﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PopularityAlgorithm
{
    private class ColorNode
    {
        public Color Color { get; set; }
        public int Frequency { get; set; }
        public ColorNode Left { get; set; }
        public ColorNode Right { get; set; }

        public ColorNode(Color color, int frequency)
        {
            Color = color;
            Frequency = frequency;
        }
    }

    private static double ColorDistance(Color c1, Color c2)
    {
        int redDiff = c1.R - c2.R;
        int greenDiff = c1.G - c2.G;
        int blueDiff = c1.B - c2.B;
        return Math.Sqrt(redDiff * redDiff + greenDiff * greenDiff + blueDiff * blueDiff);
    }

    private static List<Color> FindMostPopularColors(Bitmap originalBitmap, int k)
    {
        var colorFrequency = new Dictionary<Color, int>();

        for (int y = 0; y < originalBitmap.Height; y++)
        {
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                Color pixelColor = originalBitmap.GetPixel(x, y);

                if (colorFrequency.ContainsKey(pixelColor))
                    colorFrequency[pixelColor]++;
                else
                    colorFrequency[pixelColor] = 1;
            }
        }

        var result = colorFrequency
            .OrderByDescending(x => x.Value)
            .Take(k)
            .ToList();

        return result.Select(x => x.Key).ToList();
    }

    private static ColorNode BuildColorTree(List<Color> colors)
    {
        if (colors == null || colors.Count == 0)
            return null;

        colors = colors.OrderBy(c =>
            (c.R * 0.299 + c.G * 0.587 + c.B * 0.114)
        ).ToList();

        return BuildColorTreeRecursive(colors, 0, colors.Count - 1);
    }

    private static ColorNode BuildColorTreeRecursive(List<Color> colors, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;
        ColorNode node = new ColorNode(colors[mid], 1);

        node.Left = BuildColorTreeRecursive(colors, start, mid - 1);
        node.Right = BuildColorTreeRecursive(colors, mid + 1, end);

        return node;
    }

    private static Color FindClosestColor(ColorNode root, Color targetColor)
    {
        if (root == null)
            throw new ArgumentNullException(nameof(root));

        ColorNode best = root;
        double minDistance = ColorDistance(root.Color, targetColor);
        FindClosestColorRecursive(root, targetColor, ref best, ref minDistance);

        return best.Color;
    }

    private static void FindClosestColorRecursive(
    ColorNode node,
    Color targetColor,
    ref ColorNode best,
    ref double minDistance)
    {
        if (node == null)
            return;

        double targetLuminance = targetColor.R * 0.299 +
                                  targetColor.G * 0.587 +
                                  targetColor.B * 0.114;

        double nodeLuminance = node.Color.R * 0.299 +
                                node.Color.G * 0.587 +
                                node.Color.B * 0.114;

        double currentDistance = ColorDistance(node.Color, targetColor);

        if (currentDistance < minDistance)
        {
            minDistance = currentDistance;
            best = node;
        }

        if (targetLuminance < nodeLuminance)
        {
            // target is darker, prioritize left subtree
            FindClosestColorRecursive(node.Left, targetColor, ref best, ref minDistance);
            if (Math.Abs(targetLuminance - nodeLuminance) < minDistance)
            {
                FindClosestColorRecursive(node.Right, targetColor, ref best, ref minDistance);
            }
        }
        else
        {
            // target is brighter, prioritize right subtree
            FindClosestColorRecursive(node.Right, targetColor, ref best, ref minDistance);
            if (Math.Abs(targetLuminance - nodeLuminance) < minDistance)
            {
                FindClosestColorRecursive(node.Left, targetColor, ref best, ref minDistance);
            }
        }
    }

    public static Bitmap QuantizeColors(Bitmap originalBitmap, int k)
    {
        if (originalBitmap == null)
            throw new ArgumentNullException(nameof(originalBitmap));
        if (k <= 0)
            throw new ArgumentException("K must be a positive integer", nameof(k));

        var popularColors = FindMostPopularColors(originalBitmap, k);
        var colorTree = BuildColorTree(popularColors);
        Bitmap quantizedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

        for (int y = 0; y < originalBitmap.Height; y++)
        {
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                Color originalColor = originalBitmap.GetPixel(x, y);
                Color closestColor = FindClosestColor(colorTree, originalColor);
                quantizedBitmap.SetPixel(x, y, closestColor);
            }
        }

        return quantizedBitmap;
    }
}