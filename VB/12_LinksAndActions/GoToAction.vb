Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Attachments
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text

Namespace GoToAction
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'create a pdf document
			Dim pdf As New PdfDocument()
			Dim page As PdfPageBase = pdf.Pages.Add()

			'add a GoToE in pdf 
			EmbeddedGoToAction(pdf, page)

			'creat a action that could jump to specific location
			JumpToSpecificLocationAction(pdf, page)

			'save and launch
			pdf.SaveToFile("GoToAction.pdf")
			PDFDocumentViewer("GoToAction.pdf")

		End Sub

		''' <summary>
		''' GoToE action
		''' </summary>
		''' <param name="pdf"></param>
		Private Shared Sub EmbeddedGoToAction(ByVal pdf As PdfDocument, ByVal page As PdfPageBase)
			'add a attachment
			Dim attachment As New PdfAttachment("..\..\..\..\..\..\Data\GoToAction.pdf")
			pdf.Attachments.Add(attachment)

			Dim text As String = "Test embedded go-to action! Click this will open the attached PDF in a new window."
			Dim font As New PdfTrueTypeFont(New Font("Arial", 13f))
			Dim width As Single = 490f
			Dim height As Single = font.Height * 2.2f
			Dim rect As New RectangleF(0, 100, width, height)
			page.Canvas.DrawString(text, font, PdfBrushes.Black, rect)

			'create a PdfDestination with specific page, location and 200% zoom factor
			Dim dest As New PdfDestination(1, New PointF(0, 842), 2f)

			'create GoToE action with dest
			Dim action As New PdfEmbeddedGoToAction(attachment.FileName, dest, True)
			Dim annotation As New PdfActionAnnotation(rect, action)

			'add the annotation
			TryCast(page, PdfNewPage).Annotations.Add(annotation)
		End Sub

		Private Shared Sub JumpToSpecificLocationAction(ByVal pdf As PdfDocument, ByVal page As PdfPageBase)
			'add a new page
			Dim pagetwo As PdfPageBase = pdf.Pages.Add()

			'draw text on the page
			pagetwo.Canvas.DrawString("This is Page Two.", New PdfFont(PdfFontFamily.Helvetica, 20f), New PdfSolidBrush(Color.Black), 10, 10)

			'create PdfDestination instance and link to PdfGoToAction
			Dim pageBottomDest As New PdfDestination(pagetwo)
			pageBottomDest.Location = New PointF(0, 5)
			pageBottomDest.Mode = PdfDestinationMode.Location
			pageBottomDest.Zoom = 1f
			Dim action As New PdfGoToAction(pageBottomDest)

			Dim buttonFont As New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold))
			Dim buttonWidth As Single = 70
			Dim buttonHeight As Single = buttonFont.Height * 1.5f
			Dim format2 As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			Dim buttonBounds As New RectangleF(0, 200, buttonWidth, buttonHeight)

			'create a rectangle and draw text
			page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds)
			page.Canvas.DrawString("To Last Page", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2)

			'add the annotation
			Dim annotation As New PdfActionAnnotation(buttonBounds, action)
			annotation.Border = New PdfAnnotationBorder(0.75f)
			annotation.Color = Color.LightGray
			TryCast(page, PdfNewPage).Annotations.Add(annotation)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
