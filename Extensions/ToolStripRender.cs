/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/


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
                ControlPaint.DrawImageDisabled(
                    e.Graphics, 
                    e.Image, 
                    e.ImageRectangle.X, 
                    e.ImageRectangle.Y, 
                    e.Item.BackColor 
                );
                return;
            }
        }
        base.OnRenderItemImage(e);
    }
}
}
