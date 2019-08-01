using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC.Models
{
	public class Watermark
	{

		//this fuction takes an Image and String for watermarking as argument
		//and returns an Image with watermark

		// watermark. Картинку загружаем по пути
		public static Bitmap WaterMarkToImage(Bitmap bmp, string watermark)
		{
			//Bitmap bmp;
			//bmp = new Bitmap(ImagePath);

			Graphics graphicsObject;
			try
			{
				//create graphics object from bitmap
				graphicsObject = Graphics.FromImage(bmp);
			}
			catch (Exception)
			{

				Bitmap bmpNew = new Bitmap(bmp.Width, bmp.Height);
				graphicsObject = Graphics.FromImage(bmpNew);

				graphicsObject.DrawImage(bmp, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);

				bmp = bmpNew;
			}

			int startsize = 10; //get the font size with respect to length of the string
								//System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical); -> draws a vertical string for watermark

			System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat(StringFormatFlags.NoWrap);

			//drawing string on Image
			graphicsObject.DrawString(watermark, new Font("Verdana", startsize, FontStyle.Bold), new SolidBrush(Color.FromArgb(128, 0, 0, 0)), 2, 2, drawFormat);


			//return a water marked image
			return (bmp);
		}




	}
}
