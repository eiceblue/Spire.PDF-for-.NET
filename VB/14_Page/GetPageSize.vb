Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetPageSize
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load an existing pdf from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			'Get the first page of the loaded PDF file
			Dim page As PdfPageBase = doc.Pages(0)

			'Get the width of page based on "point"
			Dim pointWidth As Single = page.Size.Width

			'Get the height of page
			Dim pointHeight As Single = page.Size.Height

			'Create PdfUnitConvertor to convert the unit
			Dim unitCvtr As New PdfUnitConvertor()

			'Convert the size with "pixel"
			Dim pixelWidth As Single = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Pixel)
			Dim pixelHeight As Single = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Pixel)

			'Convert the size with "inch"
			Dim inchWidth As Single = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Inch)
			Dim inchHeight As Single = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Inch)

			'Convert the size with "centimeter"
			Dim centimeterWidth As Single = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Centimeter)
			Dim centimeterHeight As Single = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Centimeter)

			'Create StringBuilder to save 
			Dim content As New StringBuilder()


			'Add pointSize string to StringBuilder
			content.AppendLine("The page size of the file is (width: " & pointWidth & "pt, height: " & pointHeight & "pt).")
			content.AppendLine("The page size of the file is (width: " & pixelWidth & "pixel, height: " & pixelHeight & "pixel).")
			content.AppendLine("The page size of the file is (width: " & inchWidth & "inch, height: " & inchHeight & "inch).")
			content.AppendLine("The page size of the file is (width: " & centimeterWidth & "cm, height: " & centimeterHeight & "cm.)")

			Dim output As String = "GetPageSize_out.txt"

			'Save them to a txt file
			File.WriteAllText(output, content.ToString())

			'Launch the file
			DocumentViewer(output)
		End Sub

		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
