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
			'Create a pdf document.
			Dim doc As New PdfDocument()

			'margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			'create section
			Dim section As PdfSection = doc.Sections.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = margin

			' Create one page
			Dim page As PdfPageBase = section.Pages.Add()

			Dim y As Single = 10

			'title
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
            page.Canvas.DrawString("Attachment", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
			y = y + font1.MeasureString("Attachment", format1).Height
			y = y + 5

			'attachment
			Dim attachment As New PdfAttachment("Header.png")
            attachment.Data = File.ReadAllBytes("..\..\..\..\..\..\..\Data\Header.png")
			attachment.Description = "Page header picture of demo."
			attachment.MimeType = "image/png"
			doc.Attachments.Add(attachment)

			attachment = New PdfAttachment("Footer.png")
            attachment.Data = File.ReadAllBytes("..\..\..\..\..\..\..\Data\Footer.png")
			attachment.Description = "Page footer picture of demo."
			attachment.MimeType = "image/png"
			doc.Attachments.Add(attachment)

			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Bold))
			Dim location As New PointF(0, y)
			Dim label As String = "Sales Report Chart"
            Dim data() As Byte = File.ReadAllBytes("..\..\..\..\..\..\..\Data\SalesReportChart.png")
			Dim size As SizeF = font2.MeasureString(label)
			Dim bounds As New RectangleF(location, size)
			page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
            bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)
			Dim annotation1 As New PdfAttachmentAnnotation(bounds, "SalesReportChart.png", data)
			annotation1.Color = Color.Teal
			annotation1.Flags = PdfAnnotationFlags.ReadOnly
			annotation1.Icon = PdfAttachmentIcon.Graph
			annotation1.Text = "Sales Report Chart"
			TryCast(page, PdfNewPage).Annotations.Add(annotation1)
			y = y + size.Height + 2

			location = New PointF(0, y)
			label = "Science Personification Boston"
            data = File.ReadAllBytes("..\..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg")
			size = font2.MeasureString(label)
			bounds = New RectangleF(location, size)
			page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
            bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)
			Dim annotation2 As New PdfAttachmentAnnotation(bounds, "SciencePersonificationBoston.jpg", data)
			annotation2.Color = Color.Orange
			annotation2.Flags = PdfAnnotationFlags.NoZoom
			annotation2.Icon = PdfAttachmentIcon.PushPin
			annotation2.Text = "SciencePersonificationBoston.jpg, from Wikipedia, the free encyclopedia"
			TryCast(page, PdfNewPage).Annotations.Add(annotation2)
			y = y + size.Height + 2

			location = New PointF(0, y)
			label = "Picture of Science"
            data = File.ReadAllBytes("..\..\..\..\..\..\..\Data\Wikipedia_Science.png")
			size = font2.MeasureString(label)
			bounds = New RectangleF(location, size)
			page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
            bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)
			Dim annotation3 As New PdfAttachmentAnnotation(bounds, "Wikipedia_Science.png", data)
			annotation3.Color = Color.SaddleBrown
			annotation3.Flags = PdfAnnotationFlags.Locked
			annotation3.Icon = PdfAttachmentIcon.Tag
			annotation3.Text = "Wikipedia_Science.png, from Wikipedia, the free encyclopedia"
			TryCast(page, PdfNewPage).Annotations.Add(annotation3)
			y = y + size.Height + 2

			location = New PointF(0, y)
			label = "Hawaii Killer Font"
            data = File.ReadAllBytes("..\..\..\..\..\..\..\Data\Hawaii_Killer.ttf")
			size = font2.MeasureString(label)
			bounds = New RectangleF(location, size)
			page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
            bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)
			Dim annotation4 As New PdfAttachmentAnnotation(bounds, "Hawaii_Killer.ttf", data)
			annotation4.Color = Color.CadetBlue
			annotation4.Flags = PdfAnnotationFlags.NoRotate
			annotation4.Icon = PdfAttachmentIcon.Paperclip
			annotation4.Text = "Hawaii Killer Font, from http://www.1001freefonts.com"
			TryCast(page, PdfNewPage).Annotations.Add(annotation4)
			y = y + size.Height + 2

			'Save pdf file.
			doc.SaveToFile("Attachment.pdf")
			doc.Close()

			'Launching the Pdf file.
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
