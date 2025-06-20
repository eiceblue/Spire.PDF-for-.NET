Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Lists

Namespace List
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Create a unit converter for converting measurement units
            Dim unitCvtr As New PdfUnitConvertor()

            ' Set margin
            Dim margin As New PdfMargins()
            margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Bottom = margin.Top
            margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Right = margin.Left

            ' Add a new page to the document with A4 size and specified margins
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            ' Initialize a variable for the vertical position
            Dim y As Single = 10

            ' Set brush and font for the title text
            Dim brush1 As PdfBrush = PdfBrushes.Black
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold), True)

            ' Set formatting options for the title text
            Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

            ' Draw the title "Categories List" in the center of the page
            page.Canvas.DrawString("Categories List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)

            ' Update the vertical position
            y = y + font1.MeasureString("Categories List", format1).Height
            y = y + 5

            ' Create a linear gradient brush for the list items
            Dim rctg As New RectangleF(New PointF(0, 0), page.Canvas.ClientSize)
            Dim brush As New PdfLinearGradientBrush(rctg, Color.Navy, Color.OrangeRed, PdfLinearGradientMode.Vertical)

            ' Set font for the list items
            Dim font As New PdfFont(PdfFontFamily.Helvetica, 12.0F, PdfFontStyle.Bold)

            ' Define the formatted string for the list items
            Dim formatted As String = "Beverages" & vbLf & "Condiments" & vbLf & "Confections" & vbLf & "Dairy Products" & vbLf & "Grains/Cereals" & vbLf & "Meat/Poultry" & vbLf & "Produce" & vbLf & "Seafood"

            ' Create a PdfList object with the formatted string
            Dim list As New PdfList(formatted)
            list.Font = font
            list.Indent = 8
            list.TextIndent = 5
            list.Brush = brush

            ' Draw the list on the page and get the layout result
            Dim result As PdfLayoutResult = list.Draw(page, 0, y)

            ' Update the vertical position
            y = result.Bounds.Bottom

            ' Create another PdfSortedList object with the same formatted string
            Dim sortedList As New PdfSortedList(formatted)
            sortedList.Font = font
            sortedList.Indent = 8
            sortedList.TextIndent = 5
            sortedList.Brush = brush

            ' Draw the sorted list on the page and get the layout result
            Dim result2 As PdfLayoutResult = sortedList.Draw(page, 0, y)

            ' Update the vertical position
            y = result2.Bounds.Bottom

            ' Create an ordered marker with lower Roman numerals
            Dim marker1 As New PdfOrderedMarker(PdfNumberStyle.LowerRoman, New PdfFont(PdfFontFamily.Helvetica, 12.0F))

            ' Create another PdfSortedList object with the same formatted string and the ordered marker
            Dim list2 As New PdfSortedList(formatted)
            list2.Font = font
            list2.Marker = marker1
            list2.Indent = 8
            list2.TextIndent = 5
            list2.Brush = brush

            ' Draw the list with ordered markers on the page and get the layout result
            Dim result3 As PdfLayoutResult = list2.Draw(page, 0, y)

            ' Update the vertical position
            y = result3.Bounds.Bottom

            ' Create an ordered marker with lower Latin letters
            Dim marker2 As New PdfOrderedMarker(PdfNumberStyle.LowerLatin, New PdfFont(PdfFontFamily.Helvetica, 12.0F))

            ' Create another PdfSortedList object with the same formatted string and the ordered marker
            Dim list3 As New PdfSortedList(formatted)
            list3.Font = font
            list3.Marker = marker2
            list3.Indent = 8
            list3.TextIndent = 5
            list3.Brush = brush

            ' Draw the list with ordered markers on the page
            list3.Draw(page, 0, y)

            ' Save the PDF file as "List.pdf"
            doc.SaveToFile("List.pdf")

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("List.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
