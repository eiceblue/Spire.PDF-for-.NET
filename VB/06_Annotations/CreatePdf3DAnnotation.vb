Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Multimedia._3DArtwork
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace CreatePdf3DAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a new Pdf document.
            Dim doc As PdfDocument = New PdfDocument()

            'Add a new page to it.
            Dim page As PdfPageBase = doc.Pages.Add()

            'Draw a rectangle on the page to define the canvas area for the 3D file.
            Dim rt As Rectangle = New Rectangle(40, 120, 200, 200)

            'Initialize a new object of Pdf3DAnnotation, load the .u3d file as 3D annotation.
            Dim artwork As Pdf3DArtwork = New Pdf3DArtwork(@"..\..\..\..\..\..\Data\CreatePdf3DAnnotation.u3d", Pdf3DFileFormat.U3D)
            Dim annotation As Pdf3DAnnotation = New Pdf3DAnnotation(page, rt, artwork)
            annotation.Activation = New Pdf3DActivation()
            annotation.Activation.ActivationMode = Pdf3DActivationMode.PageOpen

            'Define a 3D view mode.
            Dim View As Pdf3DView = New Pdf3DView("3DAnnotation")
            View.Background = New Pdf3DBackground(New PdfRGBColor(Color.Purple))
            View.RenderMode = New Pdf3DRenderMode(PdfRenderModeType.Solid)
            View.InternalName = "3DAnnotation"
            View.LightingScheme = New Pdf3DLightingScheme(PdfLightingSchemeType.Day)

            'Set the 3D view mode for the annotation.
            annotation.Views.Add(View)

            'Add the annotation to Pdf.
            PdfAnnotationCollection.Create(page).Add(annotation)

            Dim result As String = "CreatePdf3DAnnotation.pdf"

            'Save the document
            doc.SaveToFile(result)
            doc.Close()

            'Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub

        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
        Catch
        End Try
        End Sub
    End Class
End Namespace
