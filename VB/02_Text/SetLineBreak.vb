Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SetLineBreak
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Create one A4 page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, New PdfMargins(40))

			'Create brush from color channel
			Dim brush As New PdfSolidBrush(Color.Black)

			'Create text
			Dim text As String = "Spire.PDF for .NET" & vbLf & "A professional PDF library applied to" & " creating, writing, editing, handling and reading PDF files" & " without any external dependencies within .NET" & "( C#, VB.NET, ASP.NET, .NET Core) application."

			text &= vbLf & vbCr & "Spire.PDF for Java" & vbLf & "A PDF Java API that enables developers to read, " & "write, convert and print PDF documents" & "in Java applications without using Adobe Acrobat."
			text &= vbLf & vbCr
			text &= "Welcome to evaluate Spire.PDF!"

			'Create rectangle with specified dimensions      
			Dim rect As New RectangleF(50, 50, page.Size.Width - 150, page.Size.Height)

			'Draw the text
			page.Canvas.DrawString(text, New PdfFont(PdfFontFamily.Helvetica, 13f), brush, rect)

			Dim result As String = "SetLineBreak_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
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
