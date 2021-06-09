Imports Spire.Pdf
Imports Spire.Pdf.Exporting.XPS.Schema
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace AddSeamSeals
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document.
			Dim doc As New PdfDocument()

			'Load the document from disk.
			doc.LoadFromFile("..\..\..\..\..\..\Data\AddSeamSeals.pdf")

			Dim convert As New PdfUnitConvertor()
			Dim pageBase As PdfPageBase = Nothing

			'Get the segmented seal image.
			Dim images() As Image = GetImage(doc.Pages.Count)
			Dim x As Single = 0
			Dim y As Single = 0

			'Draw the picture to the designated location on the PDF page.
			For i As Integer = 0 To doc.Pages.Count - 1
				pageBase = doc.Pages(i)
				x = pageBase.Size.Width - convert.ConvertToPixels(images(i).Width, PdfGraphicsUnit.Point)+40
				y = pageBase.Size.Height \ 2
				pageBase.Canvas.DrawImage(PdfImage.FromImage(images(i)), New PointF(x, y))
			Next i

			Dim result As String = "AddSeamSeals_out.pdf"

			'Save the Pdf file.
			doc.SaveToFile(result)

			'Launch the Pdf file.
			PDFDocumentViewer(result)
		End Sub

		'Define the GetImage method to segment the seal image according to the number of PDF pages.
		Private Shared Function GetImage(ByVal num As Integer) As Image()
			Dim lists As New List(Of Image)()
			Dim image As Image = Image.FromFile("..\..\..\..\..\..\Data\SealImage.jpg")
			Dim w As Integer = image.Width \ num
			Dim bitmap As Bitmap = Nothing
			For i As Integer = 0 To num - 1
				bitmap = New Bitmap(w, image.Height)
				Using g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bitmap)
					g.Clear(Color.White)
					Dim rect As New Rectangle(i * w, 0, w, image.Height)
					g.DrawImage(image, New Rectangle(0, 0, bitmap.Width, bitmap.Height), rect, GraphicsUnit.Pixel)
				End Using
				lists.Add(bitmap)
			Next i
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
