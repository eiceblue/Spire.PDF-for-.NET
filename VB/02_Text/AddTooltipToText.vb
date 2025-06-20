Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Fields
Namespace AddTooltipToText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PDF document
            Dim doc As New PdfDocument()

            ' Add a page to the document
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Draw a string on the page canvas
            page.Canvas.DrawString("Move the mouse cursor over the following text to display a tooltip",
                               New PdfTrueTypeFont(New Font("Arial", 15), True),
                               PdfBrushes.Black, New PointF(10, 20))

            ' Define variables for text and font
            Dim text1 As String = "Your Office Development Master"
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 18), True)

            ' Measure the size of the text
            Dim sizeF1 As SizeF = font1.MeasureString(text1)

            ' Create a rectangle based on the text size
            Dim rec1 As New RectangleF(New Point(100, 100), sizeF1)

            ' Draw the text on the page canvas
            page.Canvas.DrawString(text1, font1, New PdfSolidBrush(Color.Blue), rec1)

            ' Create a button field and set its properties
            Dim field1 As New PdfButtonField(page, "field1")
            field1.Bounds = rec1
            field1.ToolTip = "E-iceblue Co. Ltd., a vendor of .NET, Java and WPF development components"
            field1.BorderWidth = 0
            field1.BackColor = Color.Transparent
            field1.ForeColor = Color.Transparent
            field1.LayoutMode = PdfButtonLayoutMode.IconOnly
            field1.IconLayout.IsFitBounds = True

            ' Define variables for second text and font
            Dim text2 As String = "Spire.PDF"
            Dim font2 As New PdfFont(PdfFontFamily.TimesRoman, 20)

            ' Measure the size of the second text
            Dim sizeF2 As SizeF = font2.MeasureString(text2)

            ' Create a rectangle based on the second text size
            Dim rec2 As New RectangleF(New Point(100, 160), sizeF2)

            ' Draw the second text on the page canvas
            page.Canvas.DrawString(text2, font2, PdfBrushes.DarkOrange, rec2)

            ' Create a second button field and set its properties
            Dim field2 As New PdfButtonField(page, "field2")
            field2.Bounds = rec2
            field2.ToolTip = "A professional PDF library applied to creating, writing, editing, handling and reading PDF files without any external dependencies within .NET (C#, VB.NET, ASP.NET, .NET Core) application."
            field2.BorderWidth = 0
            field2.BackColor = Color.Transparent
            field2.ForeColor = Color.Transparent
            field2.LayoutMode = PdfButtonLayoutMode.IconOnly
            field2.IconLayout.IsFitBounds = True

            ' Enable form creation and add the button fields to the document form
            doc.AllowCreateForm = True
            doc.Form.Fields.Add(field1)
            doc.Form.Fields.Add(field2)

            ' Save the document to a file
            Dim result As String = "AddTooltipToText_out.pdf"
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
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
