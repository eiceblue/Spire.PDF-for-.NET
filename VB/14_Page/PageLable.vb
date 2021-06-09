Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace PageLable
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\Sample.pdf"
			Dim output As String = "notExistLableAddNew.pdf"

			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)
			doc.PageLabels = New PdfPageLabels()
			doc.PageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "label test ")
			doc.SaveToFile(output, FileFormat.PDF)

			PDFDocumentViewer(output)
		End Sub
		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			Dim input As String = "..\..\..\..\..\..\Data\hasLable.pdf"
			Dim output As String = "ChangeLable.pdf"

			Dim newdoc As New PdfDocument()
			newdoc.LoadFromFile(input)
			Dim pageLabels As PdfPageLabels = newdoc.PageLabels
			pageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "new lable")
			newdoc.SaveToFile(output, FileFormat.PDF)

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
