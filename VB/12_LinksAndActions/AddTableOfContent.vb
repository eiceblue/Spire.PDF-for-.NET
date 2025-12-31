Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.General
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Actions

Namespace AddTableOfContent
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\AddTableOfContent.pdf"

            ' Create a new PdfDocument
            Dim doc As New PdfDocument()

            ' Load the document from the input file
            doc.LoadFromFile(input)

            ' Get the number of pages in the document
            Dim pageCount As Integer = doc.Pages.Count

            ' Insert a new page at the beginning for the table of contents
            Dim tocPage As PdfPageBase = doc.Pages.Insert(0)

            ' Set the title for the table of contents
            Dim title As String = "Table Of Contents"

            ' Set the font and alignment for the title
            Dim titleFont As New PdfTrueTypeFont(New Font("Arial", 20, FontStyle.Bold))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim titleFont As New PdfTrueTypeFont("Arial", 20.0F, FontStyle.Bold, True)
            ' =============================================================================
            Dim centerAlignment As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

            ' Calculate the location to draw the title on the TOC page
            Dim location As New PointF(tocPage.Canvas.ClientSize.Width \ 2, titleFont.MeasureString(title).Height)

            ' Draw the title on the TOC page
            tocPage.Canvas.DrawString(title, titleFont, PdfBrushes.CornflowerBlue, location, centerAlignment)

            ' Set the font for the titles in the TOC
            Dim titlesFont As New PdfTrueTypeFont(New Font("Arial", 14))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim titlesFont As New PdfTrueTypeFont("Arial", 14.0F, FontStyle.Regular, True)
            ' =============================================================================

            ' Create an array to store the titles of each page
            Dim titles(pageCount - 1) As String

            ' Generate the titles for each page
            For i As Integer = 0 To titles.Length - 1
                titles(i) = String.Format("This is page {0}", i + 1)
            Next i

            ' Set the initial y-coordinate for drawing the titles
            Dim y As Single = titleFont.MeasureString(title).Height + 10

            ' Set the initial x-coordinate for drawing the dots
            Dim x As Single = 0

            ' Iterate through each page in the document
            For i As Integer = 1 To pageCount
                ' Get the text and size of the current title
                Dim text As String = titles(i - 1)
                Dim titleSize As SizeF = titlesFont.MeasureString(text)

                ' Get the corresponding navigated page
                Dim navigatedPage As PdfPageBase = doc.Pages(i)

                ' Create the page number text and get its size
                Dim pageNumText As String = (i + 1).ToString()
                Dim pageNumTextSize As SizeF = titlesFont.MeasureString(pageNumText)

                ' Draw the title text on the TOC page
                tocPage.Canvas.DrawString(text, titlesFont, PdfBrushes.CadetBlue, 0, y)

                ' Calculate the location for drawing the dots and page number
                Dim dotLocation As Single = titleSize.Width + 2 + x
                Dim pageNumlocation As Single = tocPage.Canvas.ClientSize.Width - pageNumTextSize.Width

                ' Draw the dots between the title and page number
                For j As Single = dotLocation To pageNumlocation - 1
                    If dotLocation >= pageNumlocation Then
                        Exit For
                    End If
                    tocPage.Canvas.DrawString(".", titlesFont, PdfBrushes.Gray, dotLocation, y)
                    dotLocation += 3
                Next j

                ' Draw the page number text on the TOC page
                tocPage.Canvas.DrawString(pageNumText, titlesFont, PdfBrushes.CadetBlue, pageNumlocation, y)

                ' Assign the location for the annotation action
                location = New PointF(0, y)

                ' Define the bounds for the title annotation
                Dim titleBounds As New RectangleF(location, New SizeF(tocPage.Canvas.ClientSize.Width, titleSize.Height))

                ' Create a destination for the navigated page
                Dim Dest As New PdfDestination(navigatedPage, New PointF(-doc.PageSettings.Margins.Top, -doc.PageSettings.Margins.Left))

                ' Create a GoTo action for the title annotation
                Dim action As New PdfActionAnnotation(titleBounds, New PdfGoToAction(Dest))
                action.Border = New PdfAnnotationBorder(0)

                ' Add the annotation to the TOC page's annotations collection
                TryCast(tocPage, PdfNewPage).Annotations.Add(action)

                ' Update the y-coordinate for the next title
                y += titleSize.Height + 10
            Next i

            ' Specify the output file path
            Dim output As String = "AddTableOfContent.pdf"

            ' Save the modified document to the output file
            doc.SaveToFile(output)

            ' Close the document
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
