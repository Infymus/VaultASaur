/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace VaultASaur3.Extensions
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripRenderer() : base() { }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            if (!e.Item.Enabled)
            {
                if (e.Image != null && !(e.Item is ToolStripControlHost))
                {
                    // Use a grayscale color matrix that keeps contrast and reduces opacity slightly
                    // instead of ControlPaint.DrawImageDisabled which can produce a washed-out look.
                    float[][] matrixItems = {
                        new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                        new float[] {0.59f,0.59f,0.59f,0,0},
                        new float[] {0.11f,0.11f,0.11f,0,0},
                        new float[] {0,0,0,0.8f,0}, // keep more of the alpha to avoid washed-out icons
                        new float[] {0,0,0,0,1}
                    };
                    ColorMatrix cm = new ColorMatrix(matrixItems);
                    using (ImageAttributes ia = new ImageAttributes())
                    {
                        ia.SetColorMatrix(cm);
                        e.Graphics.DrawImage(e.Image, e.ImageRectangle, 0, 0, e.Image.Width, e.Image.Height, GraphicsUnit.Pixel, ia);
                    }
                    return;
                }
            }
            base.OnRenderItemImage(e);
        }
    }
}
