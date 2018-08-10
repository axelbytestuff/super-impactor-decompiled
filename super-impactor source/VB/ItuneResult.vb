Imports System
Imports System.Collections.Generic

Namespace SuperImpactor
	Public Class ItuneResult
		Public resultCount As Integer

		Public results As List(Of AppleAppInfo)

		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace