Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace CreateMultilayerPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object.
			Dim doc As New PdfDocument()

			' Add a new page to the document and get a reference to it.
			Dim page As PdfPageBase = doc.Pages.Add()

			' Define the text to be displayed on the page.
			Dim text As String = "Welcome to evaluate Spire.PDF for .NET !"

			' Create a PdfStringFormat object with left alignment.
			Dim format As New PdfStringFormat(PdfTextAlignment.Left)

			' Create a PdfSolidBrush object with black color.
			Dim brush As New PdfSolidBrush(Color.Black)

			' Create a PdfTrueTypeFont object using the Calibri font with size 15 and regular style.
			Dim font As New PdfTrueTypeFont(New Font("Calibri", 15.0F, FontStyle.Regular))

			' Set the initial coordinates for drawing the text.
			Dim x As Single = 50
			Dim y As Single = 50

			' Draw the text on the page using the specified font, brush, position, and format.
			page.Canvas.DrawString(text, font, brush, New PointF(x, y), format)

			' Measure the size of the text "Welcome to evaluate" and "Spire.PDF for .NET" using the specified font and format.
			Dim size As SizeF = font.MeasureString("Welcome to evaluate", format)
			Dim size2 As SizeF = font.MeasureString("Spire.PDF for .NET", format)

			' Load an image from the specified path.
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\MultilayerImage.png")

			' Draw the image on the page at the specified position, adjusting the x-coordinate based on the measured text sizes.
			page.Canvas.DrawImage(image, New PointF(x + size.Width, y), size2)

			' Specify the file name for the resulting PDF document.
			Dim result As String = "CreateMultilayerPDF_out.pdf"

			' Save the document to the specified file.
			doc.SaveToFile(result)

			' Close the document.
			doc.Close()

			' Launch the Pdf file.
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
