Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace HeaderAndFooter
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\..\Data\HeaderAndFooter.pdf"

            ' Create a new instance of PdfDocument
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified input file
            doc.LoadFromFile(input)

            ' Define the brush for drawing
            Dim brush As PdfBrush = PdfBrushes.Black

            ' Create a pen with the specified brush and line width
            Dim pen As New PdfPen(brush, 0.75F)

            ' Define the font for text
            Dim font As New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Italic), True)
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 10.0F, FontStyle.Italic, True)
            ' =============================================================================

            ' Create string formats for right alignment and left alignment
            Dim rightAlign As New PdfStringFormat(PdfTextAlignment.Right)
            Dim leftAlign As New PdfStringFormat(PdfTextAlignment.Left)

            ' Enable measurement of trailing spaces in the string formats
            rightAlign.MeasureTrailingSpaces = True
            leftAlign.MeasureTrailingSpaces = True

            ' Get the page margins from the document's page settings
            Dim margin As PdfMargins = doc.PageSettings.Margins

            ' Calculate the space between lines based on the font height
            Dim space As Single = font.Height * 0.75F

            ' Initialize variables for positioning elements on the page
            Dim x As Single = 0
            Dim y As Single = 0
            Dim width As Single = 0

            ' Create a new PDF document to store the modified pages
            Dim newPdf As New PdfDocument()
            Dim newPage As PdfPageBase

            ' Iterate through each page in the original document
            For Each page As PdfPageBase In doc.Pages
                ' Add a new page to the new PDF document with the same size and zero margins
                newPage = newPdf.Pages.Add(page.Size, New PdfMargins(0))

                ' Set transparency for the canvas
                newPage.Canvas.SetTransparency(0.5F)

                ' Calculate the x, y, and width values for drawing elements on the page
                x = margin.Left
                width = page.Canvas.ClientSize.Width - margin.Left - margin.Right
                y = margin.Top - space

                ' Draw a line on the page
                newPage.Canvas.DrawLine(pen, x, y + 15, x + width, y + 15)

                ' Adjust the y position for the next element
                y = y + 10 - font.Height

                ' Set transparency for the canvas again
                newPage.Canvas.SetTransparency(0.5F)

                ' Load and draw a header image on the page
                Dim headerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\..\Data\Header.png")
                newPage.Canvas.DrawImage(headerImage, New PointF(0, 0))

                ' Draw a string as the header text on the page, aligned to the right
                newPage.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, rightAlign)

                ' Load and draw a footer image on the page
                Dim footerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\..\Data\Footer.png")
                newPage.Canvas.DrawImage(footerImage, New PointF(0, newPage.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height))

                ' Update the brush and font for the footer text
                brush = PdfBrushes.DarkBlue
                font = New PdfTrueTypeFont(New Font("Arial", 12.0F, FontStyle.Bold), True)
                ' =============================================================================
                ' Use the following code for netstandard dlls
                ' =============================================================================
                'Dim font As New PdfTrueTypeFont("Arial", 12.0F, FontStyle.Bold, True)
                ' =============================================================================


                ' Calculate the y position for the footer text
                y = newPage.Canvas.ClientSize.Height - margin.Bottom - font.Height

                ' Draw a string as the footer text on the page, aligned to the left
                newPage.Canvas.DrawString("Created by E-iceblue Co,.Ltd", font, brush, x, y, leftAlign)

                ' Reset the transparency for the canvas
                newPage.Canvas.SetTransparency(1)

                ' Draw the original page content onto the new page using a template
                page.CreateTemplate().Draw(newPage.Canvas, New PointF(0, 0))
            Next page

            ' Specify the output file path
            Dim output As String = "Output.pdf"

            ' Save the modified PDF document to the output file
            newPdf.SaveToFile(output)

            ' Close the documents
            newPdf.Close()
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
