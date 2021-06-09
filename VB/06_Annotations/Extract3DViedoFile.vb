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
			'Load old PDF from disk.
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\3D.pdf")

			'Get the first page.
			Dim firstPage As PdfPageBase = pdf.Pages(0)

			'Get the annotation collection of the first page
			Dim annot As PdfAnnotationCollection = firstPage.AnnotationsWidget

			'Define an int variable
			Dim count As Integer = 0

			'Traverse the annotations
			For i As Integer = 0 To annot.Count - 1
				'If it is Pdf3DAnnotation
				If TypeOf annot(i) Is Pdf3DAnnotation Then
					Dim annot3D As Pdf3DAnnotation = TryCast(annot(i), Pdf3DAnnotation)

					'Get the 3D video data
					Dim bytes() As Byte = annot3D._3DData

					'Write the data into .u3d format file
					If bytes IsNot Nothing Then
						File.WriteAllBytes(String.Format("3d-{0}.u3d", count), bytes)
						count += 1
					End If
				End If
			Next i
		End Sub
	End Class
End Namespace
