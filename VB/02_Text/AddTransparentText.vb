﻿Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddTransparentText
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Create one A4 page
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, New PdfMargins(0))

            ' Save the initial canvas state
            page.Canvas.Save()

            ' Set alpha value for transparency
            Dim alpha As Single = 0.25F
            page.Canvas.SetTransparency(alpha, alpha, PdfBlendMode.Normal)

            ' Create a rectangle with specified dimensions
            Dim rect As New RectangleF(50, 50, 450, page.Size.Height)

            ' Create the transparent text
            Dim text As String = "Spire.PDF for .NET, a professional PDF library applied to" & " creating, writing, editing, handling and reading PDF files" & " without any external dependencies within .NET" & "(C#, VB.NET, ASP.NET, .NET Core) application."
            text &= vbLf & vbLf & vbLf & vbLf & vbLf
            text &= "Spire.PDF for Java, a PDF Java API that enables" & " developers to read, write, convert and print PDF documents" & " in Java applications without using Adobe Acrobat."

            ' Create a brush from color channel
            Dim brush As New PdfSolidBrush(Color.FromArgb(30, 0, 255, 0))

            ' Draw the text on the page
            page.Canvas.DrawString(text, New PdfFont(PdfFontFamily.Helvetica, 14.0F), brush, rect)

            ' Restore the canvas state
            page.Canvas.Restore()

            ' Specify the file name for the resulting document
            Dim result As String = "AddTransparentText_out.pdf"

            ' Save the document to a file
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
