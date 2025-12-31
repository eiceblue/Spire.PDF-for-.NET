Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics


Namespace AddCalendarDropdown
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument instance
			Dim pdf As New PdfDocument()

			' Add a new page to the document with A4 size and zero margins
			Dim page As PdfPageBase = pdf.Pages.Add(PdfPageSize.A4, New PdfMargins(0))

			' Create a TrueType font for the text field
			Dim font As New PdfTrueTypeFont(New Font("Arial Unicode MS", 10.0F), True)
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font As New PdfTrueTypeFont("Arial Unicode MS", 10.0F, PdfFontStyle.Regular, True)
			' =============================================================================

			' Create a new text box field on the page named "date"
			Dim textbox As New PdfTextBoxField(page, "date")

			' Set the position and size of the text box
			textbox.Bounds = New RectangleF(40, 50, 60, 20)

			' Set the font for the text box
			textbox.Font = font

			' Get the JavaScript keystroke string for date format (mm/dd/yyyy)
			Dim kjs As String = PdfJavaScript.GetDateKeystrokeString("mm/dd/yyyy")

			' Get the JavaScript format string for date format (mm/dd/yyyy)
			Dim fjs As String = PdfJavaScript.GetDateFormatString("mm/dd/yyyy")

			' Create a JavaScript action for keystroke event
			Dim kjsAction As New PdfJavaScriptAction(kjs)

			' Create a JavaScript action for format event
			Dim fjsAction As New PdfJavaScriptAction(fjs)

			' Assign the JavaScript actions to the text box
			textbox.Actions.KeyPressed = kjsAction
			textbox.Actions.Format = fjsAction

			' Add the text box field to the form
			pdf.Form.Fields.Add(textbox)

			' Specify the output file name
			Dim result As String = "AddCalendarDropdown_result.pdf"

			' Save the modified document to the specified file path
			pdf.SaveToFile(result)

			' Close the document
			pdf.Close()

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
