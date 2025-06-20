Imports Spire.Pdf
Imports Spire.Pdf.Print
Imports System.Drawing.Printing

Namespace TrayPrintFirstApproach
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PrintDocument object.
            Dim doc As New PrintDocument()

            ' Iterate through the list of installed printers.
            For Each printer As String In PrinterSettings.InstalledPrinters

                ' Check if the printer name contains "HP ColorLaserJet MFP".
                If printer.Contains("HP ColorLaserJet MFP") Then

                    ' Set the printer name to the matched printer.
                    doc.PrinterSettings.PrinterName = printer

                    ' Exit the loop after finding a match.
                    Exit For
                End If

                ' Create a dictionary to store the available paper trays for the current printer.
                Dim myDictPaperTray = New Dictionary(Of String, PaperSource)()

                ' Iterate through the paper sources of the printer.
                For i As Integer = 0 To doc.PrinterSettings.PaperSources.Count - 1
                    myDictPaperTray.Add(doc.PrinterSettings.PaperSources(i).SourceName, doc.PrinterSettings.PaperSources(i))
                Next i

                ' Print pages 1 to 1 using Tray 1, without duplex printing, in color, and in portrait.
                pPrintPages(1, 1, myDictPaperTray("Tray 1"), False, True, False)

                ' Print pages 2 to 5 using Tray 4, with duplex printing, not in color, and in landscape.
                pPrintPages(2, 5, myDictPaperTray("Tray 4"), True, False, True)

            Next printer
        End Sub

        Private Shared Sub pPrintPages(ByVal pStart As Integer, ByVal pEnd As Integer, ByVal pSource As PaperSource, ByVal pDuplex As Boolean, ByVal IsColour As Boolean, ByVal IsLandscape As Boolean)
            Dim doc As PdfDocument = New Spire.Pdf.PdfDocument("..\..\..\..\..\..\Data\PrintPdfDocument.pdf")

            ' Select the page range to print.
            doc.PrintSettings.SelectPageRange(pStart, pEnd)

            ' Configure duplex printing based on the provided parameter.
            If pDuplex Then
                doc.PrintSettings.Duplex = Duplex.Vertical
            Else
                doc.PrintSettings.Duplex = Duplex.Simplex
            End If

            ' Configure color printing based on the provided parameter.
            doc.PrintSettings.Color = IsColour

            ' Configure printing orientation based on the provided parameter.
            doc.PrintSettings.Landscape = IsLandscape

            ' Set the paper source for printing.
            AddHandler doc.PrintSettings.PaperSettings, Sub(sender As Object, e As PdfPaperSettingsEventArgs) e.CurrentPaperSource = pSource

            ' Print the document.
            doc.Print()
        End Sub
    End Class
End Namespace
