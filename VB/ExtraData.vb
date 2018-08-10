Imports System
Imports System.Drawing
Imports System.Runtime.CompilerServices

Namespace SuperImpactor
	Public Class ExtraData
		Public Property AppDetailObj As AppInfos

		Public Property ButtonText1 As String

		Public Property ButtonText2 As String

		Public Property DescText As String

		Public Property HeaderColor As Color

		Public Property HeaderText As String

		Public Property MainImage As Bitmap

		Public Property MinorText As String

		Public Sub New()
			MyBase.New()
			Me.HeaderColor = Color.Black
		End Sub
	End Class
End Namespace