/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 1:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
//using System.Drawing;
using Godot;

namespace tukineko
{
	/// <summary>
	/// Description of Toolkit.
	/// </summary>
	public class Toolkit
	{
		private Toolkit()
		{
		}
		
		private static Toolkit instance = new Toolkit();
		public static Toolkit getDefaultToolkit()
		{
			return instance;
		}
		
		public Image_ createImage(MemoryImageSource src)
		{
			Image_ result = new Image_();
			byte[] bytes = src.bytes;
			using (MemoryStream ms = new MemoryStream(bytes))
			{
				Image bitmap = Image.CreateEmpty(src.w, src.h, false, Image.Format.Rgba8);
				for (int j = 0; j < src.h; ++j)
				{
					for (int i = 0; i < src.w; ++i)
					{
						uint p = src.pix[j * src.w + i];
						int a = (int)((p >> 24) & 0xff);
						int r = (int)((p >> 16) & 0xff);
						int g = (int)((p >>  8) & 0xff);
						int b = (int)((p >>  0) & 0xff);
						bitmap.SetPixel(i, j, new Godot.Color(a, r, g, b));
					}
				}
				result._bufferBmp = bitmap;
			}
			return result;
		}
		
		public Image_ createImage(String name)
		{
			Image_ result = new Image_();
			result._bufferBmp = Image.LoadFromFile(name);
			return result;
		}
		
		public Image_ createImage(byte[] bytes)
		{
			Image_ result = new Image_();
			//using (MemoryStream ms = new MemoryStream(bytes))
			{
				Godot.FileAccess file = Godot.FileAccess.Open("temp.jpg", Godot.FileAccess.ModeFlags.Write);
				file.StoreBuffer(bytes);
				file.Flush();
				file.Close();
                Image bitmap = Image.LoadFromFile("temp.jpg");
				result._bufferBmp = bitmap;
			}
			return result;
		}
	}
}
