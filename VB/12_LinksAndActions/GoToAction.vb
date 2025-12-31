Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Attachments
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics

Namespace GoToAction
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim pdf As New PdfDocument()

			' Add a new page to the document
			Dim page As PdfPageBase = pdf.Pages.Add()

			' Call the EmbeddedGoToAction method to add an embedded go-to action to the page
			EmbeddedGoToAction(pdf, page)

			' Call the JumpToSpecificLocationAction method to add a jump to specific location action to the page
			JumpToSpecificLocationAction(pdf, page)

			' Save the modified document to a PDF file named "GoToAction_out.pdf"
			pdf.SaveToFile("GoToAction_out.pdf")
			
			' Close the PDF document
			pdf.Close()

			' Launch the PDF file
			PDFDocumentViewer("GoToAction_out.pdf")
		End Sub

		''' <summary>
		''' GoToE action
		''' </summary>
		''' <param name="pdf"></param>
		Private Shared Sub EmbeddedGoToAction(ByVal pdf As PdfDocument, ByVal page As PdfPageBase)
			' Create a new PdfAttachment object with the filename "1.pdf"
			Dim attachment As New PdfAttachment("..\..\..\..\..\..\Data\GoToAction.pdf")

			' Add the attachment to the document
			pdf.Attachments.Add(attachment)

			' Specify the text for the embedded go-to action
			Dim text As String = "Test embedded go-to action! Clicking this will open the attached PDF in a new window."

			' Create a font for the text
			Dim font As New PdfTrueTypeFont(New Font("Arial", 13.0F))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font As New PdfTrueTypeFont("Arial", 13.0F, FontStyle.Regular, True)
			' =============================================================================

			' Specify the width and height of the rectangle for positioning the text
			Dim width As Single = 490.0F
			Dim height As Single = font.Height * 2.2F

			' Create a rectangle for positioning the text
			Dim rect As New RectangleF(0, 100, width, height)

			' Draw the text on the page's canvas
			page.Canvas.DrawString(text, font, PdfBrushes.Black, rect)

			' Create a destination for the go-to action
			Dim dest As New PdfDestination(page, New PointF(0, 0))

			' Create an embedded go-to action that opens the attached PDF
			Dim action As New PdfEmbeddedGoToAction(attachment.FileName, dest, True)

			' Create an annotation with the action
			Dim annotation As New PdfActionAnnotation(rect, action)

			' Add the annotation to the page
			TryCast(page, PdfNewPage).Annotations.Add(annotation)
		End Sub

		Private Shared Sub JumpToSpecificLocationAction(ByVal pdf As PdfDocument, ByVal page As PdfPageBase)
			' Add a new page to the document
			Dim pagetwo As PdfPageBase = pdf.Pages.Add()

			' Draw some text on the second page
			pagetwo.Canvas.DrawString("This is Page Two.", New PdfFont(PdfFontFamily.Helvetica, 20.0F), New PdfSolidBrush(Color.Black), 10, 10)

			' Create a destination for jumping to the bottom of the second page
			Dim pageBottomDest As New PdfDestination(pagetwo)
			pageBottomDest.Location = New PointF(0, 5)
			pageBottomDest.Mode = PdfDestinationMode.Location
			pageBottomDest.Zoom = 1.0F

			' Create a go-to action that jumps to the specified location
			Dim action As New PdfGoToAction(pageBottomDest)

			' Create a font for a button
			Dim buttonFont As New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Bold))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim buttonFont As New PdfTrueTypeFont("Arial", 10.0F, FontStyle.Bold, True)
			' =============================================================================

			' Specify the width and height of the button
			Dim buttonWidth As Single = 70
			Dim buttonHeight As Single = buttonFont.Height * 1.5F

			' Specify the format for center-aligned text in the button
			Dim format2 As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

			' Create a rectangle for the button
			Dim buttonBounds As New RectangleF(0, 200, buttonWidth, buttonHeight)

			' Draw the button on the page's canvas
			page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds)
			page.Canvas.DrawString("To Last Page", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2)

			' Create an annotation with the go-to action
			Dim annotation As New PdfActionAnnotation(buttonBounds, action)
			annotation.Border = New PdfAnnotationBorder(0.75F)
			annotation.Color = Color.LightGray

			' Add the annotation to the page
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
