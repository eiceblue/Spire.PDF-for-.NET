Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetPageInfo
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load an existing pdf from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\GetPageInfo.pdf")

			'Get the first page of the loaded PDF file
			Dim page As PdfPageBase = doc.Pages(0)

			'Get the size of page MediaBox based on "point"
			Dim MediaBoxWidth As Single = page.MediaBox.Width
			Dim MediaBoxHeight As Single = page.MediaBox.Height
			Dim MediaBoxX As Single = page.MediaBox.X
			Dim MediaBoxY As Single = page.MediaBox.Y

			'Get the size of page BleedBox based on "point"
			Dim BleedBoxWidth As Single = page.BleedBox.Width
			Dim BleedBoxHeight As Single = page.BleedBox.Height
			Dim BleedBoxX As Single = page.BleedBox.X
			Dim BleedBoxY As Single = page.BleedBox.Y

			'Get the size of page CropBox based on "point"
			Dim CropBoxWidth As Single = page.CropBox.Width
			Dim CropBoxHeight As Single = page.CropBox.Height
			Dim CropBoxX As Single = page.CropBox.X
			Dim CropBoxY As Single = page.CropBox.Y

			'Get the size of page ArtBox based on "point"
			Dim ArtBoxWidth As Single = page.ArtBox.Width
			Dim ArtBoxHeight As Single = page.ArtBox.Height
			Dim ArtBoxX As Single = page.ArtBox.X
			Dim ArtBoxY As Single = page.ArtBox.Y

			'Get the size of page TrimBox based on "point"
			Dim TrimBoxWidth As Single = page.TrimBox.Width
			Dim TrimBoxHeight As Single = page.TrimBox.Height
			Dim TrimBoxX As Single = page.TrimBox.X
			Dim TrimBoxY As Single = page.TrimBox.Y

			'Get the actual size of page
			Dim actualSizeW As Single = page.ActualSize.Width
			Dim actualSizeH As Single = page.ActualSize.Height

			'Gets the rotation angle of the current page
			Dim rotationAngle As PdfPageRotateAngle = page.Rotation
			Dim rotation As String = rotationAngle.ToString()

			'Create StringBuilder to save 
			Dim content As New StringBuilder()

			'Add page information string to StringBuilder
			content.AppendLine("MediaBox width: " & MediaBoxWidth & "pt, height: " & MediaBoxHeight & "pt, RectangleF X: " & MediaBoxX & "pt, RectangleF Y: " & MediaBoxY & "pt.")
			content.AppendLine("BleedBox width: " & BleedBoxWidth & "pt,  height: " & BleedBoxHeight & "pt, RectangleF X: " & BleedBoxX & "pt, RectangleF Y: " & BleedBoxY & "pt.")
			content.AppendLine("CropBox width: " & CropBoxWidth & "pt,  height: " & CropBoxHeight & "pt, RectangleF X: " & CropBoxX & "pt, RectangleF Y: " & CropBoxY & "pt.")
			content.AppendLine("ArtBox width: " & ArtBoxWidth & "pt,  height: " & ArtBoxHeight & "pt, RectangleF X: " & ArtBoxX & "pt, RectangleF Y: " & ArtBoxY & "pt.")
			content.AppendLine("TrimBox width: " & TrimBoxWidth & "pt,  height: " & TrimBoxHeight & "pt, RectangleF X: " & TrimBoxX & "pt, RectangleF Y: " & TrimBoxY & "pt.")
			content.AppendLine("The actual size of the current page width: " & actualSizeW)
			content.AppendLine("The actual size of the current page height: " & actualSizeH)
			content.AppendLine("The rotation angle of the current page: " & rotation)

			Dim result As String = "PageInfo.txt"
			'Save them to a txt file
			File.WriteAllText(result, content.ToString())

			'Launch the file
			DocumentViewer(result)
		End Sub

		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
