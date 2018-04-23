Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsCallback) AndAlso (Not IsPostBack) Then
			htmlEditor.Html = LoadHtml()
		End If
	End Sub
	Protected Sub htmlEditor_CustomDataCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CustomDataCallbackEventArgs)
		Select Case e.Parameter
			Case "Save"
				'Code Central - Read Only Mode
				'SaveHtml(htmlEditor.Html)
		End Select
	End Sub
	Private Function LoadHtml() As String
		Dim html As String = String.Empty

		Using connection As OleDbConnection = GetConnection()
			Dim command As New OleDbCommand(String.Empty, connection)
			command.CommandText = "SELECT TOP 1 [Html] FROM [Items]"

			connection.Open()
			Dim htmlFromDatabase As Object = command.ExecuteScalar()
			If htmlFromDatabase IsNot Nothing Then
				html = htmlFromDatabase.ToString()
			End If
		End Using

		Return html
	End Function
	Private Sub SaveHtml(ByVal html As String)
		Using connection As OleDbConnection = GetConnection()
			Dim command As New OleDbCommand(String.Empty, connection)
			command.CommandText = String.Format("UPDATE [Items] SET [Html] = '{0}'", html)

			connection.Open()
			command.ExecuteNonQuery()
		End Using
	End Sub
	Private Function GetConnection() As OleDbConnection
		Dim connection As New OleDbConnection()
		connection.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", MapPath("~/App_Data/Database.mdb"))
		Return connection
	End Function
End Class