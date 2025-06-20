Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace CreatePdfLineAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PDF document
			Dim document As New PdfDocument()

			' Add a new page to the document
			Dim page As PdfPageBase = document.Pages.Add()

			' Define the points for the first line annotation
			Dim linePoints() As Integer = {100, 650, 180, 650}

			' Create a new line annotation with the specified points and text
			Dim lineAnnotation As New PdfLineAnnotation(linePoints, "This is the first line annotation")

			' Set the border style and width for the line annotation
			lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Solid
			lineAnnotation.lineBorder.BorderWidth = 1

			' Set the line intent for the line annotation
			lineAnnotation.LineIntent = PdfLineIntent.LineDimension

			' Set the line ending styles for the line annotation
			lineAnnotation.BeginLineStyle = PdfLineEndingStyle.Butt
			lineAnnotation.EndLineStyle = PdfLineEndingStyle.Diamond

			' Set the flags for the line annotation
			lineAnnotation.Flags = PdfAnnotationFlags.Default

			' Set the inner line color and background color for the line annotation
			lineAnnotation.InnerLineColor = New PdfRGBColor(Color.Green)
			lineAnnotation.BackColor = New PdfRGBColor(Color.Green)

			' Set the leader line extension and leader line properties for the line annotation
			lineAnnotation.LeaderLineExt = 0
			lineAnnotation.LeaderLine = 0

			' Add the line annotation to the page
            page.Annotations.Add(lineAnnotation)

			' Define the points for the second line annotation
			linePoints = New Integer() {100, 550, 280, 550}

			' Create a new line annotation with the specified points and text
			lineAnnotation = New PdfLineAnnotation(linePoints, "This is the second line annotation")

			' Set the border style and width for the line annotation
			lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Underline
			lineAnnotation.lineBorder.BorderWidth = 2

			' Set the line intent for the line annotation
			lineAnnotation.LineIntent = PdfLineIntent.LineArrow

			' Set the line ending styles for the line annotation
			lineAnnotation.BeginLineStyle = PdfLineEndingStyle.Circle
			lineAnnotation.EndLineStyle = PdfLineEndingStyle.Diamond

			' Set the flags for the line annotation
			lineAnnotation.Flags = PdfAnnotationFlags.Default

			' Set the inner line color and background color for the line annotation
			lineAnnotation.InnerLineColor = New PdfRGBColor(Color.Pink)
			lineAnnotation.BackColor = New PdfRGBColor(Color.Pink)

			' Set the leader line extension and leader line properties for the line annotation
			lineAnnotation.LeaderLineExt = 0
			lineAnnotation.LeaderLine = 0

			' Add the line annotation to the page
            page.Annotations.Add(lineAnnotation)

			' Define the points for the third line annotation
			linePoints = New Integer() {100, 450, 280, 450}

			' Create a new line annotation with the specified points and text
			lineAnnotation = New PdfLineAnnotation(linePoints, "This is the third line annotation")

			' Set the border style and width for the line annotation
			lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Beveled
			lineAnnotation.lineBorder.BorderWidth = 2

			' Set the line intent for the line annotation
			lineAnnotation.LineIntent = PdfLineIntent.LineDimension

			' Set the line ending styles for the line annotation
			lineAnnotation.BeginLineStyle = PdfLineEndingStyle.None
			lineAnnotation.EndLineStyle = PdfLineEndingStyle.None

			' Set the flags for the line annotation
			lineAnnotation.Flags = PdfAnnotationFlags.Default

			' Set the inner line color and background color for the line annotation
			lineAnnotation.InnerLineColor = New PdfRGBColor(Color.Blue)
			lineAnnotation.BackColor = New PdfRGBColor(Color.Blue)

			' Set the leader line extension and leader line properties for the line annotation
			lineAnnotation.LeaderLineExt = 1
			lineAnnotation.LeaderLine = 1

			' Add the line annotation to the page
            page.Annotations.Add(lineAnnotation)

			' Save the document to a file
			Dim result As String = "CreatePdfLineAnnotation_out.pdf"
			document.SaveToFile(result)

			' Close the document
			document.Close()

			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
