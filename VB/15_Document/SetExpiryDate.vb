Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Namespace SetExpiryDate
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Load the input file path
			Dim input As String = "..\..\..\..\..\..\Data\PDFTemplate-Az.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the document from the input file path
			doc.LoadFromFile(input)

			' Define JavaScript code for date validation and expiration message
			Dim javaScript As String = "var rightNow = new Date();" & "var endDate = new Date('October 20, 2015 23:59:59');" & "if(rightNow.getTime() > endDate)" & "app.alert('This document has expired, please contact us for a new one.',1);" & "this.closeDoc();"

			' Create a PdfJavaScriptAction object with the JavaScript code
			Dim js As New PdfJavaScriptAction(javaScript)

			' Set the action to be executed after the document is opened
			doc.AfterOpenAction = js

			' Specify the output file name
			Dim result As String = "SetExpiryDate_out.pdf"

			' Save the modified document to the output file path
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
