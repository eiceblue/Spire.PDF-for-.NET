Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Threading.Tasks


Namespace GetBoundsOfTextMarkupAnnotationWidget
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click

			' Create a PdfDocument object
			Dim doc As New PdfDocument()
			' Load a PDF file
			doc.LoadFromFile("..\..\..\..\..\..\Data\PdfTextMarkupAnnotation.pdf")

			' Save the obtained text to a .txt file
			Dim sb As New StringBuilder()

			' Loop through each page in the document
			For Each page As PdfPageBase In doc.Pages
				' Get all annotations on the page
				Dim annotations As PdfAnnotationCollection = page.Annotations
				' Loop through the annotations
				For Each annotation As PdfAnnotation In annotations
					' Check if the annotation is a highlight annotation                                     
                    If TypeOf annotation Is PdfTextMarkupAnnotationWidget Then
                        Dim highlightAnnotation As PdfTextMarkupAnnotationWidget = CType(annotation, PdfTextMarkupAnnotationWidget)

                        ' Get annotation Type
                        If highlightAnnotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight Then
                            For i As Integer = 0 To highlightAnnotation.QuadPoints.Length - 1
                                sb.AppendLine("Point" & i & " X:" & highlightAnnotation.QuadPoints(i).X.ToString())
                                sb.AppendLine("Point" & i & " Y:" & highlightAnnotation.QuadPoints(i).Y.ToString())
                            Next
                        End If
                    End If
				Next annotation
			Next page
			Dim result As String = "result.txt"
			File.WriteAllText(result, sb.ToString())


			'Launch the file.
			DocumentViewer(result)
		End Sub

		Private Sub DocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
