Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics

Namespace CreatePdf3DAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PDF document
			Dim doc As New PdfDocument()

			' Add a new page to the document
			Dim page As PdfPageBase = doc.Pages.Add()

			' Define a rectangle for the 3D annotation
			Dim rt As New Rectangle(0, 80, 200, 200)

			' Create a new 3D annotation with the specified rectangle and U3D file path
			Dim annotation As New Pdf3DAnnotation(rt, "..\..\..\..\..\..\Data\CreatePdf3DAnnotation.u3d")

			' Configure the activation settings for the 3D annotation
			annotation.Activation = New Pdf3DActivation()
			annotation.Activation.ActivationMode = Pdf3DActivationMode.PageOpen

			' Create a new 3D view for the annotation
			Dim View As New Pdf3DView()

			' Set the background color of the 3D view
			View.Background = New Pdf3DBackground(New PdfRGBColor(Color.Purple))

			' Set the name of the 3D view node
			View.ViewNodeName = "3DAnnotation"

			' Set the rendering mode for the 3D view
			View.RenderMode = New Pdf3DRendermode(Pdf3DRenderStyle.Solid)

			' Set the internal name of the 3D view
			View.InternalName = "3DAnnotation"

			' Set the lighting scheme for the 3D view
			View.LightingScheme = New Pdf3DLighting()
			View.LightingScheme.Style = Pdf3DLightingStyle.Day

			' Add the 3D view to the annotation's list of views
			annotation.Views.Add(View)

			' Add the 3D annotation to the page's list of annotations
            page.Annotations.Add(annotation)

			' Specify the filename for the resulting PDF file
			Dim result As String = "CreatePdf3DAnnotation_out.pdf"

			' Save the document to the specified file
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
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
