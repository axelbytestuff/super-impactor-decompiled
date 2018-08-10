Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms

Namespace SuperImpactor
	Public Class ListViewEx
		Inherits ListView
		Private imgList As ImageList

		Public Const BUTTONWIDTH As Integer = 105

		Public Const BUTTONPADING As Integer = 10

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.DrawColumnHeader,  New DrawListViewColumnHeaderEventHandler(AddressOf Me.Me_DrawColumnHeader)
			AddHandler MyBase.DrawItem,  New DrawListViewItemEventHandler(AddressOf Me.Me_DrawItem)
			AddHandler MyBase.DrawSubItem,  New DrawListViewSubItemEventHandler(AddressOf Me.Me_DrawSubItem)
			AddHandler MyBase.MouseClick,  New MouseEventHandler(AddressOf Me.ListViewEx_MouseClick)
			AddHandler MyBase.MouseMove,  New MouseEventHandler(AddressOf Me.ListViewEx_MouseMove)
			Me.imgList = New ImageList()
			MyBase.OwnerDraw = True
			MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
			MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
			MyBase.View = System.Windows.Forms.View.Details
			Me.BackColor = Color.White
			MyBase.FullRowSelect = True
			Me.imgList.ColorDepth = ColorDepth.Depth32Bit
			Me.imgList.ImageSize = New System.Drawing.Size(64, 64)
			MyBase.SmallImageList = Me.imgList
		End Sub

		Private Function isInRect(ByVal x As Integer, ByVal y As Integer, ByVal rec As Rectangle) As Object
			Dim obj As Object
			obj = If(Not (x > rec.X And x < rec.X + rec.Width And y > rec.Y And y < rec.Y + rec.Height), False, True)
			Return obj
		End Function

		Private Sub ListViewEx_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
			If (MyBase.SelectedItems.Count > 0) Then
				Dim item As ListViewItem = MyBase.SelectedItems(0)
				Dim tag As ExtraData = DirectCast(item.Tag, ExtraData)
				If (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(tag.ButtonText1, "", False) <> 0, Me.isInRect(e.X, e.Y, New Rectangle(item.Bounds.X + item.Bounds.Width - 105 - 10, item.Bounds.Y + 5, 105, 30))))) Then
					RaiseEvent Button1Click(Me, New FileEventArgs(tag))
				ElseIf (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(tag.ButtonText2, "", False) <> 0, Me.isInRect(e.X, e.Y, New Rectangle(item.Bounds.X + item.Bounds.Width - 230, item.Bounds.Y + 5, 105, 30))))) Then
					RaiseEvent Button2Click(Me, New FileEventArgs(tag))
				End If
			End If
		End Sub

		Private Sub ListViewEx_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim itemAt As ListViewItem = MyBase.GetItemAt(e.X, e.Y)
			If (itemAt IsNot Nothing) Then
				Dim tag As ExtraData = DirectCast(itemAt.Tag, ExtraData)
				If (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(tag.ButtonText1, "", False) <> 0, Me.isInRect(e.X, e.Y, New Rectangle(itemAt.Bounds.X + itemAt.Bounds.Width - 105 - 10, itemAt.Bounds.Y + 5, 105, 30))))) Then
					Me.Cursor = Cursors.Hand
				ElseIf (Not Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(tag.ButtonText2, "", False) <> 0, Me.isInRect(e.X, e.Y, New Rectangle(itemAt.Bounds.X + itemAt.Bounds.Width - 230, itemAt.Bounds.Y + 5, 105, 30))))) Then
					Me.Cursor = Me.DefaultCursor
				Else
					Me.Cursor = Cursors.Hand
				End If
			End If
		End Sub

		Private Sub Me_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs)
			e.DrawDefault = True
		End Sub

		Private Sub Me_DrawItem(ByVal sender As Object, ByVal e As DrawListViewItemEventArgs)
			e.DrawDefault = False
		End Sub

		Private Sub Me_DrawSubItem(ByVal sender As Object, ByVal e As DrawListViewSubItemEventArgs)
			If (CInt((e.ItemState And ListViewItemStates.Selected)) <> 0) Then
			End If
			If (e.ColumnIndex <> 0) Then
				e.DrawDefault = True
			Else
				Dim tag As ExtraData = DirectCast(e.Item.Tag, ExtraData)
				Dim font As System.Drawing.Font = New System.Drawing.Font("Arial", 12!, FontStyle.Bold)
				Dim font1 As System.Drawing.Font = New System.Drawing.Font("Arial", 8!, FontStyle.Bold)
				Dim font2 As System.Drawing.Font = New System.Drawing.Font("Arial", 8!, FontStyle.Italic)
				Dim bounds As System.Drawing.Rectangle = e.Bounds
				Dim x As Integer = bounds.X + 5 + 40
				bounds = e.Bounds
				Dim y As Integer = bounds.Y + 1
				bounds = e.Bounds
				Dim rectangle As System.Drawing.RectangleF = New System.Drawing.Rectangle(x, y, bounds.Width - 40, font.Height)
				bounds = e.Bounds
				Dim num As Integer = bounds.X + 5 + 40
				bounds = e.Bounds
				Dim y1 As Integer = bounds.Y + 23
				bounds = e.Bounds
				Dim rectangleF As System.Drawing.RectangleF = New System.Drawing.Rectangle(num, y1, bounds.Width - 40, font1.Height)
				bounds = e.Bounds
				Dim x1 As Integer = bounds.X + 5 + 40
				bounds = e.Bounds
				Dim num1 As Integer = bounds.Y + 40
				bounds = e.Bounds
				Dim rectangle1 As System.Drawing.RectangleF = New System.Drawing.Rectangle(x1, num1, bounds.Width - 40, font2.Height)
				Dim stringFormat As System.Drawing.StringFormat = New System.Drawing.StringFormat() With
				{
					.Alignment = StringAlignment.Near,
					.Trimming = StringTrimming.EllipsisCharacter
				}
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
				Dim graphics As System.Drawing.Graphics = e.Graphics
				Dim mainImage As Bitmap = tag.MainImage
				bounds = e.Bounds
				Dim x2 As Integer = bounds.X + 4 + 5
				bounds = e.Bounds
				graphics.DrawImage(mainImage, x2, bounds.Y + 4, 32, 32)
				e.Graphics.DrawString(tag.HeaderText, font, New System.Drawing.SolidBrush(tag.HeaderColor), rectangle, stringFormat)
				e.Graphics.DrawString(tag.MinorText, font1, Brushes.Blue, rectangleF, stringFormat)
				e.Graphics.DrawString(tag.DescText, font2, Brushes.Black, rectangle1, stringFormat)
				stringFormat.Alignment = StringAlignment.Center
				If (Operators.CompareString(tag.ButtonText1, "", False) <> 0) Then
					Using solidBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.FromArgb(25, 152, 254))
						Dim graphic As System.Drawing.Graphics = e.Graphics
						Dim num2 As Integer = e.Bounds.X
						bounds = e.Bounds
						Dim width As Integer = num2 + bounds.Width - 105 - 10
						bounds = e.Bounds
						graphic.FillRectangle(solidBrush, New System.Drawing.Rectangle(width, bounds.Y + 5, 105, 30))
						Dim graphics1 As System.Drawing.Graphics = e.Graphics
						Dim buttonText1 As String = tag.ButtonText1
						Dim white As Brush = Brushes.White
						Dim x3 As Integer = e.Bounds.X
						bounds = e.Bounds
						Dim width1 As Integer = x3 + bounds.Width - 105 - 10 + 2
						bounds = e.Bounds
						graphics1.DrawString(buttonText1, font, white, New System.Drawing.Rectangle(width1, bounds.Y + 10, 105, 30), stringFormat)
					End Using
				End If
				If (Operators.CompareString(tag.ButtonText2, "", False) <> 0) Then
					Dim graphic1 As System.Drawing.Graphics = e.Graphics
					Dim controlLight As Brush = SystemBrushes.ControlLight
					Dim num3 As Integer = e.Bounds.X
					bounds = e.Bounds
					Dim width2 As Integer = num3 + bounds.Width - 230
					bounds = e.Bounds
					graphic1.FillRectangle(controlLight, New System.Drawing.Rectangle(width2, bounds.Y + 5, 105, 30))
					Dim graphics2 As System.Drawing.Graphics = e.Graphics
					Dim buttonText2 As String = tag.ButtonText2
					Dim black As Brush = Brushes.Black
					Dim x4 As Integer = e.Bounds.X
					bounds = e.Bounds
					Dim width3 As Integer = x4 + bounds.Width - 230 + 2
					bounds = e.Bounds
					graphics2.DrawString(buttonText2, font, black, New System.Drawing.Rectangle(width3, bounds.Y + 10, 105, 30), stringFormat)
				End If
			End If
		End Sub

		Public Event Button1Click As EventHandler(Of FileEventArgs)

		Public Event Button2Click As EventHandler(Of FileEventArgs)
	End Class
End Namespace