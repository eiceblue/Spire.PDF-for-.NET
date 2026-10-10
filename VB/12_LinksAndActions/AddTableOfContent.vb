Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Destinations
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace AddTableOfContent
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Specify the path to the input PDF file.
            Dim input As String = "..\\..\\..\\..\\..\\..\\Data\\AddTableOfContent.pdf"

            ' Open a PDF document.
            Dim doc As PdfDocument = New PdfDocument()
            doc.LoadFromFile(input)

            ' Get the total number of pages in the document.
            Dim pageCount As Integer = doc.Pages.Count

            ' Insert a blank page at the beginning of the PDF document.
            Dim tocPage As PdfPageBase = doc.Pages.Insert(0)

            ' Set the title for the table of contents.
            Dim title As String = "Table Of Contents"
            Dim titleFont As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 20, FontStyle.Bold))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim titleFont As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 20, PdfFontStyle.Bold, True)
            */

            Dim centerAlignment As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
            Dim location As PointF = New PointF(tocPage.Canvas.ClientSize.Width / 2, titleFont.MeasureString(title).Height)
            tocPage.Canvas.DrawString(title, titleFont, PdfBrushes.CornflowerBlue, location, centerAlignment)

            ' Draw the table of contents entries.
            Dim titlesFont As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 14))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
              Dim titlesFont As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 14, PdfFontStyle.Regular, True)
            */
            Dim titles As String[] = New String[pageCount]
            Dim i As Integer = 0
            While i < titles.Length
                titles[i] = String.Format("This Is page {0}", i + 1)
            Next
            Dim y As Single = titleFont.MeasureString(title).Height + 10
            Dim x As Single = 0

            Dim i As Integer = 1
            While i <= pageCount
                Dim text As String = titles[i - 1]
                Dim titleSize As SizeF = titlesFont.MeasureString(text)

                ' Get the page that the table of contents entry will navigate to.
                Dim navigatedPage As PdfPageBase = doc.Pages[i]

                Dim pageNumText As String = (i + 1).ToString()
                Dim pageNumTextSize As SizeF = titlesFont.MeasureString(pageNumText)

                ' Draw the entry text.
                tocPage.Canvas.DrawString(text, titlesFont, PdfBrushes.CadetBlue, 0, y)

                Dim dotLocation As Single = titleSize.Width + 2 + x
                Dim pageNumlocation As Single = tocPage.Canvas.ClientSize.Width - pageNumTextSize.Width

                ' Draw dots between the entry text and page number.
                ' For float j = dotLocation; j < pageNumlocation; j++
                    If dotLocation >= pageNumlocation Then
                        Dim Select As Exit
                    End If
                    tocPage.Canvas.DrawString(".", titlesFont, PdfBrushes.Gray, dotLocation, y)
                    dotLocation += 3
                Next

                ' Draw the page number.
                tocPage.Canvas.DrawString(pageNumText, titlesFont, PdfBrushes.CadetBlue, pageNumlocation, y)

                ' Add the table of contents action.
                location = New PointF(0 + 40, y + 40)
                Dim titleBounds As RectangleF = New RectangleF(location, New SizeF(tocPage.Canvas.ClientSize.Width, titleSize.Height))
                Dim Dest As PdfXYZExplicitDestination = New PdfXYZExplicitDestination(navigatedPage, -doc.PageSettings.Margins.Top, -doc.PageSettings.Margins.Left)
                Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(tocPage, titleBounds, New PdfGoToAction(Dest))
                annotation.Border.Width = 0
                PdfAnnotationCollection.Create(tocPage).Add(annotation)
                y += titleSize.Height + 10
            Next

            Dim output As String = "AddTableOfContent.pdf"

            ' Save the PDF document.
            doc.SaveToFile(output)

            'Launching the Pdf file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
