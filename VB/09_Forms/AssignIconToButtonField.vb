Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AssignIconToButtonField
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

            ' Create a new button field
            Dim btn As New PdfButtonField(page, "button1")

            ' Set the bounds (position and size) of the button
            btn.Bounds = New RectangleF(0, 50, 120, 100)

            ' Set the highlight mode of the button to "Push"
            btn.HighlightMode = PdfHighlightMode.Push

            ' Set the layout mode of the button to display caption overlaying the icon
            btn.LayoutMode = PdfButtonLayoutMode.CaptionOverlayIcon

            ' Set the caption text of the button
            btn.Text = "Normal Text"

            ' Set the icon image of the button using an image file
            btn.Icon = PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png")

            ' Set the alternate text of the button
            btn.AlternateText = "Alternate Text"

            ' Set the alternate icon image of the button using an image file
            btn.AlternateIcon = PdfImage.FromFile("..\..\..\..\..\..\Data\PdfImage.png")

            ' Set the rollover text of the button
            btn.RolloverText = "Rollover Text"

            ' Set the rollover icon image of the button using an image file
            btn.RolloverIcon = PdfImage.FromFile("..\..\..\..\..\..\Data\PDFJAVA.png")

            ' Set the spaces between the icon and the caption
            btn.IconLayout.Spaces = New Single() {0.5F, 0.5F}

            ' Set the scale mode for the button icon as proportional
            btn.IconLayout.ScaleMode = PdfButtonIconScaleMode.Proportional

            ' Set the reason for scaling the button icon always
            btn.IconLayout.ScaleReason = PdfButtonIconScaleReason.Always

            ' Disable fitting the icon within the button bounds
            btn.IconLayout.IsFitBounds = False

            ' Add the button field to the document's form fields collection
            doc.Form.Fields.Add(btn)

            ' Set the output file path
            Dim result As String = "AssignIconToButtonField-result.pdf"

            ' Save the modified document to the output file
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)

        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try

        End Sub
    End Class
End Namespace
