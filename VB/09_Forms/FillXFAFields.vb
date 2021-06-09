Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports System.ComponentModel
Imports System.Text

Namespace FillXFAFields
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim doc As New PdfDocument()
			doc.LoadFromFile("XFASample.pdf")

			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)
			Dim xfafields As List(Of XfaField) = formWidget.XFAForm.XfaFields
			For Each xfaField As XfaField In xfafields
				If TypeOf xfaField Is XfaTextField Then
					Dim xf As XfaTextField = TryCast(xfaField, XfaTextField)

					Select Case xfaField.Name
						Case "EmployeeName"
							xf.Value = "Gary"
						Case "Address"
							xf.Value = "Chengdu, China"
						Case "StateProv"
							xf.Value = "Sichuan Province"
						Case "ZipCode"
							xf.Value = "610093"
						Case "SSNumber"
							xf.Value = "000-00-0000"
						Case "HomePhone"
							xf.Value = "86-028-81705109"
						Case "CellPhone"
							xf.Value = "123456789"
						Case "Comments"
							xf.Value = "This demo shows how to fill XFA forms using Spire.PDF"
						Case Else
					End Select
				End If
			Next xfaField
			doc.SaveToFile("FillXfaField.pdf", FileFormat.PDF)
		End Sub
	End Class
End Namespace
