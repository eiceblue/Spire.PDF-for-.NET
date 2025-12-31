Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace Transparency
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Add a new section to the document
            Dim section As PdfSection = doc.Sections.Add()

            ' Load an image from file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\ChartImage.png")

            ' Calculate the dimensions of the image
            Dim imageWidth As Single = image.PhysicalDimension.Width / 2
            Dim imageHeight As Single = image.PhysicalDimension.Height / 2

            ' Iterate over each blend mode option
            For Each mode As PdfBlendMode In System.Enum.GetValues(GetType(PdfBlendMode))

                ' Add a new page to the section
                Dim page As PdfPageBase = section.Pages.Add()

                ' Get the width of the page canvas
                Dim pageWidth As Single = page.Canvas.ClientSize.Width

                ' Set an initial value for the y coordinate
                Dim y As Single = 0

                ' Increase the y coordinate by 15 units
                y = y + 15

                ' Create a brush for drawing text
                Dim brush As PdfBrush = New PdfSolidBrush(Color.OrangeRed)

                ' Create a font for the text
                Dim font As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))

                ' =============================================================================
                ' Use the following code for netstandard dlls
                ' =============================================================================
                'Dim font As New PdfTrueTypeFont("Arial", 16.0F, FontStyle.Bold, True)
                ' =============================================================================

                ' Create a string format for center alignment
                Dim format As New PdfStringFormat(PdfTextAlignment.Center)

                ' Create the text to display
                Dim text As String = String.Format("Transparency Blend Mode: {0}", mode)

                ' Draw the text on the page
                page.Canvas.DrawString(text, font, brush, pageWidth / 2, y, format)

                ' Measure the size of the text
                Dim size As SizeF = font.MeasureString(text, format)

                ' Increase the y coordinate based on the size of the text and add some spacing
                y = y + size.Height + 25

                ' Draw the image on the page
                page.Canvas.DrawImage(image, 0, y, imageWidth, imageHeight)

                ' Save the current canvas state
                page.Canvas.Save()

                ' Calculate the spacing between images
                Dim d As Single = (page.Canvas.ClientSize.Width - imageWidth) / 5

                ' Reset the x coordinate and adjust the y coordinate
                Dim x As Single = d
                y = y + d / 2 + 40

                ' Iterate over a range of values
                For i As Integer = 0 To 4
                    ' Calculate the alpha value based on the iteration
                    Dim alpha As Single = 1.0F / 6 * (5 - i)

                    ' Set the transparency for the canvas using the alpha and blend mode
                    page.Canvas.SetTransparency(alpha, alpha, mode)

                    ' Draw the image on the page with the adjusted transparency
                    page.Canvas.DrawImage(image, x, y, imageWidth, imageHeight)

                    ' Update the x and y coordinates for the next image
                    x = x + d
                    y = y + d / 2 + 40
                Next i

                ' Restore the canvas to its previous state
                page.Canvas.Restore()
            Next mode

            ' Save the document to a file named "Transparency.pdf"
            doc.SaveToFile("Transparency.pdf")

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("Transparency.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
