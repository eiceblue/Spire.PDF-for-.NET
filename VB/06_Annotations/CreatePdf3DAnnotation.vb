Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace CreatePdf3DAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new Pdf document.
			Dim doc As New PdfDocument()

			'Add a new page to it.
			Dim page As PdfPageBase = doc.Pages.Add()

			'Draw a rectangle on the page to define the canvas area for the 3D file.
			Dim rt As New Rectangle(0, 80, 200, 200)

			'Initialize a new object of Pdf3DAnnotation, load the .u3d file as 3D annotation.
			Dim annotation As New Pdf3DAnnotation(rt, "..\..\..\..\..\..\Data\CreatePdf3DAnnotation.u3d")
			annotation.Activation = New Pdf3DActivation()
			annotation.Activation.ActivationMode = Pdf3DActivationMode.PageOpen

			'Define a 3D view mode.
			Dim View As New Pdf3DView()
			View.Background = New Pdf3DBackground(New PdfRGBColor(Color.Purple))
			View.ViewNodeName = "3DAnnotation"
			View.RenderMode = New Pdf3DRendermode(Pdf3DRenderStyle.Solid)
			View.InternalName = "3DAnnotation"
			View.LightingScheme = New Pdf3DLighting()
			View.LightingScheme.Style = Pdf3DLightingStyle.Day

			'Set the 3D view mode for the annotation.
			annotation.Views.Add(View)

			'Add the annotation to Pdf.
			page.AnnotationsWidget.Add(annotation)

			Dim result As String = "CreatePdf3DAnnotation_out.pdf"

			'Save the document
			doc.SaveToFile(result)
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
