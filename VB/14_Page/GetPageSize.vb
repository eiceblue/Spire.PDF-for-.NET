Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.IO
Imports System.Text

Namespace GetPageSize
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load an existing PDF from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			' Get the first page of the loaded PDF file
			Dim page As PdfPageBase = doc.Pages(0)

			' Get the width of the page based on "point"
			Dim pointWidth As Single = page.Size.Width

			' Get the height of the page
			Dim pointHeight As Single = page.Size.Height

			' Create a PdfUnitConvertor to convert the unit
			Dim unitCvtr As New PdfUnitConvertor()

			' Convert the size to "pixel"
			Dim pixelWidth As Single = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Pixel)
			Dim pixelHeight As Single = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Pixel)

			' Convert the size to "inch"
			Dim inchWidth As Single = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Inch)
			Dim inchHeight As Single = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Inch)

			' Convert the size to "centimeter"
			Dim centimeterWidth As Single = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Centimeter)
			Dim centimeterHeight As Single = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Centimeter)

			' Create a StringBuilder to save the content
			Dim content As New StringBuilder()

			' Add size information to the StringBuilder
			content.AppendLine("The page size of the file is (width: " & pointWidth & "pt, height: " & pointHeight & "pt).")
			content.AppendLine("The page size of the file is (width: " & pixelWidth & "pixel, height: " & pixelHeight & "pixel).")
			content.AppendLine("The page size of the file is (width: " & inchWidth & "inch, height: " & inchHeight & "inch).")
			content.AppendLine("The page size of the file is (width: " & centimeterWidth & "cm, height: " & centimeterHeight & "cm.)")

			' Specify the output file path for the text file
			Dim output As String = "GetPageSize_out.txt"

			' Save the size information to a text file
			File.WriteAllText(output, content.ToString())

			' Close the PDF document
			doc.Close()

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
