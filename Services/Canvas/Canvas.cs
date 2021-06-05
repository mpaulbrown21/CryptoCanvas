using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Canvas
{
    public class Canvas : ICanvas
    {
        public byte[] GetCanvasData()
        {
            var bitMap = GetCanvas();

            return ImageToByte2(bitMap);
        }

        private Bitmap GetCanvas()
        {
            var bitmap = new Bitmap(Constants.CANVAS_PIXEL_WIDTH, Constants.CANVAS_PIXEL_HEIGHT);

            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, Color.BlueViolet);
                }
            }

            return bitmap;
        }

        private static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
