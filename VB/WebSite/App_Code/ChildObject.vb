Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports System.ComponentModel

<TypeConverter(GetType(ChildObjectTypeConverter))> _
Public Class ChildObject
	Inherits XPObject
	Public Sub New()
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

	Protected _ChildName As String
	Public Property ChildName() As String
		Get
			Return _ChildName
		End Get
		Set(ByVal value As String)
			SetPropertyValue(Of String)("ChildName", _ChildName, value)
		End Set
	End Property

	<Association("Child-Parents", GetType(ParentObject))> _
	Public ReadOnly Property Parents() As XPCollection(Of ParentObject)
		Get
			Return GetCollection(Of ParentObject)("Parents")
		End Get
	End Property

End Class

'
' * Resources:
' * http://www.codeproject.com/KB/dotnet/BasicPropertyGrid.aspx
' * http://msdn.microsoft.com/en-us/library/ayybcxe5.aspx
' * 
' * ChildObjectTypeConverter:
' * Converts the ChildObject to String: store Oid;
' * Converts the ChildObject from String: get the object from the Session;
' 

Public Class ChildObjectTypeConverter
	Inherits TypeConverter
	Public Overrides Overloads Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
		If sourceType Is GetType(String) Then
			Return True
		End If

		Return MyBase.CanConvertFrom(context, sourceType)
	End Function

	Public Overrides Overloads Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object
		If TypeOf value Is String Then
			Dim session As New Session()
			Dim child As ChildObject = session.GetObjectByKey(Of ChildObject)(Convert.ToInt32(value))

			Return child
		End If

		Return MyBase.ConvertFrom(context, culture, value)
	End Function

	Public Overrides Overloads Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
		If destinationType Is GetType(String) Then
			Dim childObject As ChildObject = CType(value, ChildObject)

			Return childObject.Oid.ToString()
		End If

		Return MyBase.ConvertTo(context, culture, value, destinationType)
	End Function
End Class