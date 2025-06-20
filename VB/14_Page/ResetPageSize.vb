Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ResetPageSize
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\ResetPageSize.pdf"

            ' Specify the output file name
            Dim output As String = "ResetPageSize.pdf"

            ' Load the original document from the input file
            Dim originalDoc As New PdfDocument()
            originalDoc.LoadFromFile(input)

            ' Set the margins for the new pages
            Dim margins As New PdfMargins(0)

            ' Create a new document to store the modified pages
            Using newDoc As New PdfDocument()
                ' Specify the scale factor for resizing the pages
                Dim scale As Single = 0.8F

                ' Iterate through each page in the original document
                For i As Integer = 0 To originalDoc.Pages.Count - 1
                    ' Get the current page
                    Dim page As PdfPageBase = originalDoc.Pages(i)

                    ' Calculate the new width and height based on the scale factor
                    Dim width As Single = page.Size.Width * scale
                    Dim height As Single = page.Size.Height * scale

                    ' Add a new page to the new document with the expected width, height, and margins
                    Dim newPage As PdfPageBase = newDoc.Pages.Add(New SizeF(width, height), margins)

                    ' Scale the content of the page to match the new size
                    newPage.Canvas.ScaleTransform(scale, scale)

                    ' Copy the content of the original page into the new page
                    newPage.Canvas.DrawTemplate(page.CreateTemplate(), PointF.Empty)
                Next i

                ' Save the modified document to the output file
                newDoc.SaveToFile(output)
            End Using

            ' Close the original PDF document
            originalDoc.Close()

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
