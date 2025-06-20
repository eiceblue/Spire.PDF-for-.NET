Imports Spire.Pdf

Namespace PageLable
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim input As String = "..\..\..\..\..\..\Data\Sample.pdf"

			' Specify the output file path for the modified PDF
			Dim output As String = "notExistLableAddNew.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load an existing PDF from disk
			doc.LoadFromFile(input)

			' Assign a new instance of PdfPageLabels to doc.PageLabels
			doc.PageLabels = New PdfPageLabels()

			' Add page labels starting from page 0 with Decimal Arabic Numerals style and text "label test"
			doc.PageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "label test ")

			' Save the modified document to the output file
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the PDF document
			doc.Close()

			' Launch the file
			PDFDocumentViewer(output)
		End Sub
		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			' Specify the input file path
			Dim input As String = "..\..\..\..\..\..\Data\hasLable.pdf"

			' Specify the output file path for the modified PDF
			Dim output As String = "ChangeLable.pdf"

			' Create a new PdfDocument object
			Dim newdoc As New PdfDocument()

			' Load an existing PDF from disk
			newdoc.LoadFromFile(input)

			' Get the current page labels
			Dim pageLabels As PdfPageLabels = newdoc.PageLabels

			' Add page labels starting from page 0 with Decimal Arabic Numerals style and text "new label"
			pageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "new label")

			' Save the modified document to the output file
			newdoc.SaveToFile(output, FileFormat.PDF)

			' Close the PDF document
			newdoc.Close()

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
