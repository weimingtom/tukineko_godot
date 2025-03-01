/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/25
 * Time: 5:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
//using System.Drawing;
using Godot;

namespace tukineko
{
	/// <summary>
	/// Description of Color.
	/// </summary>
	public class Color_
	{
		public Color color_ = Godot.Colors.Black;
		public Color_()
		{
			color_ = Godot.Colors.Black;
		}
		
		public Color_(int r, int g, int b)
		{
			color_ = new Color(r / 255.0f, g / 255.0f, b / 255.0f, 255 / 255.0f);
		}
		
		public Color_(uint rgba, bool hasalpha)
		{
			if (hasalpha)
			{
				int a = (int)((rgba >> 24) & 0xff);
				int r = (int)((rgba >> 16) & 0xff);
				int g = (int)((rgba >>  8) & 0xff);
				int b = (int)((rgba >>  0) & 0xff);
				color_ = new Color(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
            }
			else
			{
				int r = (int)((rgba >> 16) & 0xff);
				int g = (int)((rgba >>  8) & 0xff);
				int b = (int)((rgba >>  0) & 0xff);
				color_ = new Color(r / 255.0f, g / 255.0f, b / 255.0f, 255 / 255.0f);
            }
		}
		
		public static Color_ black = new Color_(0, 0, 0);
		public static Color_ white = new Color_(0xff, 0xff, 0xff);
	}
}
