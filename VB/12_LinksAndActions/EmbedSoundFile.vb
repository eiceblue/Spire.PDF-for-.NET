Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General

Namespace EmbedSoundFile
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument
			Dim doc As New PdfDocument()

			' Load an existing PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\EmbedSoundFile.pdf")

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Create a new PdfSoundAction with the specified sound file path
			Dim soundAction As New PdfSoundAction("..\..\..\..\..\..\Data\Music.wav")

			' Set the properties of the sound
			soundAction.Sound.Bits = 15
			soundAction.Sound.Channels = PdfSoundChannels.Stereo
			soundAction.Sound.Encoding = PdfSoundEncoding.Signed
			soundAction.Volume = 0.8F
			soundAction.Repeat = True

			' Set the after-open action of the document to the sound action
			doc.AfterOpenAction = soundAction

			' Specify the output file path
			Dim result As String = "EmbedSoundFile_out.pdf"

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
