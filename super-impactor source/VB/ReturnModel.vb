Imports System

Namespace SuperImpactor
	Public Class ReturnModel
		Private m_return_code As Integer

		Private m_message As String

		Public Property message As String
			Get
				Return Me.m_message
			End Get
			Set(ByVal value As String)
				Me.m_message = value
			End Set
		End Property

		Public Property return_code As Integer
			Get
				Return Me.m_return_code
			End Get
			Set(ByVal value As Integer)
				Me.m_return_code = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace