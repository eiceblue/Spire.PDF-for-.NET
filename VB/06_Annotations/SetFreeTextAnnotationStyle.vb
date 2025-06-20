Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics

Namespace SetFreeTextAnnotationStyle
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object 
			Dim doc As New PdfDocument()

			' Load an existing PDF document
			doc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_4.pdf")

			' Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			' Create a rectangle for the annotation position and size
			Dim rect As New RectangleF(150, 120, 150, 30)

			' Create a free text annotation with the specified rectangle
			Dim textAnnotation As New PdfFreeTextAnnotation(rect)

			'Specify content.
			textAnnotation.Text = vbLf & "Free Text Annotation Formatting"

			' Set the font of the annotation
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 10)
			textAnnotation.Font = font

			' Set the border of the annotation
			Dim border As New PdfAnnotationBorder(1.0F)
			textAnnotation.Border = border

			' Set the border color of the annotation
			textAnnotation.BorderColor = Color.Purple

			' Set the line ending style of the annotation
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle

			' Set the color of the annotation
			textAnnotation.Color = Color.Green

			' Set the opacity of the annotation
			textAnnotation.Opacity = 0.8F

			' Add the annotation to the page
            page.Annotations.Add(textAnnotation)

			' Repeat the above steps for three more annotations with different properties

			rect = New RectangleF(150, 200, 150, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "Free Text Annotation Formatting"
			border = New PdfAnnotationBorder(1.0F)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.LightGoldenrodYellow
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightPink
			textAnnotation.Opacity = 0.8F
            page.Annotations.Add(textAnnotation)

			rect = New RectangleF(150, 280, 280, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "How to Set Free Text Annotation Formatting in Pdf file"
			border = New PdfAnnotationBorder(1.0F)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Gray
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle
			textAnnotation.Color = Color.LightSkyBlue
			textAnnotation.Opacity = 0.8F
            page.Annotations.Add(textAnnotation)

			rect = New RectangleF(150, 360, 200, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "Free Text Annotation Formatting"
			border = New PdfAnnotationBorder(1.0F)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Pink
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightGreen
			textAnnotation.Opacity = 0.8F
            page.Annotations.Add(textAnnotation)

			' Save the modified PDF document to a file
			Dim result As String = "SetFreeTextAnnotationFormatting_out.pdf"
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
