Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo



	Public Class ParentObject
		Inherits XPObject
		Private Sub New()
			MyBase.New()
			' This constructor is used when an object is loaded from a persistent storage.
			' Do not place any code here.
		End Sub

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
			' This constructor is used when an object is loaded from a persistent storage.
			' Do not place any code here.
		End Sub

		Public Overrides Sub AfterConstruction()
			MyBase.AfterConstruction()
			' Place here your initialization code.
		End Sub

		Protected _Child As ChildObject
		<Association("Child-Parents", GetType(ParentObject))> _
		Public Property Child() As ChildObject
			Get
				Return _Child
			End Get
			Set(ByVal value As ChildObject)
				SetPropertyValue(Of ChildObject)("Child", _Child, value)
			End Set
		End Property

		Protected _Name As String
		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Name", _Name, value)
			End Set
		End Property
	End Class

