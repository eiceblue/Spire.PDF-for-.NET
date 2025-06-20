Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.IO

Namespace Extract3DViedoFile
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()
            pdf.LoadFromFile("..\..\..\..\..\..\Data\3D.pdf")

            ' Get the first page of the PDF document
            Dim firstPage As PdfPageBase = pdf.Pages(0)

            ' Get the collection of annotations on the first page
            Dim annot As PdfAnnotationCollection = firstPage.Annotations

            ' Initialize a counter to keep track of the number of 3D annotations found
            Dim count As Integer = 0

            ' Iterate through each annotation in the collection
            For i As Integer = 0 To annot.Count - 1

                ' Check if the current annotation is a 3D annotation
                If TypeOf annot(i) Is Pdf3DAnnotation Then

                    ' Cast the annotation to Pdf3DAnnotation type
                    Dim annot3D As Pdf3DAnnotation = TryCast(annot(i), Pdf3DAnnotation)

                    ' Get the 3D data bytes from the annotation
                    Dim bytes() As Byte = annot3D._3DData

                    ' Check if the 3D data bytes exist
                    If bytes IsNot Nothing Then

                        ' Write the 3D data bytes to a file with a unique name based on the counter
                        File.WriteAllBytes(String.Format("3d-{0}.u3d", count), bytes)

                        ' Increment the counter
                        count += 1
                    End If
                End If
            Next i

            ' Close the document
            pdf.Close()
        End Sub
	End Class
End Namespace
