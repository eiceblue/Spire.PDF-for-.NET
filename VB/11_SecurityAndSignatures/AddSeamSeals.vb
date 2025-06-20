Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddSeamSeals
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified file path
            doc.LoadFromFile("..\..\..\..\..\..\Data\AddSeamSeals.pdf")

            ' Create a new PdfUnitConvertor for unit conversion
            Dim convert As New PdfUnitConvertor()

            ' Declare variables for page base, images, and coordinates
            Dim pageBase As PdfPageBase = Nothing
            Dim images() As Image = GetImage(doc.Pages.Count)
            Dim x As Single = 0
            Dim y As Single = 0

            ' Iterate through each page in the PDF document
            For i As Integer = 0 To doc.Pages.Count - 1
                ' Get the current page
                pageBase = doc.Pages(i)

                ' Calculate the position to draw the image at the right side of the page
                x = pageBase.Size.Width - convert.ConvertToPixels(images(i).Width, PdfGraphicsUnit.Point) + 40
                y = pageBase.Size.Height / 2

                ' Draw the image on the page canvas at the calculated position
                pageBase.Canvas.DrawImage(PdfImage.FromImage(images(i)), New PointF(x, y))
            Next i

            ' Specify the output file path for the modified PDF document
            Dim result As String = "AddSeamSeals_out.pdf"

            ' Save the modified PDF document to the output file path
            doc.SaveToFile(result)

            ' Close the PDF document
            doc.Close()

            ' Launch the file
            PDFDocumentViewer(result)
        End Sub
        Private Shared Function GetImage(ByVal num As Integer) As Image()
            ' Create a list to store the images
            Dim lists As New List(Of Image)()

            ' Load the seal image from file
            Dim image As Image = Image.FromFile("..\..\..\..\..\..\Data\SealImage.jpg")

            ' Calculate the width for each sub-image based on the number of pages
            Dim w As Integer = image.Width \ num

            ' Declare a bitmap variable
            Dim bitmap As Bitmap = Nothing

            ' Iterate through each sub-image
            For i As Integer = 0 To num - 1
                ' Create a new bitmap with the appropriate width
                bitmap = New Bitmap(w, image.Height)

                ' Draw the sub-image onto the bitmap
                Using g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bitmap)
                    g.Clear(Color.White)
                    Dim rect As New Rectangle(i * w, 0, w, image.Height)
                    g.DrawImage(image, New Rectangle(0, 0, bitmap.Width, bitmap.Height), rect, GraphicsUnit.Pixel)
                End Using

                ' Add the bitmap to the list of images
                lists.Add(bitmap)
            Next i

            ' Convert the list of images to an array and return it
            Return lists.ToArray()
        End Function

        Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
