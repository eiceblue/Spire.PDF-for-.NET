Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid

Namespace ChangeBorderColor
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim document As New PdfDocument()

            ' Load an existing PDF file
            document.LoadFromFile("..\..\..\..\..\..\Data\ChangeBorderColor.pdf")

            ' Get the first page of the document
            Dim page As PdfPageBase = document.Pages(0)

            ' Define an array of strings containing data in a specific format
            Dim data() As String = {"VendorName;Address1;City;State;Country", "Cacor Corporation;161 Southfield Rd;Southfield;OH;U.S.A.", "Underwater;50 N 3rd Street;Indianapolis;IN;U.S.A.", "J.W.  Luscher Mfg.;65 Addams Street;Berkely;MA;U.S.A.", "Scuba Professionals;3105 East Brace;Rancho Dominguez;CA;U.S.A.", "Divers'  Supply Shop;5208 University Dr;Macon;GA;U.S.A.", "Techniques;52 Dolphin Drive;Redwood City;CA;U.S.A.", "Perry Scuba;3443 James Ave;Hapeville;GA;U.S.A.", "Beauchat, Inc.;45900 SW 2nd Ave;Ft Lauderdale;FL;U.S.A.", "Amor Aqua;42 West 29th Street;New York;NY;U.S.A.", "Aqua Research Corp.;P.O. Box 998;Cornish;NH;U.S.A.", "B&K Undersea Photo;116 W 7th Street;New York;NY;U.S.A.", "Diving International Unlimited;1148 David Drive;San Diego;DA;U.S.A.", "Nautical Compressors;65 NW 167 Street;Miami;FL;U.S.A.", "Glen Specialties, Inc.;17663 Campbell Lane;Huntington Beach;CA;U.S.A.", "Dive Time;20 Miramar Ave;Long Beach;CA;U.S.A.", "Undersea Systems, Inc.;18112 Gotham Street;Huntington Beach;CA;U.S.A.", "Felix Diving;310 S Michigan Ave;Chicago;IL;U.S.A.", "Central Valley Skin Divers;160 Jameston Ave;Jamaica;NY;U.S.A.", "Parkway Dive Shop;241 Kelly Street;South Amboy;NJ;U.S.A.", "Marine Camera & Dive;117 South Valley Rd;San Diego;CA;U.S.A.", "Dive Canada;275 W Ninth Ave;Vancouver;British Columbia;Canada", "Dive & Surf;P.O. Box 20210;Indianapolis;IN;U.S.A.", "Fish Research Labs;29 Wilkins Rd Dept. SD;Los Banos;CA;U.S.A."}

            ' Create a new PdfGrid object
            Dim grid As New PdfGrid()

            ' Add rows to the grid based on the length of the data array
            For r As Integer = 0 To data.Length - 1
                Dim row As PdfGridRow = grid.Rows.Add()
            Next r

            ' Add 5 columns to the grid
            grid.Columns.Add(5)

            ' Set the width of each column
            grid.Columns(0).Width = 120
            grid.Columns(1).Width = 120
            grid.Columns(2).Width = 120
            grid.Columns(3).Width = 50
            grid.Columns(4).Width = 60

            ' Calculate the height for each row
            Dim height As Single = page.Canvas.ClientSize.Height - (grid.Rows.Count + 1)
            For i As Integer = 0 To grid.Rows.Count - 1
                grid.Rows(i).Height = 12.5F
            Next i

            ' Populate the grid with data from the data array
            For r As Integer = 0 To data.Length - 1
                Dim rowData() As String = data(r).Split(";"c)
                For c As Integer = 0 To rowData.Length - 1
                    grid.Rows(r).Cells(c).Value = rowData(c)
                Next c
            Next r

            ' Set the font for the first row of the grid
            grid.Rows(0).Style.Font = New PdfTrueTypeFont(New Font("Arial", 8.0F, FontStyle.Bold), True)

            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'grid.Rows(0).Style.Font = New PdfTrueTypeFont("Arial", 8.0F, FontStyle.Bold, True)
            ' =============================================================================

            ' Create a new border with a light blue color
            Dim border As New PdfBorders()
            border.All = New PdfPen(Color.LightBlue)

            ' Apply the border to each cell in the grid
            For Each pgr As PdfGridRow In grid.Rows
                For Each pgc As PdfGridCell In pgr.Cells
                    pgc.Style.Borders = border
                Next pgc
            Next pgr

            ' Draw the grid on the page at a specific location
            grid.Draw(page, New PointF(50, 330))

            ' Save the modified document to a new PDF file
            document.SaveToFile("BorderColor.pdf")

            ' Close the document
            document.Close()

            ' Launch the pdf file
            PDFDocumentViewer("BorderColor.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
