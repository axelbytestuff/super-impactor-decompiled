using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace SuperImpactor
{
	public class ListViewEx : ListView
	{
		private ImageList imgList;

		public const int BUTTONWIDTH = 105;

		public const int BUTTONPADING = 10;

		public ListViewEx()
		{
			base.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this.Me_DrawColumnHeader);
			base.DrawItem += new DrawListViewItemEventHandler(this.Me_DrawItem);
			base.DrawSubItem += new DrawListViewSubItemEventHandler(this.Me_DrawSubItem);
			base.MouseClick += new MouseEventHandler(this.ListViewEx_MouseClick);
			base.MouseMove += new MouseEventHandler(this.ListViewEx_MouseMove);
			this.imgList = new ImageList();
			base.OwnerDraw = true;
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.View = System.Windows.Forms.View.Details;
			this.BackColor = Color.White;
			base.FullRowSelect = true;
			this.imgList.ColorDepth = ColorDepth.Depth32Bit;
			this.imgList.ImageSize = new System.Drawing.Size(64, 64);
			base.SmallImageList = this.imgList;
		}

		private object isInRect(int x, int y, Rectangle rec)
		{
			object obj;
			obj = (!(x > rec.X & x < checked(rec.X + rec.Width) & y > rec.Y & y < checked(rec.Y + rec.Height)) ? false : true);
			return obj;
		}

		private void ListViewEx_MouseClick(object sender, MouseEventArgs e)
		{
			if (base.SelectedItems.Count > 0)
			{
				ListViewItem item = base.SelectedItems[0];
				ExtraData tag = (ExtraData)item.Tag;
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(tag.ButtonText1, "", false) != 0, this.isInRect(e.X, e.Y, new Rectangle(checked(checked(checked(item.Bounds.X + item.Bounds.Width) - 105) - 10), checked(item.Bounds.Y + 5), 105, 30)))))
				{
					EventHandler<FileEventArgs> eventHandler = this.Button1Click;
					if (eventHandler != null)
					{
						eventHandler(this, new FileEventArgs(tag));
					}
				}
				else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(tag.ButtonText2, "", false) != 0, this.isInRect(e.X, e.Y, new Rectangle(checked(checked(item.Bounds.X + item.Bounds.Width) - 230), checked(item.Bounds.Y + 5), 105, 30)))))
				{
					EventHandler<FileEventArgs> eventHandler1 = this.Button2Click;
					if (eventHandler1 != null)
					{
						eventHandler1(this, new FileEventArgs(tag));
					}
				}
			}
		}

		private void ListViewEx_MouseMove(object sender, MouseEventArgs e)
		{
			ListViewItem itemAt = base.GetItemAt(e.X, e.Y);
			if (itemAt != null)
			{
				ExtraData tag = (ExtraData)itemAt.Tag;
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(tag.ButtonText1, "", false) != 0, this.isInRect(e.X, e.Y, new Rectangle(checked(checked(checked(itemAt.Bounds.X + itemAt.Bounds.Width) - 105) - 10), checked(itemAt.Bounds.Y + 5), 105, 30)))))
				{
					this.Cursor = Cursors.Hand;
				}
				else if (!Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(tag.ButtonText2, "", false) != 0, this.isInRect(e.X, e.Y, new Rectangle(checked(checked(itemAt.Bounds.X + itemAt.Bounds.Width) - 230), checked(itemAt.Bounds.Y + 5), 105, 30)))))
				{
					this.Cursor = this.DefaultCursor;
				}
				else
				{
					this.Cursor = Cursors.Hand;
				}
			}
		}

		private void Me_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void Me_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			e.DrawDefault = false;
		}

		private void Me_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			if ((int)(e.ItemState & ListViewItemStates.Selected) != 0)
			{
			}
			if (e.ColumnIndex != 0)
			{
				e.DrawDefault = true;
			}
			else
			{
				ExtraData tag = (ExtraData)e.Item.Tag;
				System.Drawing.Font font = new System.Drawing.Font("Arial", 12f, FontStyle.Bold);
				System.Drawing.Font font1 = new System.Drawing.Font("Arial", 8f, FontStyle.Bold);
				System.Drawing.Font font2 = new System.Drawing.Font("Arial", 8f, FontStyle.Italic);
				Rectangle bounds = e.Bounds;
				int x = checked(checked(bounds.X + 5) + 40);
				bounds = e.Bounds;
				int y = checked(bounds.Y + 1);
				bounds = e.Bounds;
				RectangleF rectangle = new Rectangle(x, y, checked(bounds.Width - 40), font.Height);
				bounds = e.Bounds;
				int num = checked(checked(bounds.X + 5) + 40);
				bounds = e.Bounds;
				int y1 = checked(bounds.Y + 23);
				bounds = e.Bounds;
				RectangleF rectangleF = new Rectangle(num, y1, checked(bounds.Width - 40), font1.Height);
				bounds = e.Bounds;
				int x1 = checked(checked(bounds.X + 5) + 40);
				bounds = e.Bounds;
				int num1 = checked(bounds.Y + 40);
				bounds = e.Bounds;
				RectangleF rectangle1 = new Rectangle(x1, num1, checked(bounds.Width - 40), font2.Height);
				StringFormat stringFormat = new StringFormat()
				{
					Alignment = StringAlignment.Near,
					Trimming = StringTrimming.EllipsisCharacter
				};
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				Graphics graphics = e.Graphics;
				Bitmap mainImage = tag.MainImage;
				bounds = e.Bounds;
				int x2 = checked(checked(bounds.X + 4) + 5);
				bounds = e.Bounds;
				graphics.DrawImage(mainImage, x2, checked(bounds.Y + 4), 32, 32);
				e.Graphics.DrawString(tag.HeaderText, font, new SolidBrush(tag.HeaderColor), rectangle, stringFormat);
				e.Graphics.DrawString(tag.MinorText, font1, Brushes.Blue, rectangleF, stringFormat);
				e.Graphics.DrawString(tag.DescText, font2, Brushes.Black, rectangle1, stringFormat);
				stringFormat.Alignment = StringAlignment.Center;
				if (Operators.CompareString(tag.ButtonText1, "", false) != 0)
				{
					using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(25, 152, 254)))
					{
						Graphics graphic = e.Graphics;
						int num2 = e.Bounds.X;
						bounds = e.Bounds;
						int width = checked(checked(checked(num2 + bounds.Width) - 105) - 10);
						bounds = e.Bounds;
						graphic.FillRectangle(solidBrush, new Rectangle(width, checked(bounds.Y + 5), 105, 30));
						Graphics graphics1 = e.Graphics;
						string buttonText1 = tag.ButtonText1;
						Brush white = Brushes.White;
						int x3 = e.Bounds.X;
						bounds = e.Bounds;
						int width1 = checked(checked(checked(checked(x3 + bounds.Width) - 105) - 10) + 2);
						bounds = e.Bounds;
						graphics1.DrawString(buttonText1, font, white, new Rectangle(width1, checked(bounds.Y + 10), 105, 30), stringFormat);
					}
				}
				if (Operators.CompareString(tag.ButtonText2, "", false) != 0)
				{
					Graphics graphic1 = e.Graphics;
					Brush controlLight = SystemBrushes.ControlLight;
					int num3 = e.Bounds.X;
					bounds = e.Bounds;
					int width2 = checked(checked(num3 + bounds.Width) - 230);
					bounds = e.Bounds;
					graphic1.FillRectangle(controlLight, new Rectangle(width2, checked(bounds.Y + 5), 105, 30));
					Graphics graphics2 = e.Graphics;
					string buttonText2 = tag.ButtonText2;
					Brush black = Brushes.Black;
					int x4 = e.Bounds.X;
					bounds = e.Bounds;
					int width3 = checked(checked(checked(x4 + bounds.Width) - 230) + 2);
					bounds = e.Bounds;
					graphics2.DrawString(buttonText2, font, black, new Rectangle(width3, checked(bounds.Y + 10), 105, 30), stringFormat);
				}
			}
		}

		public event EventHandler<FileEventArgs> Button1Click;

		public event EventHandler<FileEventArgs> Button2Click;
	}
}