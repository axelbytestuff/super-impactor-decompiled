Imports System
Imports System.Collections.Generic

Namespace SuperImpactor
	Public Class AppleAppInfo
		Public price As Double

		Public fileSizeBytes As String

		Public description As String

		Public releaseDate As String

		Public minimumOsVersion As String

		Public screenshotUrls As List(Of String)

		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace