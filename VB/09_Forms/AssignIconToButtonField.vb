Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text

Namespace AssignIconToButtonField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a PDF document       
			Dim doc As New PdfDocument()
			Dim page As PdfPageBase = doc.Pages.Add()

			'Create a Button
			Dim btn As New PdfButtonField(page, "button1")
			btn.Bounds = New RectangleF(0, 50, 120, 100)
			btn.HighlightMode = PdfHighlightMode.Push
			btn.LayoutMode = PdfButtonLayoutMode.CaptionOverlayIcon

			'Set text and icon for Normal appearance
			btn.Text = "Normal Text"
			btn.Icon = PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png")

			'Set text and icon for Click appearance (Can only be set when highlight mode is Push)
			btn.AlternateText = "Alternate Text"
			btn.AlternateIcon = PdfImage.FromFile("..\..\..\..\..\..\Data\PdfImage.png")

			'Set text and icon for Rollover appearance (Can only be set when highlight mode is Push)
			btn.RolloverText = "Rollover Text"
			btn.RolloverIcon = PdfImage.FromFile("..\..\..\..\..\..\Data\PDFJAVA.png")

			'Set icon layout
			btn.IconLayout.Spaces = New Single() { 0.5f, 0.5f }
			btn.IconLayout.ScaleMode = PdfButtonIconScaleMode.Proportional
			btn.IconLayout.ScaleReason = PdfButtonIconScaleReason.Always
			btn.IconLayout.IsFitBounds = False

			'Add the button to the document
			doc.Form.Fields.Add(btn)

			Dim result As String = "AssignIconToButtonField-result.pdf"

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
