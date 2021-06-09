Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Namespace EmbedSoundFile
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document
			Dim doc As New PdfDocument()

			doc.LoadFromFile("..\..\..\..\..\..\Data\EmbedSoundFile.pdf")
			'Add a page
			Dim page As PdfPageBase = doc.Pages(0)

			'Create a sound action
			Dim soundAction As New PdfSoundAction("..\..\..\..\..\..\Data\Music.wav")
			soundAction.Sound.Bits = 15
			soundAction.Sound.Channels = PdfSoundChannels.Stereo
			soundAction.Sound.Encoding = PdfSoundEncoding.Signed
			soundAction.Volume = 0.8f
			soundAction.Repeat = True

			' Set the sound action to be executed when the PDF document is opened
			doc.AfterOpenAction = soundAction


			Dim result As String = "EmbedSoundFile_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
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
