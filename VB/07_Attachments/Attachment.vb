Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Attachments
Imports Spire.Pdf.Graphics

Namespace Attachment
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object 
			Dim doc As New PdfDocument()

			' Load an existing PDF file named "Attachment.pdf"
			doc.LoadFromFile("..\..\..\..\..\..\Data\Attachment.pdf")

			' Get the first page of the PDF
			Dim page As PdfPageBase = doc.Pages(0)

			' Set initial Y position for drawing content
			Dim y As Single = 320

			' Set brush, font, and format for the title text
			Dim brush1 As PdfBrush = PdfBrushes.CornflowerBlue
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 18.0F, FontStyle.Bold))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font1 As New PdfTrueTypeFont("Arial", 18.0F, FontStyle.Bold, True)
			' =============================================================================
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

			' Draw the title text "Attachment" on the page
			page.Canvas.DrawString("Attachment", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)

			' Update the Y position for the next element
			y = y + font1.MeasureString("Attachment", format1).Height
			y = y + 10

			' Create a new PdfAttachment object for the header image
			Dim attachment As New PdfAttachment("Header.png")
			attachment.Data = File.ReadAllBytes("..\..\..\..\..\..\Data\Header.png")
			attachment.Description = "Page header picture of demo."
			attachment.MimeType = "image/png"
			doc.Attachments.Add(attachment)

			' Create another PdfAttachment object for the footer image
			attachment = New PdfAttachment("Footer.png")
			attachment.Data = File.ReadAllBytes("..\..\..\..\..\..\Data\Footer.png")
			attachment.Description = "Page footer picture of demo."
			attachment.MimeType = "image/png"
			doc.Attachments.Add(attachment)

			' Set X position, font, location, and label for the first annotation
			Dim x As Single = 50
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 14.0F, FontStyle.Bold))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font2 As New PdfTrueTypeFont("Arial", 14.0F, FontStyle.Bold, True)
			' =============================================================================
			Dim location As New PointF(x, y)
			Dim label As String = "Sales Report Chart"
			Dim data() As Byte = File.ReadAllBytes("..\..\..\..\..\..\Data\SalesReportChart.png")
			Dim size As SizeF = font2.MeasureString(label)
			Dim bounds As New RectangleF(location, size)

			' Draw the label text on the page
			page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)

			' Set bounds for the first annotation
			bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)

			' Create a new PdfAttachmentAnnotation object with the specified bounds, file name, and data
			Dim annotation1 As New PdfAttachmentAnnotation(bounds, "SalesReportChart.png", data)

			' Set the color of the annotation to Teal
			annotation1.Color = Color.Teal

			' Set the flags of the annotation to ReadOnly
			annotation1.Flags = PdfAnnotationFlags.ReadOnly

			' Set the icon of the annotation to Graph
			annotation1.Icon = PdfAttachmentIcon.Graph

			' Set the text of the annotation
			annotation1.Text = "Sales Report Chart"

			' Add the annotation to the page
            page.Annotations.Add(annotation1)

			' Update the Y position for the next element
			y = y + size.Height + 3

			' Repeat the above steps for the next annotations with different data and settings

			location = New PointF(x, y)
			label = "Science Personification Boston"
			data = File.ReadAllBytes("..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg")
			size = font2.MeasureString(label)
			bounds = New RectangleF(location, size)
			page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
			bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)

			Dim annotation2 As New PdfAttachmentAnnotation(bounds, "SciencePersonificationBoston.jpg", data)
			annotation2.Color = Color.Orange
			annotation2.Flags = PdfAnnotationFlags.NoZoom
			annotation2.Icon = PdfAttachmentIcon.PushPin
			annotation2.Text = "SciencePersonificationBoston.jpg, from Wikipedia, the free encyclopedia"
            page.Annotations.Add(annotation2)

			y = y + size.Height + 2

			location = New PointF(x, y)
			label = "Picture of Science"
			data = File.ReadAllBytes("..\..\..\..\..\..\Data\Wikipedia_Science.png")
			size = font2.MeasureString(label)
			bounds = New RectangleF(location, size)
			page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
			bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)

			Dim annotation3 As New PdfAttachmentAnnotation(bounds, "Wikipedia_Science.png", data)
			annotation3.Color = Color.SaddleBrown
			annotation3.Flags = PdfAnnotationFlags.Locked
			annotation3.Icon = PdfAttachmentIcon.Tag
			annotation3.Text = "Wikipedia_Science.png, from Wikipedia, the free encyclopedia"
            page.Annotations.Add(annotation3)

			y = y + size.Height + 2

			location = New PointF(x, y)
			label = "PT_Serif-Caption-Web-Regular Font"
			data = File.ReadAllBytes("..\..\..\..\..\..\Data\PT_Serif-Caption-Web-Regular.ttf")
			size = font2.MeasureString(label)
			bounds = New RectangleF(location, size)
			page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
			bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)

			Dim annotation4 As New PdfAttachmentAnnotation(bounds, "PT_Serif-Caption-Web-Regular.ttf", data)
			annotation4.Color = Color.CadetBlue
			annotation4.Icon = PdfAttachmentIcon.Paperclip
			annotation4.Text = "PT_Serif-Caption-Web-Regular Font, from https://company.paratype.com"
            page.Annotations.Add(annotation4)

			y = y + size.Height + 2

			' Save the modified PDF document
			doc.SaveToFile("Attachment.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("Attachment.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
