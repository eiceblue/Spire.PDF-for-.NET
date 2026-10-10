Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Multimedia

Namespace SoundAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define a rectangle for the sound annotation
            Dim rect As RectangleF = New RectangleF(100, 100, 20, 15)

            ' Generate a minimal raw PCM sound data (1 second of silence, 8-bit, mono)
            Dim soundData As Byte[] = New Byte[8000]
            Dim i As Integer = 0
            While i < soundData.Length
                soundData[i] = 128; ' Middle value for unsigned 8-bit audio
            Next

            ' Create a sound object from the byte array
            Dim sound As PdfSound = New PdfSound(soundData)

            ' Create a sound annotation with the sound object
            Dim annotation As PdfSoundAnnotation = New PdfSoundAnnotation(page, rect, sound)

            ' Set the annotation properties
            annotation.Icon = PdfSoundIcon.Speaker
            annotation.Color = Color.Red
            annotation.Flags = PdfAnnotationFlags.Print
            annotation.Border.Width = 2f
            annotation.Subject = "Subject"
            annotation.Title = "Title"
            annotation.Contents = "Contents"
            annotation.Name = "Name"

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "SoundAnnotation.pdf"
            doc.SaveToFile(output)
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
