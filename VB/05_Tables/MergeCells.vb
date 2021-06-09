Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid
Imports System.ComponentModel
Imports System.Text

Namespace MergeCells
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document and load file from disk
			Dim doc As New PdfDocument()
		doc.LoadFromFile("..\..\..\..\..\..\Data\MergeCells.pdf")
			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Create a grid
			Dim grid As New PdfGrid()
			grid.Columns.Add(5)

			'Set the width
			For j As Integer = 0 To grid.Columns.Count - 1
				grid.Columns(j).Width = 100
			Next j

			'Add rows
			Dim row0 As PdfGridRow = grid.Rows.Add()
			Dim row1 As PdfGridRow = grid.Rows.Add()
			Dim height As Single = 21.0f

			'Set the height
			For i As Integer = 0 To grid.Rows.Count - 1
				grid.Rows(i).Height = height
			Next i

			grid.Draw(page, New PointF(50, 410))

			row0.Style.Font = New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold), True)
			row1.Style.Font = New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Italic), True)

			row0.Cells(0).Value = "Corporation"

			'Merge two rows
			row0.Cells(0).RowSpan = 2

			row0.Cells(1).Value = "B&K Undersea Photo"
			row0.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

			'Merge two columns
			row0.Cells(1).ColumnSpan = 3

			row0.Cells(4).Value = "World"
			row0.Cells(4).Style.Font = New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold Or FontStyle.Italic), True)
			row0.Cells(4).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			row0.Cells(4).Style.BackgroundBrush = PdfBrushes.LightGreen

			row1.Cells(1).Value = "Diving International Unlimited"
			row1.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

			'Merge four columns
			row1.Cells(1).ColumnSpan = 4

			grid.Draw(page, New PointF(50, 480))

			'Save the pdf document
			doc.SaveToFile("MergeCells.pdf")

			'Launch the document
			PDFDocumentViewer("MergeCells.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
