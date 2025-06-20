Imports Spire.Pdf
Imports Spire.Pdf.Utilities
Imports System.Text
Imports System.IO

Namespace ExtractTable
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input and output file paths
            Dim input As String = "..\..\..\..\..\..\Data\ExtractTable.pdf"
            Dim output As String = "ExtractTable_result.txt"

            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the input file
            pdf.LoadFromFile(input)

            ' Create a PdfTableExtractor object for extracting tables from the document
            Dim extractor As New PdfTableExtractor(pdf)

            ' Initialize an array to store the extracted tables
            Dim tableLists() As PdfTable = Nothing

            ' Create a StringBuilder object to build the extracted text
            Dim builder As New StringBuilder()

            ' Iterate over each page of the document
            For pageIndex As Integer = 0 To pdf.Pages.Count - 1
                ' Extract tables from the current page
                tableLists = extractor.ExtractTable(pageIndex)

                ' Check if any tables were extracted
                If tableLists IsNot Nothing AndAlso tableLists.Length > 0 Then
                    ' Iterate over each extracted table
                    For Each table As PdfTable In tableLists
                        ' Get the number of rows and columns in the table
                        Dim row As Integer = table.GetRowCount()
                        Dim column As Integer = table.GetColumnCount()

                        ' Iterate over each cell in the table
                        For i As Integer = 0 To row - 1
                            For j As Integer = 0 To column - 1
                                ' Extract the text from each cell
                                Dim text As String = table.GetText(i, j)

                                ' Append the extracted text to the StringBuilder
                                builder.Append(text & " ")
                            Next j

                            ' Add a line break after each row
                            builder.Append(vbCrLf)
                        Next i
                    Next table
                End If
            Next pageIndex

            ' Write the extracted text to the output file
            File.WriteAllText(output, builder.ToString())

            ' Close the PdfDocument
            pdf.Close()

            ' Launch the Pdf files
            FileViewer(output)
		End Sub
		Private Sub FileViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
