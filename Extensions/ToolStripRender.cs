/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/


using System.Drawing.Imaging;

namespace VaultASaur3.Extensions
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripRenderer() : base() { }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip != null)
            {
                e.Graphics.Clear(e.ToolStrip.BackColor);
                return;
            }

            base.OnRenderToolStripBackground(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Keep the toolbar visually flat without drawing a surrounding frame.
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item is ToolStripButton button)
            {
                if (button.BackColor != Color.Transparent || button.Selected || button.Pressed || button.Checked)
                {
                    Color hoverColor = button.Pressed
                        ? Color.FromArgb(170, 205, 245)
                        : Color.FromArgb(215, 232, 255);

                    using var brush = new SolidBrush(hoverColor);
                    e.Graphics.FillRectangle(brush, new Rectangle(Point.Empty, button.Size));
                }

                return;
            }

            base.OnRenderButtonBackground(e);
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            if (e.Image == null || e.Item is ToolStripControlHost)
            {
                base.OnRenderItemImage(e);
                return;
            }

            if (!e.Item.Enabled)
            {
                using var attributes = new ImageAttributes();
                var matrix = new float[][]
                {
                    new float[] { 1, 0, 0, 0, 0 },
                    new float[] { 0, 1, 0, 0, 0 },
                    new float[] { 0, 0, 1, 0, 0 },
                    new float[] { 0, 0, 0, 0.55f, 0 },
                    new float[] { 0, 0, 0, 0, 1 }
                };

                attributes.SetColorMatrix(new ColorMatrix(matrix), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                e.Graphics.DrawImage(e.Image, e.ImageRectangle, 0, 0, e.Image.Width, e.Image.Height, GraphicsUnit.Pixel, attributes);
                return;
            }

            base.OnRenderItemImage(e);
        }
    }
}
