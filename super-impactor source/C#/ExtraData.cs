using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace SuperImpactor
{
	public class ExtraData
	{
		public AppInfos AppDetailObj
		{
			get;
			set;
		}

		public string ButtonText1
		{
			get;
			set;
		}

		public string ButtonText2
		{
			get;
			set;
		}

		public string DescText
		{
			get;
			set;
		}

		public Color HeaderColor
		{
			get;
			set;
		}

		public string HeaderText
		{
			get;
			set;
		}

		public Bitmap MainImage
		{
			get;
			set;
		}

		public string MinorText
		{
			get;
			set;
		}

		public ExtraData()
		{
			this.HeaderColor = Color.Black;
		}
	}
}