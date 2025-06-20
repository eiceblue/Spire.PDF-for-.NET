Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics

Namespace InvisibleFreeTextAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object 
			Dim doc As New PdfDocument()

			doc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_4.pdf")

			' Get the first page of the PDF
			Dim page As PdfPageBase = doc.Pages(0)

			' Define the rectangle for the first free text annotation
			Dim rect As New RectangleF(100, 120, 150, 30)

			' Create a new PdfFreeTextAnnotation with the specified rectangle
			Dim FreetextAnnotation As New PdfFreeTextAnnotation(rect)

			' Set the text content of the free text annotation
			FreetextAnnotation.Text = "Invisible Free Text Annotation"

			' Create a new font for the annotation
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 10)

			' Create a border for the annotation
			Dim border As New PdfAnnotationBorder(1.0F)

			' Set the font and border properties of the free text annotation
			FreetextAnnotation.Font = font
			FreetextAnnotation.Border = border

			' Set the border color of the free text annotation to purple
			FreetextAnnotation.BorderColor = Color.Purple

			' Set the line ending style of the free text annotation to a circle
			FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle

			' Set the color of the free text annotation to green
			FreetextAnnotation.Color = Color.Green

			' Set the opacity of the free text annotation to 0.8
			FreetextAnnotation.Opacity = 0.8F

			' Set the flags of the free text annotation to enable printing and disable viewing
			FreetextAnnotation.Flags = PdfAnnotationFlags.Print Or PdfAnnotationFlags.NoView

			' Add the first free text annotation to the page's annotations widget
            page.Annotations.Add(FreetextAnnotation)

			' Define the rectangle for the second free text annotation
			rect = New RectangleF(100, 180, 150, 30)

			' Create a new PdfFreeTextAnnotation with the specified rectangle
			FreetextAnnotation = New PdfFreeTextAnnotation(rect)

			' Set the text content of the free text annotation
			FreetextAnnotation.Text = "Show Free Text Annotation"

			' Set the font and border properties of the free text annotation
			FreetextAnnotation.Font = font
			FreetextAnnotation.Border = border

			' Set the border color of the free text annotation to light pink
			FreetextAnnotation.BorderColor = Color.LightPink

			' Set the line ending style of the free text annotation to a circle
			FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle

			' Set the color of the free text annotation to light green
			FreetextAnnotation.Color = Color.LightGreen

			' Set the opacity of the free text annotation to 0.8
			FreetextAnnotation.Opacity = 0.8F

			' Add the second free text annotation to the page's annotations widget
            page.Annotations.Add(FreetextAnnotation)

			' Specify the output file path for the modified PDF
			Dim result As String = "InvisibleFreeTextAnnotation_out.pdf"

			' Save the modified PDF document to the output file
			doc.SaveToFile(result)

			' Close the PDF document
			doc.Close()

			'Launch the Pdf file
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
