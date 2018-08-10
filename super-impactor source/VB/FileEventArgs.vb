Imports System

Namespace SuperImpactor
	Public Class FileEventArgs
		Inherits EventArgs
		Public data As ExtraData

		Public Sub New(ByVal v As ExtraData)
			MyBase.New()
			Me.data = v
		End Sub
	End Class
End Namespace