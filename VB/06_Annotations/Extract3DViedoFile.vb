Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.IO
Imports System.Windows.Forms

Namespace Extract3DViedoFile
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Load old PDF from disk.
            Dim pdf As PdfDocument = New PdfDocument()
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\3D.pdf")

            'Get the first page.
            Dim firstPage As PdfPageBase = pdf.Pages[0]

            'Get the annotation collection of the first page
            Dim annot As PdfAnnotationCollection = PdfAnnotationCollection.Create(firstPage)

            'Define an int variable
            Dim count As Integer = 0

            'Traverse the annotations
            Dim i As Integer = 0
            While i < annot.Count
                'If it is Pdf3DAnnotation
                If annot[i] is Pdf3DAnnotation Then
                    Dim annot3D As Pdf3DAnnotation = annot[i] as Pdf3DAnnotation

                    'Get the 3D video data
                    Dim bytes As Byte[] = annot3D.Artwork.Data

                    'Write the data into .u3d format file
                    If bytes != null Then
                        File.WriteAllBytes(String.Format(@"3d-{0}.u3d", count), bytes)
                        count += 1
                    End If
                End If
            Next
        End Sub
    End Class
End Namespace
