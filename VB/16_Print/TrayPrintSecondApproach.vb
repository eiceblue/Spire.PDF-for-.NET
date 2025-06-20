Imports Spire.Pdf
Imports System.Drawing.Printing
Imports Spire.Pdf.Print

Namespace TrayPrintSecondApproach
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            'Initialize an object of PdfDocument class' Create a new PdfDocument object.
            Dim doc As New PdfDocument()

            ' Load the PDF document from a file.
            doc.LoadFromFile("..\..\..\..\..\..\Data\PrintPdfDocument.pdf")

            ' Set the color printing option to true.
            doc.PrintSettings.Color = True

            ' Set the landscape printing option to true.
            doc.PrintSettings.Landscape = True

            ' Set the duplex printing option to horizontal.
            doc.PrintSettings.Duplex = Duplex.Horizontal

            ' Add an event handler for the PaperSettings event.
            AddHandler doc.PrintSettings.PaperSettings, Sub(sender1 As Object, e1 As PdfPaperSettingsEventArgs)
                                                            ' Set the paper source of page 1-50 as tray 1.
                                                            If 1 <= e1.CurrentPaper AndAlso e1.CurrentPaper <= 50 Then
                                                                e1.CurrentPaperSource = e1.PaperSources(0)
                                                                ' Set the paper source of the rest of pages as tray 2.
                                                            Else
                                                                e1.CurrentPaperSource = e1.PaperSources(1)
                                                            End If
                                                        End Sub

            ' Print the document.
            doc.Print()

            ' Close the document after printing.
            doc.Close()
        End Sub
    End Class
End Namespace
