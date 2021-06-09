Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Imports System.Drawing.Printing
Namespace TrayPrintFirstApproach
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim doc As New PrintDocument()

			' Gets paper sources
			For Each printer As String In PrinterSettings.InstalledPrinters
				If printer.Contains("HP ColorLaserJet MFP") Then
					doc.PrinterSettings.PrinterName = printer
					Exit For
				End If

				Dim myDictPaperTray = New Dictionary(Of String, PaperSource)()
				For i As Integer = 0 To doc.PrinterSettings.PaperSources.Count - 1
					myDictPaperTray.Add(doc.PrinterSettings.PaperSources(i).SourceName, doc.PrinterSettings.PaperSources(i))
				Next i

				' Uses tray1 to print the first page on one side
				pPrintPages(1, 1, myDictPaperTray("Tray 1"), False,True,False)
				' Uses tray4 to print the second page to fifth page on both sides
				pPrintPages(2, 5, myDictPaperTray("Tray 4"), True,False,True)
			Next printer
		End Sub

		Private Shared Sub pPrintPages(ByVal pStart As Integer, ByVal pEnd As Integer, ByVal pSource As PaperSource, ByVal pDuplex As Boolean, ByVal IsColour As Boolean, ByVal IsLandscape As Boolean)
			Dim doc As PdfDocument = New Spire.Pdf.PdfDocument("..\..\..\..\..\..\Data\PrintPdfDocument.pdf")
			doc.PrintSettings.SelectPageRange(pStart, pEnd)


			If pDuplex Then
				doc.PrintSettings.Duplex = Duplex.Vertical
			Else
				doc.PrintSettings.Duplex = Duplex.Simplex
			End If

			If IsColour Then
				doc.PrintSettings.Color = True
			Else
				doc.PrintSettings.Color = False
			End If

			If IsLandscape Then
				doc.PrintSettings.Landscape = True
			Else
				doc.PrintSettings.Landscape = False
			End If

			AddHandler doc.PrintSettings.PaperSettings, Sub(sender As Object, e As Spire.Pdf.Print.PdfPaperSettingsEventArgs) e.CurrentPaperSource = pSource

			doc.Print()
		End Sub
	End Class
End Namespace
