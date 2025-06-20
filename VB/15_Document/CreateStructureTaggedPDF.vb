Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interchange.TaggedPdf
Imports Spire.Pdf.Tables

Namespace CreateStructureTaggedPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Add a new page to the document with A4 size and 20-point margins
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, New PdfMargins(20))

			' Set the tab order of the page to structure-based
			page.SetTabOrder(TabOrder.Structure)

			' Create a new tagged content object for the document
			Dim taggedContent As New PdfTaggedContent(doc)

			' Set the language of the tagged content
			taggedContent.SetLanguage("en-US")

			' Set the title of the tagged content
			taggedContent.SetTitle("test")

			' Set the PDF/UA-1 identification for the tagged content
			taggedContent.SetPdfUA1Identification()

			' Create a new font object using Times New Roman font with size 14
			Dim font As New PdfTrueTypeFont(New Font("Times New Roman", 14), True)

			' Create a new solid brush object with black color
			Dim brush As New PdfSolidBrush(Color.Black)

			' Create a new structure element of type Document
			Dim document As PdfStructureElement = taggedContent.StructureTreeRoot.AppendChildElement(PdfStandardStructTypes.Document)

			' Create a new structure element of type Heading Level 1
			Dim heading1 As PdfStructureElement = document.AppendChildElement(PdfStandardStructTypes.HeadingLevel1)

			' Begin a marked content block for the heading element on the page
			heading1.BeginMarkedContent(page)

			' Define the text for the heading
			Dim headingText As String = "What is a Tagged PDF?"

			' Draw the heading text on the canvas of the page
			page.Canvas.DrawString(headingText, font, brush, New PointF(0, 50))

			' End the marked content block for the heading element
			heading1.EndMarkedContent(page)

			' Create a new structure element of type Paragraph
			Dim paragraph As PdfStructureElement = document.AppendChildElement(PdfStandardStructTypes.Paragraph)

			' Begin a marked content block for the paragraph element on the page
			paragraph.BeginMarkedContent(page)

			' Define the text for the paragraph
			Dim paragraphText As String = "'Tagged PDF' doesn’t seem like a life-changing term. But for some, it is. For people who are blind or have low vision and use assistive technology (such as screen readers and connected Braille displays) to access information, an untagged PDF means they are missing out on information contained in the document because assistive technology cannot 'read' untagged PDFs.  Digital accessibility has opened up so many avenues to information that were once closed to people with visual disabilities, but PDFs often get left out of the equation."

			' Define the rectangle for the paragraph text on the page
			Dim rect As New RectangleF(0, 80, page.Canvas.ClientSize.Width, page.Canvas.ClientSize.Height)

			' Draw the paragraph text on the canvas of the page within the defined rectangle
			page.Canvas.DrawString(paragraphText, font, brush, rect)

			' End the marked content block for the paragraph element
			paragraph.EndMarkedContent(page)

			' Create a new structure element of type Figure
			Dim figure As PdfStructureElement = document.AppendChildElement(PdfStandardStructTypes.Figure)

			' Begin a marked content block for the figure element on the page
			figure.BeginMarkedContent(page)

			' Load an image from file
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\E-logo.png")

			' Draw the image on the canvas of the page at the specified position
			page.Canvas.DrawImage(image, New PointF(350, 200))

			' End the marked content block for the figure element
			figure.EndMarkedContent(page)

			' Create a new structure element of type Table
			Dim table As PdfStructureElement = document.AppendChildElement(PdfStandardStructTypes.Table)

			' Create a new PdfTable object
			Dim pdfTable As New PdfTable()

			' Set the default font of the table
			pdfTable.Style.DefaultStyle.Font = font

			' Create a new DataTable object
			Dim dataTable As New DataTable()

			' Add columns to the DataTable
			dataTable.Columns.Add("Name")
			dataTable.Columns.Add("Age")
			dataTable.Columns.Add("Sex")

			' Add rows to the DataTable
			dataTable.Rows.Add(New String() {"John", "22", "Male"})
			dataTable.Rows.Add(New String() {"Katty", "25", "Female"})

			' Set the DataTable as the data source for the PdfTable
			pdfTable.DataSource = dataTable

			' Enable header row in the PdfTable
			pdfTable.Style.ShowHeader = True

			' Associate the PdfTable with the structure element
			pdfTable.StructureElement = table

			' Draw the PdfTable on the canvas of the page at the specified position
			pdfTable.Draw(page.Canvas, New PointF(0, 300), 300)

			' Save the file
			doc.SaveToFile("structuredTagged.pdf")

			' Close the document
			doc.Close()

			' Launch the pdf file
			PDFDocumentViewer("structuredTagged.pdf")
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
