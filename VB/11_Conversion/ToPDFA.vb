Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf

Namespace ToPDFA
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file
			Dim input As String = "..\..\..\..\..\..\Data\Sample5.pdf"

			'open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)
            Dim newDoc As New PdfNewDocument()
			'set to pdfA 
            newDoc.Conformance = PdfConformanceLevel.Pdf_A1B
            For i As Integer = 0 To doc.Pages.Count - 1
                Dim size As SizeF = doc.Pages(i).Size
                Dim newPage As PdfPageBase = newDoc.Pages.Add(size, New Spire.Pdf.Graphics.PdfMargins(0))
                doc.Pages(i).CreateTemplate().Draw(newPage, 0, 0)
            Next


			Dim output As String = "ToPDFA.pdf"

            newDoc.Save(output)

			'Launching the result file.
			PDFDocumentViewer(output)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
