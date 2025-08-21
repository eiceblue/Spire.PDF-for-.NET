# 代码核心功能提取

# Spire.PDF C# Hello World
## Create a simple PDF document with "Hello, World!" text
```csharp
//Create a pdf instance
PdfDocument doc = new PdfDocument();

//Create one page
PdfPageBase page = doc.Pages.Add();            

//Draw the text
page.Canvas.DrawString("Hello, World!",
                       new PdfFont(PdfFontFamily.Helvetica, 30f),
                       new PdfSolidBrush(Color.Black),
                       10, 10);
```

---

# Spire.PDF C# Text Border
## Add border around text in PDF document
```csharp
// Get the first page
PdfPageBase page = doc.Pages[0];

string text = "Hello, World!";

// Create the font to use and set the font style 
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Times New Roman", 11, FontStyle.Regular), true);

// Measure the size of the text
SizeF size = font.MeasureString(text);

// Create a PdfSolidBrush instance for setting the color of text
PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
int x = 60;
int y = 300;

// Draw the text on page
page.Canvas.DrawString(text,
                       font,
                       new PdfSolidBrush(Color.Black),
                       x, y);

// Draw border for text          
page.Canvas.DrawRectangle(new PdfPen(brush, 0.5f), new Rectangle(x, y, (int)size.Width, (int)size.Height));
```

---

# spire.pdf csharp tooltip
## add tooltip to text in pdf
```csharp
//Create a pdf instance
PdfDocument doc = new PdfDocument();

//Create one page
PdfPageBase page = doc.Pages.Add();

//Define the text and its style
String text1 = "Your Office Development Master";
PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 18), true);
SizeF sizeF1 = font1.MeasureString(text1);
RectangleF rec1 = new RectangleF(new Point(100, 100), sizeF1);

//Draw text 
page.Canvas.DrawString(text1, font1, new PdfSolidBrush(Color.Blue), rec1);

//Create invisible button on text position
PdfButtonField field1 = new PdfButtonField(page, "field1");

//Set the bounds and size of field
field1.Bounds = rec1;

//Set tooltip content
field1.ToolTip = "E-iceblue Co. Ltd., a vendor of .NET, Java and WPF development components";

//Set no border for field
field1.BorderWidth = 0;

//Set backcolor and forcolor for field
field1.BackColor = Color.Transparent;
field1.ForeColor = Color.Transparent;
field1.LayoutMode = PdfButtonLayoutMode.IconOnly;
field1.IconLayout.IsFitBounds = true;

//Define the text and its style 
String text2 = "Spire.PDF";
PdfFont font2 = new PdfFont(PdfFontFamily.TimesRoman, 20);
SizeF sizeF2 = font2.MeasureString(text2);
RectangleF rec2 = new RectangleF(new Point(100, 160), sizeF2);

//Draw text 
page.Canvas.DrawString(text2, font2, PdfBrushes.DarkOrange, rec2);

//Create invisible button on text position
PdfButtonField field2 = new PdfButtonField(page, "field2");
field2.Bounds = rec2;
field2.ToolTip = "A professional PDF library applied to creating," +
                 "writing, editing, handling and reading PDF files" +
                 "without any external dependencies within .NET" +
                 "( C#, VB.NET, ASP.NET, .NET Core) application.";
field2.BorderWidth = 0;
field2.BackColor = Color.Transparent;
field2.ForeColor = Color.Transparent;
field2.LayoutMode = PdfButtonLayoutMode.IconOnly;
field2.IconLayout.IsFitBounds = true;

//Add the buttons to pdf form
doc.AllowCreateForm = true;
doc.Form.Fields.Add(field1);
doc.Form.Fields.Add(field2);
```

---

# Spire.PDF C# Transparent Text
## Add transparent text to a PDF document using Spire.PDF library
```csharp
//Create a PDF instance
PdfDocument doc = new PdfDocument();

//Create one A4 page
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(0));
page.Canvas.Save();

//Set transparency for page
float alpha = 0.25f;
page.Canvas.SetTransparency(alpha, alpha, PdfBlendMode.Normal);

//Create rectangle with specified dimensions      
RectangleF rect = new RectangleF(50, 50, 450, page.Size.Height);

//Create transparent text
String text = "Spire.PDF for .NET,a professional PDF library applied to" +
    " creating, writing, editing, handling and reading PDF files" +
    " without any external dependencies within .NET" +
    "( C#, VB.NET, ASP.NET, .NET Core) application.";
text += "\n\n\n\n\n";
text += "Spire.PDF for Java,a PDF Java API that enables" +
    "developers to read, write, convert and print PDF documents" +
    "in Java applications without using Adobe Acrobat.";

//Create brush from color channel
PdfSolidBrush brush = new PdfSolidBrush(Color.FromArgb(30, 0, 255, 0));

//Draw the text
page.Canvas.DrawString(text,
                       new PdfFont(PdfFontFamily.Helvetica, 14f),
                       brush,
                       rect);
page.Canvas.Restore();
```

---

# Spire.PDF C# Rotated Text
## Draw rotated text in PDF document
```csharp
//Create a PDF instance
PdfDocument doc = new PdfDocument();

//Create a page
PdfPageBase page = doc.Pages.Add();

//Define the text and its style
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f), true);
PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);
string text = "This is a text";

//Draw text before rotating Canvas
page.Canvas.DrawString(text, font, brush, 20, 30);

//Draw text before rotating Canvas
page.Canvas.DrawString(text, font, brush, 20, 150);

//Create PdfGraphicsState instance to save the state of page Canvas
PdfGraphicsState state = page.Canvas.Save();

PointF point1 = new PointF(20, 30);

//Rotate Canvas 90 degrees clockwise
page.Canvas.RotateTransform(90, point1);

//Draw text in rotated Canvas
page.Canvas.DrawString(text, font, brush, point1);

//Restores the state of this page Canvas to the state represented by a PdfGraphicsState.
page.Canvas.Restore(state);

//Redrawing a new text requires initializing a new state
PdfGraphicsState state2 = page.Canvas.Save();

PointF point2 = new PointF(20, 150);

//Rotate Canvas 90 degrees counterclockwise
page.Canvas.RotateTransform(-90, point2);

//Draw text in rotated Canvas
page.Canvas.DrawString(text, font, brush, point2);

//Restores the state of this page Canvas to the state represented by a PdfGraphicsState.
page.Canvas.Restore(state2);
```

---

# spire.pdf csharp text drawing
## demonstrates various text drawing techniques in PDF documents
```csharp
// Create a pdf instance
PdfDocument doc = new PdfDocument();

// Create one page
PdfPageBase page = doc.Pages.Add();

// Draw the text - brush
DrawText(page);

// Draw the text - alignment
AlignText(page);

// Draw the text - align in rectangle
AlignTextInRectangle(page);

// Draw the text - transform
TransformText(page);
RotateText(page);

// Draw the text - alignment
private void AlignText(PdfPageBase page)
{
    PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 20f);
    PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);

    // Draws left-aligned text
    PdfStringFormat leftAlignment = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
    page.Canvas.DrawString("Left!", font, brush, 0, 20, leftAlignment);
    page.Canvas.DrawString("Left!", font, brush, 0, 50, leftAlignment);

    // Draws right-aligned text
    PdfStringFormat rightAlignment = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
    page.Canvas.DrawString("Right!", font, brush, page.Canvas.ClientSize.Width, 20, rightAlignment);
    page.Canvas.DrawString("Right!", font, brush, page.Canvas.ClientSize.Width, 50, rightAlignment);

    // Draws center-aligned text
    PdfStringFormat centerAlignment = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
    page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, page.Canvas.ClientSize.Width / 2, 40, centerAlignment);
}

// Draw the text - align in rectangle
private void AlignTextInRectangle(PdfPageBase page)
{
    // Create the font to use and set the font style 
    PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 10f);
    PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);

    RectangleF rctg1 = new RectangleF(0, 70, page.Canvas.ClientSize.Width / 2, 100);
    RectangleF rctg2 = new RectangleF(page.Canvas.ClientSize.Width / 2, 70, page.Canvas.ClientSize.Width / 2, 100);

    // Draw rectangle and specifies its fill color and position
    page.Canvas.DrawRectangle(new PdfSolidBrush(Color.LightBlue), rctg1);
    page.Canvas.DrawRectangle(new PdfSolidBrush(Color.LightSkyBlue), rctg2);

    // Draws left-aligned text
    PdfStringFormat leftAlignment = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);
    page.Canvas.DrawString("Left! Left!", font, brush, rctg1, leftAlignment);
    page.Canvas.DrawString("Left! Left!", font, brush, rctg2, leftAlignment);

    // Draws right-aligned text
    PdfStringFormat rightAlignment = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
    page.Canvas.DrawString("Right! Right!", font, brush, rctg1, rightAlignment);
    page.Canvas.DrawString("Right! Right!", font, brush, rctg2, rightAlignment);

    // Draws center-aligned text
    PdfStringFormat centerAlignment = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Bottom);
    page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, rctg1, centerAlignment);
    page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, rctg2, centerAlignment);
}

private void RotateText(PdfPageBase page)
{
    // Save graphics state
    PdfGraphicsState state = page.Canvas.Save();

    // Draw the text - transform           
    PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 10f);
    PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);

    PdfStringFormat centerAlignment = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
    float x = page.Canvas.ClientSize.Width / 2;
    float y = 380;

    page.Canvas.TranslateTransform(x, y);
    for (int i = 0; i < 12; i++)
    {
        // Rotate Canvas
        page.Canvas.RotateTransform(30);
        // Draw text 
        page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, 20, 0, centerAlignment);
    }

    // Restore graphics
    page.Canvas.Restore(state);
}

private void TransformText(PdfPageBase page)
{
    // Save graphics state
    PdfGraphicsState state = page.Canvas.Save();

    // Draw the text - transform           
    PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 18f);
    PdfSolidBrush brush1 = new PdfSolidBrush(Color.DeepSkyBlue);
    PdfSolidBrush brush2 = new PdfSolidBrush(Color.CadetBlue);

    page.Canvas.TranslateTransform(20, 200);
    page.Canvas.ScaleTransform(1f, 0.6f);
    page.Canvas.SkewTransform(-10, 0);
    page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush1, 0, 0);

    page.Canvas.SkewTransform(10, 0);
    page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush2, 0, 0);

    page.Canvas.ScaleTransform(1f, -1f);
    page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush2, 0, -2 * 18);

    // Restore graphics
    page.Canvas.Restore(state);
}

private void DrawText(PdfPageBase page)
{
    // Save graphics state
    PdfGraphicsState state = page.Canvas.Save();

    // Draw text - brush
    String text = "Go! Turn Around! Go! Go! Go!";
    PdfPen pen = PdfPens.DeepSkyBlue;
    PdfSolidBrush brush = new PdfSolidBrush(Color.White);
    PdfStringFormat format = new PdfStringFormat();
    PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 18f, PdfFontStyle.Italic);
    SizeF size = font.MeasureString(text, format);
    RectangleF rctg
        = new RectangleF(page.Canvas.ClientSize.Width / 2 + 10, 180,
        size.Width / 3 * 2, size.Height * 2);
    page.Canvas.DrawString(text, font, pen, brush, rctg, format);

    // Restore graphics
    page.Canvas.Restore(state);
}
```

---

# spire.pdf csharp gradient text
## draw text with gradient brush in pdf
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Add a new page
PdfPageBase page = doc.Pages.Add();

//Create a rectangle
Rectangle rect = new Rectangle(new Point(0, 0), new Size(300, 100));

//Create a brush with gradient
PdfLinearGradientBrush brush = new PdfLinearGradientBrush(rect, Color.Red, Color.Blue, PdfLinearGradientMode.Horizontal);

//Create a true type font with size 20f, underline style
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 20, FontStyle.Underline));

//Draw text
page.Canvas.DrawString("Welcome to E-iceblue!", font, brush, new Point(0, 100));
```

---

# spire.pdf csharp font embedding
## Embed fonts into PDF document
```csharp
// Creating an instance of the PdfEmbeddedFontConverter class and specifying the path to the source PDF file
PdfEmbeddedFontConverter converter = new PdfEmbeddedFontConverter(@"..\..\..\..\..\..\Data\UnEmbed.pdf");

// Specifying the output file path where the converted PDF with embedded fonts will be saved
string output = @"EmbedFontToPdf.pdf";

// Calling the ToEmbeddedFontDocument method of the converter object to convert the PDF and embed fonts
converter.ToEmbeddedFontDocument(output);
```

---

# Spire.PDF Extract Highlighted Text
## Extract text that has been highlighted in a PDF document
```csharp
//Create a pdf instance
PdfDocument doc = new PdfDocument();

PdfPageBase page = doc.Pages[0];
PdfTextMarkupAnnotationWidget textMarkupAnnotation;
StringBuilder stringBuilder = new StringBuilder();
PdfTextExtractor pdfTextExtractor = new PdfTextExtractor(page);
//Get PdfTextMarkupAnnotationWidget objects
for (int i = 0; i < page.Annotations.Count; i++)
{
    if (page.Annotations[i] is PdfTextMarkupAnnotationWidget)
    {
        textMarkupAnnotation = page.Annotations[i] as PdfTextMarkupAnnotationWidget;
        //Get the highlighted text
        PdfTextExtractOptions pdfTextExtractOptions = new PdfTextExtractOptions();
        pdfTextExtractOptions.ExtractArea = textMarkupAnnotation.Bounds;
        stringBuilder.AppendLine(pdfTextExtractor.ExtractText(pdfTextExtractOptions));

        //Get the highlighted color
        Color color = textMarkupAnnotation.TextMarkupColor;
    }
}
```

---

# Spire.PDF C# Text Extraction
## Extract text from a specific page of a PDF document
```csharp
// Read a pdf file
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Get the first page
PdfPageBase page = doc.Pages[0];

// Extract text from page keeping white space
PdfTextExtractOptions options = new PdfTextExtractOptions();
options.IsExtractAllText = true; //false->Extract text from page without keeping white space
PdfTextExtractor pdfTextExtractor = new PdfTextExtractor(page);
String text = pdfTextExtractor.ExtractText(options);
```

---

# Spire.PDF C# Text Extraction
## Extract text from a specific area in a PDF document
```csharp
// Load the PDF file
PdfDocument pdf = new PdfDocument();

// Get the first page of the PDF
PdfPageBase page = pdf.Pages[0];

// Define options for text extraction
PdfTextExtractOptions options = new PdfTextExtractOptions();
options.ExtractArea = new RectangleF(80, 180, 500, 200);

// Create a PdfTextExtractor object and extract text using the specified options
PdfTextExtractor pdfTextExtractor = new PdfTextExtractor(page);
string text = pdfTextExtractor.ExtractText(options);
```

---

# Spire.PDF C# Text Highlighting
## Find and highlight specific text in a PDF document
```csharp
// Load the document from disk
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile("FindAndHighlightText.pdf");

// Iterate through each page of the document
foreach (PdfPageBase page in pdf.Pages)
{
    // Create a PdfTextFinder object for the current page
    PdfTextFinder finder = new PdfTextFinder(page);
    finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.WholeWord;

    // Find the occurrences of the specified text
    List<PdfTextFragment> finds = finder.Find("science");

    // Highlight the found text
    foreach (PdfTextFragment find in finds)
    {
        find.HighLight();
    }
}

// Save the modified document
pdf.SaveToFile("FindAndHighlightText_out.pdf", FileFormat.PDF);
```

---

# spire.pdf csharp text finder
## find text in pdf document by reading order
```csharp
// Create a new PdfDocument object to work with PDF files
PdfDocument doc = new PdfDocument();

// Load the PDF file from the specified file path
doc.LoadFromFile(filePath);

// Get the first page of the loaded document
PdfPageBase pdfPageBase = doc.Pages[0];

// Create a PdfTextFinder object with the first page for searching text
PdfTextFinder finder = new PdfTextFinder(pdfPageBase);

// Set the search strategy as Simple
finder.Options.Strategy = PdfTextStrategy.Simple;

// Find all occurrences of the text on the page
List<PdfTextFragment> pdfTextFragments = finder.Find("knowledge");

// Iterate over each found text fragment
foreach (PdfTextFragment find in pdfTextFragments)
{
    // Get the found text
    string text = find.Text;

    // Get the sizes of the text
    foreach (SizeF size in find.Sizes)
    {
        // Process text size
    }

    // Get the positions of the text
    foreach (PointF point in find.Positions)
    {
        // Process text position
    }

    // Get the line that contains the searched text
    string lineText = find.LineText;
}

// Dispose of system resources associated with the PdfDocument object
doc.Dispose();
```

---

# Spire.PDF C# Text Search
## Find and highlight text in a defined area of a PDF document
```csharp
// Define a rectangle to specify the search area
RectangleF rctg = new RectangleF(0, 0, 300, 300);

//Get the first page
PdfPageBase pdfPageBase = doc.Pages[0];

// Create a PdfTextFinder object for the first page
PdfTextFinder finder = new PdfTextFinder(pdfPageBase);
finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.WholeWord;
finder.Options.Area = rctg;

//Find text in the rectangle
List<PdfTextFragment> finds = finder.Find("Spire");
List<PdfTextFragment> findouts = finder.Find("PDF");

//Highlight the found text
foreach (PdfTextFragment find in finds)
{
    find.HighLight(Color.Green);
}

foreach (PdfTextFragment findOut in findouts)
{
    findOut.HighLight(Color.Yellow);
}
```

---

# spire.pdf csharp font
## demonstrates how to use different types of fonts in PDF documents
```csharp
//Get one page
PdfPageBase page = doc.Pages[0];

float l = page.Canvas.ClientSize.Width / 2;
PointF center = new PointF(l, l);
float r = (float)Math.Sqrt(2 * l * l);
PdfRadialGradientBrush brush = new PdfRadialGradientBrush(center, 0f, center, r, Color.Blue, Color.Red);
PdfFontFamily[] fontFamilies = (PdfFontFamily[])Enum.GetValues(typeof(PdfFontFamily));
float y = 200;
for (int i = 0; i < fontFamilies.Length; i++)
{
    String text = String.Format("Font Family: {0}", fontFamilies[i]);
    float x1 = 40;
    y = 200 + i * 16;

    //Define font
    PdfFont font1 = new PdfFont(PdfFontFamily.Courier, 14f);
    PdfFont font2 = new PdfFont(fontFamilies[i], 14f);

    //Measure the width of text
    float x2 = x1 + 10 + font1.MeasureString(text).Width;

    //Draw text
    page.Canvas.DrawString(text, font1, brush, x1, y);
    page.Canvas.DrawString(text, font2, brush, x2, y);
}

//True type font - embedded
System.Drawing.Font font = new System.Drawing.Font("Arial", 15f, FontStyle.Bold);
PdfTrueTypeFont trueTypeFont = new PdfTrueTypeFont(font);
page.Canvas.DrawString("Font Family: Arial - Embedded", trueTypeFont, brush, 40, (y = y + 26f));

//Right to left
String arabicText
    = "\u0627\u0644\u0630\u0647\u0627\u0628\u0021\u0020"
    + "\u0628\u062F\u0648\u0631\u0647\u0020\u062D\u0648\u0644\u0647\u0627\u0021\u0020"
    + "\u0627\u0644\u0630\u0647\u0627\u0628\u0021\u0020"
    + "\u0627\u0644\u0630\u0647\u0627\u0628\u0021\u0020"
    + "\u0627\u0644\u0630\u0647\u0627\u0628\u0021";
trueTypeFont = new PdfTrueTypeFont(font, true);
RectangleF rctg = new RectangleF(new PointF(40, (y = y + 26f)), page.Canvas.ClientSize);

//Define the format of string 
PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
format.RightToLeft = true;

//Draw text
page.Canvas.DrawString(arabicText, trueTypeFont, brush, rctg, format);

//True type font - not embedded
font = new System.Drawing.Font("Batang", 14f, FontStyle.Italic);
trueTypeFont = new PdfTrueTypeFont(font);
page.Canvas.DrawString("Font Family: Batang - Not Embedded", trueTypeFont, brush, 40, (y = y + 16f));

//Font file
String fontFileName = "PT_Serif-Caption-Web-Regular.ttf";
trueTypeFont = new PdfTrueTypeFont(fontFileName, 20f);
page.Canvas.DrawString("PT Serif Caption Font", trueTypeFont, brush, 40, (y = y + 36f));
page.Canvas.DrawString("PT Serif Caption Font", new PdfFont(PdfFontFamily.Helvetica, 8f), brush, 40, (y = y + 40f));

//Cjk font
PdfCjkStandardFont cjkFont = new PdfCjkStandardFont(PdfCjkFontFamily.MonotypeHeiMedium, 14f);
page.Canvas.DrawString("How to say 'Font' in Chinese? \u5B57\u4F53", cjkFont, brush, 40, (y = y + 36f));

cjkFont = new PdfCjkStandardFont(PdfCjkFontFamily.HanyangSystemsGothicMedium, 14f);
page.Canvas.DrawString("How to say 'Font' in Japanese? \u30D5\u30A9\u30F3\u30C8", cjkFont, brush, 40, (y = y + 36f));

cjkFont = new PdfCjkStandardFont(PdfCjkFontFamily.HanyangSystemsShinMyeongJoMedium, 14f);
page.Canvas.DrawString("How to say 'Font' in Korean? \uAE00\uAF34", cjkFont, brush, 40, (y = y + 36f));
```

---

# spire.pdf text search
## get details of searched text in pdf document
```csharp
// Load the PDF document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Get the first page of the PDF document
PdfPageBase page = doc.Pages[0];

// Create a PdfTextFinder object for searching text within the page
PdfTextFinder finder = new PdfTextFinder(page);
finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;

// Find occurrences of the specified text within the page
List<PdfTextFragment> finds = finder.Find("Spire.PDF for .NET");

// Create a StringBuilder object to store the details of the searched text
StringBuilder builder = new StringBuilder();

// Iterate through each found text fragment
foreach (PdfTextFragment find in finds)
{
    builder.AppendLine("==================================================================================");
    // Append the matched text and the detail of matched text to the StringBuilder
    builder.AppendLine("Match Text: " + find.Text);
    builder.AppendLine("Size: " + find.Sizes[0]);
    builder.AppendLine("Position: " + find.Positions[0]);
    builder.AppendLine("The line that contains the searched text: " + find.LineText);
}
```

---

# spire.pdf csharp text search
## get font information of searched text in pdf
```csharp
// Create PdfTextFinder
PdfTextFinder finds = new PdfTextFinder(page);
// Set options to find
finds.Options.Parameter = TextFindParameter.None;
// Find the key word
List<PdfTextFragment> result = finds.Find("science");

// Iterate the results
foreach (PdfTextFragment find in result)
{
    // Get the line of keyword 
    string text = find.LineText;
    // Get the font name 
    string FontName = find.TextStates[0].FontName;
    // Get the font size
    float FontSize = find.TextStates[0].FontSize;
    // Get font family
    string FontFamily = find.TextStates[0].FontFamily;
    // Get whether the keyword is bold
    bool IsBold = find.TextStates[0].IsBold;
    // Get whether the keyword is simulate bold
    bool IsSimulateBold = find.TextStates[0].IsSimulateBold;
    // Get whether the keyword is italic
    bool IsItalic = find.TextStates[0].IsItalic;
    // Get color
    Color color = find.TextStates[0].ForegroundColor;
}
```

---

# Spire.PDF C# Text Measurement
## Get text size based on different font types
```csharp
// Create text to measure
string text = "Spire.PDF for .NET";

// Create an instance for PdfFont
PdfFont font1 = new PdfFont(PdfFontFamily.TimesRoman, 12f);

// Get text size based on font name and size
SizeF sizeF1 = font1.MeasureString(text);

// Create an instance for PdfTrueTypeFont
PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Regular), true);

// Get text size based on font name and size
SizeF sizeF2 = font2.MeasureString(text);
```

---

# Spire.PDF C# HTML Text Insertion
## Insert HTML styled text into PDF document
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Add a new page
PdfNewPage page = doc.Pages.Add() as PdfNewPage;

//HTML string
string htmlText = "This demo shows how we can insert <u><i>HTML styled text</i></u> to PDF using "
                 + "<font color='#FF4500'>Spire.PDF for .NET</font>. ";

//Render HTML text
PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 25);
PdfBrush brush = PdfBrushes.Black;
PdfHTMLTextElement richTextElement = new PdfHTMLTextElement(htmlText, font, brush);
richTextElement.TextAlign = TextAlign.Left;

//Format Layout
PdfMetafileLayoutFormat format = new PdfMetafileLayoutFormat();
format.Layout = PdfLayoutType.Paginate;
format.Break = PdfLayoutBreakType.FitPage;

//Draw htmlString  
richTextElement.Draw(page, new RectangleF(0, 20, page.GetClientSize().Width, page.GetClientSize().Height), format);
```

---

# Spire.PDF C# Text Replacement
## Replace all searched text in a PDF document
```csharp
String input = @"..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf";
PdfDocument doc = new PdfDocument();

// Read a pdf file
doc.LoadFromFile(input);

// Get the first page of pdf file
PdfPageBase page = doc.Pages[0];

// Create a PdfTextFinder object for searching text within the page
PdfTextFinder finder = new PdfTextFinder(page);
finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;

// Find occurrences of the specified text within the page
List<PdfTextFragment> finds = finder.Find("Spire.PDF for .NET");

String newText = "E-iceblue Spire.PDF";

// Creates a brush
PdfBrush brush = new PdfSolidBrush(Color.DarkBlue);

// Defines a font
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Regular));

RectangleF rec;

// Iterate through each found text fragment
foreach (PdfTextFragment find in finds)
{
    // Gets the bound of the found text in page
    rec = find.Bounds[0];

    page.Canvas.DrawRectangle(PdfBrushes.White, rec);
    // Draws new text as defined font and color
    page.Canvas.DrawString(newText, font, brush, rec);

    // This method can directly replace old text with newText,but it just can set the background color, can not set font/forecolor
    // find.ApplyRecoverString(newText, Color.Gray);
}

String result = "ReplaceAllSearchedText_out.pdf";

//Save the document
doc.SaveToFile(result);
```

---

# spire.pdf text replacement
## replace the first occurrence of searched text in a pdf document
```csharp
// Get the first page of pdf file
PdfPageBase page = doc.Pages[0];

// Create a PdfTextFinder object for searching text within the first page
PdfTextFinder finder = new PdfTextFinder(page);
finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;

// Find occurrences of the specified text within the first page
List<PdfTextFragment> finds = finder.Find("Spire.PDF for .NET");

String newText = "Spire.PDF API";

// Gets the first found object
PdfTextFragment find = finds[0];

// Creates a brush
PdfBrush brush = new PdfSolidBrush(Color.DarkBlue);

// Defines a font
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 15f, FontStyle.Bold));

// Gets the bound of the first found text in page
RectangleF rec = find.Bounds[0];

page.Canvas.DrawRectangle(PdfBrushes.White, rec);

// Draws new text as defined font and color
page.Canvas.DrawString(newText, font, brush, rec);

// This method can directly replace old text with newText, but it just can set the background color, can not set font/forecolor
// find.ApplyRecoverString(newText, Color.Gray);
```

---

# spire.pdf font replacement
## replace fonts in pdf document
```csharp
//Load the document from disk 
PdfDocument doc = new PdfDocument();
doc.LoadFromFile("ReplaceFont.pdf");

//Get the fonts used in PDF
PdfUsedFont[] fonts = doc.UsedFonts;

//Create a new font 
PdfTrueTypeFont newfont = new PdfTrueTypeFont(new Font("Arial", 13f), true);

// Iterate through each used fonts
foreach (PdfUsedFont font in fonts)
{
    //Replace the font with new font
    font.Replace(newfont);
}

//Save the document
doc.SaveToFile("Output.pdf");
```

---

# Spire.PDF C# Text Replacement
## Replace text in PDF documents ignoring case sensitivity
```csharp
// Get a page from the pdf document
PdfPageBase page = doc.Pages[0];

// Create a PdfTextReplacer using the page
PdfTextReplacer replacer = new PdfTextReplacer(page);

// Set options for text replacement
PdfTextReplaceOptions option = new PdfTextReplaceOptions();
option.ReplaceType = PdfTextReplaceOptions.ReplaceActionType.IgnoreCase;
replacer.Options = option;

// Only replace the first occurrence of "text" with "This is a test" in this page
replacer.ReplaceText("text", "This is a test");

// Replace all occurrences of "pdf" with "Spire.Pdf for Net" in this page
replacer.ReplaceAllText("pdf", "Spire.Pdf for Net");
```

---

# spire.pdf csharp text replacement
## Replace text in PDF document using Spire.PDF library
```csharp
// Create a new PdfDocument
PdfDocument doc = new PdfDocument();

// Get the first page of the pdf file
PdfPageBase page = doc.Pages[0];

// Create a PdfTextReplacer using the first page
PdfTextReplacer replacer = new PdfTextReplacer(page);

// Replace all occurrences of "Spire.PDF" with "E-iceblue" in this page
replacer.ReplaceAllText("Spire.PDF", "E-iceblue");

// Replace the first occurrence of "Adobe Acrobat" with "PDF editors"
replacer.ReplaceText("Adobe Acrobat", "PDF editors");
```

---

# spire.pdf csharp text search
## search text and add hyperlink to pdf
```csharp
// Create a PdfTextFinder using the first page
PdfTextFinder finder = new PdfTextFinder(page);

// Set the search parameter to ignore case
finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;

// Find all occurrences of "e-iceblue" in the PDF and store them in a list
List<PdfTextFragment> finds = finder.Find("e-iceblue");

// Define the hyperlink URL
String url = "http://www.e-iceblue.com";

// Iterate through each found text fragment
foreach (PdfTextFragment find in finds)
{
    // Create a PdfUriAnnotation object to add a hyperlink for the searched text
    PdfUriAnnotation uri = new PdfUriAnnotation(find.Bounds[0]);
    uri.Uri = url;
    uri.Border = new PdfAnnotationBorder(1f);
    uri.Color = Color.Blue;

    // Add the annotation to the page's annotation widget
    page.Annotations.Add(uri);
}
```

---

# spire.pdf csharp text search
## search text in pdf and draw rectangles around found text
```csharp
// Read a pdf file
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Get the first page of pdf file
PdfPageBase page = doc.Pages[0];

// Create a PdfTextFinder object for searching text within the first page
PdfTextFinder finder = new PdfTextFinder(page);
finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;

// Find occurrences of the specified text within the first page
List<PdfTextFragment> finds = finder.Find("Spire.PDF for .NET");

// Iterate through each found text fragment
foreach (PdfTextFragment find in finds)
{
    // Draw a rectangle with red pen
    page.Canvas.DrawRectangle(new PdfPen(PdfBrushes.Red, 0.9f), find.Bounds[0]);
}

//Save the document
doc.SaveToFile(result);
```

---

# Spire.PDF Text Search with Regular Expressions
## Search for text patterns in PDF using regular expressions and replace them
```csharp
// Get the first page of pdf file
PdfPageBase page = doc.Pages[0];

// Create a PdfTextFinder object for searching text within the first page
PdfTextFinder finder = new PdfTextFinder(page);
finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.Regex;

// Find occurrences of the specified text within the first page
List<PdfTextFragment> finds = finder.Find("\\d{4}");

String newText = "New Year";

// Creates a brush
PdfBrush brush = new PdfSolidBrush(Color.DarkBlue);

// Defines a font
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 7f, FontStyle.Bold));

// Defines text horizontal/vertical center format
PdfStringFormat centerAlign = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

RectangleF rec;

// Iterate through each found text fragment
foreach (PdfTextFragment find in finds)
{
    // Gets the bound of the found text in page
    rec = find.Bounds[0];

    page.Canvas.DrawRectangle(PdfBrushes.GreenYellow, rec);
    // Draws new text as defined font and color
    page.Canvas.DrawString(newText, font, brush, rec, centerAlign);
    
    // This method can directly replace old text with newText, but it just can set the background color, can not set font/forecolor
    // find.ApplyRecoverString(newText, Color.Gray);
}
```

---

# spire.pdf csharp text formatting
## set horizontal scaling factor for text in pdf
```csharp
// Create a new PDF document object
PdfDocument doc = new PdfDocument();

// Add a new page to the document
PdfPageBase page = doc.Pages.Add();

// Create a solid brush with black color
PdfSolidBrush solidBrush = new PdfSolidBrush(new PdfRGBColor(Color.Black));

// Create a string format object
PdfStringFormat format = new PdfStringFormat();

// Set the horizontal scaling factor to 80%
format.HorizontalScalingFactor = 80;

// Create a font object
PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);

// Define the text to be displayed
string text = "This is test string, The zoom ratio is 80%";

// Draw the text on the page with the specified font, brush, position, and format
page.Canvas.DrawString(text, font, solidBrush, 10, 50, format);

// Define the second text
string text2 = "This is test string, The zoom ratio is 100%";

// Set the horizontal scaling factor to 100%
format.HorizontalScalingFactor = 100;

// Draw the second text on the page
page.Canvas.DrawString(text2, font, solidBrush, 10, 80, format);

// Define the third text
string text3 = "This is test string, The zoom ratio is 120%";

// Set the horizontal scaling factor to 120%
format.HorizontalScalingFactor = 120;

// Draw the third text on the page
page.Canvas.DrawString(text3, font, solidBrush, 10, 110, format);
```

---

# Spire.PDF C# Text Line Breaks
## Creating a PDF document with text containing line breaks
```csharp
// Create a pdf document
PdfDocument doc = new PdfDocument();

// Create one A4 page
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(40));

// Create brush from color channel
PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

// Create text
String text = "Spire.PDF for .NET" +
    "\n" +
    "A professional PDF library applied to" +
    " creating, writing, editing, handling and reading PDF files" +
    " without any external dependencies within .NET" +
    "( C#, VB.NET, ASP.NET, .NET Core) application.";

text += "\n\rSpire.PDF for Java" +
     "\n" +
    "A PDF Java API that enables developers to read, " +
    "write, convert and print PDF documents" +
    "in Java applications without using Adobe Acrobat.";
text += "\n\r";
text += "Welcome to evaluate Spire.PDF!";

// Create rectangle with specified dimensions  
RectangleF rect = new RectangleF(50, 50, page.Size.Width - 150, page.Size.Height);

// Draw the text
page.Canvas.DrawString(text,
                       new PdfFont(PdfFontFamily.Helvetica, 13f),
                       brush,
                       rect);
```

---

# Spire.PDF C# Superscript and Subscript
## Creating superscript and subscript text in PDF documents
```csharp
// Create a PDF document and add a page
PdfDocument doc = new PdfDocument();
PdfPageBase page = doc.Pages.Add();

// Set font and brush
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 20f));
PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

string text = "Spire.PDF for .NET";

// Draw Superscript
DrawSuperscript(page, text, font, brush);

// Draw Subscript
DrawSubscript(page, text, font, brush);

private void DrawSuperscript(PdfPageBase page, string text, PdfTrueTypeFont font, PdfSolidBrush brush)
{
    float x = 120f;
    float y = 100f;
    page.Canvas.DrawString(text, font, brush, new PointF(x, y));

    // Measure the string
    SizeF size = font.MeasureString(text);

    // Set the x coordinate of the superscript text
    x += size.Width;

    // Instantiate a PdfStringFormat instance
    PdfStringFormat format = new PdfStringFormat();

    // Set format as superscript
    format.SubSuperScript = PdfSubSuperScript.SuperScript;

    // Draw superscript text with format
    text = "Superscript";
    page.Canvas.DrawString(text, font, brush, new PointF(x, y), format);
}

private void DrawSubscript(PdfPageBase page, string text, PdfTrueTypeFont font, PdfSolidBrush brush)
{
    float x = 120f;
    float y = 150f;
    page.Canvas.DrawString(text, font, brush, new PointF(x, y));

    // Measure the string
    SizeF size = font.MeasureString(text);

    // Set the x coordinate of the subscript text
    x += size.Width;

    // Instantiate a PdfStringFormat instance
    PdfStringFormat format = new PdfStringFormat();

    // Set format as subscript
    format.SubSuperScript = PdfSubSuperScript.SubScript;

    // Draw subscript text with format
    text = "SubScript";
    page.Canvas.DrawString(text, font, brush, new PointF(x, y), format);
}
```

---

# spire.pdf csharp text layout
## layout text around image in pdf
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Create one page
PdfPageBase page = doc.Pages.Add();
float pageWidth = page.Canvas.ClientSize.Width;
float y = 0;

//Load an image
PdfImage image = PdfImage.FromFile("image.png");
page.Canvas.DrawImage(image, new PointF(pageWidth - image.PhysicalDimension.Width, y));
float imageLeftSpace = pageWidth - image.PhysicalDimension.Width - 2;
float imageBottom = image.PhysicalDimension.Height + y;

//Define the format of string
PdfStringFormat format4 = new PdfStringFormat();
String text = "Sample text for layout";

//Define the font style
PdfTrueTypeFont font5 = new PdfTrueTypeFont(new Font("Arial", 12f));
format4.LineSpacing = font5.Size * 1.5f;

PdfBrush brush2 = new PdfSolidBrush(Color.Black);

PdfStringLayouter textLayouter = new PdfStringLayouter();
float imageLeftBlockHeight = imageBottom - y;
PdfStringLayoutResult result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
if (result.ActualSize.Height < imageBottom - y)
{
    imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight;
    result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
}
foreach (LineInfo line in result.Lines)
{
    //Draw text
    page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4);
    y = y + result.LineHeight + 2;
}

// Handle remaining text that doesn't fit in the allocated space next to the image
PdfTextWidget textWidget = new PdfTextWidget(result.Remainder, font5, brush2);
PdfTextLayout textLayout = new PdfTextLayout();
textLayout.Break = PdfLayoutBreakType.FitPage;
textLayout.Layout = PdfLayoutType.Paginate;
RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
textWidget.StringFormat = format4;
textWidget.Draw(page, bounds, textLayout);
```

---

# spire.pdf csharp text wrapping
## wrap text around image in pdf document
```csharp
// Creates a pdf document
PdfDocument doc = new PdfDocument();

// Creates a page 
PdfPageBase page = doc.Pages.Add();

//Gets page width
float pageWidth = page.Canvas.ClientSize.Width;
float y = 0;

y = y + 8;

// Creates a brush
PdfBrush brush = new PdfSolidBrush(Color.Black);

// Defines a font
PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 20f, FontStyle.Bold));

// Defines a text center alignment format
PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
format1.CharacterSpacing = 1f;

String text = "Spire.PDF for .NET";
// Draws text at the specified position
page.Canvas.DrawString(text, font1, brush, pageWidth / 2, y, format1);
// Get the size of text
SizeF size = font1.MeasureString(text, format1);
y = y + size.Height + 6;

// Loads an image 
PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\PdfImage.png");

// Draws image at the specified position
page.Canvas.DrawImage(image, new PointF(pageWidth - image.PhysicalDimension.Width, y));
float imageLeftSpace = pageWidth - image.PhysicalDimension.Width - 2;
float imageBottom = image.PhysicalDimension.Height + y;

PdfStringFormat format2 = new PdfStringFormat();
// Loads the text around the image
text = System.IO.File.ReadAllText(@"..\..\..\..\..\..\Data\text.txt");

PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 16f));

//Set line spacing
format2.LineSpacing = font2.Size * 1.5f;

PdfStringLayouter textLayouter = new PdfStringLayouter();
float imageLeftBlockHeight = imageBottom - y;

// Splits the text around into multiple lines based on the draw area
PdfStringLayoutResult result
    = textLayouter.Layout(text, font2, format2, new SizeF(imageLeftSpace, imageLeftBlockHeight));
if (result.ActualSize.Height < imageLeftBlockHeight)
{
    imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight;
    result = textLayouter.Layout(text, font2, format2, new SizeF(imageLeftSpace, imageLeftBlockHeight));
}
// Draws all the lines onto the page
foreach (LineInfo line in result.Lines)
{
    page.Canvas.DrawString(line.Text, font2, brush, 0, y, format2);
    y = y + result.LineHeight;
}

// Draw the rest of the text onto the page
PdfTextWidget textWidget = new PdfTextWidget(result.Remainder, font2, brush);
PdfTextLayout textLayout = new PdfTextLayout();
textLayout.Break = PdfLayoutBreakType.FitPage;
textLayout.Layout = PdfLayoutType.Paginate;
RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
textWidget.StringFormat = format2;
textWidget.Draw(page, bounds, textLayout);
```

---

# spire.pdf csharp svg to pdf
## add SVG image to PDF document
```csharp
//Create a new PDF document.
PdfDocument existingPDF = new PdfDocument();

//Load an existing PDF
existingPDF.LoadFromFile(@"..\..\..\..\..\..\Data\SampleB_1.pdf");

//Create a new PDF document.
PdfDocument doc = new PdfDocument();

//Load the SVG file
doc.LoadFromSvg(@"..\..\..\..\..\..\Data\template.svg");

//Create template
PdfTemplate template = doc.Pages[0].CreateTemplate();

//Draw template on existing PDF
existingPDF.Pages[0].Canvas.DrawTemplate(doc.Pages[0].CreateTemplate(), new PointF(50, 250), new SizeF(200, 200));

//Save the document
String result = "AddSVGToPDF_out.pdf";
existingPDF.SaveToFile(result, FileFormat.PDF);
```

---

# Spire.PDF Convert PDF Pages to EMF
## Convert all pages of a PDF document to EMF image files
```csharp
// Open pdf document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile(file);

// Iterate through each page
for (int i = 0; i < pdf.Pages.Count; i++)
{
    String fileName = String.Format("ToEMF-img-{0}.emf", i);
    // Save page to images in metafile type
    using (Image image = pdf.SaveAsImage(i, PdfImageType.Metafile, 300, 300))
    {
        image.Save(fileName, ImageFormat.Emf);
    }
}

pdf.Close();
```

---

# Spire.PDF C# Convert PDF to PNG
## Convert all pages of a PDF document to PNG images
```csharp
//Open pdf document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile(file);

// Iterate through each page
for (int i = 0; i < pdf.Pages.Count; i++)
{
    String fileName = String.Format("ToPNG-img-{0}.png", i);

    //Save page to images in PNG type
    using (Image image = pdf.SaveAsImage(i, 300, 300))
    {
        image.Save(fileName, ImageFormat.Png);
    }
}

pdf.Close();
```

---

# Spire.PDF C# Image to PDF Conversion
## Convert image stream to PDF document
```csharp
// Create a pdf document with a section and page added
PdfDocument pdf = new PdfDocument();
PdfSection section = pdf.Sections.Add();
PdfPageBase page = section.Pages.Add();

// Create a MemoryStream object from image Byte array
MemoryStream ms = new MemoryStream(data);

// Specify the image source as MemoryStream
PdfImage image = PdfImage.FromStream(ms);

// Set image display location and size in PDF
// Calculate rate
float widthFitRate = image.PhysicalDimension.Width / page.Canvas.ClientSize.Width;
float heightFitRate = image.PhysicalDimension.Height / page.Canvas.ClientSize.Height;
float fitRate = Math.Max(widthFitRate, heightFitRate);

// Calculate the size of image 
float fitWidth = image.PhysicalDimension.Width / fitRate;
float fitHeight = image.PhysicalDimension.Height / fitRate;

// Draw image
page.Canvas.DrawImage(image, 0, 30, fitWidth, fitHeight);
```

---

# spire.pdf csharp image conversion
## convert image to pdf
```csharp
// Create a pdf document with a section and page added.
PdfDocument pdf = new PdfDocument();
PdfSection section = pdf.Sections.Add();
PdfPageBase page = pdf.Pages.Add();

//Load a tiff image from system
PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\bg.png");

//Set image display location and size in PDF
//Calculate rate
float widthFitRate = image.PhysicalDimension.Width / page.Canvas.ClientSize.Width;
float heightFitRate = image.PhysicalDimension.Height / page.Canvas.ClientSize.Height;
float fitRate = Math.Max(widthFitRate, heightFitRate);

//Calculate the size of image 
float fitWidth = image.PhysicalDimension.Width / fitRate;
float fitHeight = image.PhysicalDimension.Height / fitRate;

//Draw image
page.Canvas.DrawImage(image, 0, 30, fitWidth, fitHeight);
```

---

# Spire.PDF C# Convert PDF to BMP
## Convert PDF pages to BMP images
```csharp
// Open pdf document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile(file);

// Iterate through each page
for (int i = 0; i < pdf.Pages.Count; i++)
{
    // Save page to images in Bmp type
    String fileName = String.Format("ToBMP-img-{0}.bmp", i);
    using (Image image = pdf.SaveAsImage(i, 300, 300))
    {
        image.Save(fileName, ImageFormat.Bmp);
    }
}

pdf.Close();
```

---

# spire.pdf csharp image manipulation
## delete images from pdf by bounds
```csharp
//Open pdf document
PdfDocument pdf = new PdfDocument();

//Get the first page
PdfPageBase page = pdf.Pages[0];

//Get the information of all images in this page 
PdfImageHelper helper = new PdfImageHelper();
Spire.Pdf.Utilities.PdfImageInfo[] images = helper.GetImagesInfo(page);

//Traverse the array
for (int i = 0; i < images.Length; i++)
{
    //Case 1: delete the image if it's bounds contains a certain point
    if (images[i].Bounds.Contains(49.68f, 72.75f))
    {
        helper.DeleteImage(images[i]);
    }

    //Case 2: delete the image if it's bounds intersects with a certain rectangle
    if (images[i].Bounds.IntersectsWith(new RectangleF(100f, 500f, 30f, 40f)))
    {
        helper.DeleteImage(images[i]);
    }
}
```

---

# spire.pdf csharp image manipulation
## delete image from pdf document
```csharp
// Create a new PdfDocument instance
PdfDocument pdf = new PdfDocument();

// Load the PDF document
pdf.LoadFromFile(file);

// Get the first page of the PDF document
PdfPageBase page = pdf.Pages[0];

// Create a PdfImageHelper instance for working with images in the PDF
PdfImageHelper helper = new PdfImageHelper();

// Get information about the images on the page
Spire.Pdf.Utilities.PdfImageInfo[] images = helper.GetImagesInfo(page);

// Delete the first image on the page
helper.DeleteImage(images[0]);
```

---

# spire.pdf csharp delete image
## delete image from pdf document
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load the document from disk
doc.LoadFromFile("DeleteImage.pdf");

//Get the first page
PdfPageBase page = doc.Pages[0];

//Delete the first image on the page
page.DeleteImage(0);

//Save the document
doc.SaveToFile("Output.pdf");
```

---

# Spire.PDF C# Image Drawing
## Draw and transform images in PDF documents
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();            

//Create one page
PdfPageBase page = doc.Pages.Add();

// Method for drawing an image on the specified page
private void DrawImage(PdfPageBase page)
{
    // Load an image from file
    PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\ChartImage.png");

    // Calculate the scaled width and height of the image
    float width = image.Width * 0.75f;
    float height = image.Height * 0.75f;

    // Calculate the x-coordinate to center the image horizontally on the page
    float x = (page.Canvas.ClientSize.Width - width) / 2;

    // Draw the image on the page at the specified position and size
    page.Canvas.DrawImage(image, x, 60, width, height);
}

// Method for transforming the image and drawing it on the page
private void TransformImage(PdfPageBase page)
{
    // Load an image from file
    PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\ChartImage.png");

    // Define the skew angles and scaling factors
    int skewX = 20;
    int skewY = 20;
    float scaleX = 0.2f;
    float scaleY = 0.6f;

    // Calculate the transformed width and height of the image
    int width = (int)((image.Width + image.Height * Math.Tan(Math.PI * skewX / 180)) * scaleX);
    int height = (int)((image.Height + image.Width * Math.Tan(Math.PI * skewY / 180)) * scaleY);

    // Create a template with the transformed dimensions
    PdfTemplate template = new PdfTemplate(width, height);

    // Apply scale and skew transformations to the graphics of the template
    template.Graphics.ScaleTransform(scaleX, scaleY);
    template.Graphics.SkewTransform(skewX, skewY);

    // Draw the image onto the template
    template.Graphics.DrawImage(image, 0, 0);

    // Save the current graphics state
    PdfGraphicsState state = page.Canvas.Save();

    // Adjust the position and transparency for multiple repetitions of the template
    page.Canvas.TranslateTransform(page.Canvas.ClientSize.Width - 50, 260);
    float offset = (page.Canvas.ClientSize.Width - 100) / 12;

    // Repeat the template drawing with varying transparency levels
    for (int i = 0; i < 12; i++)
    {
        page.Canvas.TranslateTransform(-offset, 0);
        page.Canvas.SetTransparency(i / 12.0f);
        page.Canvas.DrawTemplate(template, new PointF(0, 0));
    }

    // Restore the graphics state to its original settings
    page.Canvas.Restore(state);
}
```

---

# spire.pdf csharp image extraction
## extract images from PDF document
```csharp
// Create a PDF document
PdfDocument doc = new PdfDocument();

// Load a file from disk
doc.LoadFromFile(@"..\..\..\..\..\..\Data\ExtractImges.pdf");

// Get the first page of the document
PdfPageBase page = doc.Pages[0];

// Create an instance of PdfImageHelper to work with images
PdfImageHelper imageHelper = new PdfImageHelper();

// Get information about the images on the page
PdfImageInfo[] imageInfos = imageHelper.GetImagesInfo(page);

// Extract images from the page
int index = 0;
foreach (PdfImageInfo info in imageInfos)
{
    // Save each image as a PNG file with a unique name
    info.Image.Save(string.Format("Image-{0}.png", index));
    index++;
}

// Dispose the PDF document to release resources
doc.Dispose();
```

---

# Spire.PDF Convert Page to EMF
## Convert a PDF page to EMF image format using Spire.PDF library
```csharp
//Open pdf document
PdfDocument pdf = new PdfDocument();

//Convert a particular page to emf
//Set page index
int pageIndex = 1;
//Save page to image in metafile type
using (Image image = pdf.SaveAsImage(pageIndex, PdfImageType.Metafile, 300, 300))
{
    // Save as EMF format
}

pdf.Close();
```

---

# spire.pdf csharp page to png conversion
## convert pdf page to png image
```csharp
//Open pdf document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile(file);

//Convert a particular page to png
//Set page index and image name
int pageIndex = 1;
String fileName = "PageToPNG.png";
//Save page to image
using (Image image = pdf.SaveAsImage(pageIndex, 300, 300))
{
    image.Save(fileName, ImageFormat.Png);
}

pdf.Close();
```

---

# Spire.PDF C# Convert PDF Page to TIFF
## Demonstrates how to convert a PDF page to TIFF image using Spire.PDF library
```csharp
//Open PDF document
PdfDocument pdf = new PdfDocument();
// inputFilePath: path to the input PDF file
pdf.LoadFromFile(inputFilePath);

//Convert a particular page to TIFF
// pageIndex: index of the page to convert (1-based)
int pageIndex = 1;
Image image = pdf.SaveAsImage(pageIndex);

//Save as TIFF with compression
ImageCodecInfo info = GetEncoderInfo("image/tiff");
EncoderParameters ep = new EncoderParameters(2);
ep.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
ep.Param[1] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionLZW);

// outputFilePath: path to save the output TIFF file
image.Save(outputFilePath, info, ep);

private static ImageCodecInfo GetEncoderInfo(string mimeType)
{
    //Get encoder information of all image types
    ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

    //Find the information of TIFF type
    for (int j = 0; j < encoders.Length; j++)
    {
        if (encoders[j].MimeType == mimeType)
            return encoders[j];
    }
    throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
}
```

---

# Spire.PDF C# Image Replacement
## Replace images in PDF documents using Spire.PDF library
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load file from disk.
doc.LoadFromFile("ReplaceImage.pdf");

//Get the first page.
PdfPageBase page = doc.Pages[0];

//Create PdfImageHelper object to get Image from page
PdfImageHelper helper = new PdfImageHelper();
Spire.Pdf.Utilities.PdfImageInfo[] images = helper.GetImagesInfo(page);

//Replace the first image on the page.
helper.ReplaceImage(images[0], PdfImage.FromFile("E-iceblueLogo.png"));

String result = "ReplaceImage_out.pdf";

//Save the document
doc.SaveToFile(result);
```

---

# spire.pdf csharp image replacement
## replace image in pdf document
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Get the first page
PdfPageBase page = doc.Pages[0];

//Get images of the first page
PdfImageInfo[] imageInfo = page.ImagesInfo;

//Replace the first image on the page
page.ReplaceImage(imageInfo[0].Image, PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png"));
```

---

# spire.pdf csharp image replacement
## replace image in pdf document
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load file from disk.
doc.LoadFromFile(@"..\..\..\..\..\..\Data\ReplaceImage.pdf");

//Get the first page.
PdfPageBase page = doc.Pages[0];

//Load a image
PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");

//Replace the first image on the page.
page.ReplaceImage(0, image);

String result = "Output.pdf";

//Save the document
doc.SaveToFile(result);
```

---

# Spire.PDF C# Image Replacement
## Replace images with text in PDF documents
```csharp
//Create PdfImageHelper object to get Images from page
PdfImageHelper helper = new PdfImageHelper();
Spire.Pdf.Utilities.PdfImageInfo[] images = helper.GetImagesInfo(page);

//Get width and height of image
float widthInPixel = images[0].Image.Width;
float heightInPixel = images[0].Image.Height;

//Convert unit from Pixel to Point
PdfUnitConvertor convertor = new PdfUnitConvertor();
float width = convertor.ConvertFromPixels(widthInPixel, PdfGraphicsUnit.Point);
float height = convertor.ConvertFromPixels(heightInPixel, PdfGraphicsUnit.Point);

//Get location of image
float xPos = images[0].Bounds.X;
float yPos = images[0].Bounds.Y;

//Remove the image
helper.DeleteImage(images[0]);

//Define a rectangle at the image location
RectangleF rect = new RectangleF(new PointF(xPos, yPos), new SizeF(width, height));

//Define string format for center alignment
PdfStringFormat format = new PdfStringFormat();
format.Alignment = PdfTextAlignment.Center;
format.LineAlignment = PdfVerticalAlignment.Middle;

//Draw a string at the location of the image
page.Canvas.DrawString("ReplacedText", new PdfFont(PdfFontFamily.Helvetica, 18f), PdfBrushes.Purple, rect, format);
```

---

# spire.pdf csharp image
## set image size in pdf document
```csharp
//Create a pdf document.
PdfDocument doc = new PdfDocument();

//Create one page
PdfPageBase page = doc.Pages.Add();

//Load an image
PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\ChartImage.png");

//Set the width and height of image
float width = image.Width * 0.75f;
float height = image.Height * 0.75f;

//Define a position to draw image
float x = (page.Canvas.ClientSize.Width - width) / 2;
float y = 60f;

//Draw image on page canvas
page.Canvas.DrawImage(image, x, y, width, height);
```

---

# spire.pdf csharp barcode generation
## create various types of barcodes in PDF document
```csharp
//Create a pdf document.
PdfDocument doc = new PdfDocument();

//Set the margin
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

//Add PdfSection and set layout for it
PdfSection section = doc.Sections.Add();
section.PageSettings.Margins = margin;
section.PageSettings.Size = PdfPageSize.A4;

//Create one page
PdfPageBase page = section.Pages.Add();
float y = 10;

//Create a font and set style for it 
PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Bold), true);

PdfTextWidget text = new PdfTextWidget();
text.Font = font1;
text.Text = "Codabar:";
PdfLayoutResult result = text.Draw(page, 0, y);
page = result.Page;
y = result.Bounds.Bottom + 2;

//Draw Codabar
PdfCodabarBarcode barcode1 = new PdfCodabarBarcode("00:12-3456/7890");
barcode1.BarcodeToTextGapHeight = 1f;
barcode1.TextDisplayLocation = TextLocation.Bottom;
barcode1.TextColor = Color.Blue;
barcode1.Draw(page, new PointF(0, y));
y = barcode1.Bounds.Bottom + 5;

//Draw Code11Barcode
text.Text = "Code11:";
result = text.Draw(page, 0, y);
page = result.Page;
y = result.Bounds.Bottom + 2;

PdfCode11Barcode barcode2 = new PdfCode11Barcode("123-4567890");
barcode2.BarcodeToTextGapHeight = 1f;
barcode2.TextDisplayLocation = TextLocation.Bottom;
barcode2.TextColor = Color.Blue;
barcode2.Draw(page, new PointF(0, y));
y = barcode2.Bounds.Bottom + 5;

//Draw Code128-A
text.Text = "Code128-A:";
result = text.Draw(page, 0, y);
page = result.Page;
y = result.Bounds.Bottom + 2;

//Create PdfCode128ABarcode object and set style for it
PdfCode128ABarcode barcode3 = new PdfCode128ABarcode("HELLO 00-123");
barcode3.BarcodeToTextGapHeight = 1f;
barcode3.TextDisplayLocation = TextLocation.Bottom;
barcode3.TextColor = Color.Blue;
barcode3.Draw(page, new PointF(0, y));
y = barcode3.Bounds.Bottom + 5;

//Draw Code128-B
text.Text = "Code128-B:";
result = text.Draw(page, 0, y);
page = result.Page;
y = result.Bounds.Bottom + 2;

//Create PdfCode128BBarcode object and set style for it
PdfCode128BBarcode barcode4 = new PdfCode128BBarcode("Hello 00-123");
barcode4.BarcodeToTextGapHeight = 1f;
barcode4.TextDisplayLocation = TextLocation.Bottom;
barcode4.TextColor = Color.Blue;
barcode4.Draw(page, new PointF(0, y));
y = barcode4.Bounds.Bottom + 5;

//Draw Code32
text.Text = "Code32:";
result = text.Draw(page, 0, y);
page = result.Page;
y = result.Bounds.Bottom + 2;

//Create PdfCode32Barcode object and set style for it
PdfCode32Barcode barcode5 = new PdfCode32Barcode("16273849");
barcode5.BarcodeToTextGapHeight = 1f;
barcode5.TextDisplayLocation = TextLocation.Bottom;
barcode5.TextColor = Color.Blue;
barcode5.Draw(page, new PointF(0, y));
y = barcode5.Bounds.Bottom + 5;

page = section.Pages.Add();
y = 10;

//Draw Code39
text.Text = "Code39:";
result = text.Draw(page, 0, y);
page = result.Page;
y = result.Bounds.Bottom + 2;

//Create PdfCode39Barcode object and set style for it
PdfCode39Barcode barcode6 = new PdfCode39Barcode("16-273849");
barcode6.BarcodeToTextGapHeight = 1f;
barcode6.TextDisplayLocation = TextLocation.Bottom;
barcode6.TextColor = Color.Blue;
barcode6.Draw(page, new PointF(0, y));
y = barcode6.Bounds.Bottom + 5;

//Draw Code39-E
text.Text = "Code39-E:";
result = text.Draw(page, 0, y);
page = result.Page;
y = result.Bounds.Bottom + 2;

//Create PdfCode39ExtendedBarcode object and set style for it
PdfCode39ExtendedBarcode barcode7 = new PdfCode39ExtendedBarcode("16-273849");
barcode7.BarcodeToTextGapHeight = 1f;
barcode7.TextDisplayLocation = TextLocation.Bottom;
barcode7.TextColor = Color.Blue;
barcode7.Draw(page, new PointF(0, y));
y = barcode7.Bounds.Bottom + 5;

//Draw Code93
text.Text = "Code93:";
result = text.Draw(page, 0, y);
page = result.Page;
y = result.Bounds.Bottom + 2;

//Create PdfCode93Barcode object and set style for it
PdfCode93Barcode barcode8 = new PdfCode93Barcode("16-273849");
barcode8.BarcodeToTextGapHeight = 1f;
barcode8.TextDisplayLocation = TextLocation.Bottom;
barcode8.TextColor = Color.Blue;
barcode8.QuietZone.Bottom = 5;
barcode8.Draw(page, new PointF(0, y));
y = barcode8.Bounds.Bottom + 5;

//Draw Code93-E
text.Text = "Code93-E:";
result = text.Draw(page, 0, y);
page = result.Page;
y = result.Bounds.Bottom + 2;

//Create PdfCode93ExtendedBarcode object and set style for it
PdfCode93ExtendedBarcode barcode9 = new PdfCode93ExtendedBarcode("16-273849");
barcode9.BarcodeToTextGapHeight = 1f;
barcode9.TextDisplayLocation = TextLocation.Bottom;
barcode9.TextColor = Color.Blue;
barcode9.Draw(page, new PointF(0, y));
```

---

# spire.pdf spot color drawing
## draw content using spot color with different tints
```csharp
//Initialize an instance of PdfSeparationColorSpace
PdfSeparationColorSpace cs = new PdfSeparationColorSpace("MySpotColor", Color.DarkViolet);

//Set tini = 1 for the cs
PdfSeparationColor color = new PdfSeparationColor(cs, 1f);

//Create a brush with spot color
PdfSolidBrush brush = new PdfSolidBrush(color);

//Draw a string
page.Canvas.DrawString("Tint=1.0", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(160, 160));

//Draw pie with spot color(DarkViolet)
page.Canvas.DrawPie(brush, 148, 200, 60, 60, 360, 360);

page.Canvas.DrawString("Tint=0.7", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(230, 160));
color = new PdfSeparationColor(cs, 0.7f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 218, 200, 60, 60, 360, 360);         

page.Canvas.DrawString("Tint=0.4", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(300, 160));
color = new PdfSeparationColor(cs, 0.4f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 288, 200, 60, 60, 360, 360);

page.Canvas.DrawString("Tint=0.1", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(370, 160));
color = new PdfSeparationColor(cs, 0.1f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 358, 200, 60, 60, 360, 360);

//Draw pie with spot color(Purple)
cs = new PdfSeparationColorSpace("MySpotColor", Color.Purple);
color = new PdfSeparationColor(cs, 1f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 148, 280, 60, 60, 360, 360);

color = new PdfSeparationColor(cs, 0.7f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 218, 280, 60, 60, 360, 360);

color = new PdfSeparationColor(cs, 0.4f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 288, 280, 60, 60, 360, 360);

color = new PdfSeparationColor(cs, 0.1f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 358, 280, 60, 60, 360, 360);

//Draw pie with spot color(DarkSlateBlue)
cs = new PdfSeparationColorSpace("MySpotColor", Color.DarkSlateBlue);
color = new PdfSeparationColor(cs, 1f);
brush = new PdfSolidBrush(color);

page.Canvas.DrawPie(brush, 148, 360, 60, 60, 360, 360);

color = new PdfSeparationColor(cs, 0.7f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 218, 360, 60, 60, 360, 360);

color = new PdfSeparationColor(cs, 0.4f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 288, 360, 60, 60, 360, 360);

color = new PdfSeparationColor(cs, 0.1f);
brush = new PdfSolidBrush(color);
page.Canvas.DrawPie(brush, 358, 360, 60, 60, 360, 360);
```

---

# spire.pdf csharp dashed line
## draw dashed line on pdf
```csharp
//Get the first page
PdfPageBase page = pdf.Pages[0];

//Save graphics state
PdfGraphicsState state = page.Canvas.Save();

//Set location and size for line
float x = 150;
float y = 200;
float width = 300;

//Create pens and set syle for it
PdfPen pen = new PdfPen(Color.Red, 3f);

//Set dash style and pattern
pen.DashStyle = PdfDashStyle.Dash;
pen.DashPattern = new float[] { 1, 4, 1 };

//Draw dashed lines
page.Canvas.DrawLine(pen, x, y, x + width, y);

//Restore graphics
page.Canvas.Restore(state);
```

---

# Spire.PDF C# Drawing Filled Rectangles
## Demonstrates how to draw filled rectangles on a PDF document
```csharp
//Get the first page
PdfPageBase page = pdf.Pages[0];

//save graphics state
PdfGraphicsState state = page.Canvas.Save();

//Set rectangle display location and size
int x = 200;
int y = 300;
int width = 200;
int height = 120;

//Create a pen and a brush
PdfPen pen = new PdfPen(Color.Black, 1f);
PdfBrush brush = new PdfSolidBrush(Color.OrangeRed);

//Draw a filled rectangle
page.Canvas.DrawRectangle(pen, brush, new Rectangle(new Point(x, y), new Size(width, height)));

//restore graphics
page.Canvas.Restore(state);
```

---

# Spire.PDF C# Line Drawing
## Draw lines and shapes on a PDF document
```csharp
//Save graphics state
PdfGraphicsState state = page.Canvas.Save();

//Set location and size
float x = 95;
float y = 95;
float width = 400;
float height = 500;

//Create pens
PdfPen pen = new PdfPen(Color.Black, 0.1f);
PdfPen pen1 = new PdfPen(Color.Red, 0.1f);

//Draw a rectangle
page.Canvas.DrawRectangle(pen, x, y, width, height);

//Draw two crossed lines
page.Canvas.DrawLine(pen1, x, y, x + width, y + height);
page.Canvas.DrawLine(pen1, x + width, y, x, y + height);

//Restore graphics
page.Canvas.Restore(state);
```

---

# spire.pdf csharp rectangle drawing
## draw rectangles on pdf with different colors and styles
```csharp
// Save graphics state
PdfGraphicsState state = page.Canvas.Save();

// Set rectangle display location and size
int x = 130;
int y = 100;
int width = 300;
int height = 400;

// Draw rectangles
PdfPen pen = new PdfPen(Color.Black, 0.1f);
page.Canvas.DrawRectangle(pen, new Rectangle(new Point(x, y), new Size(width, height)));

y = y + height - 50;
width = 100;
height = 50;

// Initialize an instance of PdfSeparationColorSpace
PdfSeparationColorSpace cs = new PdfSeparationColorSpace("MyColor", Color.FromArgb(0, 100, 0, 0));
PdfPen pen1 = new PdfPen(Color.Red, 1f);

// Create a brush with spot color
PdfBrush brush = new PdfSolidBrush(new PdfSeparationColor(cs, 0.1f));

// Draw rectangles
page.Canvas.DrawRectangle(pen1, brush, new Rectangle(new Point(x, y), new Size(width, height)));

// Restore graphics
page.Canvas.Restore(state);
```

---

# spire.pdf csharp draw shapes
## Draw various shapes in a PDF document using Spire.PDF library
```csharp
private static void DrawPath(PdfPageBase page)
{
    // Define array to store point of line
    PointF[] points = new PointF[5];
    for (int i = 0; i < points.Length; i++)
    {
        float x = (float)Math.Cos(i * 2 * Math.PI / 5);
        float y = (float)Math.Sin(i * 2 * Math.PI / 5);
        points[i] = new PointF(x, y);
    }
    PdfPath path = new PdfPath();
    path.AddLine(points[2], points[0]);
    path.AddLine(points[0], points[3]);
    path.AddLine(points[3], points[1]);
    path.AddLine(points[1], points[4]);
    path.AddLine(points[4], points[2]);

    // Save graphics state
    PdfGraphicsState state = page.Canvas.Save();

    // Define a pen and set style for it
    PdfPen pen = new PdfPen(Color.DeepSkyBlue, 0.02f);
    PdfBrush brush1 = new PdfSolidBrush(Color.CadetBlue);

    // Apply scale and TranslateTransform to the graphics
    page.Canvas.ScaleTransform(50f, 50f);
    page.Canvas.TranslateTransform(5f, 1.2f);

    // Draw line
    page.Canvas.DrawPath(pen, path);

    page.Canvas.TranslateTransform(2f, 0f);
    path.FillMode = PdfFillMode.Alternate;
    page.Canvas.DrawPath(pen, brush1, path);

    page.Canvas.TranslateTransform(2f, 0f);
    path.FillMode = PdfFillMode.Winding;
    page.Canvas.DrawPath(pen, brush1, path);

    PdfLinearGradientBrush brush2 = new PdfLinearGradientBrush(new PointF(-2, 0), new PointF(2, 0), Color.Red, Color.Blue);
    page.Canvas.TranslateTransform(-4f, 2f);
    path.FillMode = PdfFillMode.Alternate;
    page.Canvas.DrawPath(pen, brush2, path);

    PdfRadialGradientBrush brush3 = new PdfRadialGradientBrush(new PointF(0f, 0f), 0f, new PointF(0f, 0f), 1f, Color.Red, Color.Blue);
    page.Canvas.TranslateTransform(2f, 0f);
    path.FillMode = PdfFillMode.Winding;
    page.Canvas.DrawPath(pen, brush3, path);

    PdfTilingBrush brush4 = new PdfTilingBrush(new RectangleF(0, 0, 4f, 4f));
    brush4.Graphics.DrawRectangle(brush2, 0, 0, 4f, 4f);

    page.Canvas.TranslateTransform(2f, 0f);
    path.FillMode = PdfFillMode.Winding;
    page.Canvas.DrawPath(pen, brush4, path);

    // Restore graphics
    page.Canvas.Restore(state);
}

private static void DrawSpiro(PdfPageBase page)
{
    // Save graphics state
    PdfGraphicsState state = page.Canvas.Save();

    // Draw shape - Spiro
    PdfPen pen = PdfPens.DeepSkyBlue;

    int nPoints = 1000;
    double r1 = 30;
    double r2 = 25;
    double p = 35;
    double x1 = r1 + r2 - p;
    double y1 = 0;
    double x2 = 0;
    double y2 = 0;

    page.Canvas.TranslateTransform(100, 100);

    for (int i = 0; i < nPoints; i++)
    {
        double t = i * Math.PI / 90;
        x2 = (r1 + r2) * Math.Cos(t) - p * Math.Cos((r1 + r2) * t / r2);
        y2 = (r1 + r2) * Math.Sin(t) - p * Math.Sin((r1 + r2) * t / r2);
        page.Canvas.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
        x1 = x2;
        y1 = y2;
    }

    // Restore graphics
    page.Canvas.Restore(state);
}

private static void DrawRectangle(PdfPageBase page)
{
    // Save graphics state
    PdfGraphicsState state = page.Canvas.Save();

    // Draw a pen and set Style for it
    PdfPen pen = new PdfPen(System.Drawing.Color.Chocolate, 1f);

    // Draw rectangle
    page.Canvas.DrawRectangle(pen, new System.Drawing.Rectangle(new System.Drawing.Point(20, 310), new System.Drawing.Size(150, 120)));

    // Restore graphics
    page.Canvas.Restore(state);
}

private static void DrawPie(PdfPageBase page)
{
    // Save graphics state
    PdfGraphicsState state = page.Canvas.Save();

    PdfPen pen = new PdfPen(System.Drawing.Color.DarkRed, 2f);

    // Draw pie
    page.Canvas.DrawPie(pen, 220, 320, 100, 90, 360, 360);

    // Restore graphics
    page.Canvas.Restore(state);
}

private static void DrawEllipse(PdfPageBase page)
{
    // Save graphics state
    PdfGraphicsState state = page.Canvas.Save();

    PdfBrush brush = new PdfSolidBrush(System.Drawing.Color.CadetBlue);

    // Draw ellipse
    page.Canvas.DrawEllipse(brush, 380, 325, 80, 80);

    // Restore graphics
    page.Canvas.Restore(state);
}
```

---

# spire.pdf csharp gradient shapes
## draw shapes with gradient fill in PDF
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Create one page
PdfPageBase page = doc.Pages.Add();

//Create a PdfLinearGradientBrush and set style for it
PdfLinearGradientBrush brush1 = new PdfLinearGradientBrush(new Rectangle(new Point(100, 100), new Size(200, 120)), Color.BlueViolet, Color.DarkBlue, PdfLinearGradientMode.Horizontal);

//Draw a rectangle
page.Canvas.DrawRectangle(brush1, new Rectangle(new Point(100, 100), new Size(200, 120)));

//Create a PdfRadialGradientBrush and set style for it
PdfRadialGradientBrush brush2 = new PdfRadialGradientBrush(new PointF(200f, 400f), 100f, new PointF(300f, 500f), 100f, Color.SkyBlue, Color.DarkBlue);

//Draw a ellipse
page.Canvas.DrawEllipse(brush2, new Rectangle(new Point(100, 300), new Size(200, 200)));
```

---

# spire.pdf csharp list
## create and format different types of lists in PDF document
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Create Margin
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

//Create one page and set margin for it
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

float y = 10;

//Title
PdfBrush brush1 = PdfBrushes.Black;

//Create a font and set style for it
PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold), true);

//Create a PdfStringFormat object to define a string format
PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);

//Draw text
page.Canvas.DrawString("Categories List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
y = y + font1.MeasureString("Categories List", format1).Height;
y = y + 5;

//Define a rectangle
RectangleF rctg = new RectangleF(new PointF(0, 0), page.Canvas.ClientSize);
PdfLinearGradientBrush brush = new PdfLinearGradientBrush(rctg, Color.Navy, Color.OrangeRed, PdfLinearGradientMode.Vertical);
PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);
String formatted = "Beverages\nCondiments\nConfections\nDairy Products\nGrains/Cereals\nMeat/Poultry\nProduce\nSeafood";

//Create a list
PdfList list = new PdfList(formatted);
list.Font = font;
list.Indent = 8;
list.TextIndent = 5;
list.Brush = brush;

//Draw the list on the page
PdfLayoutResult result = list.Draw(page, 0, y);
y = result.Bounds.Bottom;

//Create another list
PdfSortedList sortedList = new PdfSortedList(formatted);
sortedList.Font = font;
sortedList.Indent = 8;
sortedList.TextIndent = 5;
sortedList.Brush = brush;

//Draw the list on the page
PdfLayoutResult result2 = sortedList.Draw(page, 0, y);

y = result2.Bounds.Bottom;
PdfOrderedMarker marker1 = new PdfOrderedMarker(PdfNumberStyle.LowerRoman, new PdfFont(PdfFontFamily.Helvetica, 12f));

//Create PdfSortedList object to set style for list
PdfSortedList list2 = new PdfSortedList(formatted);
list2.Font = font;
list2.Marker = marker1;
list2.Indent = 8;
list2.TextIndent = 5;
list2.Brush = brush;
//Draw list
PdfLayoutResult result3 = list2.Draw(page, 0, y);
y = result3.Bounds.Bottom;

PdfOrderedMarker marker2 = new PdfOrderedMarker(PdfNumberStyle.LowerLatin, new PdfFont(PdfFontFamily.Helvetica, 12f));

//Create PdfSortedList object to set style for list
PdfSortedList list3 = new PdfSortedList(formatted);
list3.Font = font;
list3.Marker = marker2;
list3.Indent = 8;
list3.TextIndent = 5;
list3.Brush = brush;
//Draw list
list3.Draw(page, 0, y);
```

---

# spire.pdf csharp overlay
## overlay two pdf documents with transparency
```csharp
//Create page template from the first page of doc1
PdfTemplate template = doc1.Pages[0].CreateTemplate();

//Iterate each page in doc2
foreach (PdfPageBase page in doc2.Pages)
{
    //Set transparency for page 
    page.Canvas.SetTransparency(0.25f, 0.25f, PdfBlendMode.Overlay);

    //Draw template
    page.Canvas.DrawTemplate(template, PointF.Empty);
}
```

---

# spire.pdf transparency
## set transparency for rectangles in pdf
```csharp
//Get the first page
PdfPageBase page = pdf.Pages[0];

//Save graphics state
PdfGraphicsState state = page.Canvas.Save();

//Draw rectangles
int x = 200;
int y = 300;
int width = 200;
int height = 100;
PdfPen pen = new PdfPen(Color.Black, 1f);
PdfBrush brush = new PdfSolidBrush(Color.Red);
PdfBlendMode mode = new PdfBlendMode();

//Set transparency for page 
page.Canvas.SetTransparency(0.5f, 0.5f, mode);

//Draw rectangle
page.Canvas.DrawRectangle(pen, brush, new Rectangle(new Point(x, y), new Size(width, height)));

x = x + width / 2;
y = y - height / 2;

//Set transparency for page 
page.Canvas.SetTransparency(0.2f, 0.2f, mode);

//Draw rectangle
page.Canvas.DrawRectangle(pen, brush, new Rectangle(new Point(x, y), new Size(width, height)));

//Restore graphics
page.Canvas.Restore(state);
```

---

# spire.pdf separation color space
## create and use separation color space with different tints in pdf
```csharp
// Create a pdf document
PdfDocument pdf = new PdfDocument();

// Add page
PdfPageBase page = pdf.Pages.Add();

// Initialize an instance of PdfSeparationColorSpace with RGB color
PdfRGBColor c = Color.Purple;
PdfSeparationColorSpace rgb = new PdfSeparationColorSpace("MySpotColor", new PdfRGBColor(c.R, c.G, c.B));

// Set tint = 1 for the color space
PdfSeparationColor color = new PdfSeparationColor(rgb, 1f);

// Create a brush with spot color
PdfSolidBrush brush = new PdfSolidBrush(color);

// Draw pie with tint=1.0
page.Canvas.DrawPie(brush, 10, 30, 60, 60, 360, 360);
page.Canvas.DrawString("Tint=1.0", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(22, 100));

// Change tint to 0.5
color = new PdfSeparationColor(rgb, 0.5f);
brush = new PdfSolidBrush(color);

// Draw pie with tint=0.5
page.Canvas.DrawPie(brush, 80, 30, 60, 60, 360, 360);
page.Canvas.DrawString("Tint=0.5", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(92, 100));

// Change tint to 0.25
color = new PdfSeparationColor(rgb, 0.25f);
brush = new PdfSolidBrush(color);

// Draw pie with tint=0.25
page.Canvas.DrawPie(brush, 150, 30, 60, 60, 360, 360);
page.Canvas.DrawString("Tint=0.25", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(162, 100));
```

---

# spire.pdf csharp transparency
## create PDF with transparency effects using different blend modes
```csharp
// Create a pdf document
PdfDocument doc = new PdfDocument();
PdfSection section = doc.Sections.Add();

// Iterate through each blend mode
foreach (PdfBlendMode mode in Enum.GetValues(typeof(PdfBlendMode)))
{
    // Add a page
    PdfPageBase page = section.Pages.Add();
    
    // Draw base image
    page.Canvas.DrawImage(image, 0, y, imageWidth, imageHeight);
    page.Canvas.Save();
    
    // Draw images with varying transparency
    for (int i = 0; i < 5; i++)
    {
        float alpha = 1.0f / 6 * (5 - i);

        // Set transparency for page
        page.Canvas.SetTransparency(alpha, alpha, mode);
        
        // Draw image with transparency
        page.Canvas.DrawImage(image, x, y, imageWidth, imageHeight);
    }
    
    page.Canvas.Restore();
}
```

---

# Spire.PDF C# Continuous Tables
## Add continuous tables to a PDF document with custom styling
```csharp
//Create a Pdf document
PdfDocument doc = new PdfDocument();

//Add a Pdf page
PdfPageBase page = doc.Pages.Add();

float y = 20;

//Draw the table 1
string title1 = "Table 1";
PdfLayoutResult result = DrawPDFTable(title1, y, page);

//Get the current Y coordinate and page
y = result.Bounds.Height+10;
page = result.Page;

//Draw the table 2
string title2 = "Table 2";
result = DrawPDFTable(title2, y, page);

private PdfLayoutResult DrawPDFTable(string title,float y, PdfPageBase page)
{
    //Draw Title
    PdfBrush brush = PdfBrushes.Black;
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);
    string title1 = title;

    //Draw text
    page.Canvas.DrawString(title1, font, brush, page.Canvas.ClientSize.Width / 2, y, format);

    //Measure the size of text to recalculate the y value
    y = y + font.MeasureString(title1, format).Height;
    y = y + 10;

    //Create PDF table and define table style
    PdfTable table = new PdfTable();

    //Set the cell padding
    table.Style.CellPadding = 3;
    table.Style.BorderPen = new PdfPen(brush, 0.75f);

    //Set default style for cell
    table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
    table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
    table.Style.DefaultStyle.StringFormat = format;

    //Set the odd row cell style
    table.Style.AlternateStyle = new PdfCellStyle();
    table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow;
    table.Style.AlternateStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
    table.Style.AlternateStyle.StringFormat = format;

    //Set the header row cell style
    table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;
    table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
    table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 14f, FontStyle.Bold));
    table.Style.HeaderStyle.StringFormat = format;
    table.Style.ShowHeader = true;

    //Draw the table on Pdf page
    PdfLayoutResult result = table.Draw(page, new PointF(0, y));

    return result;
}
```

---

# Spire.PDF C# Table with Image
## Add an image to a specific cell in a PDF table
```csharp
// Create a PDF document and page
PdfDocument doc = new PdfDocument();
PdfPageBase page = doc.Pages.Add();

// Create a table
PdfTable table = new PdfTable();
PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
table.Style.BorderPen = new PdfPen(brush, 0.5f);
table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
table.Style.HeaderSource = PdfHeaderSource.Rows;
table.Style.HeaderRowCount = 1;
table.Style.ShowHeader = true;
PdfTrueTypeFont fontHeader = new PdfTrueTypeFont(new Font("Arial", 14f));
table.Style.HeaderStyle.Font = fontHeader;
table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
PdfTrueTypeFont fontBody = new PdfTrueTypeFont(new Font("Arial", 12f));
table.Style.AlternateStyle.Font = fontBody;

// Set data source for table
table.DataSource = GetData();

// Configure column alignment
foreach (PdfColumn column in table.Columns)
{
    column.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
}

// Set up row height and cell layout for image
table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);
table.EndCellLayout += new EndCellLayoutEventHandler(table_EndCellLayout);

// Draw the table
table.Draw(page, new PointF(0, 100));

// Event handler for setting row height to accommodate image
void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
{
    if (args.RowIndex == 1)
    {
        // Load an image
        PdfImage image = PdfImage.FromFile("path_to_image.png");
        args.MinimalHeight = image.PhysicalDimension.Height + 4;
    }
}

// Event handler for drawing image in cell
void table_EndCellLayout(object sender, EndCellLayoutEventArgs args)
{
    if (args.RowIndex==1&&args.CellIndex == 1)
    {
        // Load an image
        PdfImage image = PdfImage.FromFile("path_to_image.png");
        float x = (args.Bounds.Width - image.PhysicalDimension.Width) / 2 + args.Bounds.X;
        float y = (args.Bounds.Height - image.PhysicalDimension.Height) / 2 + args.Bounds.Y;
        
        // Draw Image
        args.Graphics.DrawImage(image, x, y);
    }
}

// Get data for the table
private DataTable GetData()
{
    DataTable dt = new DataTable();
    dt.Columns.Add("column1", typeof(string));
    dt.Columns.Add("column2", typeof(string));
    DataRow row1 = dt.NewRow();
    DataRow row2 = dt.NewRow();
    row1[0] = "Column1";
    row1[1] = "Column2";
    row2[0] = "Insert an image in table cell";
    row2[1] = "";
    dt.Rows.Add(row1);
    dt.Rows.Add(row2);
    return dt;
}
```

---

# spire.pdf csharp table
## create PDF table with repeating header
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Set the margin and add a page
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

//Create data table
PdfTable table = new PdfTable();
table.Style.BorderPen = new PdfPen(PdfBrushes.Black, 0.5f);

//Header style
table.Style.HeaderSource = PdfHeaderSource.Rows;
table.Style.HeaderRowCount = 1;
table.Style.ShowHeader = true;
table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 14f, FontStyle.Bold));
table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

//Repeat header - this is the key feature
table.Style.RepeatHeader = true;

//Set default style for cell
table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));

//Set the odd row cell style
table.Style.AlternateStyle = new PdfCellStyle();
table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow;
table.Style.AlternateStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));

// Set data source for table
// table.DataSource = GetData();

//Iterate each column for table
foreach (PdfColumn column in table.Columns)
{
    // Set string format for the text in column
    column.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
}

//Set the row height
table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);

//Draw the table
table.Draw(page, new PointF(0, 10));

void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
{
    //Set the minimal height of the row
    args.MinimalHeight = 50f;
}
```

---

# Spire.PDF C# Table Border Color
## Change the border color of a PDF table

```csharp
//Create a grid
PdfGrid grid = new PdfGrid();

//Add rows and columns
for (int r = 0; r < 25; r++)
{
    PdfGridRow row = grid.Rows.Add();
}
grid.Columns.Add(5);

//Set the width for column
grid.Columns[0].Width = 120;
grid.Columns[1].Width = 120;
grid.Columns[2].Width = 120;
grid.Columns[3].Width = 50;
grid.Columns[4].Width = 60;

//set the height of rows
for (int i = 0; i < grid.Rows.Count; i++)
{
    grid.Rows[i].Height = 12.5f;
}

//Set color of border
PdfBorders border = new PdfBorders();
border.All = new PdfPen(Color.LightBlue);

//Apply border color to all cells
foreach (PdfGridRow pgr in grid.Rows)
{
    foreach (PdfGridCell pgc in pgr.Cells)
    {
        pgc.Style.Borders = border;
    }
}

//Draw the grid
grid.Draw(page, new PointF(50, 330));
```

---

# Spire.PDF C# Table with DataSource
## Create a PDF table with data from a database source
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Set the margin
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

//Create one page and set margin for it 
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

//Create data table
PdfTable table = new PdfTable();

//Set the cell padding
table.Style.CellPadding = 2;
table.Style.BorderPen = new PdfPen(PdfBrushes.Black, 0.75f);

//Set default style for cell
table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));

//Set the odd row cell style
table.Style.AlternateStyle = new PdfCellStyle();
table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow;
table.Style.AlternateStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));

//Set the header row cell style
table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;
table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold));
table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
table.Style.ShowHeader = true;

//Create OleDbConnection object to connect to data source
using (OleDbConnection conn = new OleDbConnection())
{
    conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb";
    OleDbCommand command = new OleDbCommand();
    command.CommandText = " select Name,Capital,Continent,Area,Population from country ";
    command.Connection = conn;
    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
    {
        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);
        table.DataSourceType = PdfTableDataSourceType.TableDirect;

        //Set data source for table
        table.DataSource = dataTable;
    }
}

float width = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width;
//Set width for column
table.Columns[0].Width = width * 0.24f * width;
table.Columns[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
table.Columns[1].Width = width * 0.21f * width;
table.Columns[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
table.Columns[2].Width = width * 0.24f * width;
table.Columns[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
table.Columns[3].Width = width * 0.13f * width;
table.Columns[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
table.Columns[4].Width = width * 0.18f * width;
table.Columns[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

//Draw table on the page
table.Draw(page, new PointF(0, 10));
```

---

# Spire.PDF C# Grid Embedding
## Embed a grid within a cell in a PDF document
```csharp
//Create a pdf grid
PdfGrid grid = new PdfGrid();

//Add a row 
PdfGridRow row = grid.Rows.Add();

//Add two columns
grid.Columns.Add(2);

//Set the width of the columns
grid.Columns[0].Width = 120;
grid.Columns[1].Width = 300;

//Set the cell padding
grid.Style.CellPadding = new PdfPaddings(25, 25, 1, 1);

//Create another grid to embed
PdfGrid grid2 = new PdfGrid();
grid2.Columns.Add(2);
PdfGridRow newrow = grid2.Rows.Add();
grid2.Columns[0].Width = 120;
grid2.Columns[1].Width = 120;

//Set value for newrow and set string format for it
newrow.Cells[0].Value = "Embeded grid";
newrow.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
newrow.Cells[1].Value = "Embeded grid";
newrow.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

//Assign grid2 to the cell
row.Cells[1].Value = grid2;
row.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
```

---

# Spire.PDF Table Extraction
## Extract tables from PDF documents and retrieve text from each cell
```csharp
// Create PdfTableExtractor object to extract tables from PDF
PdfTableExtractor extractor = new PdfTableExtractor(pdf);
PdfTable[] tableLists = null;
StringBuilder builder = new StringBuilder();

// Iterate each page of PDF file
for (int pageIndex = 0; pageIndex < pdf.Pages.Count; pageIndex++)
{
    // Extract tables in each page
    tableLists = extractor.ExtractTable(pageIndex);

    if (tableLists != null && tableLists.Length > 0)
    {
        // Iterate each table from array
        foreach (PdfTable table in tableLists)
        {
            int row = table.GetRowCount();
            int column = table.GetColumnCount();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    // Extract the text in each cell
                    string text = table.GetText(i, j);

                    // Append the text into StringBuilder
                    builder.Append(text + " ");
                }

                builder.Append("\r\n");
            }
        }
    }
}
```

---

# Spire.PDF C# Grid Creation
## Create and customize a PDF grid with nested grid support
```csharp
//Create a grid
PdfGrid grid = new PdfGrid();

//Set the cell padding
grid.Style.CellPadding = new PdfPaddings(1, 1, 1, 1);

//Add columns to grid
int columnCount = 5;
grid.Columns.Add(columnCount);

//Set column width for grid
float width = page.Canvas.ClientSize.Width - (grid.Columns.Count + 1);
grid.Columns[0].Width = width * 0.25f;
grid.Columns[1].Width = width * 0.25f;
grid.Columns[2].Width = width * 0.25f;
grid.Columns[3].Width = width * 0.15f;
grid.Columns[4].Width = width * 0.10f;

//Set header style for grid
PdfGridRow headerRow = grid.Headers.Add(1)[0];
headerRow.Style.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold), true);
headerRow.Style.BackgroundBrush = new PdfLinearGradientBrush(new PointF(0, 0), new PointF(page.Canvas.ClientSize.Width, 0), Color.Red, Color.Blue);

//Set header cell values and styles
String[] headers = { "VendorName", "Address1", "City", "State", "Country" };
for (int i = 0; i < headers.Length; i++)
{
    //Set value for header cell
    headerRow.Cells[i].Value = headers[i];

    //Set string format for header cell
    headerRow.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
    if (i == 0)
    {
        headerRow.Cells[i].Style.BackgroundBrush = PdfBrushes.Gray;
    }
}

//Add rows to grid
Random random = new Random();
for (int r = 0; r < 5; r++)
{
    PdfGridRow row = grid.Rows.Add();
    row.Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f), true);
    
    //Set background brush with gradient
    byte[] buffer = new byte[6];
    random.NextBytes(buffer);
    PdfRGBColor color1 = new PdfRGBColor(buffer[0], buffer[1], buffer[2]);
    PdfRGBColor color2 = new PdfRGBColor(buffer[3], buffer[4], buffer[5]);
    row.Style.BackgroundBrush = new PdfLinearGradientBrush(new PointF(0, 0), new PointF(page.Canvas.ClientSize.Width, 0), color1, color2);
    
    //Set cell values and styles
    for (int c = 0; c < columnCount; c++)
    {
        row.Cells[c].Value = "Data " + r + "-" + c;
        if (c == 0)
        {
            //Set back color for cell
            row.Cells[c].Style.BackgroundBrush = PdfBrushes.Gray;
        }
        if (c < 3)
        {
            //Set string format for cell
            row.Cells[c].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
        }
        else
        {
            //Set string format for cell
            row.Cells[c].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
        }
    }
}

//Add a total amount row
PdfGridRow totalAmountRow = grid.Rows.Add();
totalAmountRow.Style.BackgroundBrush = PdfBrushes.Plum;
totalAmountRow.Cells[0].Value = "Total Amount";
totalAmountRow.Cells[0].Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold), true);
totalAmountRow.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
totalAmountRow.Cells[1].ColumnSpan = 4;
totalAmountRow.Cells[1].Value = "Summary data";
totalAmountRow.Cells[1].Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold | FontStyle.Italic), true);
totalAmountRow.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

//Create a nested grid
PdfGrid productList = new PdfGrid();
productList.Style.Font = new PdfTrueTypeFont(new Font("Arial", 8f), true);
productList.Columns.Add(1);
for (int i = 0; i < 3; i++)
{
    PdfGridRow row = productList.Rows.Add();
    row.Cells[0].Value = "Product " + i;
}
productList.Headers[0].Cells[0].Value = "Product List";
productList.Headers[0].Cells[0].Style.Font = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Bold), true);
productList.Headers[0].Cells[0].Style.Borders.All = new PdfPen(new PdfTilingBrush(new SizeF(1, 1)), 0);

//Embed the nested grid into the cell of main grid
grid.Rows[0].Cells[0].Value = productList;
grid.Rows[0].Cells[0].StringFormat.Alignment = PdfTextAlignment.Left;

//Draw the grid on the page
PdfLayoutResult result = grid.Draw(page, new PointF(0, y));
```

---

# spire.pdf csharp table with images
## create PDF table with images
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Set the margin
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

//Create one page and set margin for it
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

float y = 10;

//Title
PdfBrush brush1 = PdfBrushes.Black;
PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
y = y + font1.MeasureString("Country List", format1).Height;
y = y + 5;

//Create data table
PdfTable table = new PdfTable();

//Set the cell padding
table.Style.CellPadding = 2;
table.Style.BorderPen = new PdfPen(brush1, 0.75f);

//Set default style for cell
table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));

//Set the cell style for odd row 
table.Style.AlternateStyle = new PdfCellStyle();
table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow;
table.Style.AlternateStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));

//Set the cell style for header row 
table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;
table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold));
table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
table.Style.ShowHeader = true;

float width = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width;

//Set width for column
table.Columns[0].Width = width * 0.21f;

//Set string format for cell of column
table.Columns[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
table.Columns[1].Width = width * 0.10f;
table.Columns[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
table.Columns[2].Width = width * 0.19f;
table.Columns[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
table.Columns[3].Width = width * 0.21f;
table.Columns[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
table.Columns[4].Width = width * 0.12f;
table.Columns[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
table.Columns[5].Width = width * 0.17f;
table.Columns[5].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);
table.EndCellLayout += new EndCellLayoutEventHandler(table_EndCellLayout);

PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
tableLayout.Break = PdfLayoutBreakType.FitElement;
tableLayout.Layout = PdfLayoutType.Paginate;
tableLayout.EndColumnIndex = table.Columns.Count - 2 - 1;

PdfLayoutResult result = table.Draw(page, new PointF(0, y), tableLayout);
y = y + result.Bounds.Height + 5;

PdfBrush brush2 = PdfBrushes.Gray;
PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
page.Canvas.DrawString(String.Format("* {0} countries in the list.", table.Rows.Count), font2, brush2, 5, y);

void table_EndCellLayout(object sender, EndCellLayoutEventArgs args)
{
    if (args.RowIndex < 0)
    {
        //Header
        return;
    }
    if (args.CellIndex == 1)
    {
        DataTable dataTable = (sender as PdfTable).DataSource as DataTable;
        PdfImage image = dataTable.Rows[args.RowIndex][7] as PdfImage;
        float x = (args.Bounds.Width - image.PhysicalDimension.Width) / 2 + args.Bounds.X;
        float y = (args.Bounds.Height - image.PhysicalDimension.Height) / 2 + args.Bounds.Y;
        args.Graphics.DrawImage(image, x, y);
    }
}

void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
{
    if (args.RowIndex < 0)
    {
        //Header
        return;
    }
    DataTable dataTable = (sender as PdfTable).DataSource as DataTable;
    byte[] imageData = dataTable.Rows[args.RowIndex][6] as byte[];
    using (MemoryStream stream = new MemoryStream(imageData))
    {
        PdfImage image = PdfImage.FromStream(stream);
        args.MinimalHeight = 4 + image.PhysicalDimension.Height;
        dataTable.Rows[args.RowIndex][7] = image;
    }            
}
```

---

# spire.pdf csharp page break
## insert page break in pdf table
```csharp
//Create a Pdf document
PdfDocument doc = new PdfDocument();

//Add a page
PdfPageBase page = doc.Pages.Add();

float y = 10;

//Title
PdfBrush brush1 = PdfBrushes.Black;
PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
y = y + font1.MeasureString("Country List", format1).Height;
y = y + 5;

//Create a table
PdfTable table = new PdfTable();
table.Style.BorderPen = new PdfPen(brush1, 0.5f);

//Set the cell style for header row 
table.Style.HeaderSource = PdfHeaderSource.Rows;
table.Style.HeaderRowCount = 1;
table.Style.ShowHeader = true;
table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 14f, FontStyle.Bold));
table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

//Repeat header
table.Style.RepeatHeader = true;

//Set default style for cell
table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
table.Style.DefaultStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

//Set the cell style for odd row
table.Style.AlternateStyle = new PdfCellStyle();
table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow;
table.Style.AlternateStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
table.Style.AlternateStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

//Set data source for table
table.DataSource = GetData();

//Set the Pdf table layout and specify the paginate bounds
PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
tableLayout.Break = PdfLayoutBreakType.FitElement;
tableLayout.Layout = PdfLayoutType.Paginate;
tableLayout.PaginateBounds = new RectangleF(0, y, page.ActualSize.Width - 100, page.ActualSize.Height / 3);

//Set the row height
table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);

//Drow the table in page
PdfLayoutResult result = table.Draw(page, new PointF(0, y), tableLayout);

void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
{
    args.MinimalHeight = 50f;
}
```

---

# Spire.PDF C# Table Cell Merging
## Demonstrates how to merge cells in a PDF table using Spire.PDF library
```csharp
//Create a grid
PdfGrid grid = new PdfGrid();
grid.Columns.Add(5);

//Iterate each column of grid
for (int j = 0; j < grid.Columns.Count; j++)
{
    //Set width of column
    grid.Columns[j].Width = 100;
}

//Add rows
PdfGridRow row0 = grid.Rows.Add();
PdfGridRow row1 = grid.Rows.Add();
float height = 21.0f;

//Iterate each row of grid
for (int i = 0; i < grid.Rows.Count; i++)
{
    //Set the height for row 
    grid.Rows[i].Height = height;
}

// Draw the grid on the page at the specified location
grid.Draw(page, new PointF(50, 410));

// Set font styles for specific rows and cells
row0.Style.Font = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold), true);
row1.Style.Font = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Italic), true);

row0.Cells[0].Value = "Corporation";

// Merge two rows
row0.Cells[0].RowSpan = 2;

row0.Cells[1].Value = "B&K Undersea Photo";
row0.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

// Merge two columns
row0.Cells[1].ColumnSpan = 3;

// Set value for cell and set style for it
row0.Cells[4].Value = "World";
row0.Cells[4].Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold | FontStyle.Italic), true);
row0.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
row0.Cells[4].Style.BackgroundBrush = PdfBrushes.LightGreen;

row1.Cells[1].Value = "Diving International Unlimited";
row1.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

// Merge four columns
row1.Cells[1].ColumnSpan = 4;

// Draw the updated grid on the page at a different location
grid.Draw(page, new PointF(50, 480));
```

---

# spire.pdf csharp grid
## create PDF grid without borders
```csharp
// Create a new grid
PdfGrid grid = new PdfGrid();

// Add a row to the grid
PdfGridRow row1 = grid.Rows.Add();

// Add 2 columns to the grid
grid.Columns.Add(2);

// Set border dash style for specific cell in the row
row1.Cells[0].Style.Borders.Bottom.DashStyle = PdfDashStyle.None;
row1.Cells[0].Style.Borders.Top.DashStyle = PdfDashStyle.None;
row1.Cells[0].Style.Borders.Right.DashStyle = PdfDashStyle.None;
row1.Cells[0].Style.Borders.Left.DashStyle = PdfDashStyle.None;

// Set cell values in the row
string str = "Hello Word!";
for (int i = 0; i < grid.Columns.Count; i++)
{
    row1.Cells[i].Value = str;
}

// Draw the grid on the page at the specified position
grid.Draw(page, new PointF(0, 50));
```

---

# Spire.PDF C# Table Cell Padding
## Set padding for table cells in a PDF grid
```csharp
// Create a new grid
PdfGrid grid = new PdfGrid();

// Set the cell padding for the grid
grid.Style.CellPadding = new PdfPaddings(10, 10, 10, 10);

// Fill the grid with data from a data source
grid.DataSource = GetData();

// Set text alignment and vertical alignment for each cell in the grid
foreach (PdfGridRow row in grid.Rows)
{
    foreach (PdfGridCell cell in row.Cells)
    {
        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
    }
}

// Draw the grid on the page at position (0, 0)
grid.Draw(page, new PointF(0, 0));
```

---

# spire.pdf csharp table
## create a simple table in PDF document
```csharp
// Add title to the page
PdfBrush brush1 = PdfBrushes.Black;
PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
y = y + font1.MeasureString("Country List", format1).Height;
y = y + 5;

// Create a new table and set its style
PdfTable table = new PdfTable();
table.Style.CellPadding = 2;
table.Style.HeaderSource = PdfHeaderSource.Rows;
table.Style.HeaderRowCount = 1;
table.Style.ShowHeader = true;

// Specify the data source for table
table.DataSource = dataSource;

// Draw the table on the page
PdfLayoutResult result = table.Draw(page, new PointF(60, y));
y = y + result.Bounds.Height + 5;

// Add a note about the number of countries in the list
PdfBrush brush2 = PdfBrushes.Gray;
PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
page.Canvas.DrawString(String.Format("* {0} countries in the list.", data.Length - 1), font2, brush2, 65, y);
```

---

# spire.pdf csharp table border
## create a PDF table with custom borders
```csharp
// Create a new PDF table
PdfTable table = new PdfTable();

// Set the color and style of the table border
PdfTableStyle style = new PdfTableStyle();
style.CellPadding = 2;
style.BorderPen = new PdfPen(Color.Gray, 1f);
table.Style = style;

// Add a custom method to the BeginRowLayout event
table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);

// Draw the PDF table onto the PDF document at a specific position
table.Draw(page, new PointF(60, 320));

private void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
{
    // Set the color and style of the table cell border
    PdfCellStyle cellStyle = new PdfCellStyle();
    cellStyle.BorderPen = new PdfPen(Color.LightBlue, 0.9f);
    args.CellStyle = cellStyle;
}
```

---

# Spire.PDF C# Table Layout
## Create and layout a table in PDF document with custom styles and formatting
```csharp
// Create a data table for the PDF
PdfTable table = new PdfTable();

//Set the cell padding
table.Style.CellPadding = 1;
table.Style.BorderPen = new PdfPen(PdfBrushes.Black, 0.75f);

//Set default style for cell
table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f), true);

//Set the cell style for header row 
table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;
table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold), true);
table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);

table.Style.ShowHeader = true;
table.Style.RepeatHeader = true;

// Set the column widths and string formats for the table
float width = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width;
for (int i = 0; i < table.Columns.Count; i++)
{
    if (i == 1)
    {
        // Set the width and alignment for the second column
        table.Columns[i].Width = width * 0.4f * width;
        table.Columns[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
    }
    else
    {
        // Set the width and alignment for other columns
        table.Columns[i].Width = width * 0.12f * width;
        table.Columns[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
    }
}

// Add a custom method to the BeginRowLayout event
table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);

// Draw the table on the page with specified layout format
PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
tableLayout.Break = PdfLayoutBreakType.FitElement;
tableLayout.Layout = PdfLayoutType.Paginate;
PdfLayoutResult result = table.Draw(page, new PointF(0, y), tableLayout);

// Event handler for BeginRowLayout
void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
{
    if (args.RowIndex < 0)
    {
        //Header
        return;
    }
    if (args.RowIndex % 3 == 0)
    {
        //Set the background color
        args.CellStyle.BackgroundBrush = PdfBrushes.LightYellow;
    }
    else
    {
        args.CellStyle.BackgroundBrush = PdfBrushes.SkyBlue;
    }
}
```

---

# spire.pdf csharp annotation
## add free text annotation to pdf
```csharp
// Define a rectangle for the free text annotation
RectangleF rect = new RectangleF(0, 300, 100, 80);

// Create a free text annotation and set its properties
PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(rect);
textAnnotation.Text = "\n  Spire.PDF";

// Set border style for annotation
PdfAnnotationBorder border = new PdfAnnotationBorder(1f);
textAnnotation.Border = border;
textAnnotation.BorderColor = Color.Gray;
textAnnotation.LineEndingStyle = PdfLineEndingStyle.Slash;

//Set font for annotation
PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 20);
textAnnotation.Font = font;

//Set color for text annotation
textAnnotation.Color = Color.LightBlue;
textAnnotation.Opacity = 0.8f;

// Add the free text annotation to the page
page.Annotations.Add(textAnnotation);
```

---

# Spire.PDF C# Ink Annotation
## Create and add an ink annotation to a PDF page
```csharp
// Create a PDF document
PdfDocument pdf = new PdfDocument();

// Add a page to the document
PdfPageBase pdfPage = pdf.Pages.Add();

// Define the points for the ink annotation
System.Collections.Generic.List<int[]> inkList = new System.Collections.Generic.List<int[]>();
int[] intPoints = new int[]
{
    100, 800,
    200, 800,
    200, 700
};
inkList.Add(intPoints);

// Create an ink annotation using the defined points
PdfInkAnnotation ia = new PdfInkAnnotation(inkList);

// Set properties of the ink annotation such as color, border width, opacity, and text
ia.Color = Color.Pink;
ia.Border.Width = 12;
ia.Opacity = 0.3f;
ia.Text = "e-iceblue";

// Add the ink annotation to the page's annotation widget collection
pdfPage.Annotations.Add(ia);
```

---

# spire.pdf csharp annotations
## create various types of annotations in pdf document
```csharp
// Add a document link annotation to the page
private float AddDocumentLinkAnnotation(PdfPageBase page, float y)
{
    // Set up font and formatting
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
    PdfStringFormat format = new PdfStringFormat();
    format.MeasureTrailingSpaces = true;

    String prompt = "Document Link: ";
    SizeF size = font.MeasureString(prompt);

    // Draw the prompt text
    page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
    float x = font.MeasureString(prompt, format).Width;

    // Set up the destination for the link annotation
    PdfDestination dest = new PdfDestination(page);
    dest.Mode = PdfDestinationMode.Location;
    dest.Location = new PointF(0, y);
    dest.Zoom = 2f;

    String label = "Click me, Zoom 200%";
    size = font.MeasureString(label);

    // Draw the label text
    RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
    page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

    // Create a document link annotation and set its properties
    PdfDocumentLinkAnnotation annotation = new PdfDocumentLinkAnnotation(bounds, dest);
    annotation.Color = Color.Blue;

    // Add the annotation to the page's annotation collection
    (page as PdfNewPage).Annotations.Add(annotation);
    y = bounds.Bottom;

    return y;
}

// Add a file link annotation to the page
private float AddFileLinkAnnotation(PdfPageBase page, float y)
{
    // Set up font and formatting
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
    PdfStringFormat format = new PdfStringFormat();
    format.MeasureTrailingSpaces = true;

    // Draw the prompt text
    String prompt = "Launch File: ";
    SizeF size = font.MeasureString(prompt);
    page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
    float x = font.MeasureString(prompt, format).Width;

    // Draw the label text
    String label = @"Launch Notepad.exe";
    size = font.MeasureString(label);
    RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
    page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

    // Create a file link annotation and set its properties
    PdfFileLinkAnnotation annotation = new PdfFileLinkAnnotation(bounds, @"C:\Windows\Notepad.exe");
    annotation.Color = Color.Blue;

    // Add the annotation to the page's annotation collection
    (page as PdfNewPage).Annotations.Add(annotation);
    y = bounds.Bottom;

    return y;
}

// Add a free text annotation to the page
private float AddFreeTextAnnotation(PdfPageBase page, float y)
{
    // Set up font and formatting
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
    PdfStringFormat format = new PdfStringFormat();
    format.MeasureTrailingSpaces = true;

    // Draw the prompt text
    String prompt = "Text Markup: ";
    SizeF size = font.MeasureString(prompt);
    page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
    float x = font.MeasureString(prompt, format).Width;

    // Draw the label text and bounding rectangle
    String label = @"I'm a text box, not a TV";
    size = font.MeasureString(label);
    RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
    page.Canvas.DrawRectangle(new PdfPen(Color.Blue, 0.1f), bounds);
    page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

    // Set up the free text annotation with its properties
    PointF location = new PointF(bounds.Right + 16, bounds.Top - 16);
    RectangleF annotaionBounds = new RectangleF(location, new SizeF(80, 32));
    PdfFreeTextAnnotation annotation = new PdfFreeTextAnnotation(annotaionBounds);
    annotation.AnnotationIntent = PdfAnnotationIntent.FreeTextCallout;
    annotation.Border = new PdfAnnotationBorder(0.5f);
    annotation.BorderColor = Color.Red;
    location = new PointF(bounds.Right + 16, bounds.Top - 16);
    annotation.CalloutLines = new PointF[] {
            new PointF(bounds.Right, bounds.Top),
            new PointF(bounds.Right+8, bounds.Top - 8),
            location
        };
    annotation.Color = Color.Yellow;
    annotation.Flags = PdfAnnotationFlags.Locked;
    annotation.Font = font;
    annotation.LineEndingStyle = PdfLineEndingStyle.OpenArrow;
    annotation.MarkupText = "Just a joke.";
    annotation.Opacity = 0.75f;
    annotation.TextMarkupColor = Color.Green;

    // Add the free text annotation to the page's annotation collection
    (page as PdfNewPage).Annotations.Add(annotation);
    y = bounds.Bottom;

    return y;
}

// Add a line annotation to the page
private float AddLineAnnotation(PdfPageBase page, float y)
{
    // Set up font and formatting
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
    PdfStringFormat format = new PdfStringFormat();
    format.MeasureTrailingSpaces = true;

    // Draw the prompt text
    String prompt = "Line Annotation: ";
    SizeF size = font.MeasureString(prompt);
    page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
    float x = font.MeasureString(prompt, format).Width;

    // Draw the label text and bounding rectangle
    String label = @"Line Annotation";
    size = font.MeasureString(label);
    page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
    RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
    int[] linePoints = new int[]
    {
         (int)bounds.Left, (int)bounds.Top, (int)bounds.Right, (int)bounds.Bottom
    };

    // Create a line annotation and set its properties
    PdfLineAnnotation annotation = new PdfLineAnnotation(linePoints, "Annotation");
    annotation.BeginLineStyle = PdfLineEndingStyle.ClosedArrow;
    annotation.EndLineStyle = PdfLineEndingStyle.ClosedArrow;
    annotation.LineCaption = true;
    annotation.BackColor = Color.Black;
    annotation.CaptionType = PdfLineCaptionType.Inline;

    // Add the line annotation to the page's annotation collection
    (page as PdfNewPage).Annotations.Add(annotation);
    y = bounds.Bottom;

    return y;
}

// Add a text markup annotation to the page
private float AddTextMarkupAnnotation(PdfPageBase page, float y)
{
    // Set up font and formatting
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
    PdfStringFormat format = new PdfStringFormat();
    format.MeasureTrailingSpaces = true;

    // Draw the prompt text
    String prompt = "Highlight incorrect spelling: ";
    SizeF size = font.MeasureString(prompt, format);
    page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
    float x = size.Width;

    // Draw the label text and bounding rectangle
    String label = "demo of anotation";
    page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
    size = font.MeasureString("demo of ", format);
    x = x + size.Width;
    PointF incorrectWordLocation = new PointF(x, y);
    String markupText = "Should be 'annotation'";

    // Create a text markup annotation and set its properties
    PdfTextMarkupAnnotation annotation = new PdfTextMarkupAnnotation(markupText, "anotation", new RectangleF(x, y, 100f, 100f), font);
    annotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight;
    annotation.TextMarkupColor = Color.LightSkyBlue;

    // Add the text markup annotation to the page's annotation collection
    (page as PdfNewPage).Annotations.Add(annotation);
    y = y + size.Height;

    return y;
}

// Add a popup annotation to the page
private float AddPopupAnnotation(PdfPageBase page, float y)
{
    // Set up font and formatting
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
    PdfStringFormat format = new PdfStringFormat();
    format.MeasureTrailingSpaces = true;

    // Draw the prompt text
    String prompt = "Markup incorrect spelling: ";
    SizeF size = font.MeasureString(prompt, format);
    page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
    float x = size.Width;

    // Draw the label text and bounding rectangle
    String label = "demo of annotation";
    page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
    x = x + font.MeasureString(label, format).Width;
    String markupText = "All words were spelled correctly";
    size = font.MeasureString(markupText);

    // Create a popup annotation and set its properties
    PdfPopupAnnotation annotation = new PdfPopupAnnotation(new RectangleF(new PointF(x, y), SizeF.Empty), markupText);
    annotation.Icon = PdfPopupIcon.Paragraph;
    annotation.Open = true;
    annotation.Color = Color.Yellow;

    // Add the popup annotation to the page's annotation collection
    (page as PdfNewPage).Annotations.Add(annotation);
    y = y + size.Height;

    return y;
}

// Add a rubber stamp annotation to the page
private float AddRubberStampAnnotation(PdfPageBase page, float y)
{
    // Set up font and formatting
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
    PdfStringFormat format = new PdfStringFormat();
    format.MeasureTrailingSpaces = true;

    // Draw the prompt text
    String prompt = "Markup incorrect spelling: ";
    SizeF size = font.MeasureString(prompt, format);
    page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
    float x = size.Width;

    // Draw the label text and bounding rectangle
    String label = "demo of annotation";
    page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
    x = x + font.MeasureString(label, format).Width;
    String markupText = "Just a draft, not checked.";
    size = font.MeasureString(markupText);

    // Create a rubber stamp annotation and set its properties
    PdfRubberStampAnnotation annotation = new PdfRubberStampAnnotation(new RectangleF(x, y, font.Height, font.Height), markupText);
    annotation.Icon = PdfRubberStampAnnotationIcon.Draft;
    annotation.Color = Color.Plum;

    // Add the rubber stamp annotation to the page's annotation collection
    (page as PdfNewPage).Annotations.Add(annotation);
    y = y + size.Height;

    return y;
}
```

---

# spire.pdf csharp 3d annotation
## create 3d annotation in pdf document
```csharp
//Create a new Pdf document.
PdfDocument doc = new PdfDocument();

//Add a new page to it.
PdfPageBase page = doc.Pages.Add();

//Draw a rectangle on the page to define the canvas area for the 3D file.
Rectangle rt = new Rectangle(0, 80, 200, 200);

//Initialize a new object of Pdf3DAnnotation, load the .u3d file as 3D annotation.
Pdf3DAnnotation annotation = new Pdf3DAnnotation(rt, @"..\..\..\..\..\..\Data\CreatePdf3DAnnotation.u3d");
annotation.Activation = new Pdf3DActivation();
annotation.Activation.ActivationMode = Pdf3DActivationMode.PageOpen;

//Define a 3D view mode and set its parameter
Pdf3DView View = new Pdf3DView();
View.Background = new Pdf3DBackground(new PdfRGBColor(Color.Purple));
View.ViewNodeName = "3DAnnotation";
View.RenderMode = new Pdf3DRendermode(Pdf3DRenderStyle.Solid);
View.InternalName = "3DAnnotation";
View.LightingScheme = new Pdf3DLighting();
View.LightingScheme.Style = Pdf3DLightingStyle.Day;

//Set the 3D view mode for the annotation.
annotation.Views.Add(View);

//Add the annotation to Pdf.
page.Annotations.Add(annotation);
```

---

# Spire.PDF CSharp Line Annotation
## Create PDF line annotations with different styles and properties
```csharp
//Create a PDF document.
PdfDocument document = new PdfDocument();

//Add a new page.
PdfPageBase page = document.Pages.Add();

//Create a line annotation.
int[] linePoints = new int[] { 100, 650, 180, 650 };
PdfLineAnnotation lineAnnotation = new PdfLineAnnotation(linePoints, "This is the first line annotation");

//Set the line border.
lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Solid;
lineAnnotation.lineBorder.BorderWidth = 1;

//Set the line intent.
lineAnnotation.LineIntent = PdfLineIntent.LineDimension;

//Set the line style.
lineAnnotation.BeginLineStyle = PdfLineEndingStyle.Butt;
lineAnnotation.EndLineStyle = PdfLineEndingStyle.Diamond;

//Set the line flag.
lineAnnotation.Flags = PdfAnnotationFlags.Default;

//Set the line color.
lineAnnotation.InnerLineColor = new PdfRGBColor(Color.Green);
lineAnnotation.BackColor = new PdfRGBColor(Color.Green);

//Set the leader line.
lineAnnotation.LeaderLineExt = 0;
lineAnnotation.LeaderLine = 0;

//Add the line annotation to the page.
page.Annotations.Add(lineAnnotation);

//Create another line annotation.
linePoints = new int[] { 100, 550, 280, 550 };
lineAnnotation = new PdfLineAnnotation(linePoints, "This is the second line annotation");
lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Underline;
lineAnnotation.lineBorder.BorderWidth = 2;
lineAnnotation.LineIntent = PdfLineIntent.LineArrow;
lineAnnotation.BeginLineStyle = PdfLineEndingStyle.Circle;
lineAnnotation.EndLineStyle = PdfLineEndingStyle.Diamond;
lineAnnotation.Flags = PdfAnnotationFlags.Default;
lineAnnotation.InnerLineColor = new PdfRGBColor(Color.Pink);
lineAnnotation.BackColor = new PdfRGBColor(Color.Pink);
lineAnnotation.LeaderLineExt = 0;
lineAnnotation.LeaderLine = 0;
page.Annotations.Add(lineAnnotation);

//Create yet another line annotation.
linePoints = new int[] { 100, 450, 280, 450 };
lineAnnotation = new PdfLineAnnotation(linePoints, "This is the third line annotation");
lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Beveled;
lineAnnotation.lineBorder.BorderWidth = 2;
lineAnnotation.LineIntent = PdfLineIntent.LineDimension;
lineAnnotation.BeginLineStyle = PdfLineEndingStyle.None;
lineAnnotation.EndLineStyle = PdfLineEndingStyle.None;
lineAnnotation.Flags = PdfAnnotationFlags.Default;
lineAnnotation.InnerLineColor = new PdfRGBColor(Color.Blue);
lineAnnotation.BackColor = new PdfRGBColor(Color.Blue);
lineAnnotation.LeaderLineExt = 1;
lineAnnotation.LeaderLine = 1;
page.Annotations.Add(lineAnnotation);
```

---

# Spire.PDF C# Link Annotation
## Create PDF link annotation with text
```csharp
//Declare two parameters that will be passed to the constructor of PdfFileLinkAnnotation class.
RectangleF rect = new RectangleF(0, 40, 250, 35);
string filePath = @"..\..\..\..\..\..\Data\Template_Pdf_3.pdf";

//Create a file link annotation based on the two parameters and add the annotation to the new page.
PdfFileLinkAnnotation link = new PdfFileLinkAnnotation(rect, filePath);
page.Annotations.Add(link);

//Create a free text annotation based on the same RectangleF, specifying the content.
PdfFreeTextAnnotation text = new PdfFreeTextAnnotation(rect);
text.Text = "Click here! This is a link annotation.";
PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 15);
text.Font = font;
page.Annotations.Add(text);
```

---

# Spire.PDF C# Polygon Annotation
## Create a polygon annotation in PDF document
```csharp
//Create a Pdf document.
PdfDocument pdf = new PdfDocument();

//Add a new page to it.
PdfPageBase page = pdf.Pages.Add();

//Initialize an instance of PdfPolygonAnnotation, specifying all vertex coordinates which can form a complete shape.
PdfPolygonAnnotation polygon = new PdfPolygonAnnotation(page, new PointF[] { new PointF(0, 30), new PointF(30, 15), new PointF(60, 30), new PointF(45, 50), new PointF(15, 50), new PointF(0, 30)});

//Set the border color, text, border effect and other properties of polygon annotation.
polygon.Color = Color.PaleVioletRed;
polygon.Text = "This is a polygon annotation";
polygon.Author = "E-ICEBLUE";
polygon.Subject = "polygon annotation demo";
polygon.BorderEffect = PdfBorderEffect.BigCloud;
polygon.ModifiedDate = DateTime.Now;

//Add the annotation to Pdf page.
page.Annotations.Add(polygon);
```

---

# Spire.PDF Polyline Annotation
## Create a polyline annotation in a PDF document
```csharp
//Create a pdf document
PdfDocument pdf = new PdfDocument();
//Add a new page
PdfPageBase page = pdf.Pages.Add();
//Create a polyline annotation
PdfPolyLineAnnotation polyline = new PdfPolyLineAnnotation(page, new PointF[] { new PointF(0, 60), new PointF(30, 45), new PointF(60, 90), new PointF(90, 80) });
//Set properties of polyline
polyline.Color = Color.PaleVioletRed;
polyline.Text = "This is a polygon annotation";
polyline.Author = "E-ICEBLUE";
polyline.Subject = "polygon annotation demo";
polyline.Name = "Test Annotation";
polyline.Border = new PdfAnnotationBorder(1f);
polyline.ModifiedDate = DateTime.Now;
//Add the annotation into page
page.Annotations.Add(polyline);
```

---

# spire.pdf csharp annotations
## delete all annotations from pdf document
```csharp
//Create a new PDF document
PdfDocument document = new PdfDocument();

//Load the PDF file
document.LoadFromFile("input.pdf");

//Remove all annotations from the first page
document.Pages[0].Annotations.Clear();

//Save the modified document
document.SaveToFile("output.pdf");
```

---

# Spire.PDF C# Annotation Management
## Delete annotation from PDF document
```csharp
//Open pdf document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

//Remove the first annotation
doc.Pages[0].Annotations.RemoveAt(0);

//Save pdf document
doc.SaveToFile(output);
```

---

# spire.pdf extract 3d video
## extract 3D video data from PDF annotations
```csharp
//Load PDF document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile("3D.pdf");

//Get the first page
PdfPageBase firstPage = pdf.Pages[0];

//Get the annotation collection of the first page
PdfAnnotationCollection annot = firstPage.Annotations;

//Traverse the annotations
for (int i = 0; i < annot.Count; i++)
{
    //If it is Pdf3DAnnotation
    if (annot[i] is Pdf3DAnnotation)
    {
        Pdf3DAnnotation annot3D = annot[i] as Pdf3DAnnotation;
        
        //Get the 3D video data
        byte[] bytes = annot3D._3DData;
        
        //Write the data into .u3d format file
        if (bytes != null)
        {
            File.WriteAllBytes(String.Format(@"3d-{0}.u3d", count), bytes);
            count++;
        }
    }
}
```

---

# spire.pdf csharp annotations
## extract all annotations from a pdf page
```csharp
//Create a new PDF document.
PdfDocument pdf = new PdfDocument();

//Load the file from disk.
pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_3.pdf");

//Get all annotations from the first page.
PdfAnnotationCollection annotations = pdf.Pages[0].Annotations;

StringBuilder content = new StringBuilder();

for (int i = 0; i < annotations.Count; i++)
{
    //A text annotation will attach a popup annotation since they are father-son relationship. 
    //The annotation information exists in the text annotation, so here we mask the blank popup annotation.
    if (annotations[i] is PdfPopupAnnotationWidget)
        continue;
    content.AppendLine("Annotation information: ");
    content.AppendLine("Text: " + annotations[i].Text);
    string modifiedDate = annotations[i].ModifiedDate.ToString();
    content.AppendLine("ModifiedDate: " + modifiedDate);
}
```

---

# spire.pdf csharp annotation
## get particular annotation information from pdf
```csharp
//Create a new PDF document.
PdfDocument pdf = new PdfDocument();

//Load the file from disk.
pdf.LoadFromFile("Template_Pdf_3.pdf");

//Get the annotation collection from the document.
PdfAnnotationCollection annotations = pdf.Pages[0].Annotations;

//Get particular annotation information from the document.
StringBuilder content = new StringBuilder();
if (annotations[0] is PdfTextAnnotationWidget)
{
    PdfTextAnnotationWidget textAnnotation = annotations[0] as PdfTextAnnotationWidget;
    content.AppendLine("Annotation text: " + textAnnotation.Text);
    content.AppendLine("Annotation ModifiedDate: " + textAnnotation.ModifiedDate.ToString());
    content.AppendLine("Annotation author: " + textAnnotation.Author);
    content.AppendLine("Annotation Name: " + textAnnotation.Name);
}
```

---

# spire.pdf csharp annotation
## create invisible free text annotation in pdf
```csharp
// Create a new PDF document.
PdfDocument doc = new PdfDocument();

// Get the first page of the PDF document.
PdfPageBase page = doc.Pages[0];

// Define a rectangle with specific coordinates and dimensions.
RectangleF rect = new RectangleF(100, 120, 150, 30);

// Create a new free text annotation using the defined rectangle.
PdfFreeTextAnnotation FreetextAnnotation = new PdfFreeTextAnnotation(rect);

// Set the text content of the free text annotation.
FreetextAnnotation.Text = "Invisible Free Text Annotation";

// Specify the font for the free text annotation.
PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);

// Specify the border width for the free text annotation.
PdfAnnotationBorder border = new PdfAnnotationBorder(1f);

// Set various properties for the free text annotation.
FreetextAnnotation.Font = font;
FreetextAnnotation.Border = border;
FreetextAnnotation.BorderColor = Color.Purple;
FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
FreetextAnnotation.Color = Color.Green;
FreetextAnnotation.Opacity = 0.8f;

// Set flags to make the free text annotation invisible.
FreetextAnnotation.Flags = PdfAnnotationFlags.Print | PdfAnnotationFlags.NoView;

// Add the free text annotation to the page's annotations collection.
page.Annotations.Add(FreetextAnnotation);

// Define a new rectangle for the next free text annotation.
rect = new RectangleF(100, 180, 150, 30);

// Create another free text annotation using the new rectangle.
FreetextAnnotation = new PdfFreeTextAnnotation(rect);

// Set properties for the second free text annotation.
FreetextAnnotation.Text = "Show Free Text Annotation";
FreetextAnnotation.Font = font;
FreetextAnnotation.Border = border;
FreetextAnnotation.BorderColor = Color.LightPink;
FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
FreetextAnnotation.Color = Color.LightGreen;
FreetextAnnotation.Opacity = 0.8f;

// Add the second free text annotation to the page's annotations collection.
page.Annotations.Add(FreetextAnnotation);
```

---

# Spire.PDF C# Line Annotation Modification
## Modify properties of a line annotation in a PDF document
```csharp
// Create a new PdfDocument object
PdfDocument document = new PdfDocument();

// Load an existing PDF file into the document from the specified path
document.LoadFromFile(@"..\..\..\..\..\..\Data\PdfLineAnnotation.pdf");

// Retrieve the first annotation widget from the first page of the document
PdfAnnotation annotation = document.Pages[0].Annotations[0];

// Check if the retrieved annotation is a PdfLineAnnotationWidget
if (annotation is PdfLineAnnotationWidget)
{
    // Cast the annotation as a PdfLineAnnotationWidget to access its specific properties and methods
    PdfLineAnnotationWidget lineAnn = annotation as PdfLineAnnotationWidget;

    // Set the author property of the line annotation to "Author_test"
    lineAnn.Author = "Author_test";

    // Set the subject property of the line annotation to "Subject_test"
    lineAnn.Subject = "Subject_test";
}

// Save the modified document to the specified file path
document.SaveToFile("ModifyLineAnnotation.pdf");
```

---

# Spire.PDF Free Text Annotation Alignment
## Setting text alignment for free text annotations in PDF documents
```csharp
// Create a new PdfDocument object
PdfDocument pdf = new PdfDocument();

// Add a new page to the document and assign it to the 'page' variable
PdfPageBase page = pdf.Pages.Add();

// Define a rectangle with specific coordinates and dimensions
RectangleF rect = new RectangleF(0, 300, 200, 80);

// Create a new PdfFreeTextAnnotation object and pass the rectangle as a parameter
PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(rect);

// Set the text content of the free text annotation
textAnnotation.Text = "\n  Spire.PDF";

// Create a new PdfAnnotationBorder object with a specified width
PdfAnnotationBorder border = new PdfAnnotationBorder(1f);

// Create a new PdfFont object using the Times Roman font family and a font size of 20
PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 20);

// Assign the created font to the font property of the free text annotation
textAnnotation.Font = font;

// Assign the created border to the border property of the free text annotation
textAnnotation.Border = border;

// Set the border color of the free text annotation to gray
textAnnotation.BorderColor = Color.Gray;

// Set the line ending style of the free text annotation to slash
textAnnotation.LineEndingStyle = PdfLineEndingStyle.Slash;

// Set the background color of the free text annotation to light blue
textAnnotation.Color = Color.LightBlue;

// Set the opacity of the free text annotation to 0.8
textAnnotation.Opacity = 0.8f;

// Set the alignment of the text within the free text annotation to center
textAnnotation.TextAlignment = PdfAnnotationTextAlignment.Center;

// Add the free text annotation to the annotations collection of the page
page.Annotations.Add(textAnnotation);
```

---

# spire.pdf csharp annotation
## set free text annotation style in pdf
```csharp
//Get the first page of PDF file.
PdfPageBase page = doc.Pages[0];

//Define a rectangle and create a free text annotation object.
RectangleF rect = new RectangleF(150, 120, 150, 30);
PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(rect);

//Specify content.
textAnnotation.Text = "\nFree Text Annotation Formatting";

//Set free text annotation formatting and add it to page.
PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);
PdfAnnotationBorder border = new PdfAnnotationBorder(1f);
textAnnotation.Font = font;
textAnnotation.Border = border;
textAnnotation.BorderColor = Color.Purple;
textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
textAnnotation.Color = Color.Green;
textAnnotation.Opacity = 0.8f;
page.Annotations.Add(textAnnotation);

rect = new RectangleF(150, 200, 150, 40);
textAnnotation = new PdfFreeTextAnnotation(rect);
textAnnotation.Text = "\nFree Text Annotation Formatting";
border = new PdfAnnotationBorder(1f);
font = new PdfFont(PdfFontFamily.Helvetica, 10);
textAnnotation.Font = font;
textAnnotation.Border = border;
textAnnotation.BorderColor = Color.LightGoldenrodYellow;
textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow;
textAnnotation.Color = Color.LightPink;
textAnnotation.Opacity = 0.8f;
page.Annotations.Add(textAnnotation);

rect = new RectangleF(150, 280, 280, 40);
textAnnotation = new PdfFreeTextAnnotation(rect);
textAnnotation.Text = "\noHow to Set Free Text Annotation Formatting in Pdf file";
border = new PdfAnnotationBorder(1f);
font = new PdfFont(PdfFontFamily.Helvetica, 10);
textAnnotation.Font = font;
textAnnotation.Border = border;
textAnnotation.BorderColor = Color.Gray;
textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
textAnnotation.Color = Color.LightSkyBlue;
textAnnotation.Opacity = 0.8f;
page.Annotations.Add(textAnnotation);

rect = new RectangleF(150, 360, 200, 40);
textAnnotation = new PdfFreeTextAnnotation(rect);
textAnnotation.Text = "\nFree Text Annotation Formatting";
border = new PdfAnnotationBorder(1f);
font = new PdfFont(PdfFontFamily.Helvetica, 10);
textAnnotation.Font = font;
textAnnotation.Border = border;
textAnnotation.BorderColor = Color.Pink;
textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow;
textAnnotation.Color = Color.LightGreen;
textAnnotation.Opacity = 0.8f;
page.Annotations.Add(textAnnotation);
```

---

# spire.pdf csharp annotation
## set free text annotation subject and properties
```csharp
//Get the first page of PDF file.
PdfPageBase page = doc.Pages[0];

//Initialize a PdfFreeTextAnnotation.
RectangleF rect = new RectangleF(150, 120, 150, 30);
PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(rect);

//Specify content.
textAnnotation.Text = "\nSet free text annotation subject";

//Set subject.
textAnnotation.Subject = "SubjectTest";

// Create a new PdfFont object using the Times Roman font family and a font size of 20
PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);

// Create a new PdfAnnotationBorder object with a specified width
PdfAnnotationBorder border = new PdfAnnotationBorder(1f);

// Assign the created font to the font property of the free text annotation
textAnnotation.Font = font;

// Assign the created border to the border property of the free text annotation
textAnnotation.Border = border;

// Set the border color of the free text annotation to gray
textAnnotation.BorderColor = Color.Purple;

// Set the line ending style of the free text annotation to slash
textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;

// Set the background color of the free text annotation to light blue
textAnnotation.Color = Color.Green;

// Set the opacity of the free text annotation to 0.8
textAnnotation.Opacity = 0.8f;
page.Annotations.Add(textAnnotation);
```

---

# spire.pdf text annotation properties
## copy text annotation properties from one pdf to another
```csharp
// Get the first page of the loaded document
PdfPageBase firstPage = pdf.Pages[0];

// Create a new PDF document object to store the copied annotations
PdfDocument newPdf = new PdfDocument();

// Iterate through each annotation in the first page's annotation list
foreach (PdfAnnotation annotation in firstPage.Annotations.List)
{
    // Check if the annotation is a free text annotation
    if (annotation is PdfFreeTextAnnotationWidget)
    {
        // Convert the annotation to a free text annotation object
        PdfFreeTextAnnotationWidget textAnnotation = annotation as PdfFreeTextAnnotationWidget;

        // Retrieve the rectangle bounds of the annotation
        var rect = textAnnotation.Bounds;

        // Retrieve the text content of the annotation
        var text = textAnnotation.Text;

        // Create a new page in the new PDF document with the same size as the first page
        PdfPageBase newPage = newPdf.Pages.Add(firstPage.Size);

        // Create a new free text annotation with the same rectangle bounds
        PdfFreeTextAnnotation newAnnotation = new PdfFreeTextAnnotation(rect);

        // Set the text content of the new annotation
        newAnnotation.Text = text;

        // Copy the callout lines information from the original annotation
        newAnnotation.CalloutLines = textAnnotation.CalloutLines;

        // Copy the line ending style from the original annotation
        newAnnotation.LineEndingStyle = textAnnotation.LineEndingStyle;

        // Set the annotation intent to indicate it's a free text callout
        newAnnotation.AnnotationIntent = PdfAnnotationIntent.FreeTextCallout;

        // Copy the rectangular differences information from the original annotation
        newAnnotation.RectangleDifferences = textAnnotation.RectangularDifferenceArray;

        // Set the color of the new annotation to match the original annotation
        newAnnotation.Color = textAnnotation.Color;

        // Add the new annotation to the annotations widget of the new page
        newPage.Annotations.Add(newAnnotation);
    }
}
```

---

# Spire.PDF C# Free Text Annotation Update
## Update color of free text annotations in a PDF document
```csharp
// Get the collection of annotations from the first page of the PDF document.
PdfAnnotationCollection annotations = pdf.Pages[0].Annotations;

// Iterate through each free text annotation in the collection.
foreach (PdfFreeTextAnnotationWidget annotation in annotations)
{
    // Change the color of the annotation to YellowGreen.
    annotation.Color = Color.YellowGreen;
}
```

---

# Spire.PDF C# Attachments
## Add attachments and attachment annotations to PDF documents
```csharp
// Create a pdf document
PdfDocument doc = new PdfDocument();

// Get the first page of the PDF document
PdfPageBase page = doc.Pages[0];

// Add an attachment to the PDF document
PdfAttachment attachment = new PdfAttachment("Header.png");
attachment.Data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\Header.png");
attachment.Description = "Page header picture of demo.";
attachment.MimeType = "image/png";
doc.Attachments.Add(attachment);

// Add another attachment to the PDF document
attachment = new PdfAttachment("Footer.png");
attachment.Data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\Footer.png");
attachment.Description = "Page footer picture of demo.";
attachment.MimeType = "image/png";
doc.Attachments.Add(attachment);

// Define bounds for the annotation
RectangleF bounds = new RectangleF(50, 350, 20, 20);

// Create a PdfAttachmentAnnotation for the Sales Report Chart attachment
byte[] data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SalesReportChart.png");
PdfAttachmentAnnotation annotation1 = new PdfAttachmentAnnotation(bounds, "SalesReportChart.png", data);
annotation1.Color = Color.Teal;
annotation1.Flags = PdfAnnotationFlags.ReadOnly;
annotation1.Icon = PdfAttachmentIcon.Graph;
annotation1.Text = "Sales Report Chart";

// Add the annotation to the page
page.Annotations.Add(annotation1);

// Create another annotation
data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg");
PdfAttachmentAnnotation annotation2
    = new PdfAttachmentAnnotation(bounds, "SciencePersonificationBoston.jpg", data);
annotation2.Color = Color.Orange;
annotation2.Flags = PdfAnnotationFlags.NoZoom;
annotation2.Icon = PdfAttachmentIcon.PushPin;
annotation2.Text = "SciencePersonificationBoston.jpg, from Wikipedia, the free encyclopedia";
page.Annotations.Add(annotation2);

// Create another annotation
data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\Wikipedia_Science.png");
PdfAttachmentAnnotation annotation3
    = new PdfAttachmentAnnotation(bounds, "Wikipedia_Science.png", data);
annotation3.Color = Color.SaddleBrown;
annotation3.Flags = PdfAnnotationFlags.Locked;
annotation3.Icon = PdfAttachmentIcon.Tag;
annotation3.Text = "Wikipedia_Science.png, from Wikipedia, the free encyclopedia";
page.Annotations.Add(annotation3);

// Create another annotation
data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\PT_Serif-Caption-Web-Regular.ttf");
PdfAttachmentAnnotation annotation4
    = new PdfAttachmentAnnotation(bounds, "PT_Serif-Caption-Web-Regular.ttf", data);
annotation4.Color = Color.CadetBlue;
annotation4.Flags = PdfAnnotationFlags.NoRotate;
annotation4.Icon = PdfAttachmentIcon.Paperclip;
annotation4.Text = "PT_Serif-Caption-Web-Regular, from https://company.paratype.com";
page.Annotations.Add(annotation4);
```

---

# Spire.PDF Delete Attachments
## Delete all attachments from a PDF document
```csharp
//Open pdf document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

//Get all attachments
PdfAttachmentCollection attachments = doc.Attachments;

//Delete all attachments
attachments.Clear();
```

---

# spire.pdf get attachments
## Extract all attachments from a PDF document
```csharp
//Create a new PDF document.
PdfDocument pdf = new PdfDocument();

//Load the file from disk.
pdf.LoadFromFile("input.pdf");

//Get a collection of attachments on the PDF document.
PdfAttachmentCollection collection = pdf.Attachments;

//Save all the attachments to the files.
for (int i = 0; i < collection.Count; i++) 
{
    File.WriteAllBytes(collection[i].FileName, collection[i].Data);
}
```

---

# spire.pdf csharp attachment
## extract individual attachment from pdf
```csharp
//Create a new PDF document.
PdfDocument pdf = new PdfDocument();

//Load the file from disk.
pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_2.pdf");

//Get a collection of attachments on the PDF document.
PdfAttachmentCollection collection = pdf.Attachments;

//Get the second attachment in PDF file.
PdfAttachment attachment = collection[1];

//Save the second attachment to the file.
File.WriteAllBytes(attachment.FileName, attachment.Data);
```

---

# Spire.PDF C# Get Attachment Information
## Extracts attachment information from a PDF document
```csharp
//Create a new PDF document
PdfDocument pdf = new PdfDocument();

//Load the file from disk.
pdf.LoadFromFile(filePath);

//Get a collection of attachments on the PDF document
PdfAttachmentCollection collection = pdf.Attachments;

//Get the first attachment.
PdfAttachment attachment = collection[0];

//Get attachment information
string fileName = attachment.FileName;
string description = attachment.Description;
DateTime creationDate = attachment.CreationDate;
DateTime modificationDate = attachment.ModificationDate;
```

---

# spire.pdf csharp attachment
## add attachment to PDF with relationship type
```csharp
//Define PdfAttachment
PdfAttachment attachment = new PdfAttachment(attachmentPath);

//Add addachment
doc.Attachments.Add(attachment, doc, Spire.Pdf.General.PdfAttachmentRelationship.Alternative);
```

---

# spire.pdf csharp attachment
## sort files in pdf document by custom fields
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Add a custom field with the name "No", the internal name "number", and the type NumberField to the document's collection
doc.Collection.AddCustomField("No", "number", Spire.Pdf.Collections.CustomFieldType.NumberField);

//Add a file-related field with the name "Desc", the internal name "desc", and the type Desc to the document's collection
doc.Collection.AddFileRelatedField("Desc", "desc", Spire.Pdf.Collections.FileRelatedFieldType.Desc);

//Sort the document's collection based on the fields "No" and "Desc" in ascending order
doc.Collection.Sort(new string[] { "No", "Desc" }, new bool[] { true, true });

//Create a PdfAttachment object with the path of "SampleB_1.pdf"
PdfAttachment pdfAttachment = new PdfAttachment(@"..\..\..\..\..\..\Data\SampleB_1.pdf");

//Add the PdfAttachment object to the document's collection
doc.Collection.AddAttachment(pdfAttachment);

//Create a PdfAttachment object with the path of "SampleB_2.pdf"
pdfAttachment = new PdfAttachment(@"..\..\..\..\..\..\Data\SampleB_2.pdf");

//Add the PdfAttachment object to the document's collection
doc.Collection.AddAttachment(pdfAttachment);

//Create a PdfAttachment object with the path of "SampleB_3.pdf"
pdfAttachment = new PdfAttachment(@"..\..\..\..\..\..\Data\SampleB_3.pdf");

//Add the PdfAttachment object to the document's collection
doc.Collection.AddAttachment(pdfAttachment);

//Initialize a counter variable with a value of 1
int i = 1;

//Iterate through each PdfAttachment object in the document's associated files
foreach (PdfAttachment attachment in doc.Collection.AssociatedFiles)
{
    //Set the value of the "No" field in the attachment to the current counter value
    attachment.SetFieldValue("No", i);

    //Set the value of the "Desc" field in the attachment to the file name of the attachment
    attachment.SetFieldValue("Desc", attachment.FileName);

    //Increment the counter variable
    i++;
}
```

---

# spire.pdf csharp bookmark
## create hierarchical bookmarks in pdf document
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

// Create a destination for the vendor bookmark
PdfDestination vendorBookmarkDest = new PdfDestination(page, new PointF(0, y));

// Create a bookmark for the vendor and set its properties
PdfBookmark vendorBookmark = doc.Bookmarks.Add(vendorTitle);
vendorBookmark.Color = Color.SaddleBrown;
vendorBookmark.DisplayStyle = PdfTextStyle.Bold;
vendorBookmark.Action = new PdfGoToAction(vendorBookmarkDest);

// Create a destination for the part bookmark
PdfDestination partBookmarkDest = new PdfDestination(page, new PointF(0, y));

// Create a bookmark for the part under the vendor bookmark and set its properties
PdfBookmark partBookmark = vendorBookmark.Add(partTitle);
partBookmark.Color = Color.Coral;
partBookmark.DisplayStyle = PdfTextStyle.Italic;
partBookmark.Action = new PdfGoToAction(partBookmarkDest);
```

---

# spire.pdf csharp bookmark deletion
## delete all bookmarks from a pdf document
```csharp
//Create a new Pdf document.
PdfDocument document = new PdfDocument();

//Load the file from disk.
document.LoadFromFile("Template_Pdf_1.pdf");

//Remove all bookmarks.
document.Bookmarks.Clear();

//Save the document
document.SaveToFile("DeleteAllBookmarks_out.pdf");
```

---

# Spire.PDF C# Bookmark Management
## Delete bookmarks from PDF documents
```csharp
//Delete the first bookmark
doc.Bookmarks.RemoveAt(0);
```

---

# spire.pdf csharp bookmarks
## expand or collapse bookmarks in pdf document
```csharp
// Function to iterate through the bookmarks and expand or collapse them based on the specified flag
private void ForeachBookmark(PdfBookmarkCollection collections, bool expand)
{
    // Check if the collection is empty, and return if it is
    if (collections.Count == 0)
        return;

    // Iterate through each bookmark in the collection
    foreach (PdfBookmark bookmark in collections)
    {
        // Check if the current bookmark has child bookmarks
        if ((bookmark as PdfBookmarkCollection).Count > 0)
        {
            // Recursively call the function to process child bookmarks
            ForeachBookmark(bookmark as PdfBookmarkCollection, expand);

            // Set the ExpandBookmark property of the current bookmark to the specified flag
            bookmark.ExpandBookmark = expand;
        }
    }
}
```

---

# spire.pdf csharp bookmarks
## expand or collapse specific bookmarks in pdf
```csharp
// Set BookMarkExpandOrCollapse as "true" for the first bookmarks and "false" for the first level of the second bookmarks  
pdf.Bookmarks[0].ExpandBookmark = true;
(pdf.Bookmarks[1] as PdfBookmarkCollection)[0].ExpandBookmark = false;
```

---

# spire.pdf csharp bookmarks
## extract all bookmarks from a pdf document
```csharp
//Create a new Pdf document.
PdfDocument doc = new PdfDocument();

//Load the file from disk.
doc.LoadFromFile("template.pdf");

//Get bookmarks collection of the Pdf file.
PdfBookmarkCollection bookmarks = doc.Bookmarks;

//Get Pdf Bookmarks.
GetBookmarks(bookmarks);

private void GetBookmarks(PdfBookmarkCollection bookmarks)
{
    //Declare a new StringBuilder content
    StringBuilder content = new StringBuilder();

    //Get Pdf bookmarks information.
    if (bookmarks.Count > 0)
    {
        content.AppendLine("Pdf bookmarks:");
        foreach (PdfBookmark parentBookmark in bookmarks)
        {
            //Get the title.
            content.AppendLine(parentBookmark.Title);
        
            //Get the text style.
            string textStyle = parentBookmark.DisplayStyle.ToString();
            content.AppendLine(textStyle);
            GetChildBookmark(parentBookmark,content);
        }
    }
}

private void GetChildBookmark(PdfBookmark parentBookmark, StringBuilder content)
{
    if (parentBookmark.Count > 0)
    {
        foreach (PdfBookmark childBookmark in parentBookmark)
        {
            //Get the title.
            content.AppendLine(childBookmark.Title);

            //Get the text style.
            string textStyle = childBookmark.DisplayStyle.ToString();
            content.AppendLine(textStyle);
            GetChildBookmark(childBookmark, content);
        }
    }
}
```

---

# Spire.PDF C# Bookmark Page Number
## Get the page number of a bookmark in a PDF document
```csharp
//Get bookmarks collections of the PDF file
PdfBookmarkCollection bookmarks = doc.Bookmarks;

//Get the page number of the first bookmark
PdfBookmark bookmark = bookmarks[0];
int pageNumber = doc.Pages.IndexOf(bookmark.Destination.Page) + 1;
```

---

# Spire.PDF C# Get Child Bookmarks
## Extract child bookmark information from a PDF document
```csharp
//Declare a new StringBuilder content
StringBuilder content = new StringBuilder();

//Get Pdf child Bookmarks information.
foreach (PdfBookmark parentBookmark in bookmarks)
{
    if (parentBookmark.Count > 0)
    {
        content.AppendLine("Child Bookmarks:");

        foreach (PdfBookmark childBookmark in parentBookmark)
        {
            //Get the title
            content.AppendLine(childBookmark.Title);

            //Get the color.
            string color = childBookmark.Color.ToString();
            content.AppendLine(color);

            //Get the text style.
            string textStyle = childBookmark.DisplayStyle.ToString();
            content.AppendLine(textStyle);
        }
    }
}
```

---

# spire.pdf bookmark zoom
## set inherit zoom for pdf bookmarks
```csharp
//Create a new PDF document
PdfDocument pdfdoc = new PdfDocument();

//Get bookmarks collections of the PDF file
PdfBookmarkCollection bookmarks = pdfdoc.Bookmarks;

//Set Zoom level as 0.5, which represents inherit zoom
foreach (PdfBookmark bookMark in bookmarks)
{
    bookMark.Destination.Zoom = 0.5f;
}
```

---

# spire.pdf csharp bookmark zoom
## Set inherit zoom for PDF bookmarks
```csharp
// Get the bookmarks collection of the PDF file
PdfBookmarkCollection bookmarks = pdf.Bookmarks;

// Iterate through each bookmark in the collection
for (int i = 0; i < bookmarks.Count; i++)
{
    // Set inherit zoom for the current bookmark
    PdfBookmark bookmark = bookmarks[i];
    SetBookmarkAction(bookmark);
}

private void SetBookmarkAction(PdfBookmark bookmark)
{
    // Get the destination of the bookmark
    PdfDestination dest = bookmark.Destination;

    // Set the destination mode to "Location" and the zoom level to 0
    dest.Mode = PdfDestinationMode.Location;
    dest.Zoom = 0;

    // Iterate through each child bookmark recursively
    for (int i = 0; i < bookmark.Count; i++)
    {
        PdfBookmark childbookmark = bookmark[i];
        SetBookmarkAction(childbookmark);
    }
}
```

---

# Spire.PDF C# Bookmark Management
## Update PDF bookmarks and their styles recursively
```csharp
// Get the first bookmark from the document
PdfBookmark bookmark = doc.Bookmarks[0];

// Change the title of the bookmark
bookmark.Title = "Modified BookMark";

// Set the color of the bookmark to Black
bookmark.Color = Color.Black;

// Set the outline text style of the bookmark to Bold
bookmark.DisplayStyle = PdfTextStyle.Bold;

// Edit the child bookmarks of the parent bookmark
EditChildBookmark(bookmark);

// Function to edit the child bookmarks of a parent bookmark recursively
private void EditChildBookmark(PdfBookmark parentBookmark)
{
    // Iterate through each child bookmark of the parent bookmark
    foreach (PdfBookmark childBookmark in parentBookmark)
    {
        // Set the color of the child bookmark to Blue
        childBookmark.Color = Color.Blue;

        // Set the outline text style of the child bookmark to Regular
        childBookmark.DisplayStyle = PdfTextStyle.Regular;

        // Recursively call EditChild2Bookmark to edit the child's child bookmarks
        EditChild2Bookmark(childBookmark);
    }
}

// Function to edit the child's child bookmarks recursively
private void EditChild2Bookmark(PdfBookmark childBookmark)
{
    // Iterate through each child bookmark of the child bookmark
    foreach (PdfBookmark child2Bookmark in childBookmark)
    {
        // Set the color of the child's child bookmark to LightSalmon
        child2Bookmark.Color = Color.LightSalmon;

        // Set the outline text style of the child's child bookmark to Italic
        child2Bookmark.DisplayStyle = PdfTextStyle.Italic;
    }
}
```

---

# spire.pdf csharp calendar dropdown
## add calendar dropdown field to pdf document
```csharp
// Create a new PDF document
PdfDocument pdf = new PdfDocument();

// Add a new page to the PDF document with A4 size and zero margins
PdfPageBase page = pdf.Pages.Add(PdfPageSize.A4, new PdfMargins(0));

// Create a TrueType font using Arial Unicode MS with a font size of 10
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial Unicode MS", 10f), true);

// Create a new text box field on the page with the field name "date"
PdfTextBoxField textbox = new PdfTextBoxField(page, "date");

// Set the position and size of the text box
textbox.Bounds = new RectangleF(40, 50, 60, 20);

// Set the font for the text box
textbox.Font = font;

// Get the JavaScript keystroke string for date input in the format "mm/dd/yyyy"
string kjs = PdfJavaScript.GetDateKeystrokeString("mm/dd/yyyy");

// Get the JavaScript format string for date input in the format "mm/dd/yyyy"
string fjs = PdfJavaScript.GetDateFormatString("mm/dd/yyyy");

// Create JavaScript actions for the keystroke and format settings
PdfJavaScriptAction kjsAction = new PdfJavaScriptAction(kjs);
PdfJavaScriptAction fjsAction = new PdfJavaScriptAction(fjs);

// Assign the JavaScript actions to the text box
textbox.Actions.KeyPressed = kjsAction;
textbox.Actions.Format = fjsAction;

// Add the text box field to the form fields collection of the PDF document
pdf.Form.Fields.Add(textbox);
```

---

# Spire.PDF C# Checkbox
## Add checkbox field to PDF document
```csharp
// Create a new PDF document
PdfDocument doc = new PdfDocument();

// Allow the document to create form fields
doc.AllowCreateForm = true;

// Create a checkbox field on the first page of the document with the field name "fieldID"
PdfCheckBoxField checkboxField = new PdfCheckBoxField(doc.Pages[0], "fieldID");

// Set the size and position of the checkbox field
float checkboxWidth = 40;
float checkboxHeight = 40;
checkboxField.Bounds = new RectangleF(60, 300, checkboxWidth, checkboxHeight);

// Set the border width of the checkbox field
checkboxField.BorderWidth = 0.75f;

// Set the initial checked state of the checkbox field to true
checkboxField.Checked = true;

// Set the style of the checkbox field to "Check"
checkboxField.Style = PdfCheckBoxStyle.Check;

// Set the checkbox field as a required field
checkboxField.Required = true;

// Add the checkbox field to the form fields collection of the PDF document
doc.Form.Fields.Add(checkboxField);
```

---

# Spire.PDF C# ComboBox
## Add a combo box field to a PDF document
```csharp
// Create a combo box field on the first page of the document with the field name "Combox1"
PdfComboBoxField comboBoxField = new PdfComboBoxField(doc.Pages[0], "Combox1");

// Set the size and position of the combo box field
comboBoxField.Bounds = new RectangleF(60, 300, 70, 30);

// Set the border width of the combo box field
comboBoxField.BorderWidth = 0.75f;

// Set the font of the combo box field to Helvetica with a font size of 9
comboBoxField.Font = new PdfFont(PdfFontFamily.Helvetica, 9f);

// Set the combo box field as a required field
comboBoxField.Required = true;

// Add items to the combo box field
comboBoxField.Items.Add(new PdfListFieldItem("Apple", "item1"));
comboBoxField.Items.Add(new PdfListFieldItem("Banana", "item2"));
comboBoxField.Items.Add(new PdfListFieldItem("Pear", "item3"));
comboBoxField.Items.Add(new PdfListFieldItem("Peach", "item4"));
comboBoxField.Items.Add(new PdfListFieldItem("Grape", "item5"));

// Add the combo box field to the form fields collection of the PDF document
doc.Form.Fields.Add(comboBoxField);
```

---

# Spire.PDF Form Fields
## Creating PDF documents with various form fields
```csharp
// Create a new PDF document
PdfDocument doc = new PdfDocument();

// Set the margins of the document
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

// Create a new page with A4 size and zero margins
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(0));

float y = 10;

// Add a title to the page and update the current y coordinate
y = DrawPageTitle(page, y);

// Draw a button on the page for submitting the form
y = y + 10;
float buttonWidth = 80;
float buttonX = (page.Canvas.ClientSize.Width - buttonWidth) / 2;
RectangleF buttonBounds = new RectangleF(buttonX, y, buttonWidth, 16f);
PdfButtonField button = new PdfButtonField(page, "submit");
button.Text = "Submit";
button.Bounds = buttonBounds;
PdfSubmitAction submitAction = new PdfSubmitAction("http://www.e-iceblue.com");
button.Actions.MouseUp = submitAction;
doc.Form.Fields.Add(button);

// Method to draw form sections
private float DrawFormSection(String label, PdfPageBase page, float y)
{
    // Define the brushes, font, and format for the label
    PdfBrush brush1 = PdfBrushes.LightYellow;
    PdfBrush brush2 = PdfBrushes.DarkSlateGray;
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Bold));
    PdfStringFormat format = new PdfStringFormat();

    // Measure the height of the label text using the font
    float height = font.MeasureString(label).Height;

    // Draw a rectangle with brush2 as the background color for the label
    page.Canvas.DrawRectangle(brush2, 0, y, page.Canvas.ClientSize.Width, height + 2);

    // Draw the label text using brush1 inside the rectangle
    page.Canvas.DrawString(label, font, brush1, 2, y + 1);

    // Update the y-coordinate to position the next element below the label
    y = y + height + 2;

    // Draw a horizontal line below the label using a pen with light sky blue color
    PdfPen pen = new PdfPen(PdfBrushes.LightSkyBlue, 0.75f);
    page.Canvas.DrawLine(pen, 0, y, page.Canvas.ClientSize.Width, y);

    // Return the updated y-coordinate for positioning the next element
    return y + 0.75f;
}

// Method to draw different types of form fields
private float DrawFormField(XPathNavigator fieldNode, PdfForm form, PdfPageBase page, float y, int fieldIndex)
{
    // Get the width and padding of the page
    float width = page.Canvas.ClientSize.Width;
    float padding = 2;

    // Measure the label of the field
    String label = fieldNode.GetAttribute("label", "");
    PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 9f));
    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
    float labelMaxWidth = width * 0.4f - 2 * padding;
    SizeF labelSize = font1.MeasureString(label, labelMaxWidth, format);

    // Measure the height of the field
    float fieldHeight = MeasureFieldHeight(fieldNode);

    // Calculate the overall height of the field based on the label and field heights
    float height = labelSize.Height > fieldHeight ? labelSize.Height : fieldHeight;
    height = height + 2;

    // Draw the background rectangle for the field
    PdfBrush brush = PdfBrushes.SteelBlue;
    if (fieldIndex % 2 == 1)
    {
        brush = PdfBrushes.LightGreen;
    }
    page.Canvas.DrawRectangle(brush, 0, y, width, height);

    // Draw the field label inside a rectangle
    PdfBrush brush1 = PdfBrushes.LightYellow;
    RectangleF labelBounds = new RectangleF(padding, y, labelMaxWidth, height);
    page.Canvas.DrawString(label, font1, brush1, labelBounds, format);

    // Draw the specific type of field based on the "type" attribute
    float fieldMaxWidth = width * 0.57f - 2 * padding;
    float fieldX = labelBounds.Right + 2 * padding;
    float fieldY = y + (height - fieldHeight) / 2;
    String fieldType = fieldNode.GetAttribute("type", "");
    String fieldId = fieldNode.GetAttribute("id", "");
    bool required = "true" == fieldNode.GetAttribute("required", "");
    switch (fieldType)
    {
        case "text":
        case "password":
            // Draw a text box field with the specified attributes
            PdfTextBoxField textField = new PdfTextBoxField(page, fieldId);
            textField.Bounds = new RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight);
            textField.BorderWidth = 0.75f;
            textField.BorderStyle = PdfBorderStyle.Solid;
            textField.Required = required;
            if ("password" == fieldType)
            {
                textField.Password = true;
            }
            if ("true" == fieldNode.GetAttribute("multiple", ""))
            {
                textField.Multiline = true;
                textField.Scrollable = true;
            }
            form.Fields.Add(textField);
            break;
        case "checkbox":
            // Draw a checkbox field with the specified attributes
            PdfCheckBoxField checkboxField = new PdfCheckBoxField(page, fieldId);
            float checkboxWidth = fieldHeight - 2 * padding;
            float checkboxHeight = checkboxWidth;
            checkboxField.Bounds = new RectangleF(fieldX, fieldY + padding, checkboxWidth, checkboxHeight);
            checkboxField.BorderWidth = 0.75f;
            checkboxField.Style = PdfCheckBoxStyle.Cross;
            checkboxField.Required = required;
            form.Fields.Add(checkboxField);
            break;
        case "list":
            // Draw a list box field with the specified attributes
            XPathNodeIterator itemNodes = fieldNode.Select("item");
            if ("true" == fieldNode.GetAttribute("multiple", ""))
            {
                PdfListBoxField listBoxField = new PdfListBoxField(page, fieldId);
                listBoxField.Bounds = new RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight);
                listBoxField.BorderWidth = 0.75f;
                listBoxField.MultiSelect = true;
                listBoxField.Font = new PdfFont(PdfFontFamily.Helvetica, 9f);
                listBoxField.Required = required;
                // Add items into the list box
                foreach (XPathNavigator itemNode in itemNodes)
                {
                    String text = itemNode.SelectSingleNode("text()").Value;
                    listBoxField.Items.Add(new PdfListFieldItem(text, text));
                }
                listBoxField.SelectedIndex = 0;
                form.Fields.Add(listBoxField);
                break;
            }
            if (itemNodes != null && itemNodes.Count <= 3)
            {
                // Draw a radio button list field with the specified attributes
                PdfRadioButtonListField radioButtonListFile = new PdfRadioButtonListField(page, fieldId);
                radioButtonListFile.Required = required;
                // Add items into the radio button list
                float fieldItemHeight = fieldHeight / itemNodes.Count;
                float radioButtonWidth = fieldItemHeight - 2 * padding;
                float radioButtonHeight = radioButtonWidth;
                foreach (XPathNavigator itemNode in itemNodes)
                {
                    String text = itemNode.SelectSingleNode("text()").Value;
                    PdfRadioButtonListItem fieldItem = new PdfRadioButtonListItem(text);
                    fieldItem.BorderWidth = 0.75f;
                    fieldItem.Bounds = new RectangleF(fieldX, fieldY + padding, radioButtonWidth, radioButtonHeight);
                    radioButtonListFile.Items.Add(fieldItem);

                    float fieldItemLabelX = fieldX + radioButtonWidth + padding;
                    SizeF fieldItemLabelSize = font1.MeasureString(text);
                    float fieldItemLabelY = fieldY + (fieldItemHeight - fieldItemLabelSize.Height) / 2;
                    page.Canvas.DrawString(text, font1, brush1, fieldItemLabelX, fieldItemLabelY);

                    fieldY = fieldY + fieldItemHeight;
                }
                form.Fields.Add(radioButtonListFile);

                break;
            }

            //Combo box
            PdfComboBoxField comboBoxField = new PdfComboBoxField(page, fieldId);
            comboBoxField.Bounds = new RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight);
            comboBoxField.BorderWidth = 0.75f;
            comboBoxField.Font = new PdfFont(PdfFontFamily.Helvetica, 9f);
            comboBoxField.Required = required;
            //Add items into combo box.
            foreach (XPathNavigator itemNode in itemNodes)
            {
                String text = itemNode.SelectSingleNode("text()").Value;
                comboBoxField.Items.Add(new PdfListFieldItem(text, text));
            }
            form.Fields.Add(comboBoxField);
            break;

    }

    if (required)
    {
        //Draw *
        float flagX = width * 0.97f + padding;
        PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
        SizeF size = font3.MeasureString("*");
        float flagY = y + (height - size.Height) / 2;
        page.Canvas.DrawString("*", font3, PdfBrushes.Red, flagX, flagY);
    }

    return y + height;
}

// Method to measure field height based on field type
private float MeasureFieldHeight(XPathNavigator fieldNode)
{
    // Get the type attribute of the field
    String fieldType = fieldNode.GetAttribute("type", "");

    // Set the default height for fields
    float defaultHeight = 16f;

    // Determine the height based on the field type
    switch (fieldType)
    {
        case "text":
        case "password":
            // For text and password fields, check if multiple attribute is true
            if ("true" == fieldNode.GetAttribute("multiple", ""))
            {
                return defaultHeight * 3;
            }
            return defaultHeight;

        case "checkbox":
            // Checkbox fields have the default height
            return defaultHeight;

        case "list":
            // For list fields, check if multiple attribute is true or the number of items is less than or equal to 3
            if ("true" == fieldNode.GetAttribute("multiple", ""))
            {
                return defaultHeight * 3;
            }
            XPathNodeIterator itemNodes = fieldNode.Select("item");
            if (itemNodes != null && itemNodes.Count <= 3)
            {
                return defaultHeight * 3;
            }
            return defaultHeight;

    }

    // If an invalid field type is encountered, throw an exception
    String message = String.Format("Invalid field type: {0}", fieldType);
    throw new ArgumentException(message);
}
```

---

# spire.pdf csharp javascript action
## add JavaScript actions to PDF form fields
```csharp
// Allow creation of form fields in the document
pdf.AllowCreateForm = true;

// Create a font object with Helvetica family, font size 12, and bold style
PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);

// Create a brush object for drawing black color
PdfBrush brush = PdfBrushes.Black;

// Specify the starting coordinates for drawing text on the page
float x = 50;
float y = 550;
float tempX = 0;

// Draw a text string on the page
string text1 = "Enter a number, such as 12345: ";
page.Canvas.DrawString(text1, font, brush, x, y);

// Add a textBox field to the page
tempX = font.MeasureString(text1).Width + x + 15;
PdfTextBoxField textbox = new PdfTextBoxField(page, "Number-TextBox");
textbox.Bounds = new RectangleF(tempX, y, 100, 15);
textbox.BorderWidth = 0.75f;
textbox.BorderStyle = PdfBorderStyle.Solid;

// Set a JavaScript action for handling key press events in the text field
string js = PdfJavaScript.GetNumberKeystrokeString(2, 0, 0, 0, "$", true);
PdfJavaScriptAction jsAction = new PdfJavaScriptAction(js);
textbox.Actions.KeyPressed = jsAction;

// Add a JavaScript action to format the value of the text field
js = PdfJavaScript.GetNumberFormatString(2, 0, 0, 0, "$", true);
jsAction = new PdfJavaScriptAction(js);
textbox.Actions.Format = jsAction;

// Add the text box field to the form fields collection of the PDF document
pdf.Form.Fields.Add(textbox);
```

---

# spire.pdf csharp radio button caption
## add caption to radio button in pdf form
```csharp
//Get pdf forms
PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

//Find the radio button field and add capture
for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
{
    PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

    if (field is PdfRadioButtonListFieldWidget)
    {
        PdfRadioButtonListFieldWidget radioButton = field as PdfRadioButtonListFieldWidget;
        if (radioButton.Name == "RadioButton")
        {
            //Get the page
            PdfPageBase page = radioButton.Page;

            //Set capture name
            string text = "Radio button caption";
            //Set font, pen and brush
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f);
            PdfPen pen = new PdfPen(Color.Red, 0.02f);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Red);
            //Set the capture location
            float x = radioButton.Location.X;
            float y = radioButton.Location.Y - font.MeasureString(text).Height - 10;
            //Draw capture
            page.Canvas.DrawString(text, font, pen, brush, x, y);
        }
    }
}
```

---

# spire.pdf csharp radio button field
## add radio button field to pdf document
```csharp
// Get the first page of the PDF document
PdfPageBase page = pdf.Pages[0];

// Allow creation of form fields in the document
pdf.AllowCreateForm = true;

// Create a new PdfFont using the Helvetica font family, size 12, and bold style
PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);

// Create a PdfBrush for drawing black color
PdfBrush brush = PdfBrushes.Black;

// Specify the starting coordinates for drawing text on the page
float x = 50;
float y = 550;
float tempX = 0;

// Specify the text to be drawn on the page
string text = "RadioButton: ";

// Draw the text on the page using the specified font, brush, and coordinates
page.Canvas.DrawString(text, font, brush, x, y);

// Calculate the X coordinate for placing the radio button field next to the drawn text
tempX = font.MeasureString(text).Width + x + 15;

// Create a PdfRadioButtonListField with a unique name and associate it with the current PDF page
PdfRadioButtonListField radioButton = new PdfRadioButtonListField(page, "RadioButton");
radioButton.Required = true;
// Set the Required property to true for the radio button field

// Create a PdfRadioButtonListItem for the radio button field
PdfRadioButtonListItem fieldItem = new PdfRadioButtonListItem();
fieldItem.BorderWidth = 0.75f;
fieldItem.Bounds = new RectangleF(tempX, y, 15, 15);
// Set the border width and bounds (position and size) for the radio button item

// Add the radio button item to the radio button field
radioButton.Items.Add(fieldItem);

// Add the radio button field to the form fields collection of the PDF document
pdf.Form.Fields.Add(radioButton);
```

---

# spire.pdf csharp radio button
## add radio button field with options to pdf
```csharp
//Get the first page
PdfPageBase page = pdf.Pages[0];

//As for existing pdf, the property needs to be set as true
pdf.AllowCreateForm = true;

//Create a new pdf font
PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);

//Create a pdf brush
PdfBrush brush = PdfBrushes.Black;

float x = 150;
float y = 550;
float temX = 0;

//Create a pdf radio button list
PdfRadioButtonListField radioButton = new PdfRadioButtonListField(page, "RadioButton");
radioButton.Required = true;

//Add items into radio button list.
for (int i = 0; i < 3; i++)
{
    // Set its style
    PdfRadioButtonListItem item = new PdfRadioButtonListItem(string.Format("item{0}", i));
    item.BorderWidth = 0.75f;
    item.Bounds = new RectangleF(x, y, 15, 15);
    item.BorderColor = Color.Red;
    item.ForeColor = Color.Red;
    radioButton.Items.Add(item);
    temX = x + 20;
    page.Canvas.DrawString(string.Format("Item{0}", i), font, brush, temX, y);
    x = temX + 100;
}

//Add the radio button list field into pdf document
pdf.Form.Fields.Add(radioButton);
```

---

# Spire.PDF C# TextBox Field
## Add a text box field to a PDF document
```csharp
// Set the AllowCreateForm property to true for existing PDF documents
// This allows the creation of form fields in the document
pdf.AllowCreateForm = true;

// Create a PdfTextBoxField with a unique name and associate it with the current PDF page
PdfTextBoxField textbox = new PdfTextBoxField(page, "TextBox");
textbox.Bounds = new RectangleF(x, y, 100, 15);
textbox.BorderWidth = 0.75f;
textbox.BorderStyle = PdfBorderStyle.Solid;

// Add the text box field to the form fields collection of the PDF document
pdf.Form.Fields.Add(textbox);
```

---

# spire pdf form field tooltip
## add tooltip to form field in pdf
```csharp
//As for existing pdf, the property needs to be set as true
doc.AllowCreateForm = true;

//Create a pdf font
PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);

//Create a pdf brush
PdfBrush brush = PdfBrushes.Black;

float x = 50;
float y = 590;
float tempX = 0;

string text = "E-mail: ";

//Draw a text into page
page.Canvas.DrawString(text, font, brush, x, y);

tempX = font.MeasureString(text).Width + x + 15;

//Create a pdf textbox field
PdfTextBoxField textbox = new PdfTextBoxField(page, "TextBox");

//Set the bounds of textbox field
textbox.Bounds = new RectangleF(tempX, y, 100, 15);

//Set the border width of textbox field
textbox.BorderWidth = 0.75f;

//Set the border style of textbox field
textbox.BorderStyle = PdfBorderStyle.Solid;

//Add the textbox field into pdf document
doc.Form.Fields.Add(textbox);

//Add a tooltip for the textbox field
doc.Form.Fields["TextBox"].ToolTip = "Please insert a valid email address";
```

---

# Spire.PDF C# Button Field
## Assign icons to PDF button field with different appearances
```csharp
//Create a Button and set its style
PdfButtonField btn = new PdfButtonField(page, "button1");
btn.Bounds = new RectangleF(0, 50, 120, 100);
btn.HighlightMode = PdfHighlightMode.Push;
btn.LayoutMode = PdfButtonLayoutMode.CaptionOverlayIcon;

//Set text and icon for Normal appearance
btn.Text = "Normal Text";
btn.Icon = PdfImage.FromFile("icon_path.png");

//Set text and icon for Click appearance (Can only be set when highlight mode is Push)
btn.AlternateText = "Alternate Text";
btn.AlternateIcon = PdfImage.FromFile("alternate_icon_path.png");

//Set text and icon for Rollover appearance (Can only be set when highlight mode is Push)
btn.RolloverText = "Rollover Text";
btn.RolloverIcon = PdfImage.FromFile("rollover_icon_path.png");

//Set icon layout
btn.IconLayout.Spaces = new float[] { 0.5f, 0.5f };
btn.IconLayout.ScaleMode = PdfButtonIconScaleMode.Proportional;
btn.IconLayout.ScaleReason = PdfButtonIconScaleReason.Always;
btn.IconLayout.IsFitBounds = false;

//Add the button to the document
doc.Form.Fields.Add(btn);
```

---

# Spire.PDF Auto Font Size for Text Box Field
## This code demonstrates how to automatically adjust font size for text box fields in a PDF form
```csharp
// Get the form widget from the PDF document
PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

// Iterate through each field in the form
foreach (PdfField field in formWidget.FieldsWidget.List)
{
    // Check if the field is a text box field
    if (field is PdfTextBoxFieldWidget)
    {
        // Cast the field to a PdfTextBoxFieldWidget
        PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;

        // Set the font of the text box field to Arial with a size of 16
        textBoxField.Font = new PdfTrueTypeFont(new Font("Arial", 16), true);

        // The "true" value for FontSizeAuto ensures that the font size is automatically adjusted based on the available space
        textBoxField.FontSizeAuto = true;

        // Set the text value of the text box field to "e-iceblue"
        textBoxField.Text = "e-iceblue";
    }
}
```

---

# spire.pdf csharp automatic fields
## create and draw various automatic fields in a PDF document
```csharp
// Method to draw automatic fields on a PDF page
private void DrawAutomaticField(PdfPageBase page)
{
    float y = 20;

    // Draw the title for the field list
    PdfBrush brush1 = PdfBrushes.CadetBlue;
    PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
    PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
    page.Canvas.DrawString("Automatic Field List", font1, brush1,
        page.Canvas.ClientSize.Width / 2, y, format1);
    y = y + font1.MeasureString("Automatic Field List", format1).Height;
    y = y + 15;

    // Define an array of field names
    String[] fieldList = new String[]
    {
        "DateTimeField",
        "CreationDateField",
        "DocumentAuthorField",
        "SectionNumberField",
        "SectionPageNumberField",
        "SectionPageCountField",
        "PageNumberField",
        "PageCountField",
        "DestinationPageNumberField",
        "CompositeField"
    };

    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
    PdfStringFormat fieldNameFormat = new PdfStringFormat();
    fieldNameFormat.MeasureTrailingSpaces = true;

    // Iterate through each field name in the list
    foreach (String fieldName in fieldList)
    {
        // Draw the field name
        String text = String.Format("{0}: ", fieldName);
        page.Canvas.DrawString(text, font, PdfBrushes.DodgerBlue, 0, y);
        float x = font.MeasureString(text, fieldNameFormat).Width;
        RectangleF bounds = new RectangleF(x, y, 200, font.Height);
        DrawAutomaticField(fieldName, page, bounds);
        y = y + font.Height + 8;
    }
}

// Method to draw a specific automatic field on a PDF page
void DrawAutomaticField(String fieldName, PdfPageBase page, RectangleF bounds)
{
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Italic));
    PdfBrush brush = PdfBrushes.OrangeRed;
    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);

    if ("DateTimeField" == fieldName)
    {
        // Create and draw a DateTime field
        PdfDateTimeField field = new PdfDateTimeField();
        field.Font = font;
        field.Brush = brush;
        field.StringFormat = format;
        field.Bounds = bounds;
        field.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        field.Draw(page.Canvas);
    }

    if ("CreationDateField" == fieldName)
    {
        PdfCreationDateField field = new PdfCreationDateField();
        field.Font = font;
        field.Brush = brush;
        field.StringFormat = format;
        field.Bounds = bounds;
        field.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        field.Draw(page.Canvas);
    }

    if ("DocumentAuthorField" == fieldName)
    {
        PdfDocumentAuthorField field = new PdfDocumentAuthorField();
        field.Font = font;
        field.Brush = brush;
        field.StringFormat = format;
        field.Bounds = bounds;
        field.Draw(page.Canvas);
    }

    if ("SectionNumberField" == fieldName)
    {
        PdfSectionNumberField field = new PdfSectionNumberField();
        field.Font = font;
        field.Brush = brush;
        field.StringFormat = format;
        field.Bounds = bounds;
        field.Draw(page.Canvas);
    }

    if ("SectionPageNumberField" == fieldName)
    {
        PdfSectionPageNumberField field = new PdfSectionPageNumberField();
        field.Font = font;
        field.Brush = brush;
        field.StringFormat = format;
        field.Bounds = bounds;
        field.Draw(page.Canvas);
    }

    if ("SectionPageCountField" == fieldName)
    {
        PdfSectionPageCountField field = new PdfSectionPageCountField();
        field.Font = font;
        field.Brush = brush;
        field.StringFormat = format;
        field.Bounds = bounds;
        field.Draw(page.Canvas);
    }

    if ("PageNumberField" == fieldName)
    {
        PdfPageNumberField field = new PdfPageNumberField();
        field.Font = font;
        field.Brush = brush;
        field.StringFormat = format;
        field.Bounds = bounds;
        field.Draw(page.Canvas);
    }

    if ("PageCountField" == fieldName)
    {
        PdfPageCountField field = new PdfPageCountField();
        field.Font = font;
        field.Brush = brush;
        field.StringFormat = format;
        field.Bounds = bounds;
        field.Draw(page.Canvas);
    }

    if ("DestinationPageNumberField" == fieldName)
    {
        PdfDestinationPageNumberField field = new PdfDestinationPageNumberField();
        field.Font = font;
        field.Brush = brush;
        field.StringFormat = format;
        field.Bounds = bounds;
        field.Page = page as PdfNewPage;
        field.Draw(page.Canvas);
    }

    if ("CompositeField" == fieldName)
    {
        PdfSectionPageNumberField field1 = new PdfSectionPageNumberField();
        field1.NumberStyle = PdfNumberStyle.LowerRoman;
        PdfSectionPageCountField field2 = new PdfSectionPageCountField();
        PdfCompositeField fields = new PdfCompositeField();
        fields.Font = font;
        fields.Brush = brush;
        fields.StringFormat = format;
        fields.Bounds = bounds;
        fields.AutomaticFields = new PdfAutomaticField[] { field1, field2 };
        fields.Text = "section page {0} of {1}";
        fields.Draw(page.Canvas);
    }
}
```

---

# spire.pdf csharp form field
## change location of form field in pdf
```csharp
// Get the form widget from the PDF
PdfFormWidget form = pdf.Form as PdfFormWidget;

// Iterate through each field in the form
for (int i = 0; i < form.FieldsWidget.List.Count; i++)
{
    // Get the current field
    PdfField field = form.FieldsWidget.List[i] as PdfField;

    // Check if the field is a textbox field
    if (field is PdfTextBoxFieldWidget)
    {
        // Cast the field to a textbox field
        PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;

        // Find the textbox named "TextBox1"
        if (textbox.Name == "TextBox1")
        {
            // Change the location of the field
            textbox.Location = new PointF(390, 525);
        }
    }
}
```

---

# spire.pdf csharp form fields
## determine and set required fields in pdf form
```csharp
// Get pdf forms
PdfFormWidget formWidget = doc.Form as PdfFormWidget;

// Find the particular form field and determine if it is marked as required or not
for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
{
    PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

    // Check if the field is a textbox field
    if (field is PdfTextBoxFieldWidget)
    {
        // Cast the field to a textbox field
        PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;

        // Check if the field name matches "username"
        if (textbox.Name == "username")
        {
            // Mark the field as required
            textbox.Required = true;
        }

        // Check if the field name matches "password2"
        if (textbox.Name == "password2")
        {
            // Mark the field as not required
            textbox.Required = false;
        }
    }
}
```

---

# Extract JavaScript from PDF Form Fields
## This code demonstrates how to extract JavaScript code from a PDF form field using Spire.PDF library.
```csharp
//Create a pdf document
PdfDocument pdf = new PdfDocument();

//Load a pdf document
pdf.LoadFromFile("input.pdf");

string js = null;

PdfFormWidget form = pdf.Form as PdfFormWidget;

//Iterate each field widget
for (int i = 0; i < form.FieldsWidget.List.Count; i++)
{
    PdfField field = form.FieldsWidget.List[i] as PdfField;
    if (field is PdfTextBoxFieldWidget)
    {
        PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;

        //Find the textbox named total
        if (textbox.Name == "total")
        {
            //Get the action
            PdfJavaScriptAction jsa = textbox.Actions.Calculate;

            if (jsa != null)
            {
                //Get JavaScript
                js = jsa.Script;
            }
        }
    }
}
```

---

# spire.pdf csharp form fields
## fill PDF form fields with different field types
```csharp
// Get pdf forms
PdfFormWidget formWidget = doc.Form as PdfFormWidget;

// Fill pdf form fields
for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
{
    PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

    // Check if the field is a textbox field
    if (field is PdfTextBoxFieldWidget)
    {
        PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;

        switch (textBoxField.Name)
        {
            case "email":
                textBoxField.Text = "support@e-iceblue.com";
                break;
            case "username":
                textBoxField.Text = "E-iceblue";
                break;
            case "password":
                textBoxField.Password = true;
                textBoxField.Text = "e-iceblue";
                break;
            case "password2":
                textBoxField.Password = true;
                textBoxField.Text = "e-iceblue";
                break;
            case "company_name ":
                textBoxField.Text = "E-iceblue";
                break;
            case "first_name":
                textBoxField.Text = "James";
                break;
            case "last_name":
                textBoxField.Text = "Chen";
                break;
            case "middle_name":
                textBoxField.Text = "J";
                break;
            case "address1":
                textBoxField.Text = "Chengdu";
                break;
            case "address2":
                textBoxField.Text = "Beijing";
                break;
            case "city":
                textBoxField.Text = "Shanghai";
                break;
            case "postal_code":
                textBoxField.Text = "11111";
                break;
            case "state":
                textBoxField.Text = "Shanghai";
                break;
            case "phone":
                textBoxField.Text = "1234567901";
                break;
            case "mobile_phone":
                textBoxField.Text = "123456789";
                break;
            case "fax":
                textBoxField.Text = "12121212";
                break;
        }
    }

    // Check if the field is a list box field
    if (field is PdfListBoxWidgetFieldWidget)
    {
        PdfListBoxWidgetFieldWidget listBoxField = field as PdfListBoxWidgetFieldWidget;

        switch (listBoxField.Name)
        {
            case "email_format":
                int[] index = { 1 };
                listBoxField.SelectedIndex = index;
                break;
        }
    }

    // Check if the field is a combo box field
    if (field is PdfComboBoxWidgetFieldWidget)
    {
        PdfComboBoxWidgetFieldWidget comBoxField = field as PdfComboBoxWidgetFieldWidget;

        switch (comBoxField.Name)
        {
            case "title":
                int[] items = { 0 };
                comBoxField.SelectedIndex = items;
                break;
        }
    }

    // Check if the field is a radio button field
    if (field is PdfRadioButtonListFieldWidget)
    {
        PdfRadioButtonListFieldWidget radioBtnField = field as PdfRadioButtonListFieldWidget;

        switch (radioBtnField.Name)
        {
            case "country":
                radioBtnField.SelectedIndex = 1;
                break;
        }
    }

    // Check if the field is a checkbox field
    if (field is PdfCheckBoxWidgetFieldWidget)
    {
        PdfCheckBoxWidgetFieldWidget checkBoxField = field as PdfCheckBoxWidgetFieldWidget;

        switch (checkBoxField.Name)
        {
            case "agreement_of_terms":
                checkBoxField.Checked = true;
                break;
        }
    }

    // Check if the field is a button field
    if (field is PdfButtonWidgetFieldWidget)
    {
        PdfButtonWidgetFieldWidget btnField = field as PdfButtonWidgetFieldWidget;

        switch (btnField.Name)
        {
            case "submit":
                btnField.Text = "Submit";
                break;
        }
    }
}
```

---

# Spire.PDF C# Button Field Image
## Fill image in PDF button field
```csharp
//Get pdf forms
PdfFormWidget form = pdf.Form as PdfFormWidget;

//Traverse all the forms
for (int i = 0; i < form.FieldsWidget.Count; i++)
{
    //If it is Button field
    if (form.FieldsWidget[i] is PdfButtonWidgetFieldWidget)
    {
        PdfButtonWidgetFieldWidget field = form.FieldsWidget[i] as PdfButtonWidgetFieldWidget;
        if (field.Name == "Button1")
        {
            //Set "true" to fit bounds
            field.IconLayout.IsFitBounds = true;

            //Fill the annotation rectangle exactly without its original aspect ratio
            field.IconLayout.ScaleMode = PdfButtonIconScaleMode.Anamorphic;

            //Fill an image
            field.SetButtonImage(PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-logo.png"));
        }
    }
}
```

---

# Spire.PDF CSharp XFA Form Fields
## Fill various types of XFA form fields in a PDF document
```csharp
// Load a Pdf file
PdfDocument doc = new PdfDocument();
doc.LoadFromFile("XFASample.pdf");

PdfFormWidget formWidget = doc.Form as PdfFormWidget;
List<XfaField> xfafields = formWidget.XFAForm.XfaFields;

// Iterate through each XFA field in the form
foreach (XfaField xfaField in xfafields)
{
    if (xfaField is XfaTextField)
    {
        XfaTextField textField = xfaField as XfaTextField;
        textField.Value = "E-iceblue";
    }
    if (xfaField is XfaDateTimeField)
    {
        XfaDateTimeField datetimeField = xfaField as XfaDateTimeField;
        datetimeField.Value = DateTime.Now.ToString();
    }
    if (xfaField is XfaCheckButtonField)
    {
        XfaCheckButtonField checkButtonField = xfaField as XfaCheckButtonField;
        checkButtonField.Checked = true;
    }
    if (xfaField is XfaChoiceListField)
    {
        XfaChoiceListField choiceListField = xfaField as XfaChoiceListField;
        choiceListField.SelectedItem = choiceListField.Items[0];
        choiceListField.SelectedItems.Add("NewItem");
    }
    if (xfaField is XfaDoubleField)
    {
        XfaDoubleField doubleField = xfaField as XfaDoubleField;
        doubleField.Value = 2.14;
    }
}

// Save the result pdf file
doc.SaveToFile("FillXfaField.pdf", FileFormat.PDF);
```

---

# spire.pdf xfa image field
## fill XFA image field with image in PDF document
```csharp
//Create a PdfDocument object
PdfDocument pdfDocument = new PdfDocument();

//Load PDF document
pdfDocument.LoadFromFile("XFAImageField.pdf");

PdfFormWidget form = pdfDocument.Form as PdfFormWidget;
if (form.XFAForm != null)
{
    //Get the xfa Fields  
    List<XfaField> xFields = form.XFAForm.XfaFields;
    for (int i = 0; i < xFields.Count; i++)
    {
        if (xFields[i] is XfaImageField)
        {
            //add image to ImageFiled
            XfaImageField xImageField = xFields[i] as XfaImageField;
            FileStream fileStream = new FileStream("E-logo.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            xImageField.Image = Image.FromStream(fileStream);
        }
    }
}
```

---

# Spire.PDF C# Form Field Processing
## Flatten form fields in PDF document
```csharp
// Create and load pdf document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Flatten form fields
doc.Form.IsFlatten = true;
```

---

# spire.pdf get form field coordinates
## retrieve coordinates of a text box field in pdf form
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load from file
doc.LoadFromFile("TextBoxSampleB.pdf");

//Get form fields
PdfFormWidget formWidget = doc.Form as PdfFormWidget;

//Get textbox
PdfTextBoxFieldWidget textbox = formWidget.FieldsWidget["Text1"] as PdfTextBoxFieldWidget;

//Get the location of the textbox
PointF location = textbox.Location;
```

---

# spire.pdf csharp form field
## get text field value from pdf form
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load from file
doc.LoadFromFile("TextBoxSampleB_1.pdf");

//Get form fields
PdfFormWidget formWidget = doc.Form as PdfFormWidget;

//Get textbox
PdfTextBoxFieldWidget textbox = formWidget.FieldsWidget["Text1"] as PdfTextBoxFieldWidget;

//Get the text of the textbox
String text = textbox.Text;

MessageBox.Show("The value of the field named " + textbox.Name + " is " + text);
```

---

# spire.pdf csharp extract javascript
## extract javascript from checkbox field in pdf
```csharp
//Get Pdf forms
PdfFormWidget fw = doc.Form as PdfFormWidget;

//Create StringBuilder
StringBuilder sb = new StringBuilder();

//Loop forms fields
for (int i = 0; i < fw.FieldsWidget.Count; i++)
{
    PdfField pdfField = fw.FieldsWidget[i];

    //Get PdfCheckBoxWidgetFieldWidget objects
    if (pdfField is PdfCheckBoxWidgetFieldWidget)
    {
        PdfCheckBoxWidgetFieldWidget checkBoxField = pdfField as PdfCheckBoxWidgetFieldWidget;
        PdfJavaScriptAction mousedown = (PdfJavaScriptAction)checkBoxField.Actions.MouseDown;

        //Get the JavaScript text
        sb.Append(mousedown.Script.ToString());
    }
}
```

---

# spire.pdf csharp get radio button style
## Extract and retrieve the button style of radio button fields from a PDF form
```csharp
//Open pdf document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile(input);

//Get the first page
PdfPageBase page = pdf.Pages[0];

//Get all form fields
PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

StringBuilder builder = new StringBuilder();

int num = 0;

//Loop through all fields
for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
{
    PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

    //Find the radio button field
    if (field is PdfRadioButtonListFieldWidget)
    {
        num++;
        PdfRadioButtonListFieldWidget radio = field as PdfRadioButtonListFieldWidget;

        //Get the button style
        PdfCheckBoxStyle buttonStyle = radio.ButtonStyle;
        builder.AppendLine(String.Format("The button style of Radio button {0} is: "+buttonStyle.ToString(),num));
    }
}
```

---

# spire.pdf csharp form fields
## extract values from all form fields in a PDF document
```csharp
// Create a StringBuilder object to store the result.
StringBuilder sb = new StringBuilder();

// Create a new PdfDocument object and load the PDF file.
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Get the form widget from the loaded PDF document.
PdfFormWidget formWidget = doc.Form as PdfFormWidget;

// Iterate through each field in the form.
for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
{
    // Get the current field.
    PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

    // Check if the field is a TextBox field.
    if (field is PdfTextBoxFieldWidget)
    {
        // Convert the field to a TextBox field.
        PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;

        // Get the text value of the TextBox.
        string text = textBoxField.Text;

        // Append the text value to the StringBuilder.
        sb.Append("The text in the textbox is " + text + "\r\n");
    }

    // Check if the field is a ListBox field.
    if (field is PdfListBoxWidgetFieldWidget)
    {
        // Convert the field to a ListBox field.
        PdfListBoxWidgetFieldWidget listBoxField = field as PdfListBoxWidgetFieldWidget;

        // Append a label for the ListBox items.
        sb.Append("Listbox items are \r\n");

        // Get the values of the ListBox.
        PdfListWidgetItemCollection items = listBoxField.Values;

        // Iterate through each item in the ListBox.
        foreach (PdfListWidgetItem item in items)
        {
            // Append the value of each item to the StringBuilder.
            sb.Append(item.Value + "\r\n");
        }

        // Get the selected value of the ListBox.
        string selectedValue = listBoxField.SelectedValue;

        // Append the selected value to the StringBuilder.
        sb.Append("The selected value in the listbox is " + selectedValue + "\r\n");
    }

    // Check if the field is a ComboBox field.
    if (field is PdfComboBoxWidgetFieldWidget)
    {
        // Convert the field to a ComboBox field.
        PdfComboBoxWidgetFieldWidget comBoxField = field as PdfComboBoxWidgetFieldWidget;

        // Append a label for the ComboBox items.
        sb.Append("ComboBox items are \r\n");

        // Get the values of the ComboBox.
        PdfListWidgetItemCollection items = comBoxField.Values;

        // Iterate through each item in the ComboBox.
        foreach (PdfListWidgetItem item in items)
        {
            // Append the value of each item to the StringBuilder.
            sb.Append(item.Value + "\r\n");
        }

        // Get the selected value of the ComboBox.
        string selectedValue = comBoxField.SelectedValue;

        // Append the selected value to the StringBuilder.
        sb.Append("The selected value in the ComboBox is " + selectedValue + "\r\n");
    }

    // Check if the field is a RadioButtonList field.
    if (field is PdfRadioButtonListFieldWidget)
    {
        // Convert the field to a RadioButtonList field.
        PdfRadioButtonListFieldWidget radioBtnField = field as PdfRadioButtonListFieldWidget;

        // Get the value of the selected radio button.
        string value = radioBtnField.Value;

        // Append the value to the StringBuilder.
        sb.Append("The value in the radioButtonField is " + value + "\r\n");
    }

    // Check if the field is a CheckBox field.
    if (field is PdfCheckBoxWidgetFieldWidget)
    {
        // Convert the field to a CheckBox field.
        PdfCheckBoxWidgetFieldWidget checkBoxField = field as PdfCheckBoxWidgetFieldWidget;

        // Get the checked state of the CheckBox.
        bool state = checkBoxField.Checked;

        // Append the checked state to the StringBuilder.
        sb.Append("If the checkBox is checked: " + state + "\r\n");
    }
}
```

---

# spire.pdf csharp form field
## modify PDF form field value
```csharp
// Get the form widget from the PDF document.
PdfFormWidget form = pdf.Form as PdfFormWidget;

// Iterate through each field in the form.
for (int i = 0; i < form.FieldsWidget.List.Count; i++)
{
    // Get the current field.
    PdfField field = form.FieldsWidget.List[i] as PdfField;

    // Check if the field is a TextBox field.
    if (field is PdfTextBoxFieldWidget)
    {
        // Convert the field to a TextBox field.
        PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;

        // Check if the TextBox field has a specific name.
        if (textbox.Name == "TextBox1")
        {
            // Modify the text value of TextBox1.
            textbox.Text = "New value";
        }
    }
}
```

---

# spire.pdf csharp form field
## modify form field visibility in PDF
```csharp
// Get the form widget from the loaded PDF document
PdfFormWidget form = pdf.Form as PdfFormWidget;

// Get the first field in the form
PdfField field = form.FieldsWidget.List[0] as Spire.Pdf.Fields.PdfField;

// Set the annotation flags for the field to the default value
field.AnnotationFlags = Spire.Pdf.Annotations.PdfAnnotationFlags.Default;

// Uncomment the following line if you want to set the field as hidden
// field.AnnotationFlags = Spire.Pdf.Annotations.PdfAnnotationFlags.Hidden; 
```

---

# Spire.PDF C# Required Field Recognition
## Identify required fields in a PDF form
```csharp
// Create a new instance of PdfDocument
PdfDocument doc = new PdfDocument();

// Load the PDF document
doc.LoadFromFile(input);

// Get the form widget from the loaded PDF document
PdfFormWidget formWidget = doc.Form as PdfFormWidget;

// Iterate through all the fields in the form
for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
{
    // Get the current field from the FieldsWidget list
    PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

    // Check if the field is required
    if (field.Required)
    {
        MessageBox.Show("The field named: " + field.Name + " is required");
    }
}
```

---

# Spire.PDF Form Field Removal
## Remove form fields from a PDF document
```csharp
//Create a PdfDocument
PdfDocument pdf = new PdfDocument();

//Get form from the document
PdfFormWidget formWidget = pdf.Form as PdfFormWidget;
if (formWidget != null)
{
    for (int i = 0; i <= formWidget.FieldsWidget.List.Count - 1; i++)
    {
        //Case 1: Remove the first form field
        if (i == 0)
        {
            PdfField field = formWidget.FieldsWidget.List[i] as PdfField;
            formWidget.FieldsWidget.Remove(field);
            break;
        }
    }
    //Case 2: Remove all form fields
    //formWidget.FieldsWidget.Clear();
}
```

---

# spire.pdf csharp radio button selection
## select radio button item in pdf form
```csharp
// Get the form widget from the loaded PDF document
PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

// Iterate through all the fields in the form
for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
{
    // Get the current field from the FieldsWidget list
    PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

    // Check if the field is a radio button list field
    if (field is PdfRadioButtonListFieldWidget)
    {
        // Cast the field to PdfRadioButtonListFieldWidget
        PdfRadioButtonListFieldWidget radioButton = field as PdfRadioButtonListFieldWidget;

        // Check if the radio button field name matches "RadioButton"
        if (radioButton.Name == "RadioButton")
        {
            // Select the second item in the radio button list
            radioButton.SelectedIndex = 1;
        }
    }
}
```

---

# spire.pdf csharp checkbox
## set export value for checkbox fields in pdf
```csharp
// Get the form widget from the loaded PDF document
PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

// Initialize a counter variable
int count = 1;

// Traverse all fields in the FieldsWidget
foreach (PdfFieldWidget field in formWidget.FieldsWidget)
{
    // Check if the field is a checkbox
    if (field is PdfCheckBoxWidgetFieldWidget)
    {
        // Cast the field to PdfCheckBoxWidgetFieldWidget
        PdfCheckBoxWidgetFieldWidget checkbox = field as PdfCheckBoxWidgetFieldWidget;

        // Set the export value for the checkbox
        checkbox.SetExportValue("True" + (count++));
    }
}
```

---

# Spire.PDF C# Form Field Font Setting
## Set font for PDF form field
```csharp
//Get form fields
PdfFormWidget formWidget = doc.Form as PdfFormWidget;

//Get textbox
PdfTextBoxFieldWidget textbox = formWidget.FieldsWidget["Text1"] as PdfTextBoxFieldWidget;

//Set the font for textbox
textbox.Font = new PdfTrueTypeFont(new Font("Tahoma", 12), true);

//Set text
textbox.Text = "Hello World";
```

---

# Spire.PDF Show/Hide Form Fields
## This code demonstrates how to hide PDF form fields on mouse down action
```csharp
// Iterate through all the pages in the PDF document
for (int c = 0; c < pdf.Pages.Count; c++)
{
    // Get the form widget from the PDF document
    PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

    // Iterate through all the fields in the form
    for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
    {
        // Get the current field from the FieldsWidget list
        PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

        // Check if the field is a TextBoxField
        if (field is PdfTextBoxFieldWidget)
        {
            // Cast the field to PdfTextBoxFieldWidget
            PdfTextBoxFieldWidget widget = field as PdfTextBoxFieldWidget;

            // Create a new hide action for the field
            PdfHideAction hideAction = new PdfHideAction(widget.Name, true);

            // Set the mouse down action of the TextBoxField to the hide action
            widget.MouseDown = hideAction;
        }
    }
}
```

---

# spire.pdf csharp datetime stamp
## add date time stamp to pdf document
```csharp
// Get the first page of the document
PdfPageBase page = document.Pages[0];

// Set the font and brush for the text
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Regular), true);
PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);

// Generate a string representing the current date and time
String timeString = DateTime.Now.ToString("MM/dd/yy hh:mm:ss tt ");

// Create a template with specified dimensions
PdfTemplate template = new PdfTemplate(140, 15);

// Define a rectangle to position the template on the page
RectangleF rect = new RectangleF(new PointF(page.ActualSize.Width - template.Width - 10, page.ActualSize.Height - template.Height - 10), template.Size);

// Draw the time string onto the template
template.Graphics.DrawString(timeString, font, brush, new PointF(0, 0));

// Create a rubber stamp annotation
PdfRubberStampAnnotation stamp = new PdfRubberStampAnnotation(rect);

// Create a custom appearance for the stamp annotation
PdfAppearance appearance = new PdfAppearance(stamp);
appearance.Normal = template;

// Assign the custom appearance to the stamp annotation
stamp.Appearance = appearance;

// Add the stamp annotation to the page's annotations widget
page.Annotations.Add(stamp);
```

---

# spire.pdf csharp headers
## add different headers to pdf pages
```csharp
// Define header texts
string header1 = "Header 1";
string header2 = "Header 2";

// Define the font style for the headers
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 15f, FontStyle.Bold));

// Define the brush color for the headers
PdfBrush brush = PdfBrushes.Red;

// Define the rectangle to position the header on the first page
RectangleF rect = new RectangleF(new PointF(0, 20), new SizeF(doc.PageSettings.Size.Width, 50f));

// Define the string format for the headers, aligning them in the center
PdfStringFormat format = new PdfStringFormat();
format.Alignment = PdfTextAlignment.Center;

// Draw the first header with the defined font, brush, rectangle, and format on the first page of the document
doc.Pages[0].Canvas.DrawString(header1, font, brush, rect, format);

// Change the font style and brush color for the second header
font = new PdfTrueTypeFont(new Font("Aleo", 15f, FontStyle.Regular));
brush = PdfBrushes.Black;

// Change the alignment of the string format to left alignment for the second header
format.Alignment = PdfTextAlignment.Left;

// Draw the second header with the updated font, brush, rectangle, and format on the second page of the document
doc.Pages[1].Canvas.DrawString(header2, font, brush, rect, format);
```

---

# Spire.PDF Image Stamp
## Add an image stamp to PDF document
```csharp
// Create a rubber stamp annotation with a specified rectangle for its size and position
PdfRubberStampAnnotation loStamp = new PdfRubberStampAnnotation(new RectangleF(new PointF(0, 0), new SizeF(60, 60)));

// Create an instance of PdfAppearance for the rubber stamp annotation
PdfAppearance loApprearance = new PdfAppearance(loStamp);

// Load an image file to be used as the stamp
PdfImage image = PdfImage.FromFile(@"image stamp.jpg");

// Create a template with specific dimensions
PdfTemplate template = new PdfTemplate(210, 210);

// Draw the loaded image onto the template
template.Graphics.DrawImage(image, 60, 60);

// Set the normal appearance of the stamp to use the created template
loApprearance.Normal = template;

// Assign the custom appearance to the rubber stamp annotation
loStamp.Appearance = loApprearance;

// Add the rubber stamp annotation to the page's annotations widget
page.Annotations.Add(loStamp);
```

---

# spire.pdf csharp text stamp
## add text stamp to pdf document
```csharp
// Create a template with specific dimensions to hold the stamp
PdfTemplate template = new PdfTemplate(125, 55);

// Set the font, brush, and pen for drawing the stamp
PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Elephant", 10f, FontStyle.Italic), true);
PdfSolidBrush brush = new PdfSolidBrush(Color.DarkRed);
PdfPen pen = new PdfPen(brush);

// Define a rectangle that represents the bounds of the stamp
RectangleF rectangle = new RectangleF(new PointF(5, 5), template.Size);

// Define the corner radius for the stamp's rounded corners
int CornerRadius = 20;

// Create a path for the stamp shape using arcs and lines
PdfPath path = new PdfPath();
path.AddArc(template.GetBounds().X, template.GetBounds().Y, CornerRadius, CornerRadius, 180, 90);
path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y, CornerRadius, CornerRadius, 270, 90);
path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
path.AddArc(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
path.AddLine(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, template.GetBounds().X, template.GetBounds().Y + CornerRadius / 2);

// Draw the stamp shape on the template
template.Graphics.DrawPath(pen, path);

// Draw the stamp text on the template
String s1 = "REVISED\n";
String s2 = "by E-iceblue at " + DateTime.Now.ToString("MM dd, yyyy");
template.Graphics.DrawString(s1, font1, brush, new PointF(5, 10));
PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Lucida Sans Unicode", 9f, FontStyle.Bold), true);
template.Graphics.DrawString(s2, font2, brush, new PointF(2, 30));

// Create a rubber stamp annotation with the specified rectangle for its size and position
PdfRubberStampAnnotation stamp = new PdfRubberStampAnnotation(rectangle);

// Create an appearance object for the rubber stamp annotation
PdfAppearance apprearance = new PdfAppearance(stamp);

// Set the normal appearance of the stamp to use the created template
apprearance.Normal = template;

// Assign the custom appearance to the rubber stamp annotation
stamp.Appearance = apprearance;

// Add the rubber stamp annotation to the page's annotations widget
page.Annotations.Add(stamp);
```

---

# spire.pdf csharp tiling background
## Add tiling background image to PDF pages with transparency
```csharp
// Create a PdfTilingBrush with a size relative to the page canvas
PdfTilingBrush brush = new PdfTilingBrush(new SizeF(page.Canvas.Size.Width / 3, page.Canvas.Size.Height / 5));

// Set the transparency of the brush graphics
brush.Graphics.SetTransparency(0.3f);

// Draw the image onto the brush graphics, centered within the brush
brush.Graphics.DrawImage(image, new PointF((brush.Size.Width - image.Width) / 2, (brush.Size.Height - image.Height) / 2));

// Use the brush to draw a rectangle on the page canvas, covering the entire page area
page.Canvas.DrawRectangle(brush, new RectangleF(new PointF(0, 0), page.Canvas.Size));
```

---

# Spire.PDF C# Fill and Stroke Text
## Add rotated text with stroke to PDF page
```csharp
// Get the first page of the document
PdfPageBase page = doc.Pages[0];

// Define a PDF pen with gray color
PdfPen pen = new PdfPen(Color.Gray);

// Save the current graphics state
PdfGraphicsState state = page.Canvas.Save();

// Rotate the page canvas by -20 degrees
page.Canvas.RotateTransform(-20);

// Create a PdfStringFormat object and set the character spacing to 5f
PdfStringFormat format = new PdfStringFormat();
format.CharacterSpacing = 5f;

// Draw the string "E-ICEBLUE" on the page using a specified font, pen, position, and format
page.Canvas.DrawString("E-ICEBLUE", new PdfFont(PdfFontFamily.Helvetica, 45f), pen, 0, 500f, format);

// Restore the graphics state to its previous state
page.Canvas.Restore(state);
```

---

# spire.pdf csharp header footer
## add header and footer to pdf document
```csharp
// Define the brush for text drawing
PdfBrush brush = PdfBrushes.Black;

// Define the pen for line drawing
PdfPen pen = new PdfPen(brush, 0.75f);

// Define the font for text drawing
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Italic), true);

// Define the string format for right-aligned text
PdfStringFormat rightAlign = new PdfStringFormat(PdfTextAlignment.Right);

// Define the string format for left-aligned text
PdfStringFormat leftAlign = new PdfStringFormat(PdfTextAlignment.Left);

rightAlign.MeasureTrailingSpaces = true;
leftAlign.MeasureTrailingSpaces = true;

// Get the page margins of the document
PdfMargins margin = doc.PageSettings.Margins;

// Calculate the spacing between lines
float space = font.Height * 0.75f;

// Initialize variables for position and width calculation
float x = 0;
float y = 0;
float width = 0;

foreach (PdfPageBase page in doc.Pages)
{
    // Add a new page to the new PDF document
    newPage = newPdf.Pages.Add(page.Size, new PdfMargins(0));

    // Set transparency for the canvas
    newPage.Canvas.SetTransparency(0.5f);

    // Calculate the position and width for header elements
    x = margin.Left;
    width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
    y = margin.Top - space;

    // Draw a line as a header separator
    newPage.Canvas.DrawLine(pen, x, y + 15, x + width, y + 15);
    y = y + 10 - font.Height;

    // Load the header image
    PdfImage headerImage = PdfImage.FromFile(@"..\..\..\..\..\..\..\Data\Header.png");

    // Draw the header image on the new page
    newPage.Canvas.DrawImage(headerImage, new PointF(0, 0));

    // Draw the header text on the new page with right alignment
    newPage.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, rightAlign);

    // Load the footer image
    PdfImage footerImage = PdfImage.FromFile(@"..\..\..\..\..\..\..\Data\Footer.png");

    // Draw the footer image on the new page
    newPage.Canvas.DrawImage(footerImage, new PointF(0, newPage.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height));

    // Change the font and brush for the footer text
    brush = PdfBrushes.DarkBlue;
    font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Bold), true);
    y = newPage.Canvas.ClientSize.Height - margin.Bottom - font.Height;

    // Draw the footer text on the new page with left alignment
    newPage.Canvas.DrawString("Created by E-iceblue Co,.Ltd", font, brush, x, y, leftAlign);

    // Reset the transparency of the canvas
    newPage.Canvas.SetTransparency(1);

    // Draw the original page content onto the new page
    page.CreateTemplate().Draw(newPage.Canvas, new PointF(0, 0));
}
```

---

# Spire.PDF C# Image and Page Number
## Add image in header and page numbers in footer of PDF document
```csharp
//create a PDF document
PdfDocument doc = new PdfDocument();
doc.PageSettings.Size = PdfPageSize.A4;

//reset the default margins to 0
doc.PageSettings.Margins = new PdfMargins(0);

//create a PdfMargins object, the parameters indicate the page margins you want to set
PdfMargins margins = new PdfMargins(50, 50, 50, 50);

//get page size
SizeF pageSize = doc.PageSettings.Size;

//create a header template with content and apply it to page template
doc.Template.Top = CreateHeaderTemplate(doc, margins, pageSize);

//create a footer template with content and apply it to page template
doc.Template.Bottom = CreateFooterTemplate(doc, margins, pageSize);

//apply blank templates to other parts of page template
doc.Template.Left = new PdfPageTemplateElement(margins.Left, doc.PageSettings.Size.Height);
doc.Template.Right = new PdfPageTemplateElement(margins.Right, doc.PageSettings.Size.Height);

//Create one page
PdfPageBase page = doc.Pages.Add();            

//Draw the text
page.Canvas.DrawString("Hello, World!",
                       new PdfFont(PdfFontFamily.Helvetica, 30f),
                       new PdfSolidBrush(Color.Black),
                       10, 10);

private PdfPageTemplateElement CreateHeaderTemplate(PdfDocument doc, PdfMargins margins, SizeF pageSize)
{
    //create a PdfPageTemplateElement object as header space
    PdfPageTemplateElement headerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Top);
    headerSpace.Foreground = false;

    //declare two float variables
    float x = margins.Left;
    float y = 0;

    //draw image in header space 
    PdfImage headerImage = PdfImage.FromFile("../../../../../../../Data/E-iceblueLogo.png");
    float width = headerImage.Width / 2;
    float height = headerImage.Height / 2;
    headerSpace.Graphics.DrawImage(headerImage, x, margins.Top - height - 5, width, height);

    //draw line in header space
    PdfPen pen = new PdfPen(PdfBrushes.LightGray, 1);
    headerSpace.Graphics.DrawLine(pen, x, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2);

    //return headerSpace
    return headerSpace;
}

private PdfPageTemplateElement CreateFooterTemplate(PdfDocument doc, PdfMargins margins, SizeF pageSize)
{
    // Create a PdfPageTemplateElement object to serve as the footer space
    PdfPageTemplateElement footerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Bottom);
    footerSpace.Foreground = false;

    // Declare two float variables for positioning
    float x = margins.Left;
    float y = 0;

    // Draw a line in the footer space using a gray pen
    PdfPen pen = new PdfPen(PdfBrushes.Gray, 1);
    footerSpace.Graphics.DrawLine(pen, x, y, pageSize.Width - x, y);

    // Draw text in the footer space
    y = y + 5;

    // Define the font for the text
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 10f), true);

    // Create a dynamic field for the page number
    PdfPageNumberField number = new PdfPageNumberField();

    // Create a dynamic field for the page count
    PdfPageCountField count = new PdfPageCountField();

    // Create a composite field that combines the page number and page count fields
    PdfCompositeField compositeField = new PdfCompositeField(font, PdfBrushes.Black, "Page {0} of {1}", number, count);

    // Set the string format for the composite field (left-aligned, top vertical alignment)
    compositeField.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);

    // Measure the size of the composite field to determine its bounds
    SizeF size = font.MeasureString(compositeField.Text);
    compositeField.Bounds = new RectangleF(x, y, size.Width, size.Height);

    // Draw the composite field on the footer space
    compositeField.Draw(footerSpace.Graphics);

    // Return the footer space element
    return footerSpace;
}
```

---

# Spire.PDF C# Template
## Create header and footer templates with image and text
```csharp
//Get the first page
PdfPageBase page = doc.Pages[0];

//Get the margins of Pdf
PdfMargins margin = doc.PageSettings.Margins;

//Define font and brush
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Impact", 14f, FontStyle.Regular));
PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);

//Load an image
PdfImage image = PdfImage.FromFile("image.png");

//Specify the image size
SizeF imageSize = new SizeF(image.Width / 2, image.Height / 2);

//Create a header template
PdfTemplate headerTemplate = new PdfTemplate(page.ActualSize.Width - margin.Left - margin.Right, imageSize.Height);

//Draw the image in the template
headerTemplate.Graphics.DrawImage(image, new PointF(0, 0), imageSize);

//Create a rectangle
RectangleF rect = headerTemplate.GetBounds();

//string format
PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

//Draw a string in the template
headerTemplate.Graphics.DrawString("Header", font, brush, rect, format1);

//Create a footer template and draw a text
PdfTemplate footerTemplate = new PdfTemplate(page.ActualSize.Width - margin.Left - margin.Right, imageSize.Height);
PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
footerTemplate.Graphics.DrawString("Footer", font, brush, rect, format2);

float x = margin.Left;
float y = 0;

//Draw the header template on page at specified location
page.Canvas.DrawTemplate(headerTemplate, new PointF(x, y));

//Draw the footer template on page at specified location
y = page.ActualSize.Height - footerTemplate.Height - 10;
page.Canvas.DrawTemplate(footerTemplate, new PointF(x, y));
```

---

# Spire.PDF C# Image Watermark
## Add an image as a background watermark to the first page of a PDF document
```csharp
// Create a PDF document and load a file from the disk.
PdfDocument doc = new PdfDocument();
doc.LoadFromFile("ImageWaterMark.pdf");

// Get the first page from the document.
PdfPageBase page = doc.Pages[0];

// Load the image from a file.
Image img = Image.FromFile("Background.png");

// Set the loaded image as the background image of the page.
page.BackgroundImage = img;
```

---

# Spire.PDF C# Image Watermark
## Add an image watermark to a PDF document with transparency and scaling
```csharp
// Load an image from a file.
Image image = Image.FromFile("path_to_image_file");

// Adjust the size of the image.
int width = image.Width;
int height = image.Height;
float scale = 1.5f;
Size size = new Size((int)(width * scale), (int)(height * scale));
Bitmap scaledImage = new Bitmap(image, size);

// Convert the scaled image to a PDF image.
PdfImage pdfImage = PdfImage.FromImage(scaledImage);

// Get the first page from the document.
PdfPageBase page = doc.Pages[0];

// Specify the position on the page to insert the image.
PointF position = new PointF(160, 260);

// Save the current state of the canvas and set transparency for the image.
page.Canvas.Save();
page.Canvas.SetTransparency(0.5f, 0.5f, PdfBlendMode.Multiply);

// Draw the image on the page using the specified position.
page.Canvas.DrawImage(pdfImage, position);

// Restore the previous state of the canvas.
page.Canvas.Restore();
```

---

# Spire.PDF Inline Text and Image
## Add inline text and image elements to PDF page
```csharp
// Define text and image
string text1 = "Spire.Pdf is a robust component by";
string text2 = "Technology Co., Ltd.";

// Define font and brush
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Impact", 10f));
PdfBrush brush = PdfBrushes.DarkGray;

// Measure the size of the text
SizeF s1 = font.MeasureString(text1);
SizeF s2 = font.MeasureString(text2);

float x = 10;
float y = 10;

// Define the size of the image
SizeF imgSize = new SizeF(image.Width / 2, image.Height / 2);

// Define the rectangle and string format
SizeF size = new SizeF(s1.Width, imgSize.Width);
RectangleF rect1 = new RectangleF(new PointF(x, y), size);
PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);

// Draw the text1
page.Canvas.DrawString(text1, font, brush, rect1, format);

// Draw the image
x += s1.Width;
page.Canvas.DrawImage(image, new PointF(x, y), imgSize);

// Draw the text2
x += imgSize.Width;
size = new SizeF(s2.Width, imgSize.Height);
rect1 = new RectangleF(new PointF(x, y), size);
page.Canvas.DrawString(text2, font, brush, rect1, format);
```

---

# PDF Page Number Footer
## Add page numbers to the footer of PDF documents
```csharp
private void DrawPageNumber(PdfDocument doc, PdfMargins margin, int startNumber, int pageCount)
{
    // Iterate through each page in the document
    foreach (PdfPageBase page in doc.Pages)
    {
        // Set transparency for the canvas
        page.Canvas.SetTransparency(0.5f);

        // Define brush, pen, font, and string format for drawing the page number
        PdfBrush brush = PdfBrushes.Black;
        PdfPen pen = new PdfPen(brush, 0.75f);
        PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Italic), true);
        PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
        format.MeasureTrailingSpaces = true;

        // Calculate the spacing between lines
        float space = font.Height * 0.75f;

        // Define the initial position
        float x = margin.Left;
        float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
        float y = page.Canvas.ClientSize.Height - margin.Bottom + space;

        // Draw a line above the page number
        page.Canvas.DrawLine(pen, x, y, x + width, y);

        // Adjust the position and draw the page number label
        y = y + 1;
        String numberLabel = String.Format("{0} of {1}", startNumber++, pageCount);
        page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format);

        // Reset the transparency for the canvas
        page.Canvas.SetTransparency(1);
    }
}
```

---

# spire.pdf csharp stamp properties
## set properties for rubber stamp annotations in pdf
```csharp
// Get the first page from the document.
PdfPageBase page = pdf.Pages[0];

// Traverse through each annotation widget on the page.
foreach (PdfAnnotation annotation in page.Annotations.List)
{
    // Check if the current annotation is a rubber stamp annotation.
    if (annotation is PdfRubberStampAnnotationWidget)
    {
        // Cast the annotation to a PdfRubberStampAnnotationWidget.
        PdfRubberStampAnnotationWidget stamp = annotation as PdfRubberStampAnnotationWidget;

        // Set properties for the rubber stamp annotation.
        stamp.Author = "TestUser";
        stamp.Subject = "E-iceblue";
        stamp.CreationDate = DateTime.Now;
        stamp.ModifiedDate = DateTime.Now;
    }
}
```

---

# spire.pdf csharp table in header footer
## create and draw table in pdf header footer
```csharp
private void DrawTableInHeaderFooter(PdfDocument doc)
{
    // Define the data for the table.
    String[] data = {
                            "Column1;Column2",
                            "Spire.PDF for .NET;Spire.PDF for JAVA",
                        };

    float y = 20;
    PdfBrush brush = PdfBrushes.Black;

    // Iterate through each page in the document.
    foreach (PdfPageBase page in doc.Pages)
    {
        // Prepare the data source for the table.
        String[][] dataSource = new String[data.Length][];
        for (int i = 0; i < data.Length; i++)
        {
            dataSource[i] = data[i].Split(';');
        }

        // Create a PDF table.
        PdfTable table = new PdfTable();
        table.Style.CellPadding = 2;
        table.Style.BorderPen = new PdfPen(brush, 0.1f);
        table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
        table.Style.HeaderSource = PdfHeaderSource.Rows;
        table.Style.HeaderRowCount = 1;
        table.Style.ShowHeader = true;
        table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
        table.DataSource = dataSource;

        // Set the string format for each column.
        foreach (PdfColumn column in table.Columns)
        {
            column.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
        }

        // Draw the table on the page.
        table.Draw(page, new PointF(0, y));
    }
}
```

---

# spire.pdf csharp text watermark
## adding text watermark to pdf document
```csharp
// Create a tiling brush for drawing a text watermark.
PdfTilingBrush brush = new PdfTilingBrush(new SizeF(page.Canvas.ClientSize.Width / 2, page.Canvas.ClientSize.Height / 3));

// Set transparency for the brush graphics.
brush.Graphics.SetTransparency(0.3f);

// Save the current state of the brush graphics.
brush.Graphics.Save();

// Translate and rotate the brush graphics to position the watermark.
brush.Graphics.TranslateTransform(brush.Size.Width / 2, brush.Size.Height / 2);
brush.Graphics.RotateTransform(-45);

// Draw the text watermark using the brush graphics.
brush.Graphics.DrawString("Spire.Pdf Demo",
    new PdfFont(PdfFontFamily.Helvetica, 24), PdfBrushes.Violet, 0, 0,
    new PdfStringFormat(PdfTextAlignment.Center));

// Restore the previous state of the brush graphics.
brush.Graphics.Restore();

// Reset the transparency to fully opaque.
brush.Graphics.SetTransparency(1);

// Draw a rectangle filled with the tiling brush as the watermark on the page.
page.Canvas.DrawRectangle(brush, new RectangleF(new PointF(0, 0), page.Canvas.ClientSize));
```

---

# spire.pdf csharp digital signature
## add image signature to pdf document
```csharp
// Load a PDF document.
PdfDocument doc = new PdfDocument();
doc.LoadFromFile("input.pdf");

// Load the X509 certificate for signature.
X509Certificate2 x509 = new X509Certificate2("certificate.pfx", "password");

// Create an instance of PdfOrdinarySignatureMaker using the loaded document and certificate.
PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(doc, x509);

// Create an instance of PdfCustomSignatureAppearance as the appearance for the signature.
IPdfSignatureAppearance signatureAppearance = new PdfCustomSignatureAppearance();

// Make the signature with a specified name and the custom appearance.
signatureMaker.MakeSignature("Signature", signatureAppearance);

public class PdfCustomSignatureAppearance : IPdfSignatureAppearance
{
    public void Generate(PdfCanvas g)
    {
        // Load an image for the signature appearance.
        Image image = Image.FromFile("signature.png");

        // Draw the image on the canvas at the specified position.
        g.DrawImage(PdfImage.FromImage(image), new PointF(0, 0));
    }
}
```

---

# Spire.PDF Invisible Digital Signature
## Add an invisible digital signature to a PDF document

```csharp
// Create a new PDF document.
PdfDocument pdf = new PdfDocument();

// Load the input PDF file from the disk.
pdf.LoadFromFile("input.pdf");

// Create an X509Certificate2 object by loading the certificate file with the specified password.
X509Certificate2 x509 = new X509Certificate2("certificate.pfx", "password");

// Create an instance of PdfOrdinarySignatureMaker using the loaded document and certificate.
PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(pdf, x509);

// Create an invisible signature with the specified name.
signatureMaker.MakeSignature("signatureName");

// Save the modified PDF document to the specified output file.
pdf.SaveToFile("output.pdf", FileFormat.PDF);
```

---

# Spire.PDF Digital Signatures
## Add multiple digital signatures to a PDF document
```csharp
// Create a new PDF document
PdfDocument document = new PdfDocument();

// Load the existing PDF document
document.LoadFromFile("AddMultipleSignatures.pdf");

// Create an X509Certificate2 object by loading the certificate file
X509Certificate2 x509 = new X509Certificate2("gary.pfx", "e-iceblue");

// Create an instance of PdfOrdinarySignatureMaker
PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(document, x509);

// Set the appearance for the signature
PdfSignatureAppearance signatureAppearance = new PdfSignatureAppearance(signatureMaker.Signature);
signatureAppearance.NameLabel = "Signer:";
signatureAppearance.ContactInfoLabel = "ContactInfo:";
signatureAppearance.LocationLabel = "Location:";
signatureAppearance.ReasonLabel = "Reason:";

// Set details for the first signature
PdfSignature signature1 = signatureMaker.Signature;
signature1.Name = "Tom";
signature1.ContactInfo = "Tom Tang";
signature1.Location = "China";
signature1.Reason = "protect document data";

// Add the first signature to the specified page
signatureMaker.MakeSignature("Signature1", document.Pages[0], 100, 300, 120, 70, signatureAppearance);

// Set details for the second signature
PdfSignature signature2 = signatureMaker.Signature;
signature2.Name = "Bob";
signature2.ContactInfo = "Bob Li";
signature2.Location = "China";
signature2.Reason = "protect document data";

// Add the second signature to the specified page
signatureMaker.MakeSignature("Signature2", document.Pages[0], 400, 300, 120, 70, signatureAppearance);

// Save the modified PDF document
document.SaveToFile("AddMultipleSignatures_result.pdf", FileFormat.PDF);
```

---

# spire.pdf csharp seam seals
## add segmented seal images to pdf pages
```csharp
// Create a unit converter for PDF
PdfUnitConvertor convert = new PdfUnitConvertor();
PdfPageBase pageBase = null;

// Get the segmented seal image
Image[] images = GetImage(doc.Pages.Count);
float x = 0;
float y = 0;

// Draw the picture to the designated location on the PDF page
for (int i = 0; i < doc.Pages.Count; i++)
{
    pageBase = doc.Pages[i];
    x = pageBase.Size.Width - convert.ConvertToPixels(images[i].Width, PdfGraphicsUnit.Point) + 40;
    y = pageBase.Size.Height / 2;
    pageBase.Canvas.DrawImage(PdfImage.FromImage(images[i]), new PointF(x, y));
}

// Define the GetImage method to segment the seal image according to the number of PDF pages
static Image[] GetImage(int num)
{
    // Create a list to store segmented images
    List<Image> lists = new List<Image>();

    // Load the original seal image
    Image image = Image.FromFile(@"SealImage.jpg");

    // Calculate the width of each segmented image based on the number of pages
    int w = image.Width / num;

    // Initialize a Bitmap object
    Bitmap bitmap = null;

    // Iterate through each segment
    for (int i = 0; i < num; i++)
    {
        // Create a new Bitmap with the calculated width and the height of the original image
        bitmap = new Bitmap(w, image.Height);

        // Create a Graphics object from the Bitmap to draw on it
        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
        {
            // Clear the graphics surface with a white background
            g.Clear(Color.White);

            // Define a rectangle to specify the portion of the original image to be drawn on the segment
            Rectangle rect = new Rectangle(i * w, 0, w, image.Height);

            // Draw the portion of the original image onto the segment
            g.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), rect, GraphicsUnit.Pixel);
        }

        // Add the segmented image to the list
        lists.Add(bitmap);
    }

    // Convert the list of segmented images to an array and return it
    return lists.ToArray();
}
```

---

# Spire.PDF Digital Signature with Validity Check
## Add validity check mark to digital signature in PDF
```csharp
// Create a PdfCertificate object using the PFX file and its password
PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

// Create a PdfOrdinarySignatureMaker object with the loaded PDF document and the certificate
PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(pdf, cert);

// Set Acro6 layers to false
signatureMaker.SetAcro6Layers(false);

// Create a signature with the specified signer name on the first page of the PDF document,
// positioned at coordinates (100, 100) with a width of 120 and height of 160
signatureMaker.MakeSignature("signName", pdf.Pages[0], 100, 100, 120, 160);
```

---

# spire.pdf csharp security permissions
## configure PDF security settings and encryption
```csharp
// Define user and owner passwords
string userPassword = "";
string ownerPassword = "owner";

// Create a security policy with the specified passwords
PdfSecurityPolicy securityPolicy = new PdfPasswordSecurityPolicy(userPassword, ownerPassword);

// Set the encryption algorithm to AES 128-bit
securityPolicy.EncryptionAlgorithm = PdfEncryptionAlgorithm.AES_128;

// Allow printing of the document
securityPolicy.DocumentPrivilege.AllowPrint = true;

// Allow filling form fields in the document
securityPolicy.DocumentPrivilege.AllowFillFormFields = true;

// Allow copying content from the document
securityPolicy.DocumentPrivilege.AllowContentCopying = true;

// Encrypt the PDF document using the specified security policy
pdf.Encrypt(securityPolicy);
```

---

# Spire.PDF C# Password Protection Check
## Check if a PDF document is password protected
```csharp
// Check whether the input pdf document is password protected
bool isProtected = PdfDocument.IsPasswordProtected(@"..\..\..\..\..\..\Data\CheckPasswordProtection.pdf");

// Show the result by message box
MessageBox.Show("The pdf is " + (isProtected ? "password " : "not password ") + "protected!");
```

---

# spire.pdf csharp custom signature
## create a custom signature with graphics in a PDF document
```csharp
// Create a certificate for the digital signature
PdfCertificate cert = new PdfCertificate("certificate.pfx", "password");

// Create a new PdfSignature object with the document, page, certificate, and identifier
PdfSignature signature = new PdfSignature(doc, page, cert, "demo");

// Set the bounds (position and size) of the signature on the page
signature.Bounds = new RectangleF(50, 600, 200, 200);

// Configure custom graphics for the signature area using the DrawGraphics method
signature.ConfigureCustomGraphics(DrawGraphics);

// Method to draw custom graphics within the signature area
private void DrawGraphics(PdfCanvas g)
{
    // Create a PdfTrueTypeFont object
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 18f));

    // Specify the text to be drawn
    string text = "Signature information";

    // Measure the height of the font
    float heightY = font.MeasureString(text).Height;

    // Define the starting point for drawing the string
    PointF point1 = new PointF(0, 0);

    // Draw the string using the specified font, brush color, and position
    g.DrawString(text, font, PdfBrushes.Red, point1);

    // Define the starting point for drawing the image
    PointF point2 = new PointF(0, heightY + 10);

    // Draw the image
    g.DrawImage(PdfImage.FromFile("logo.png"), point2);
}
```

---

# PDF Decryption
## Decrypt a password-protected PDF document using Spire.PDF
```csharp
// Create a PDF document object
PdfDocument doc = new PdfDocument();

// Open the encrypted document with password
doc.LoadFromFile(encryptedPdf, "test");

// Decrypt the document
doc.Decrypt();

// Save the decrypted PDF file
doc.SaveToFile("Decryption.pdf", FileFormat.PDF);
```

---

# spire.pdf password determination
## determine correct password for encrypted pdf document
```csharp
// Define an array of passwords to be tested
String[] passwords = new String[5] { "password1", "password2", "password3", "test", "sample" };

// Iterate through each password in the array
for (int passwordcount = 0; passwordcount < passwords.Length; passwordcount++)
{
    try
    {
        // Create a new PdfDocument object
        PdfDocument doc = new PdfDocument();

        // Load the PDF document from the file using the current password from the array
        doc.LoadFromFile(filePath, passwords[passwordcount]);

        // Print a message indicating that the password is correct
        MessageBox.Show("Password = " + passwords[passwordcount] + "  is correct");
    }
    catch (Exception ex)
    {
        // Print a message indicating that the password is not correct
        MessageBox.Show("Password = " + passwords[passwordcount] + "  is not correct");
    }
}
```

---

# spire.pdf csharp digital signature
## add digital signature to pdf document
```csharp
// Load the certificate for digital signature
PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

// Create a PdfSignature object with the document, the first page of the document, the certificate, and an identifier
PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature0");
signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(270, 90));

// Load the sign image source
signature.SignImageSource = PdfImage.FromFile(imagePath);

// Set the display mode of graphics for the signature
signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

// Set the label and value for signer's name
signature.NameLabel = "Signer:";
signature.Name = "Gary";

// Set the label and value for contact information
signature.ContactInfoLabel = "ContactInfo:";
signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

// Set the label and value for the signing date
signature.DateLabel = "Date:";
signature.Date = DateTime.Now;

// Set the label and value for the location information
signature.LocationInfoLabel = "Location:";
signature.LocationInfo = "Chengdu";

// Set the label and value for the reason of signing
signature.ReasonLabel = "Reason: ";
signature.Reason = "The certificate of this document";

// Set the label and value for the distinguished name (DN)
signature.DistinguishedNameLabel = "DN: ";
signature.DistinguishedName = signature.Certificate.IssuerName.Name;

// Set the document permissions and certification status
signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
signature.Certificated = true;

// Set the fonts for sign details and sign name
signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

// Set the sign image layout mode
signature.SignImageLayout = SignImageLayout.None;
```

---

# spire.pdf csharp encryption
## encrypt PDF document with password and permissions
```csharp
// Create a security policy with the specified passwords
PdfSecurityPolicy securityPolicy = new PdfPasswordSecurityPolicy(userPassword, ownerPassword);

// Set the encryption algorithm to AES 128-bit
securityPolicy.EncryptionAlgorithm = PdfEncryptionAlgorithm.AES_128;

// Allow printing of the document
securityPolicy.DocumentPrivilege.AllowPrint = true;

// Allow filling form fields in the document
securityPolicy.DocumentPrivilege.AllowFillFormFields = true;

// Allow copying content from the document
securityPolicy.DocumentPrivilege.AllowContentCopying = true;

// Encrypt the PDF document using the specified security policy
pdf.Encrypt(securityPolicy);
```

---

# spire.pdf external services design
## create digital signature with custom PKCS7 formatter
```csharp
// Load a certificate for digital signature
X509Certificate2 cert = new X509Certificate2(certificatePath, password);

// Create a custom PKCS7 signature formatter using the certificate
CustomPKCS7SignatureFormatter customPKCS7SignatureFormatter = new CustomPKCS7SignatureFormatter(cert);

// Create a PdfSignature object with the document, the first page of the document, the custom signature formatter, and an identifier
PdfSignature signature = new PdfSignature(doc, doc.Pages[0], customPKCS7SignatureFormatter, "signature0");
signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(270, 90));
signature.GraphicsMode = GraphicMode.SignDetail;
signature.NameLabel = "Signer:";
signature.Name = "Test";
signature.Reason = "The certificate of this document";
signature.DistinguishedNameLabel = "DN: ";
signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;

// Set the font for sign details and sign name
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 15f));
signature.SignDetailsFont = font;
signature.SignNameFont = font;
signature.SignImageLayout = SignImageLayout.None;
```

---

# Spire.PDF C# Signature Image Extraction
## Extract images from PDF signatures
```csharp
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Get the existing form from the document
PdfFormWidget form = doc.Form as PdfFormWidget;

// Extract images from the signatures in the existing form
Image[] images = form.ExtractSignatureAsImages();
```

---

# spire.pdf csharp certificate extraction
## Extract signature certificates from PDF document
```csharp
// Load the PDF document from disk
PdfDocument doc = new PdfDocument();
doc.LoadFromFile("../../../../../../Data/ExtractSignatureInfo.pdf");

// Create a list to store the signatures found in the document
List<PdfSignature> signatures = new List<PdfSignature>();

// Get the form widget from the loaded document
var form = (PdfFormWidget)doc.Form;

// Iterate through each field in the form
for (int i = 0; i < form.FieldsWidget.Count; ++i)
{
    // Check if the field is a signature field
    var field = form.FieldsWidget[i] as PdfSignatureFieldWidget;
    if (field != null && field.Signature != null)
    {
        // If the field has a signature, add it to the list
        PdfSignature signature = field.Signature;
        signatures.Add(signature);
    }
}

// Get the first signature from the list
PdfSignature signatureOne = signatures[0];

// Get the certificates associated with the first signature
X509Certificate2Collection collection = signatureOne.Certificates;

// Iterate through each certificate in the collection
foreach (var certificate in collection)
{
    // Export the certificate as bytes in DER format
    byte[] cerByte = certificate.Export(X509ContentType.Cert);

    // Create a new file stream to save the exported certificate
    using (FileStream fileStream = new FileStream("Export.cer", FileMode.Create))
    {
        // Write the exported certificate bytes to the file stream
        for (int i = 0; i < cerByte.Length; i++)
            fileStream.WriteByte(cerByte[i]);

        // Set the file stream position to the beginning
        fileStream.Seek(0, SeekOrigin.Begin);

        // Read and verify the data in the file stream
        for (int i = 0; i < fileStream.Length; i++)
        {
            if (cerByte[i] != fileStream.ReadByte())
            {
                // Close the file stream if the verification fails
                fileStream.Close();
            }
        }
    }
}
```

---

# spire.pdf c# verify signed document
## Check if a signed PDF document has been modified after signing
```csharp
// Create a list to store the signatures found in the document
List<PdfSignature> signatures = new List<PdfSignature>();

// Open the PDF document and retrieve its signatures
using (PdfDocument pdf = new PdfDocument())
{
    pdf.LoadFromFile(pdfFile);

    // Get the form widget from the loaded document
    PdfFormWidget form = pdf.Form as PdfFormWidget;

    // Iterate through each field in the form
    for (int i = 0; i < form.FieldsWidget.Count; i++)
    {
        // Check if the field is a signature field
        PdfSignatureFieldWidget field = form.FieldsWidget[i] as PdfSignatureFieldWidget;
        if (field != null && field.Signature != null)
        {
            // If the field has a signature, add it to the list
            PdfSignature signature = field.Signature;
            signatures.Add(signature);
        }
    }

    // Get the first signature from the list
    PdfSignature signatureOne = signatures[0];

    // Determine if the PDF document was modified
    bool modified = signatureOne.VerifyDocModified();
}
```

---

# spire.pdf document locking after signing
## Lock PDF document after applying digital signature
```csharp
// Create a PdfCertificate object using the certificate file and its password
PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

// Create a PdfSignature object for the first page of the document with the specified certificate and signature name
PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature0");

// Set the position and size of the signature appearance on the page
signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(270, 90));

// Load an image file as the sign image source
signature.SignImageSource = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");

// Set the display mode of graphics for the signature appearance
signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

// Set the label and value for the signer's name in the signature details
signature.NameLabel = "Signer:";
signature.Name = "Gary";

// Set the label and value for the contact information in the signature details
signature.ContactInfoLabel = "ContactInfo:";
signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

// Set the label and value for the date in the signature details
signature.DateLabel = "Date:";
signature.Date = DateTime.Now;

// Set the label and value for the location information in the signature details
signature.LocationInfoLabel = "Location:";
signature.LocationInfo = "Chengdu";

// Set the label and value for the reason in the signature details
signature.ReasonLabel = "Reason: ";
signature.Reason = "The certificate of this document";

// Set the label and value for the distinguished name in the signature details
signature.DistinguishedNameLabel = "DN: ";
signature.DistinguishedName = signature.Certificate.IssuerName.Name;

// Specify the document permissions for the certified PDF
signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;

// Set the fonts to be used for the signature details and signer's name
signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

// Set the layout mode for the sign image
signature.SignImageLayout = SignImageLayout.None;

// Lock the document after applying the signature
signature.Lock = true;
```

---

# spire.pdf csharp digital signature
## set signature properties in advance for PDF document
```csharp
// Create a custom PKCS7 signature formatter using the loaded certificate
CustomPKCS7SignatureFormatterWithAPI customPKCS7SignatureFormatter = new CustomPKCS7SignatureFormatterWithAPI(cert);

// Create a PdfSignature object for the first page of the document with the custom signature formatter and signature name
PdfSignature signature = new PdfSignature(doc, doc.Pages[0], customPKCS7SignatureFormatter, "signature0");

// Set the position and size of the signature appearance on the page
signature.Bounds = new RectangleF(new PointF(250, 660), new SizeF(250, 90));

// Load an image file as the sign image source
signature.SignImageSource = PdfImage.FromFile(inputFile_img);

// Set the display mode of graphics for the signature appearance
signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

// Set the label and value for the signer's name in the signature details
signature.NameLabel = "Signer:";
signature.Name = cert.GetNameInfo(X509NameType.SimpleName, true);

// Set the label and value for the contact information in the signature details
signature.ContactInfoLabel = "ContactInfo:";
signature.ContactInfo = cert.GetNameInfo(X509NameType.SimpleName, true);

// Set the label and value for the date in the signature details
signature.DateLabel = "Date:";
signature.Date = DateTime.Now;

// Set the label and value for the location information in the signature details
signature.LocationInfoLabel = "Location:";
signature.LocationInfo = "Chengdu";

// Set the label and value for the reason in the signature details
signature.ReasonLabel = "Reason: ";
signature.Reason = "The certificate of this document";

// Set the label and value for the distinguished name in the signature details
signature.DistinguishedNameLabel = "DN: ";
signature.DistinguishedName = cert.IssuerName.Name;

// Specify the document permissions for the certified PDF
signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;

// Set the Certificated property to true to enable certification
signature.Certificated = true;

// Set the fonts to be used for the signature details and signer's name
signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

// Set the layout mode for the sign image
signature.SignImageLayout = SignImageLayout.None;
```

---

# Spire.PDF Digital Signature with Timestamp
## Create PDF signature with timestamp service and custom appearance
```csharp
// Create a PDF document
PdfDocument doc = new PdfDocument();
doc.AppendPage();

// Load certificate and create PKCS7 formatter with timestamp service
X509Certificate2 x509 = new X509Certificate2(inputFile_pfx, "e-iceblue");
PdfPKCS7Formatter formatter = new PdfPKCS7Formatter(x509, false);
formatter.TimestampService = new TSAHttpService("http://time.certum.pl");

// Create a signature maker using the document and formatter
PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(doc, formatter);

// Create a custom signature appearance for the signature
IPdfSignatureAppearance signatureAppearance = new PdfCustomSignatureAppearance();

// Make the signature on the first page of the document at position (100, 100) with a size of 100x100
signatureMaker.MakeSignature("sign", doc.Pages[0], 100, 100, 100, 100, signatureAppearance);

public class PdfCustomSignatureAppearance : IPdfSignatureAppearance
{
    // This method is used to generate a custom signature appearance on a PdfCanvas object.
    public void Generate(PdfCanvas g)
    {
        // Set the font size for the signature appearance to 10.
        float fontSize = 10;

        // Create a TrueType font object using the Arial font with the specified font size.
        PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", fontSize), true);

        // Draw the string "E-iceblue" on the PdfCanvas object 'g' using the specified font and color (red) at coordinates (0, 0).
        g.DrawString("E-iceblue", font, PdfBrushes.Red, new PointF(0, 0));
    }
}
```

---

# spire.pdf csharp ltv signature
## sign PDF with Long-Term Validation (LTV) using certificate
```csharp
// Load a PDF document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(inputFile);

// Get the first page
PdfPageBase page = doc.Pages[0];

// Load a certificate .pfx file
String pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";
PdfCertificate cer = new PdfCertificate(pfxPath, "e-iceblue", X509KeyStorageFlags.Exportable);

// Add a signature to the specified position
PdfSignature signature = new PdfSignature(doc, page, cer, "signature");
signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(180, 90));

// Set the signature content
signature.NameLabel = "Digitally signed by: Gary";
signature.LocationInfoLabel = "Location:";
signature.LocationInfo = "CN";
signature.ReasonLabel = "Reason: ";
signature.Reason = "Ensure authenticity";
signature.ContactInfoLabel = "Contact Number: ";
signature.ContactInfo = "028-81705109";
signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
signature.SignImageSource = PdfImage.FromFile(@"..\..\..\..\..\..\Data\logo.png");

// Configure OCSP (Online Certificate Status Protocol)
signature.ConfigureHttpOCSP(null, null);
```

---

# Spire.PDF Digital Signature
## Create PDF digital signature using PdfOrdinarySignatureMaker API
```csharp
// Create a new PDF document
PdfDocument pdf = new PdfDocument();

// Add a page to the document
PdfPageBase pdfPage = pdf.Pages.Add();

// Load the certificate from the specified PFX file and password
PdfCertificate cert = new PdfCertificate(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue");

// Create a new instance of PdfOrdinarySignatureMaker using the PDF document and certificate
PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(pdf, cert);

// Set details for the signature
Spire.Pdf.Interactive.DigitalSignatures.PdfSignature signature = signatureMaker.Signature;
signature.Name = "E-iceblue";
signature.ContactInfo = "028-81705109";
signature.Location = "Chengdu";
signature.Reason = "The certificate of this document";

// Create a new PdfSignatureAppearance object for the signature appearance
PdfSignatureAppearance appearance = new PdfSignatureAppearance(signature);
appearance.NameLabel = "Signer: ";
appearance.ContactInfoLabel = "ContactInfo: ";
appearance.LocationLabel = "Location: ";
appearance.ReasonLabel = "Reason: ";
appearance.SignatureImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");
appearance.GraphicMode = Spire.Pdf.Interactive.DigitalSignatures.GraphicMode.SignImageAndSignDetail;

// Make the signature with the specified name, on the specified page at position (100, 600) with a size of 200x100
signatureMaker.MakeSignature("signName", pdfPage, 100, 600, 200, 100, appearance);
```

---

# Spire.PDF C# Timestamp Signature
## Add a digital signature with timestamp to a PDF document
```csharp
// Create a certificate object
PdfCertificate cert = new PdfCertificate(pfxPath, "password", System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable);

// Add a signature to the document
PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature");
signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(180, 90));

// Configure signature properties
signature.NameLabel = "Digitally signed by: Name";
signature.LocationInfoLabel = "Location:";
signature.LocationInfo = "Location";
signature.ReasonLabel = "Reason: ";
signature.Reason = "Reason";
signature.ContactInfoLabel = "Contact Number: ";
signature.ContactInfo = "Contact";
signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
signature.SignImageSource = PdfImage.FromFile("logo.png");

// Configure timestamp server
string url = "https://timestamp.server.url";
signature.ConfigureTimestamp(url);
```

---

# Spire.PDF C# Signature Field
## Sign a PDF document using a signature field with a digital certificate
```csharp
// Create a PDF document
PdfDocument doc = new PdfDocument();

// Retrieve the form widgets from the document
PdfFormWidget widgets = doc.Form as PdfFormWidget;

// Iterate through each field widget in the form
for (int i = 0; i < widgets.FieldsWidget.List.Count; i++)
{
    // Get the current field widget
    PdfFieldWidget widget = widgets.FieldsWidget.List[i] as PdfFieldWidget;

    // Check if the field widget is a signature field
    if (widget is PdfSignatureFieldWidget)
    {
        // Get the name of the signature field
        string name = widget.Name;
        // Cast the widget to a PdfSignatureFieldWidget
        PdfSignatureFieldWidget signWidget = widget as PdfSignatureFieldWidget;

        // Open the Windows certificate store for read-only access
        System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);
        store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

        // Manually select a certificate from the store
        System.Security.Cryptography.X509Certificates.X509Certificate2Collection sel = System.Security.Cryptography.X509Certificates.X509Certificate2UI.SelectFromCollection(store.Certificates, null, null, System.Security.Cryptography.X509Certificates.X509SelectionFlag.SingleSelection);

        // Create a PdfCertificate object using the certificate data from the selected certificate
        PdfCertificate cert = new PdfCertificate(sel[0].RawData);

        // Create a PdfSignature object using the document, page, certificate, field name, and signature field widget
        PdfSignature signature = new PdfSignature(doc, signWidget.Page, cert, name, signWidget);

        // Load the sign image source
        signature.SignImageSource = PdfImage.FromFile("logo.png");

        // Set the graphics mode for display
        signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

        // Set the label and value for the signer's name
        signature.NameLabel = "Signer:";
        signature.Name = sel[0].GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

        // Set the label and value for the contact information
        signature.ContactInfoLabel = "ContactInfo:";
        signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

        // Set the label and value for the signing date
        signature.DateLabel = "Date:";
        signature.Date = DateTime.Now;

        // Set the label and value for the signing location
        signature.LocationInfoLabel = "Location:";
        signature.LocationInfo = "Chengdu";

        // Set the label and value for the reason of signing
        signature.ReasonLabel = "Reason: ";
        signature.Reason = "The certificate of this document";

        // Set the label and value for the distinguished name (DN) of the certificate issuer
        signature.DistinguishedNameLabel = "DN: ";
        signature.DistinguishedName = signature.Certificate.IssuerName.Name;

        // Set the document permissions and mark the document as certified
        signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
        signature.Certificated = true;

        // Set the fonts for the sign details and sign name, if not set, default ones will be applied
        signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
        signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

        // Set the sign image layout mode to None
        signature.SignImageLayout = SignImageLayout.None;
    }
}
```

---

# Spire.PDF Digital Signature
## Sign PDF signature fields with certificate and image
```csharp
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile(inputFile);
PdfFormWidget widgets = pdf.Form as PdfFormWidget;
for (int i = 0; i < widgets.FieldsWidget.List.Count; i++)
{
    PdfFieldWidget widget = widgets.FieldsWidget.List[i] as PdfFieldWidget;
    if (widget is PdfSignatureFieldWidget)
    {
        string originalName = widget.Name;
        X509Certificate2 cert = new X509Certificate2(inputFile_pfx, "e-iceblue");
        IPdfSignatureFormatter formatter = new PdfPKCS7Formatter(cert, false);

        PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(pdf, formatter);

        PdfSignature signature = signatureMaker.Signature;
        signature.Name = "E-iceblue";
        signature.ContactInfo = "028-81705109";
        signature.Location = "Cheng Du";
        signature.Reason = "Ensure document integrity";

        PdfSignatureAppearance appearance = new PdfSignatureAppearance(signature);
        appearance.NameLabel = "Signer: ";
        appearance.ContactInfoLabel = "ContactInfo: ";
        appearance.LocationLabel = "Loaction: ";
        appearance.ReasonLabel = "Reason: ";
        appearance.SignatureImage = PdfImage.FromFile(inputFile_Img);
        appearance.GraphicMode = GraphicMode.SignImageAndSignDetail;

        signatureMaker.MakeSignature(originalName, appearance);
    }
}
```

---

# Spire.PDF Digital Signature with Details and Image
## Sign a PDF document with digital signature including signer details and an image

```csharp
// Load the PDF document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Create a PdfCertificate object using the certificate file (.pfx) and password
PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

// Create a PdfOrdinarySignatureMaker object using the document and certificate
PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(doc, cert);

// Get the PdfSignature object for signing
Spire.Pdf.Interactive.DigitalSignatures.PdfSignature signature = signatureMaker.Signature;

// Set the details for the signature
signature.Name = "E-iceblue";
signature.ContactInfo = "028-81705109";
signature.Location = "Chengdu";
signature.Reason = "The certificate of this document";

// Create a PdfSignatureAppearance object for customizing the appearance of the signature
PdfSignatureAppearance appearance = new PdfSignatureAppearance(signature);
appearance.NameLabel = "Signer: ";
appearance.ContactInfoLabel = "ContactInfo: ";
appearance.LocationLabel = "Location: ";
appearance.ReasonLabel = "Reason: ";

// Set the picture for the signature
appearance.SignatureImage = PdfImage.FromFile(imagePath);
appearance.GraphicMode = Spire.Pdf.Interactive.DigitalSignatures.GraphicMode.SignImageAndSignDetail;

// Use the signature maker to make the signature at the specified position on the first page of the document
signatureMaker.MakeSignature("signName", doc.Pages[0], 100, 600, 200, 100, appearance);

// Save the modified document to a file
doc.SaveToFile(result, FileFormat.PDF);
```

---

# Spire.PDF C# Smart Card Signature
## Sign PDF document using smart card certificate
```csharp
// Load the PDF document from the disk
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Open the Windows certificate store for read-only access
System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);
store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

// Manually select a certificate from the store
System.Security.Cryptography.X509Certificates.X509Certificate2Collection sel = System.Security.Cryptography.X509Certificates.X509Certificate2UI.SelectFromCollection(store.Certificates, null, null, System.Security.Cryptography.X509Certificates.X509SelectionFlag.SingleSelection);

// Create a PdfCertificate object using the certificate data from the selected certificate
PdfCertificate cert = new PdfCertificate(sel[0].RawData);

// Create a PdfSignature object using the document, page, certificate, and field name
PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature0");
signature.Bounds = new RectangleF(new PointF(250, 660), new SizeF(250, 90));

// Load the sign image source
signature.SignImageSource = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png");

// Set the graphics mode for display
signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

// Set the label and value for the signer's name
signature.NameLabel = "Signer:";
signature.Name = sel[0].GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

// Set the label and value for the contact information
signature.ContactInfoLabel = "ContactInfo:";
signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

// Set the label and value for the signing date
signature.DateLabel = "Date:";
signature.Date = DateTime.Now;

// Set the label and value for the signing location
signature.LocationInfoLabel = "Location:";
signature.LocationInfo = "Chengdu";

// Set the label and value for the reason of signing
signature.ReasonLabel = "Reason: ";
signature.Reason = "The certificate of this document";

// Set the label and value for the distinguished name (DN) of the certificate issuer
signature.DistinguishedNameLabel = "DN: ";
signature.DistinguishedName = signature.Certificate.IssuerName.Name;

// Set the document permissions and mark the document as certified
signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
signature.Certificated = true;

// Set the fonts for the sign details and sign name, if not set, default ones will be applied
signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

// Set the sign image layout mode to None
signature.SignImageLayout = SignImageLayout.None;

// Save the modified PDF document to a file
doc.SaveToFile(output);
doc.Close();
```

---

# Spire.PDF C# Signature Verification
## Verify digital signatures in PDF documents
```csharp
// Create a list to store PdfSignature objects
List<PdfSignature> signatures = new List<PdfSignature>();

// Load the PDF document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile("VerifySignature.pdf");

// Get the form widget from the PDF document
var form = (PdfFormWidget)pdf.Form;

// Iterate through each field in the form
for (int i = 0; i < form.FieldsWidget.Count; ++i)
{
    var field = form.FieldsWidget[i] as PdfSignatureFieldWidget;

    // Check if the field is a signature field and has a signature
    if (field != null && field.Signature != null)
    {
        // Add the signature to the list
        PdfSignature signature = field.Signature;
        signatures.Add(signature);
    }
}

// Get the first signature from the list
PdfSignature signatureOne = signatures[0];

// Verify the signature
bool valid = signatureOne.VerifySignature();

// Check if the signature is valid
if (valid)
{
    // The signature is valid
}
else
{
    // The signature is invalid
}
```

---

# spire.pdf csharp actions
## create PDF document with various actions including goto actions, named actions, and JavaScript actions
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Set margin
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

//Create one page
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

float y = 10;

//Table top
PdfDestination tableTopDest = new PdfDestination(page);
tableTopDest.Location = new PointF(0, y);
tableTopDest.Mode = PdfDestinationMode.Location;
tableTopDest.Zoom = 1f;

//Table bottom
PdfDestination tableBottomDest = new PdfDestination(page);
tableBottomDest.Location = new PointF(0, y);
tableBottomDest.Mode = PdfDestinationMode.Location;
tableBottomDest.Zoom = 1f;

//Go to table bottom
float x = page.Canvas.ClientSize.Width - 70;
PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
RectangleF buttonBounds = new RectangleF(x, y, 70, 15);
page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds);
page.Canvas.DrawString("To Bottom", new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold)), PdfBrushes.CadetBlue, buttonBounds, format2);
PdfGoToAction action1 = new PdfGoToAction(tableBottomDest);
PdfActionAnnotation annotation1 = new PdfActionAnnotation(buttonBounds, action1);
annotation1.Border = new PdfAnnotationBorder(0.75f);
annotation1.Color = Color.LightGray;
(page as PdfNewPage).Annotations.Add(annotation1);

//Go to table top
float tableBottom = y + 5;
buttonBounds = new RectangleF(x, tableBottom, 70, 15);
page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds);
page.Canvas.DrawString("To Top", new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold)), PdfBrushes.CadetBlue, buttonBounds, format2);
PdfGoToAction action2 = new PdfGoToAction(tableTopDest);
PdfActionAnnotation annotation2 = new PdfActionAnnotation(buttonBounds, action2);
annotation2.Border = new PdfAnnotationBorder(0.75f);
annotation2.Color = Color.LightGray;
(page as PdfNewPage).Annotations.Add(annotation2);

//Go to last page
PdfNamedAction action3 = new PdfNamedAction(PdfActionDestination.LastPage);
doc.AfterOpenAction = action3;

//Script
String script = "app.alert({"
    + "    cMsg: \"Oh no, you want to leave me.\","
    + "    nIcon: 3,"
    + "    cTitle: \"JavaScript Action\""
    + "});";
PdfJavaScriptAction action4 = new PdfJavaScriptAction(script);
doc.BeforeCloseAction = action4;
```

---

# spire.pdf csharp action chain
## create a chain of actions in PDF document
```csharp
// Create a PDF document
PdfDocument doc = new PdfDocument();

// Draw pages and get the last page
PdfPageBase lastPage = DrawPages(doc);

// Define JavaScript action for after the document is opened
String script = "app.alert({"
    + "    cMsg: \"I'll lead; you must follow me.\","
    + "    nIcon: 3,"
    + "    cTitle: \"JavaScript Action\""
    + "});";
PdfJavaScriptAction action1 = new PdfJavaScriptAction(script);
doc.AfterOpenAction = action1;

// Define JavaScript action for the next action after action1
script = "app.alert({"
    + "    cMsg: \"The first page!\","
    + "    nIcon: 3,"
    + "    cTitle: \"JavaScript Action\""
    + "});";
PdfJavaScriptAction action2 = new PdfJavaScriptAction(script);
action1.NextAction = action2;

// Define a destination to navigate to the last page
PdfDestination dest = new PdfDestination(lastPage);
dest.Zoom = 1;
PdfGoToAction action3 = new PdfGoToAction(dest);
action2.NextAction = action3;

// Define JavaScript action for the next action after action3
script = "app.alert({"
    + "    cMsg: \"Oh sorry, it's the last page. I'm missing!\","
    + "    nIcon: 3,"
    + "    cTitle: \"JavaScript Action\""
    + "});";
PdfJavaScriptAction action4 = new PdfJavaScriptAction(script);
action3.NextAction = action4;

// Save the PDF file
doc.SaveToFile("ActionChain.pdf");
doc.Close();
```

---

# spire.pdf csharp launch action
## add PDF launch action to open file when clicking on text
```csharp
// Create a new PDF document 
PdfDocument doc = new PdfDocument();

// Add a page to the document
PdfPageBase page = doc.Pages.Add();

// Create a PDF Launch Action that will open a text file
PdfLaunchAction launchAction = new PdfLaunchAction("text.txt");

// Create a PDF Action Annotation with the PDF Launch Action
string text = "Click here to open file";
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 13f));
RectangleF rect = new RectangleF(50, 50, 230, 15);
page.Canvas.DrawString(text, font, PdfBrushes.ForestGreen, rect);
PdfActionAnnotation annotation = new PdfActionAnnotation(rect, launchAction);

// Add the PDF Action Annotation to the page
(page as PdfNewPage).Annotations.Add(annotation);
```

---

# Spire.PDF C# Table of Contents
## Add a table of contents with navigation links to a PDF document
```csharp
// Get the total number of pages in the document.
int pageCount = doc.Pages.Count;

// Insert a blank page at the beginning of the PDF document.
PdfPageBase tocPage = doc.Pages.Insert(0);

// Set the title for the table of contents.
string title = "Table Of Contents";
PdfTrueTypeFont titleFont = new PdfTrueTypeFont(new Font("Arial", 20, FontStyle.Bold));
PdfStringFormat centerAlignment = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
PointF location = new PointF(tocPage.Canvas.ClientSize.Width / 2, titleFont.MeasureString(title).Height);
tocPage.Canvas.DrawString(title, titleFont, PdfBrushes.CornflowerBlue, location, centerAlignment);

// Draw the table of contents entries.
PdfTrueTypeFont titlesFont = new PdfTrueTypeFont(new Font("Arial", 14));
String[] titles = new String[pageCount];
for (int i = 0; i < titles.Length; i++)
{
    titles[i] = string.Format("This is page {0}", i + 1);
}
float y = titleFont.MeasureString(title).Height + 10;
float x = 0;

for (int i = 1; i <= pageCount; i++)
{
    string text = titles[i - 1];
    SizeF titleSize = titlesFont.MeasureString(text);

    // Get the page that the table of contents entry will navigate to.
    PdfPageBase navigatedPage = doc.Pages[i];

    string pageNumText = (i + 1).ToString();
    SizeF pageNumTextSize = titlesFont.MeasureString(pageNumText);

    // Draw the entry text.
    tocPage.Canvas.DrawString(text, titlesFont, PdfBrushes.CadetBlue, 0, y);

    float dotLocation = titleSize.Width + 2 + x;
    float pageNumlocation = tocPage.Canvas.ClientSize.Width - pageNumTextSize.Width;

    // Draw dots between the entry text and page number.
    for (float j = dotLocation; j < pageNumlocation; j++)
    {
        if (dotLocation >= pageNumlocation)
        {
            break;
        }
        tocPage.Canvas.DrawString(".", titlesFont, PdfBrushes.Gray, dotLocation, y);
        dotLocation += 3;
    }

    // Draw the page number.
    tocPage.Canvas.DrawString(pageNumText, titlesFont, PdfBrushes.CadetBlue, pageNumlocation, y);

    // Add the table of contents action.
    location = new PointF(0, y);
    RectangleF titleBounds = new RectangleF(location, new SizeF(tocPage.Canvas.ClientSize.Width, titleSize.Height));
    PdfDestination Dest = new PdfDestination(navigatedPage, new PointF(-doc.PageSettings.Margins.Top, -doc.PageSettings.Margins.Left));
    PdfActionAnnotation action = new PdfActionAnnotation(titleBounds, new PdfGoToAction(Dest));
    action.Border = new PdfAnnotationBorder(0);
    (tocPage as PdfNewPage).Annotations.Add(action);
    y += titleSize.Height + 10;
}
```

---

# Spire.PDF Document Link Annotation
## Create a document link annotation in PDF that links to another page
```csharp
// Create a new PDF document
PdfDocument doc = new PdfDocument();

// Add pages
PdfPageBase page1 = doc.Pages.Add(PdfPageSize.A4, margin);
PdfPageBase page2 = doc.Pages.Add(PdfPageSize.A4, margin);

// Add a DocumentLinkAnnotation on the first page and link it to the second page
AddDocumentLinkAnnotation(doc, 0, 1, y);

private static void AddDocumentLinkAnnotation(PdfDocument pdf, int AddPage, int DestinationPage, float y)
{
    // Define a font for text
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
    
    // Set the string format for text alignment
    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
    
    // Specify the prompt text for the link
    String prompt = "Local document Link: ";
    
    // Draw the prompt text on the page at the specified vertical position
    pdf.Pages[AddPage].Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
    
    // Use MeasureString to get the width of the prompt string
    float x = font.MeasureString(prompt, format).Width;
    
    // Create a PdfDestination with the specified destination page
    PdfDestination dest = new PdfDestination(pdf.Pages[DestinationPage]);
    
    // Set the location of the destination
    dest.Location = new PointF(0, y);
    
    // Set the zoom factor for the destination
    dest.Zoom = 0.5f;
    
    // Specify the label string for the link
    String label = "Click here to link the second page.";
    
    // Use MeasureString to get the SizeF of the label string
    SizeF size = font.MeasureString(label);
    
    // Create a rectangle that defines the area for the link
    RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
    
    // Draw the label string on the page
    pdf.Pages[AddPage].Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
    
    // Create a PdfDocumentLinkAnnotation on the rectangle and link it to the destination
    PdfDocumentLinkAnnotation annotation = new PdfDocumentLinkAnnotation(bounds, dest);
    
    // Set the color for the annotation
    annotation.Color = Color.Blue;
    
    // Add the annotation to the page
    (pdf.Pages[AddPage] as PdfNewPage).Annotations.Add(annotation);
}
```

---

# spire.pdf csharp sound embedding
## embed sound file in pdf document
```csharp
// Create a sound action with the specified sound file.
PdfSoundAction soundAction = new PdfSoundAction("..\\..\\..\\..\\..\\..\\Data\\Music.wav");

// Set properties for the sound action.
soundAction.Sound.Bits = 15;
soundAction.Sound.Channels = PdfSoundChannels.Stereo;
soundAction.Sound.Encoding = PdfSoundEncoding.Signed;
soundAction.Volume = 0.8f;
soundAction.Repeat = true;

// Set the sound action to be executed when the PDF document is opened.
doc.AfterOpenAction = soundAction;
```

---

# spire.pdf csharp link extraction and update
## extract and update web link annotations in a pdf document
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load file from disk
doc.LoadFromFile("LinkAnnotation.pdf");

//Get the first page
PdfPageBase page = doc.Pages[0];

//Get the annotation collection
PdfAnnotationCollection annotations = page.Annotations;

//Verify whether widgetCollection is not null or not
if (annotations.Count > 0)
{
    //traverse the PdfAnnotationCollection
    foreach (PdfAnnotation pdfAnnotation in annotations)
    {
        //if it is PdfTextWebLinkAnnotationWidget
        if (pdfAnnotation is PdfTextWebLinkAnnotationWidget)
        {

            //Get the link annotation
            PdfTextWebLinkAnnotationWidget annotation = pdfAnnotation as PdfTextWebLinkAnnotationWidget;

            //Change the url
            annotation.Url = "http://www.e-iceblue.com/Introduce/pdf-for-net-introduce.html";

        }
    }
}

//Save the document
doc.SaveToFile("ExtractAndUpdateLink_out.pdf");
```

---

# spire.pdf csharp file link annotation
## create file link annotation in PDF document
```csharp
private static void AddFileLinkAnnotation(PdfPageBase page, float y)
{
    //Define a font
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));

    //Set the string format 
    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);

    //Text string
    String prompt = "Launch a File: ";

    //Draw text string on page canvas
    page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);

    //Use MeasureString to get the width of string
    float x = font.MeasureString(prompt, format).Width;

    //String of file name
    String label = "Sample.pdf";

    //Use MeasureString to get the SizeF of string
    SizeF size = font.MeasureString(label);

    //Create a rectangle
    RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);

    //Draw label string
    page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

    //Create PdfFileLinkAnnotation on the rectangle and link file "Sample.pdf"
    PdfFileLinkAnnotation annotation = new PdfFileLinkAnnotation(bounds, @"..\..\..\..\..\..\Data\Sample.pdf");
   
    //Set color for annotation
    annotation.Color = Color.Blue;

    //Add annotation to the page
    (page as PdfNewPage).Annotations.Add(annotation);
}
```

---

# Spire.PDF Get Link Annotations
## Extract web link annotations from PDF document
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load file from disk
doc.LoadFromFile(@"..\..\..\..\..\..\Data\LinkAnnotation.pdf");

//Get the first page
PdfPageBase page = doc.Pages[0];

//Get the annotation collection
PdfAnnotationCollection annotations = page.Annotations;

//Verify whether widgetCollection is not null or not
if (annotations.Count > 0)
{
    //traverse the PdfAnnotationCollection
    foreach (PdfAnnotation pdfAnnotation in annotations)
    {
        //if it is PdfTextWebLinkAnnotationWidget
        if (pdfAnnotation is PdfTextWebLinkAnnotationWidget)
        {
            //Get the Url
            PdfTextWebLinkAnnotationWidget WebLinkAnnotation = pdfAnnotation as PdfTextWebLinkAnnotationWidget;
            string url = WebLinkAnnotation.Url;
            
            //Get the text content
            string text = WebLinkAnnotation.Text;
        }
    }
}
```

---

# Spire.PDF GoTo Actions
## Implementation of GoTo actions in PDF documents
```csharp
/// <summary>
/// GoToE action
/// </summary>
/// <param name="pdf"></param>
private static void EmbeddedGoToAction(PdfDocument pdf, PdfPageBase page)
{
    // Add an attachment to the PDF.
    PdfAttachment attachment = new PdfAttachment("GoToAction.pdf");
    pdf.Attachments.Add(attachment);

    // Specify the text to be displayed on the page.
    string text = "Test embedded go-to action! Clicking this will open the attached PDF in a new window.";

    // Define the font and dimensions of the text box.
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 13f));
    float width = 490f;
    float height = font.Height * 2.2f;
    RectangleF rect = new RectangleF(0, 100, width, height);

    // Draw the text on the page.
    page.Canvas.DrawString(text, font, PdfBrushes.Black, rect);

    // Create a PdfDestination with a specific page, location, and zoom factor.
    PdfDestination dest = new PdfDestination(page, new PointF(0, 842));

    // Create a GoToE (Go-To Embedded) action with the specified destination.
    PdfEmbeddedGoToAction action = new PdfEmbeddedGoToAction(attachment.FileName, dest, true);

    // Create a PdfActionAnnotation with the action and the annotation rectangle.
    PdfActionAnnotation annotation = new PdfActionAnnotation(rect, action);

    // Add the annotation to the page.
    (page as PdfNewPage).Annotations.Add(annotation);
}

private static void JumpToSpecificLocationAction(PdfDocument pdf, PdfPageBase page)
{
    // Add a new page to the PDF document.
    PdfPageBase pagetwo = pdf.Pages.Add();

    // Draw text on the second page.
    pagetwo.Canvas.DrawString("This is Page Two.",
                               new PdfFont(PdfFontFamily.Helvetica, 20f),
                               new PdfSolidBrush(Color.Black),
                               10, 10);

    // Create a PdfDestination instance and link it to a PdfGoToAction.
    PdfDestination pageBottomDest = new PdfDestination(pagetwo);
    pageBottomDest.Location = new PointF(0, 5);
    pageBottomDest.Mode = PdfDestinationMode.Location;
    pageBottomDest.Zoom = 1f;
    PdfGoToAction action = new PdfGoToAction(pageBottomDest);

    // Define the font, dimensions, and formatting for a button.
    PdfTrueTypeFont buttonFont = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
    float buttonWidth = 70;
    float buttonHeight = buttonFont.Height * 1.5f;
    PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
    RectangleF buttonBounds = new RectangleF(0, 200, buttonWidth, buttonHeight);

    // Create a rectangle and draw text on the first page.
    page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds);
    page.Canvas.DrawString("To Last Page", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2);

    // Add the annotation to the first page.
    PdfActionAnnotation annotation = new PdfActionAnnotation(buttonBounds, action);
    annotation.Border = new PdfAnnotationBorder(0.75f);
    annotation.Color = Color.LightGray;
    (page as PdfNewPage).Annotations.Add(annotation);
}
```

---

# Spire.PDF C# Launch File Action
## Create PDF annotation that launches a file in a new window when clicked
```csharp
// Create a PdfLaunchAction to launch a file when the annotation is clicked.
PdfLaunchAction launchAction = new PdfLaunchAction(@"..\..\..\..\..\..\Data\Sample.pdf", PdfFilePathType.Relative);

// Set the launch action to open the file in a new window.
launchAction.IsNewWindow = true;

// Get the position and size of the found text fragment.
RectangleF rect = new RectangleF(find.Positions[0].X, find.Positions[0].Y, find.Sizes[0].Width, find.Sizes[0].Height);

// Create a PdfActionAnnotation with the launch action and the annotation rectangle.
PdfActionAnnotation annotation = new PdfActionAnnotation(rect, launchAction);

// Add the annotation to the current page.
(page as PdfPageWidget).Annotations.Add(annotation);
```

---

# spire.pdf csharp links
## create various types of links in pdf document
```csharp
// Create a new PDF document
PdfDocument doc = new PdfDocument();

// Set margins for the document
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

// Create a new page with specified size and margins
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

float y = 100;
float x = 10;

// Set font and label for the first text link
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Lucida Sans Unicode", 14));
String label = "Simple Text Link: ";

// Draw the label on the page
PdfStringFormat format = new PdfStringFormat();
format.MeasureTrailingSpaces = true;
page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);

x = font.MeasureString(label, format).Width;

// Set font and URL for the first text link
PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Lucida Sans Unicode", 14, FontStyle.Underline));
String url1 = "http://www.e-iceblue.com";

// Draw the URL on the page
page.Canvas.DrawString(url1, font1, PdfBrushes.CadetBlue, x, y);
y = y + font1.MeasureString(url1).Height + 25;

// Set font and label for the second web link
label = "Web Link: ";
page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
x = font.MeasureString(label, format).Width;

// Set text and properties for the second web link
String text = "E-iceblue home";
PdfTextWebLink link2 = new PdfTextWebLink();
link2.Text = text;
link2.Url = url1;
link2.Font = font1;
link2.Brush = PdfBrushes.CadetBlue;

// Draw the second web link on the page
link2.DrawTextWebLink(page.Canvas, new PointF(x, y));
y = y + font1.MeasureString(text).Height + 30;

// Set font and label for the URI annotation
label = "URI Annotation: ";
page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
x = font.MeasureString(label, format).Width;
text = "Google";
PointF location = new PointF(x, y);
SizeF size = font1.MeasureString(text);
RectangleF linkBounds = new RectangleF(location, size);

// Create a URI annotation and set its properties
PdfUriAnnotation link3 = new PdfUriAnnotation(linkBounds);
link3.Border = new PdfAnnotationBorder(0);
link3.Uri = "http://www.google.com";

// Add the URI annotation to the page's annotations collection
(page as PdfNewPage).Annotations.Add(link3);

// Draw the text for the URI annotation
page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y);
y = y + size.Height + 30;

// Set font and label for the URI annotation with an action
label = "URI Annotation Action: ";
page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
x = font.MeasureString(label, format).Width;
text = "JavaScript Action (Click Me)";
location = new PointF(x - 2, y - 2);
size = font1.MeasureString(text);
size = new SizeF(size.Width + 5, size.Height + 5);
linkBounds = new RectangleF(location, size);

// Create a URI annotation with border and color
PdfUriAnnotation link4 = new PdfUriAnnotation(linkBounds);
link4.Border = new PdfAnnotationBorder(0.75f);
link4.Color = Color.CadetBlue;

// Define JavaScript action script
String script = "app.alert({" +
    "cMsg: \"Hello.\"," +
    "nIcon: 3," +
    "cTitle: \"JavaScript Action\"" +
    "});";

// Create a JavaScript action and assign it to the URI annotation
PdfJavaScriptAction action = new PdfJavaScriptAction(script);
link4.Action = action;

// Add the URI annotation with the JavaScript action to the page's annotations collection
(page as PdfNewPage).Annotations.Add(link4);

// Draw the text for the URI annotation with the JavaScript action
page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y);
y = y + size.Height + 30;

label = "Need Help:  ";
page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
x = font.MeasureString(label, format).Width;
text = "Go to forum to ask questions";
link2 = new PdfTextWebLink();
link2.Text = text;
link2.Url = "https://www.e-iceblue.com/forum/components-f5.html";
link2.Font = font1;
link2.Brush = PdfBrushes.CadetBlue;
link2.DrawTextWebLink(page.Canvas, new PointF(x, y));
y = y + font1.MeasureString(text).Height + 30;

label = "Contct us:  ";
page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
x = font.MeasureString(label, format).Width;
text = "Send an email";
link2 = new PdfTextWebLink();
link2.Text = text;
link2.Url = "mailto:support@e-iceblue.com";
link2.Font = font1;
link2.Brush = PdfBrushes.CadetBlue;
link2.DrawTextWebLink(page.Canvas, new PointF(x, y));
```

---

# Spire.PDF Remove JavaScript
## Remove JavaScript from a PDF document using Spire.PDF library
```csharp
//Create a pdf document
PdfDocument document = new PdfDocument();

//Load an existing pdf from disk
document.LoadFromFile("DocumentJavaScript.pdf");

//Remove document javascript
document.RemoveDocumentJavaScript();

String result = "Output.pdf";

//Save the document
document.SaveToFile(result);
```

---

# spire.pdf hyperlink removal
## remove hyperlinks from pdf document
```csharp
// Load an existing PDF file.
PdfDocument document = new PdfDocument();
document.LoadFromFile("RemoveHyperlinks.pdf");

// Get the first page of the document.
PdfPageBase page = document.Pages[0];

// Get the collection of annotations on the page.
PdfAnnotationCollection widgetCollection = page.Annotations;

// Check if the widgetCollection is not null and contains annotations.
if (widgetCollection.Count > 0)
{
    // Iterate over the annotations in reverse order.
    for (int i = widgetCollection.Count - 1; i >= 0; i--)
    {
        // Get the current annotation.
        PdfAnnotation annotation = widgetCollection[i];

        // Check if the annotation is a TextWebLink Annotation.
        if (annotation is PdfTextWebLinkAnnotationWidget)
        {
            // Cast the annotation to TextWebLink Annotation.
            PdfTextWebLinkAnnotationWidget link = annotation as PdfTextWebLinkAnnotationWidget;

            // Remove the TextWebLink annotation from the collection.
            widgetCollection.Remove(link);
        }
    }
}

// Save the modified document to a new file.
document.SaveToFile("RemoveHyperlinks-result.pdf");
```

---

# spire.pdf remove open action
## Remove open action from PDF document
```csharp
//Create a pdf document
PdfDocument document = new PdfDocument();

//Remove action
document.AfterOpenAction = null;
```

---

# spire.pdf csharp hyperlink zoom
## set inherit zoom for PDF hyperlinks
```csharp
// Get the PdfAnnotationCollection of the first page
PdfAnnotationCollection annotations = pdf.Pages[0].Annotations;

// Iterate through each annotation in the collection
for (int i = 0; i < annotations.Count; i++)
{
    // Cast the current annotation to a PdfDocumentLinkAnnotationWidget
    PdfDocumentLinkAnnotationWidget anno = annotations[i] as PdfDocumentLinkAnnotationWidget;

    // Get the destination of the annotation
    PdfDestination dest = anno.Destination;

    // Set the mode of the destination to Location
    dest.Mode = PdfDestinationMode.Location;

    // Set the zoom level of the destination to 0
    dest.Zoom = 0;

    // Set the new destination for the annotation
    anno.Destination = dest;
}
```

---

# spire.pdf csharp specify page to view
## Set a specific page to view when opening a PDF document
```csharp
// Create a new PDF document
PdfDocument doc = new PdfDocument();

// Get the second page
PdfPageBase page = doc.Pages[1];

// Create a PdfDestination object with specific page,location (0, 100)
PdfDestination dest = new PdfDestination(page, new PointF(0, 100));

// Create a PdfGoToAction object with the destination
PdfGoToAction action = new PdfGoToAction(dest);

// Set the open action of the document to the created action
doc.AfterOpenAction = action;
```

---

# spire.pdf pdf/a attachments
## convert PDF to PDF/A standard and add attachments
```csharp
// Convert the input PDF file to PDF/A-1b standard and save it to the memory stream
PdfStandardsConverter converter = new PdfStandardsConverter(input);
converter.ToPdfA1B(ms);

// Create a new PDF document
PdfDocument newDoc = new PdfDocument();

// Load the converted PDF document from the memory stream
newDoc.LoadFromStream(ms);

// Create a PdfAttachment object with the attachment file name and data
PdfAttachment attach1 = new PdfAttachment("attachment1.png", data);

// Create a PdfAttachment object with the attachment file name and data
PdfAttachment attach2 = new PdfAttachment("attachment2.pdf", data2);

// Add the attachments to the new PDF document
newDoc.Attachments.Add(attach1);
newDoc.Attachments.Add(attach2);
```

---

# Spire.PDF C# Conversion with Permissions
## Convert permissioned PDF to different formats while respecting permission settings
```csharp
// Create a PdfDocument object
PdfDocument doc = new PdfDocument();

// Load a PDF file
doc.LoadFromFile("source.pdf", "password");        

// Apply permissions options to the conversion options.
// When the option parameter is true, the PDF cannot be converted to other formats if permission Settings are set.
doc.ConvertOptions.ApplyPermissionsOptions(true);

// Convert to different formats based on file type
if (targetFormat.Equals("PPTX"))
{
    doc.SaveToFile("result.pptx", FileFormat.PPTX);
}                 
else if (targetFormat.Equals("DOCX"))
{
    doc.SaveToFile("result.docx", FileFormat.DOCX);
}
else if (targetFormat.Equals("XLSX"))
{
    doc.SaveToFile("result.xlsx", FileFormat.XLSX);
}

// Dispose of the PdfDocument object to release resources
doc.Dispose();
```

---

# Spire.PDF C# Conversion
## Convert PDF to DOCX with document properties
```csharp
// Create an instance of the PdfToDocConverter class with the input file path
PdfToDocConverter converter = new PdfToDocConverter(inputPath);

// Set various properties for the converted Word document
converter.DocxOptions.Title = "PDFTODOCX";
converter.DocxOptions.Subject = "Set document properties.";
converter.DocxOptions.Tags = "Test Tags";
converter.DocxOptions.Categories = "PDF";
converter.DocxOptions.Commments = "This document is just for testing the properties";
converter.DocxOptions.Authors = "E-iceblue Support Team";
converter.DocxOptions.LastSavedBy = "E-iceblue Support Team";
converter.DocxOptions.Revision = 8;
converter.DocxOptions.Version = "csharp V4.0";
converter.DocxOptions.ProgramName = "Spire.Pdf for .NET";
converter.DocxOptions.Company = "E-iceblue";
converter.DocxOptions.Manager = "E-iceblue";

// Convert the PDF document to a Word document
converter.SaveToDocx(outputPath);
```

---

# Spire.PDF C# PDF Conversion
## Convert PDF to grayscale
```csharp
//Output file path
string output = "ConvertToGrayPdf-result.pdf";

//Create a PdfGrayConverter with an pdf file
PdfGrayConverter converter = new PdfGrayConverter(@"..\..\..\..\..\..\Data\ConvertToGrayPdf.pdf");

//Convert the file to gray pdf
converter.ToGrayPdf(output);
```

---

# spire.pdf csharp conversion
## convert PDF to OFD format
```csharp
// Create pdf document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile(input);

// Convert pdf to ofd
pdf.SaveToFile(output, FileFormat.OFD);
```

---

# Spire.PDF C# PDF to HTML Conversion
## Convert PDF to HTML with embedded images
```csharp
// Open the PDF document using PdfDocument
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(file);

// Set the conversion options to embed images in HTML
doc.ConvertOptions.SetPdfToHtmlOptions(true, true);

// Convert the PDF document to an HTML file
doc.SaveToFile(result, FileFormat.HTML);

// Close the PDF document
doc.Close();
```

---

# Spire.PDF C# PDF to HTML Conversion
## Convert PDF to HTML with embedded SVG
```csharp
// Load PDF document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(inputFile);

// Enable SVG embedding for HTML conversion
doc.ConvertOptions.SetPdfToHtmlOptions(true);

// Save as HTML
doc.SaveToFile(outputFile, FileFormat.HTML);

// Close document
doc.Close();
```

---

# spire.pdf csharp conversion
## convert encrypted PDF to PDF/A
```csharp
// Create a new PdfStandardsConverter object with the input file path and password
PdfStandardsConverter converter = new PdfStandardsConverter(@"..\..\..\..\..\..\Data\Decryption.pdf", "test");

// Convert the input PDF to PDF/A-2A standard and save it
converter.ToPdfA2A("EncryptedPDFToPDFA.pdf");
```

---

# Spire.PDF HTML to PDF Conversion
## Convert HTML content to PDF document using Spire.Pdf library
```csharp
//Create a pdf document.
PdfDocument doc = new PdfDocument();
PdfPageSettings pgSt = new PdfPageSettings();
pgSt.Size = PdfPageSize.A4;

PdfHtmlLayoutFormat htmlLayoutFormat = new PdfHtmlLayoutFormat();
htmlLayoutFormat.IsWaiting = false;

// Convert HTML to PDF
doc.LoadFromHTML(htmlContent, true, pgSt, htmlLayoutFormat);
```

---

# Spire.PDF HTML to PDF Conversion
## Convert HTML from URL or string to PDF using Spire.PDF with plugin
```csharp
// Set the plugin path for HTML conversion
HtmlConverter.PluginPath = @"..\..\..\..\..\..\Data\plugins";

// Convert a URL to PDF
private void ConvertURLToPDF()
{
    // Enable JavaScript execution
    bool enableJavaScript = true;

    // Set the load timeout in milliseconds
    int loadTimeout = 100 * 1000;

    // Set the page size to 612x792 points (8.5x11 inches)
    SizeF pageSize = new SizeF(612, 792);

    // Set the page margins to 0 inch
    PdfMargins margins = new PdfMargins(0, 0);

    // Perform the conversion by calling the Convert method of HtmlConverter
    HtmlConverter.Convert("https://www.e-iceblue.com/", "HTMLtoPDF.pdf", enableJavaScript, loadTimeout, pageSize, margins);
}

// Convert an HTML string to PDF
private void ConvertHtmlStringToPDF()
{
    // Specify the input HTML string
    string input = @"<strong>This is a test for converting HTML string to PDF </strong>
    <ul><li>Spire.PDF supports converting HTML in URL into PDF</li>
    <li>Spire.PDF supports converting HTML string into PDF</li>
    <li>With the new plugin</li></ul>";

    // Specify the output file name
    string outputFile = "ToPDF.pdf";

    // Enable JavaScript execution
    bool enableJavaScript = true;

    // Set the load timeout in milliseconds
    int loadTimeout = 10 * 1000;

    // Set the page size to 612x792 points (8.5x11 inches)
    SizeF pageSize = new SizeF(612, 792);

    // Set the page margins to 0 inch
    PdfMargins margins = new PdfMargins(0);

    // Specify that the input is provided as HTML source code
    LoadHtmlType htmlSourceType = LoadHtmlType.SourceCode;

    // Perform the conversion by calling the Convert method of HtmlConverter
    HtmlConverter.Convert(input, outputFile, enableJavaScript, loadTimeout, pageSize, margins, htmlSourceType);
}
```

---

# spire.pdf csharp conversion
## convert OFD to PDF
```csharp
// Specify the path of the input OFD file
string inputFile = @"..\..\..\..\..\..\Data\Sample.ofd";

// Create a new OfdConverter object with the input OFD file path
OfdConverter converter = new OfdConverter(inputFile);

// Convert the OFD file to PDF
string result = "OFDToPDF.pdf";
converter.ToPdf(result);
```

---

# Spire.PDF PDFA to PDF Conversion
## Convert PDFA file to standard PDF format
```csharp
// Open the PDF document using PdfDocument
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Create a new PDF document to draw content on a new file
PdfNewDocument newDoc = new PdfNewDocument();
newDoc.CompressionLevel = PdfCompressionLevel.None;

// Iterate through each page in the original document
foreach (PdfPageBase page in doc.Pages)
{
    // Get the size of the current page
    SizeF size = page.Size;

    // Add a new page to the new document with the same size and no margins
    PdfPageBase p = newDoc.Pages.Add(size, new Spire.Pdf.Graphics.PdfMargins(0));

    // Draw the contents of the original page onto the new page
    page.CreateTemplate().Draw(p, 0, 0);
}

// Save the new document as a PDF file
newDoc.Save(output);

// Close the new document
newDoc.Close();
```

---

# spire.pdf csharp conversion
## convert pdf to excel
```csharp
//Load a pdf document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile("input.pdf");

//Save the pdf file to excel 
pdf.SaveToFile("output.xlsx", FileFormat.XLSX);
```

---

# Spire.PDF C# PDF to Excel Conversion
## Convert PDF document to Excel XLSX file with specific layout options
```csharp
// Load a pdf document
PdfDocument pdf = new PdfDocument();
pdf.LoadFromFile(PDFFile);

// Set conversion options to line layout
pdf.ConvertOptions.SetPdfToXlsxOptions(PdfToXlsxLayout.Line);

// Save the pdf file to excel
pdf.SaveToFile(ExcelFile, FileFormat.XLSX);
```

---

# Spire.PDF C# PDF to Markdown Conversion
## Convert PDF documents to Markdown format
```csharp
// Load a PDF document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(file);

// Convert the loaded PDF document to a Markdown file
doc.SaveToFile(output, FileFormat.Markdown);

// Close the PDF document
doc.Close();
```

---

# Spire.PDF C# Remove Hyperlinks
## Remove hyperlinks from PDF document by finding and deleting TextWebLink annotations
```csharp
//Get the first page of PDF document
PdfPageBase page = document.Pages[0];

//Get the annotation collection
PdfAnnotationCollection widgetCollection = page.AnnotationsWidget;

//Iterate through annotations to find and remove hyperlinks
if (widgetCollection.Count > 0)
{
    for (int i = widgetCollection.Count - 1; i >= 0; i--)
    {
        PdfAnnotation annotation = widgetCollection[i];
        //Check if the annotation is a TextWebLink (hyperlink)
        if (annotation is PdfTextWebLinkAnnotationWidget)
        {
            PdfTextWebLinkAnnotationWidget link = annotation as PdfTextWebLinkAnnotationWidget;
            //Remove the hyperlink annotation
            widgetCollection.Remove(link);
        }
    }
}
```

---

# Spire.PDF C# Conversion
## Convert multiple PDF pages to a single SVG file
```csharp
// Load the PDF document
PdfDocument pdfDocument = new PdfDocument();
pdfDocument.LoadFromFile(@"..\..\..\..\..\..\Data\GetPageInfo.pdf");

// Set the conversion option to output a single SVG file for multi-page PDF documents
pdfDocument.ConvertOptions.OutputToOneSvg = true;

// Save the converted SVG file
string result = "output.svg";
pdfDocument.SaveToFile(result, FileFormat.SVG);

// Close the PDF document
pdfDocument.Close();
```

---

# Spire.PDF SVG to PDF Conversion
## Convert SVG files to PDF format using Spire.PDF library
```csharp
//Create a new PDF document.
PdfDocument doc = new PdfDocument();

//Load the file from disk.
doc.LoadFromSvg(@"..\..\..\..\..\..\Data\template.svg");

//Save the document
String result = "SVgToPDF_out.pdf";
doc.SaveToFile(result);
```

---

# spire.pdf csharp text to pdf conversion
## Convert text content to PDF document using Spire.PDF library
```csharp
// Create a PDF document.
PdfDocument doc = new PdfDocument();

// Add a section to the document.
PdfSection section = doc.Sections.Add();

// Add a page to the section.
PdfPageBase page = section.Pages.Add();

// Create a PdfFont object using the Helvetica font with a size of 11.
PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 11);

// Create a PdfStringFormat object for text formatting.
PdfStringFormat format = new PdfStringFormat();
format.LineSpacing = 20f;

// Create a PdfBrush object for text color.
PdfBrush brush = PdfBrushes.Black;

// Create a PdfTextLayout object for text layout options.
PdfTextLayout textLayout = new PdfTextLayout();
textLayout.Break = PdfLayoutBreakType.FitPage;
textLayout.Layout = PdfLayoutType.Paginate;

// Define the bounds of the text widget on the page.
RectangleF bounds = new RectangleF(new PointF(10, 20), page.Canvas.ClientSize);

// Create a PdfTextWidget object with the text content, font, and brush.
PdfTextWidget textWidget = new PdfTextWidget(text, font, brush);
textWidget.StringFormat = format;

// Draw the text widget on the page using the specified bounds and text layout options.
textWidget.Draw(page, bounds, textLayout);
```

---

# Spire.PDF C# TIFF to PDF Conversion
## Convert multi-frame TIFF images to PDF document

```csharp
// Split Tiff to images.
Image[] images = SplitTIFFImage(tiffImage);

using (PdfDocument pdfDocument = new PdfDocument())
{
    for (int i = 0; i < images.Length; i++)
    {
        // Convert the image to PdfImage.
        PdfImage pdfImg = PdfImage.FromImage(images[i]);

        // Add a page to the PDF document.
        PdfPageBase page = pdfDocument.Pages.Add();

        // Scale the image.
        float width = pdfImg.Width * 0.7f;
        float height = pdfImg.Height * 0.7f;
        float x = (page.Canvas.ClientSize.Width - width) / 2;

        // Draw the image on the page.
        page.Canvas.DrawImage(pdfImg, x, 0, width, height);
    }

    // Save the PDF document to a file.
    pdfDocument.SaveToFile("TiffToPdf-result.pdf");
}

public static Image[] SplitTIFFImage(Image tiffImage)
{
    int frameCount = tiffImage.GetFrameCount(FrameDimension.Page);
    Image[] images = new Image[frameCount];
    Guid objGuid = tiffImage.FrameDimensionsList[0];
    FrameDimension objDimension = new FrameDimension(objGuid);

    for (int i = 0; i < frameCount; i++)
    {
        // Select the active frame from the TIFF image.
        tiffImage.SelectActiveFrame(objDimension, i);

        using (MemoryStream ms = new MemoryStream())
        {
            // Save the active frame as a separate TIFF image.
            tiffImage.Save(ms, ImageFormat.Tiff);

            // Create an Image object from the saved frame.
            images[i] = Image.FromStream(ms);
        }
    }

    return images;
}
```

---

# spire.pdf csharp conversion
## convert PDF to DOC document
```csharp
// Load a PDF document from the specified file path.
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(file);

// Convert the loaded PDF document to a DOC file.
doc.SaveToFile("ToDoc.doc", FileFormat.DOC);

// Close the PDF document.
doc.Close();
```

---

# spire.pdf csharp conversion
## convert PDF to DOCX
```csharp
// Load a PDF document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile("input.pdf");

// Convert PDF to DOCX
doc.SaveToFile("output.docx", FileFormat.DOCX);

// Close the document
doc.Close();
```

---

# Spire.PDF C# PDF to HTML Conversion
## Convert PDF document to HTML format
```csharp
// Create a new PdfDocument object.
PdfDocument doc = new PdfDocument();

// Load the PDF document from the specified file.
doc.LoadFromFile(file);

// Convert the loaded PDF document to an HTML file.
doc.SaveToFile("ToHTML.html", FileFormat.HTML);

// Close the PDF document.
doc.Close();
```

---

# Spire.PDF C# PDF to HTML Conversion
## Convert PDF to HTML files split by pages
```csharp
// Open the PDF document using PdfDocument
PdfDocument doc = new PdfDocument();
doc.LoadFromFile("input.pdf");

// Set the conversion options to split the PDF into HTML files based on pages
// Here, each page will be converted to a separate HTML file
doc.ConvertOptions.SetPdfToHtmlOptions(false, true, 1);

// Convert the PDF document to HTML files
doc.SaveToFile("output.html", FileFormat.HTML);

// Close the PDF document
doc.Close();
```

---

# Spire.PDF C# PDF to HTML Stream Conversion
## Convert PDF document to HTML format using memory stream
```csharp
// Create a new PDF document
PdfDocument pdf = new PdfDocument();

// Load a PDF file
pdf.LoadFromFile("SampleB_1.pdf");

// Create a new memory stream
MemoryStream ms = new MemoryStream();

// Save the PDF document to an HTML stream
pdf.SaveToStream(ms, FileFormat.HTML);

// Write the content of the memory stream to an HTML file
File.WriteAllBytes("ToHtml.html", ms.ToArray());

pdf.Close();
ms.Close();
```

---

# spire.pdf csharp pdf to image conversion
## Convert PDF document pages to PNG images
```csharp
// Create a new PdfDocument object.
PdfDocument doc = new PdfDocument();

// Load the PDF document from the specified file.
doc.LoadFromFile(file);

// Save each page of the PDF document as an image.
for (int i = 0; i < doc.Pages.Count; i++)
{
    // Convert the current page to an image with a resolution of 300x300 pixels.
    using (Image image = doc.SaveAsImage(i, 300, 300))
    {
        // Save the image as a PNG file.
        image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
    }
}

// Close the PDF document.
doc.Close();
```

---

# spire.pdf csharp pdf conversion
## convert PDF to linearized PDF format
```csharp
// Create an instance of the PdfToLinearizedPdfConverter class with the input PDF file path.
PdfToLinearizedPdfConverter converter = new PdfToLinearizedPdfConverter(inputPath);

// Convert the input PDF file to a linearized PDF and save it using the specified result file name.
converter.ToLinearizedPdf(outputPath);
```

---

# Spire.PDF C# PDF to Markdown Conversion
## Convert PDF to Markdown while ignoring images
```csharp
// Create an instance of the PdfToMarkdownConverter
PdfToMarkdownConverter converter = new PdfToMarkdownConverter(inputFile);

// Set the option to ignore images 
converter.MarkdownOptions.IgnoreImage = true;

// Convert the PDF to Markdown
converter.ConvertToMarkdown(outputFile);
```

---

# Spire.PDF PDF to PCL Conversion
## Convert PDF documents to PCL format using Spire.PDF library
```csharp
// Create a new PdfDocument object.
PdfDocument doc = new PdfDocument();

// Load the PDF document from the specified input file.
doc.LoadFromFile(input);

// Save the loaded PDF document as a PCL file using the specified output file name.
doc.SaveToFile(output, FileFormat.PCL);
```

---

# Spire.PDF C# PDF to PDFA Conversion
## Convert PDF to PDFA-1b format using Spire.PDF library
```csharp
// Create an instance of the PdfStandardsConverter class
PdfStandardsConverter converter = new PdfStandardsConverter(inputFilePath);

// Convert the PDF file to PDFA-1b format
converter.ToPdfA1B(outputFilePath);
```

---

# Spire.PDF PDF/A-2B Conversion
## Convert standard PDF to PDF/A-2B format
```csharp
//Load a standard pdf document
PdfStandardsConverter converter = new PdfStandardsConverter("source.pdf");

//Convert Pdf to PdfA2B 
converter.ToPdfA2B("result.pdf");
```

---

# PDF to PDF/A Conversion with Metadata
## Converts a PDF document to PDF/A format while preserving metadata
```csharp
string path = @"..\..\..\..\..\..\Data\ToPDFAWithMetadata.pdf";
string pdfA = "ToPDFAWithMetadata_out.pdf";

// Create an instance of the PdfStandardsConverter class
PdfStandardsConverter converter = new PdfStandardsConverter(path);
// Convert to PDFA format document to preserve XMP data
converter.Options.PreserveAllowedMetadata = true;
converter.ToPdfA1A(pdfA);
```

---

# Spire.PDF C# Conversion
## Convert PDF to PostScript format
```csharp
//Load a PDF document
PdfDocument document = new PdfDocument();
document.LoadFromFile(inputPath);

//Save to PostScript
document.SaveToFile(outputPath, FileFormat.POSTSCRIPT);
```

---

# spire.pdf csharp conversion
## convert pdf to pptx
```csharp
// Create a pdf document object
PdfDocument doc = new PdfDocument();

// Load pdf document
doc.LoadFromFile(inputFile);

// Convert to pptx file
doc.SaveToFile(outputFile, FileFormat.PPTX);
doc.Close();
```

---

# Spire.PDF C# Conversion
## Convert PDF to SVG format
```csharp
//Open pdf document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(file);

//Convert to svg file
doc.SaveToFile("ToSVG-result.svg", FileFormat.SVG);
doc.Close();
```

---

# spire.pdf csharp pdf to tiff
## convert PDF document to multi-page TIFF image
```csharp
private static Image[] SaveAsImage(PdfDocument document)
{
    Image[] images = new Image[document.Pages.Count];
    for (int i = 0; i < document.Pages.Count; i++)
    {
        // Use the document.SaveAsImage() method to save the pdf page as an image
        images[i] = document.SaveAsImage(i);
    }
    return images;
}

private static ImageCodecInfo GetEncoderInfo(string mimeType)
{
    // Get the image encoders available on the system
    ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

    // Find the encoder that matches the specified MIME type
    for (int j = 0; j < encoders.Length; j++)
    {
        if (encoders[j].MimeType == mimeType)
            return encoders[j];
    }

    // Throw an exception if the specified MIME type is not found
    throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
}

public static void JoinTiffImages(Image[] images, string outFile, EncoderValue compressEncoder)
{
    // Use the save encoder
    System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
    EncoderParameters ep = new EncoderParameters(2);

    // Set the parameters for saving the images as a multi-frame TIFF file with specified compression
    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
    ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)compressEncoder);

    Image pages = images[0];
    int frame = 0;

    // Get the encoder info for TIFF format
    ImageCodecInfo info = GetEncoderInfo("image/tiff");

    foreach (Image img in images)
    {
        if (frame == 0)
        {
            pages = img;
            // Save the first frame
            pages.Save(outFile, info, ep);
        }
        else
        {
            // Save the intermediate frames as additional pages in the TIFF file
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);
            pages.SaveAdd(img, ep);
        }

        if (frame == images.Length - 1)
        {
            // Flush and close the TIFF file after saving all frames
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
            pages.SaveAdd(ep);
        }

        frame++;
    }
}
```

---

# Spire.PDF C# Conversion
## Convert PDF page to image with transparent background
```csharp
// Set the conversion options for converting the PDF document to an image with transparent background
doc.ConvertOptions.SetPdfToImageOptions(0);

// Convert a page of the PDF document to an image
Image image = doc.SaveAsImage(0, PdfImageType.Bitmap);
```

---

# spire.pdf csharp conversion
## convert PDF to Word document using second approach
```csharp
// Create a PdfToWordConverter object to convert the PDF to Word with flow layout.
PdfToWordConverter converter = new PdfToWordConverter(file);

// Save the converted Word document.
converter.SaveToDocx("ToWordConvorter.docx");

// Dispose of the converter object to release any resources used.
converter.Dispose();
```

---

# spire.pdf csharp conversion
## convert PDF to XLSX
```csharp
//Create a pdf document
using (PdfDocument doc = new PdfDocument())
{
    doc.LoadFromFile(@"..\..\..\..\..\..\Data\ChartSample.pdf");

    //Save to XLSX
    doc.SaveToFile(result, FileFormat.XLSX);
}
```

---

# Spire.PDF to XLSX Conversion
## Convert PDF to XLSX with specific options
```csharp
// Load a PDF document
PdfDocument document = new PdfDocument();
document.LoadFromFile(path);

// Create an XlsxLineLayoutOptions object with parameters: convertToMultipleSheet, showRotatedText, splitCell, wrapText
XlsxLineLayoutOptions options = new XlsxLineLayoutOptions(convertToMultipleSheet, showRotatedText, splitCell, wrapText);

// Set the PDF to Excel conversion options
document.ConvertOptions.SetPdfToXlsxOptions(options);

// Save the document as Excel format
document.SaveToFile(output, FileFormat.XLSX);
```

---

# spire.pdf csharp conversion
## convert PDF to XLSX with special table layout options
```csharp
// Create a new PdfDocument object to work with PDF files
PdfDocument document = new PdfDocument();

// Load the PDF document from the specified file path
document.LoadFromFile(filePath);

// Create a new XlsxSpecialTableLayoutOptions object with specified layout options
XlsxSpecialTableLayoutOptions options = new XlsxSpecialTableLayoutOptions(false, false, false);

// Set the XlsxSpecialTableLayoutOptions as the conversion options for PDF to XLSX conversion
document.ConvertOptions.SetPdfToXlsxOptions(options);

// Save the converted document as an XLSX file
document.SaveToFile("Result.xlsx", FileFormat.XLSX);

// Dispose of system resources associated with the PdfDocument object
document.Dispose();
```

---

# Spire.PDF C# PDF to XPS Conversion
## Convert PDF documents to XPS format
```csharp
// Create a new PdfDocument object.
PdfDocument doc = new PdfDocument();

// Load the PDF document from the specified file path.
doc.LoadFromFile(file);

// Convert the PDF document to an XPS file and save it with the specified output file name and format (XPS).
doc.SaveToFile("ToXPS-result.xps", FileFormat.XPS);

// Close the PDF document.
doc.Close();
```

---

# spire.pdf csharp xps conversion
## convert XPS document to PDF format
```csharp
// Create a new PdfDocument object.
PdfDocument doc = new PdfDocument();

// Load the XPS document into the PdfDocument object from the specified file path.
doc.LoadFromXPS(file);

// Convert the XPS document to a PDF file and save it with the output file name.
doc.SaveToFile("XPStoPDF-result.pdf");

// Close the PdfDocument object.
doc.Close();
```

---

# spire.pdf csharp conversion
## convert PDF to HTML with embedded images
```csharp
// Open pdf document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(file);

// Set the convertion option to embed image in html
doc.ConvertOptions.SetPdfToHtmlOptions(true, true);

// Convert to html file
doc.SaveToFile(result, FileFormat.HTML);
doc.Close();
```

---

# Spire.PDF C# PDF to HTML Conversion
## Convert PDF to HTML with embedded SVG
```csharp
//Open pdf document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(file);

//Set the bool useEmbeddedSvg as true to convert to HTML with embeding SVG
doc.ConvertOptions.SetPdfToHtmlOptions(true);

//Convert to html file
doc.SaveToFile(result, FileFormat.HTML);
doc.Close();
```

---

# Spire.PDF C# Conversion
## Convert PDF to HTML files split by pages
```csharp
//Open pdf document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(file);

//Split to HTML file according to pages, here one page will convert to a HTML file.
doc.ConvertOptions.SetPdfToHtmlOptions(false, true, 1);

string output = "ToHTMLFilesSplittedByPages_out.html";

//Convert to html file
doc.SaveToFile(output, FileFormat.HTML);
doc.Close();
```

---

# spire.pdf csharp pdf to html conversion
## convert PDF document to HTML using memory stream
```csharp
//Create a pdf document.
PdfDocument pdf = new PdfDocument();
//Load file from disk
pdf.LoadFromFile(@"..\..\..\..\..\..\..\Data\SampleB_1.pdf");

MemoryStream ms = new MemoryStream();
//Save to HTML stream
pdf.SaveToStream(ms, FileFormat.HTML);
```

---

# spire.pdf csharp page manipulation
## delete a specific page from a pdf document
```csharp
// Delete the fifth page from the document.
doc.Pages.RemoveAt(4);
```

---

# spire.pdf csharp content extraction
## extract text and images from PDF document
```csharp
// Create a new PdfDocument object
PdfDocument doc = new PdfDocument();
// Load the PDF document
doc.LoadFromFile(filePath);

// Create PdfImageHelper
PdfImageHelper imageHelper = new PdfImageHelper();

// Iterate through each page of the document
foreach (PdfPageBase page in doc.Pages)
{
    // Extract text from the current page
    PdfTextExtractor pdfTextExtractor = new PdfTextExtractor(page);
    PdfTextExtractOptions pdfTextExtractOptions = new PdfTextExtractOptions();
    pdfTextExtractOptions.IsExtractAllText = true;
    string extractedText = pdfTextExtractor.ExtractText(pdfTextExtractOptions);
    
    // Get images information 
    PdfImageInfo[] imageInfos = imageHelper.GetImagesInfo(page);
    
    // Extract images from the current page
    foreach (PdfImageInfo info in imageInfos)
    {
        Image image = info.Image;
    }
}

// Close the PDF document
doc.Close();
```

---

# spire.pdf csharp page count
## get the number of pages in a pdf document
```csharp
// Open a pdf document and get its page count
using (PdfDocument pdf = new PdfDocument())
{
    // Load the PDF document from the specified file path.
    pdf.LoadFromFile(pdfFile);

    // Get the number of pages in the PDF document.
    int count = pdf.Pages.Count;
}
```

---

# spire.pdf csharp page information
## extract PDF page dimensions and properties
```csharp
// Create a new PdfDocument object.
PdfDocument doc = new PdfDocument();

// Get the first page of the loaded PDF document.
PdfPageBase page = doc.Pages[0];

// Get the size and position of the MediaBox for the page in points.
float MediaBoxWidth = page.MediaBox.Width;
float MediaBoxHeight = page.MediaBox.Height;
float MediaBoxX = page.MediaBox.X;
float MediaBoxY = page.MediaBox.Y;

// Get the size and position of the BleedBox for the page in points.
float BleedBoxWidth = page.BleedBox.Width;
float BleedBoxHeight = page.BleedBox.Height;
float BleedBoxX = page.BleedBox.X;
float BleedBoxY = page.BleedBox.Y;

// Get the size and position of the CropBox for the page in points.
float CropBoxWidth = page.CropBox.Width;
float CropBoxHeight = page.CropBox.Height;
float CropBoxX = page.CropBox.X;
float CropBoxY = page.CropBox.Y;

// Get the size and position of the ArtBox for the page in points.
float ArtBoxWidth = page.ArtBox.Width;
float ArtBoxHeight = page.ArtBox.Height;
float ArtBoxX = page.ArtBox.X;
float ArtBoxY = page.ArtBox.Y;

// Get the size and position of the TrimBox for the page in points.
float TrimBoxWidth = page.TrimBox.Width;
float TrimBoxHeight = page.TrimBox.Height;
float TrimBoxX = page.TrimBox.X;
float TrimBoxY = page.TrimBox.Y;

// Get the actual width and height of the page in points.
float actualSizeW = page.ActualSize.Width;
float actualSizeH = page.ActualSize.Height;

// Get the rotation angle of the current page.
PdfPageRotateAngle rotationAngle = page.Rotation;
string rotation = rotationAngle.ToString();
```

---

# Spire.PDF Get Page Labels
## Extract page labels from a PDF document
```csharp
// Create a PdfDocument instance
PdfDocument pdf = new PdfDocument();

// Load the PDF file
pdf.LoadFromFile("PageLabel.pdf");

// Create a StringBuilder instance to store page labels
StringBuilder sb = new StringBuilder();

// Get the labels of the pages in the PDF file
for (int i = 0; i < pdf.Pages.Count; i++)
{
    // Append the page label information to the StringBuilder
    sb.AppendLine("The page label of page " + (i + 1) + " is \"" + pdf.Pages[i].PageLabel + "\"");
}
```

---

# spire.pdf c# get page size
## Extract and convert PDF page dimensions to different units
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load an existing pdf from disk
doc.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

//Get the first page of the loaded PDF file
PdfPageBase page = doc.Pages[0];

//Get the width of page based on "point"
float pointWidth = page.Size.Width;

//Get the height of page
float pointHeight = page.Size.Height;

//Create PdfUnitConvertor to convert the unit
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();

//Convert the size with "pixel"
float pixelWidth = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Pixel);
float pixelHeight = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Pixel);

//Convert the size with "inch"
float inchWidth = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Inch);
float inchHeight = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Inch);

//Convert the size with "centimeter"
float centimeterWidth = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Centimeter);
float centimeterHeight = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Centimeter);
```

---

# Spire.PDF C# Empty Page Insertion
## Demonstrates how to insert an empty page into a PDF document

```csharp
// Create a new PdfDocument object.
PdfDocument doc = new PdfDocument();

// Insert a blank page at the specified position (index 1, which becomes the second page).
doc.Pages.Insert(1);
```

---

# Spire.PDF C# Empty Page Insertion
## Insert an empty page at the end of a PDF document
```csharp
//Add an empty page at the end of the PDF document
doc.Pages.Add(PdfPageSize.A4, new PdfMargins(0, 0));
```

---

# spire.pdf csharp page labels
## manage PDF page labels
```csharp
// Create a new PDF document and load from file
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(input);

// Initialize a new instance of PdfPageLabels to manage page labels
doc.PageLabels = new PdfPageLabels();

// Add a new label starting from page 0 with Decimal_Arabic_Numerals_Style style and text "label test"
doc.PageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "label test ");

// Save the modified document to the specified output file format (PDF)
doc.SaveToFile(output, FileFormat.PDF);

// Get the PageLabels of the provided document
PdfPageLabels pageLabels = newdoc.PageLabels;

// Add a new label starting from page 0 with Decimal_Arabic_Numerals_Style style and text "new lable"
pageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "new lable");
```

---

# spire.pdf page setup
## demonstrates how to set up PDF pages with different sizes, orientations, rotations and margins
```csharp
// Create a pdf document
PdfDocument doc = new PdfDocument();

// Set the margin
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

// Create one page with A4 size and specified margin
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);
page.BackgroundColor = Color.Chocolate;

// Add another page with A4 size and specified margin
page = doc.Pages.Add(PdfPageSize.A4, margin);
page.BackgroundColor = Color.Coral;

// Add a page with A3 size, rotated 180 degrees, and landscape orientation
page = doc.Pages.Add(PdfPageSize.A3, margin, PdfPageRotateAngle.RotateAngle180, PdfPageOrientation.Landscape);
page.BackgroundColor = Color.LightPink;

// Create a section and add a page to it
PdfSection section = doc.Sections.Add();
page = section.Pages.Add();
section.PageSettings.Size = PdfPageSize.A4;
section.PageSettings.Margins = margin;

// Set background color for the page
page = section.Pages.Add();
page.BackgroundColor = Color.LightSkyBlue;

// Add a landscape-oriented section
section = doc.Sections.Add();
section.PageSettings.Orientation = PdfPageOrientation.Landscape;
page = section.Pages.Add();
section.PageSettings.Size = PdfPageSize.A4;
section.PageSettings.Margins = margin;

// Add a section with 90-degree rotation
section = doc.Sections.Add();
page = section.Pages.Add();
section.PageSettings.Size = PdfPageSize.A4;
section.PageSettings.Margins = margin;
section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;

// Add a section with 180-degree rotation
section = doc.Sections.Add();
page = section.Pages.Add();
section.PageSettings.Size = PdfPageSize.A4;
section.PageSettings.Margins = margin;
section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle180;
```

---

# spire.pdf pagination
## create PDF document with pagination, headers, footers and page numbers
```csharp
// Create a new instance of a PDF document
PdfDocument doc = new PdfDocument();

// Set the margin for the document
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

// Draw the cover page using specified margin and add it to the document
DrawCover(doc, doc.Sections.Add(), margin);

// Draw the content page using specified margin and add it to the document
DrawContent(doc, doc.Sections.Add(), margin);

// Draw the page number on the second section of the document using specified margin,
// starting from page 1 and counting the total number of pages in the second section
DrawPageNumber(doc.Sections[1], margin, 1, doc.Sections[1].Pages.Count);

private void DrawCover(PdfDocument pdf, PdfSection section, PdfMargins margin)
{
    // Set the page size of the section to A4
    section.PageSettings.Size = PdfPageSize.A4;
    section.PageSettings.Margins.All = 0;

    // Add a new page to the section
    PdfPageBase page = section.Pages.Add();

    // Create a new instance of PdfPageLabels for the document
    pdf.PageLabels = new PdfPageLabels();

    // Add page labels to the document starting from index 0 with lowercase Roman numerals and prefix "cover "
    pdf.PageLabels.AddRange(0, PdfPageLabels.Lowercase_Roman_Numerals_Style, "cover ");

    // Call a method to draw the header and footer on the page
    DrawPageHeaderAndFooter(page, margin, true);

    // Set up colors, fonts, and text format for the content
    PdfBrush brush1 = PdfBrushes.LightGray;
    PdfBrush brush2 = PdfBrushes.Blue;
    PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 8f));
    PdfStringFormat format = new PdfStringFormat();
    format.MeasureTrailingSpaces = true;
    String text1 = "(All text and picture from ";
    String text2 = "Wikipedia";
    String text3 = ", the free encyclopedia)";
    float x = 0, y = 10;

    // Adjust the starting position of drawing based on the margin
    x = x + margin.Left;
    y = y + margin.Top;

    // Draw the content strings on the page
    page.Canvas.DrawString(text1, font1, brush1, x, y, format);
    x = x + font1.MeasureString(text1, format).Width;
    page.Canvas.DrawString(text2, font1, brush2, x, y, format);
    x = x + font1.MeasureString(text2, format).Width;
    page.Canvas.DrawString(text3, font1, brush1, x, y, format);

    // Set up colors, image, and other parameters for the cover
    PdfBrush brush3 = PdfBrushes.Black;
    PdfBrush brush4 = new PdfSolidBrush(new PdfRGBColor(0xf9, 0xf9, 0xf9));
    PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg");
    String text = "Personification of \"Science\" in front of the Boston Public Library";
    float r = image.PhysicalDimension.Height / image.Height;
    PdfPen pen = new PdfPen(brush1, r);
    SizeF size = font1.MeasureString(text, image.PhysicalDimension.Width - 2);
    PdfTemplate template = new PdfTemplate(image.PhysicalDimension.Width + 4 * r + 4, image.PhysicalDimension.Height + 4 * r + 7 + size.Height);

    // Draw a rectangle with border and fill on the template
    template.Graphics.DrawRectangle(pen, brush4, 0, 0, template.Width, template.Height);

    // Adjust the starting position of drawing based on the margin and radius
    x = y = r + 2;

    // Draw a rectangle on the template with a brush
    template.Graphics.DrawRectangle(brush1, x, y,
        image.PhysicalDimension.Width + 2 * r,
        image.PhysicalDimension.Height + 2 * r);

    // Adjust the starting position of drawing within the rectangle
    x = y = x + r;

    // Draw the image on the template
    template.Graphics.DrawImage(image, x, y);

    // Adjust the starting position of drawing for the text below the image
    x = x - 1;
    y = y + image.PhysicalDimension.Height + r + 2;

    // Draw the text on the template using specified font, brush, and rectangle
    template.Graphics.DrawString(text, font1, brush3,
        new RectangleF(new PointF(x, y), size));

    // Calculate the positioning of the template and draw it on the page canvas
    float x1 = (page.Canvas.ClientSize.Width - template.Width) / 2;
    float y1 = (page.Canvas.ClientSize.Height - margin.Top - margin.Bottom) * (1 - 0.618f) - template.Height / 2 + margin.Top;
    template.Draw(page.Canvas, x1, y1);

    // Set up alignment and font for the title text
    format.Alignment = PdfTextAlignment.Center;
    PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 24f, FontStyle.Bold));

    // Calculate the positioning of the title text and draw it on the page canvas
    x = page.Canvas.ClientSize.Width / 2;
    y = y1 + template.Height + 10;
    page.Canvas.DrawString("Science History and Etymology", font2, brush3, x, y, format);
}

private void DrawContent(PdfDocument pdf, PdfSection section, PdfMargins margin)
{
    // Set the page size of the section to A4
    section.PageSettings.Size = PdfPageSize.A4;
    section.PageSettings.Margins.All = 0;

    // Add a new page to the section
    PdfPageBase page = section.Pages.Add();

    // Add page labels to the document starting from index 1 with decimal Arabic numerals and prefix "page "
    pdf.PageLabels.AddRange(1, PdfPageLabels.Decimal_Arabic_Numerals_Style, "page ");

    // Call a method to draw the header and footer on the page without cover information
    DrawPageHeaderAndFooter(page, margin, false);

    // Set up initial positions and dimensions
    float x = margin.Left;
    float y = margin.Top + 8;
    float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;

    // Set up font, brush, and pen for the title
    PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f), true);
    PdfBrush brush1 = PdfBrushes.Black;
    PdfPen pen1 = new PdfPen(brush1, 0.75f);

    // Draw the title text on the page canvas
    page.Canvas.DrawString("Science History and Etymology", font1, brush1, x, y);

    // Adjust the position and draw a horizontal line below the title
    y = y + font1.MeasureString("Science History and Etymology").Height + 6;
    page.Canvas.DrawLine(pen1, x, y, page.Canvas.ClientSize.Width - margin.Right, y);
    y = y + 1.75f;

    // Set up content strings and format options
    String content = "Main articles: History of science and Scientific revolution...";
    String[] lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Italic), true);
    PdfStringFormat format1 = new PdfStringFormat();
    format1.MeasureTrailingSpaces = true;
    format1.LineSpacing = font2.Height * 1.5f;
    format1.ParagraphIndent = font2.MeasureString("\t", format1).Width;

    // Create a PdfStringLayouter for arranging the remaining content
    PdfStringLayouter textLayouter = new PdfStringLayouter();

    // Use the textLayouter to layout the remaining content on the page
    PdfStringLayoutResult result = textLayouter.Layout(content, font3, format2, new SizeF(width, float.MaxValue));

    // Iterate through each line in the layout result
    foreach (LineInfo line in result.Lines)
    {
        // Check if the line is the first line of a paragraph
        if ((line.LineType & LineType.FirstParagraphLine) == LineType.FirstParagraphLine)
        {
            // Adjust the vertical position to create some spacing before the paragraph
            y = y + font3.Height * 0.75f;
        }

        // Check if the current position exceeds the available space on the current page
        if (y > (page.Canvas.ClientSize.Height - margin.Bottom - result.LineHeight))
        {
            // Add a new page to the section
            page = section.Pages.Add();
            
            // Call a method to draw the header and footer on the newly added page
            DrawPageHeaderAndFooter(page, margin, false);
            
            // Reset the vertical position to the top margin
            y = margin.Top;
        }

        // Draw the line of text on the page canvas
        page.Canvas.DrawString(line.Text, font3, brush1, x, y, format2);
        
        // Adjust the vertical position for the next line
        y = y + result.LineHeight;
    }
}

private void DrawPageHeaderAndFooter(PdfPageBase page, PdfMargins margin, bool isCover)
{
    // Set the transparency of the canvas
    page.Canvas.SetTransparency(0.5f);

    // Load the header and footer images
    PdfImage headerImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Header.png");
    PdfImage footerImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Footer.png");

    // Draw the header and footer images
    page.Canvas.DrawImage(headerImage, new PointF(0, 0));
    page.Canvas.DrawImage(footerImage, new PointF(0, page.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height));

    if (isCover)
    {
        page.Canvas.SetTransparency(1);
        return;
    }

    // Set up brush, pen, font, format for the header and footer text
    PdfBrush brush = PdfBrushes.Black;
    PdfPen pen = new PdfPen(brush, 0.75f);
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic), true);
    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
    format.MeasureTrailingSpaces = true;
    float space = font.Height * 0.75f;

    // Set up initial positions and dimensions
    float x = margin.Left;
    float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
    float y = margin.Top - space;

    // Draw a horizontal line below the header
    page.Canvas.DrawLine(pen, x, y, x + width, y);

    // Adjust the position for the header text
    y = y - 1 - font.Height;

    // Draw the header text
    page.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, format);

    // Set the transparency of the canvas to 1 (100% opacity)
    page.Canvas.SetTransparency(1);
}

private void DrawPageNumber(PdfSection section, PdfMargins margin, int startNumber, int pageCount)
{
    // Iterate through each page in the section
    foreach (PdfPageBase page in section.Pages)
    {
        // Set the transparency of the canvas
        page.Canvas.SetTransparency(0.5f);

        // Set up brush, pen, font, format for the page number text
        PdfBrush brush = PdfBrushes.Black;
        PdfPen pen = new PdfPen(brush, 0.75f);
        PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic), true);
        PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
        format.MeasureTrailingSpaces = true;
        float space = font.Height * 0.75f;

        // Set up initial positions and dimensions
        float x = margin.Left;
        float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
        float y = page.Canvas.ClientSize.Height - margin.Bottom + space;

        // Draw a horizontal line above the footer
        page.Canvas.DrawLine(pen, x, y, x + width, y);

        // Adjust the position for the page number text
        y = y + 1;

        // Create the page number label
        String numberLabel = String.Format("{0} of {1}", startNumber++, pageCount);

        // Draw the page number label
        page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format);

        // Set the transparency of the canvas to 1 (100% opacity)
        page.Canvas.SetTransparency(1);
    }
}
```

---

# Spire.PDF C# Page Size Reset
## Reset PDF page size by scaling pages
```csharp
// Set the margins for the new document
PdfMargins margins = new PdfMargins(0);

// Create a new PDF document to store the reset page size version
using (PdfDocument newDoc = new PdfDocument())
{
    // Set the scale factor for resizing the pages
    float scale = 0.8f;

    // Iterate through each page of the original document
    for (int i = 0; i < originalDoc.Pages.Count; i++)
    {
        PdfPageBase page = originalDoc.Pages[i];

        // Calculate the new width and height based on the scale factor
        float width = page.Size.Width * scale;
        float height = page.Size.Height * scale;

        // Add a new page to the new document with the expected width, height, and margins
        PdfPageBase newPage = newDoc.Pages.Add(new SizeF(width, height), margins);

        // Apply the scale transformation to the new page
        newPage.Canvas.ScaleTransform(scale, scale);

        // Copy the content of the original page into the new page
        newPage.Canvas.DrawTemplate(page.CreateTemplate(), PointF.Empty);
    }
}
```

---

# Spire.PDF C# Page Rotation
## Rotate an existing PDF page by 270 degrees clockwise
```csharp
// Create a new PDF document
PdfDocument doc = new PdfDocument();

// Load an existing PDF
doc.LoadFromFile("input.pdf");

// Get the first page
PdfPageBase page = doc.Pages[0];

// Get the original rotation angle
int rotation = (int)page.Rotation;

// Set the desired rotation angle (rotate 270 degrees clockwise)
rotation += (int)PdfPageRotateAngle.RotateAngle270;

// Apply the rotation to the PDF page
page.Rotation = (PdfPageRotateAngle)rotation;

// Save the modified document
doc.SaveToFile("output.pdf");
```

---

# Spire.PDF Page Rotation
## Creating a PDF with a rotated page
```csharp
// Create a new PDF document
PdfDocument doc = new PdfDocument();

// Create a PdfUnitConvertor to convert units
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();

// Set the page margins using converted units (2.54 cm top and bottom, 2.0 cm left and right)
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(2.0f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

// Create a new section for the document
PdfSection section = doc.Sections.Add();

// Set the size of the PDF page to "A4"
section.PageSettings.Size = PdfPageSize.A4;

// Set the page margins for the section
section.PageSettings.Margins = margin;

// Set the rotation angle of the section to 90 degrees clockwise
section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;

// Add a new page to the section
PdfPageBase page = section.Pages.Add();
```

---

# Spire.PDF C# Page Orientation
## Set PDF page orientation based on content dimensions
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Add a section
PdfSection section = doc.Sections.Add();

//Set page orientation based on content dimensions
if (contentWidth > section.PageSettings.Size.Width)
    //Set the orientation as landscape
    section.PageSettings.Orientation = PdfPageOrientation.Landscape;
else
    section.PageSettings.Orientation = PdfPageOrientation.Portrait;

//Add a new page with the specified orientation
PdfPageBase page = section.Pages.Add();
```

---

# Spire.PDF C# Tab Order
## Set tab order in PDF document
```csharp
// Disable incremental updates to the document structure to set tab order
pdf.FileInfo.IncrementalUpdate = false;

// Get the first page of the PDF
PdfPageBase page = pdf.Pages[0];

// Set the tab order of the page using the structure method
page.SetTabOrder(TabOrder.Structure);
```

---

# Spire.PDF C# Page Splitting
## Split a PDF page into multiple pages with half the height
```csharp
// Create a new PDF document
PdfDocument newPdf = new PdfDocument();

// Remove all the margins for the new document
newPdf.PageSettings.Margins.All = 0;

// Set the page size of the new PDF to match the width and half the height of the original page
newPdf.PageSettings.Width = originalPage.Size.Width;
newPdf.PageSettings.Height = originalPage.Size.Height / 2;

// Add a new page to the new PDF document
PdfPageBase newPage = newPdf.Pages.Add();

// Specify the text layout settings for drawing the page content
PdfTextLayout format = new PdfTextLayout();
format.Break = PdfLayoutBreakType.FitPage;
format.Layout = PdfLayoutType.Paginate;

// Draw the content of the original page onto the new page using a template
originalPage.CreateTemplate().Draw(newPage, new PointF(0, 0), format);
```

---

# spire.pdf csharp split pages
## split PDF file by particular pages
```csharp
//Create a pdf document
PdfDocument oldPdf = new PdfDocument();

//Create a new PDF document
PdfDocument newPdf = new PdfDocument();

//Initialize a new instance of PdfPageBase class
PdfPageBase page;

//Specify the pages which you want them to be split
for (int i = 1; i < 3; i++)
{
    //Add same size page for newPdf
    page = newPdf.Pages.Add(oldPdf.Pages[i].Size, new Spire.Pdf.Graphics.PdfMargins(0));

    //Create template of the oldPdf page and draw into newPdf page
    oldPdf.Pages[i].CreateTemplate().Draw(page, new System.Drawing.PointF(0, 0));
}
```

---

# spire.pdf csharp zoom page contents
## Scale PDF page contents to fit new page size
```csharp
// Create a new PDF document
PdfDocument newDoc = new PdfDocument();

// Iterate through each page in the original document
foreach (PdfPageBase page in doc.Pages)
{
    // Add a new page to the new document with 'A3' size and no margins
    PdfPageBase newPage = newDoc.Pages.Add(PdfPageSize.A3, new PdfMargins(0, 0));

    // Zoom the content of the original page to fit within the boundaries of the new page
    newPage.Canvas.ScaleTransform(newPage.ActualSize.Width / page.ActualSize.Width,
                                  (newPage.ActualSize.Height / page.ActualSize.Height));

    // Draw the content of the original page onto the new page
    newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(0, 0));
}
```

---

# Spire.PDF C# Metadata Operations
## Add custom metadata to PDF from XML
```csharp
//Set the metadata from xml file to Pdf file
doc.Metadata = PdfXmpMetadata.Parse(stream);
```

---

# spire.pdf csharp layers
## add layers to PDF document
```csharp
// Create a new layer named "red line" with visibility set to "On"
PdfLayer layer = doc.Layers.AddLayer("red line", PdfVisibility.On);

// Create a graphics context for drawing on the specified page's canvas using the created layer
PdfCanvas pcA = layer.CreateGraphics(page.Canvas);

// Draw a red line on the graphics context using a pen with thickness 2, starting from (100, 350) to (300, 350)
pcA.DrawLine(new PdfPen(PdfBrushes.Red, 2), new PointF(100, 350), new PointF(300, 350));

// Create a new layer named "blue line" without specifying visibility (default is "Off")
layer = doc.Layers.AddLayer("blue line");

// Create a graphics context for drawing on the first page's canvas using the newly created layer
PdfCanvas pcB = layer.CreateGraphics(doc.Pages[0].Canvas);

// Draw a blue line on the graphics context using a pen with thickness 2, starting from (100, 400) to (300, 400)
pcB.DrawLine(new PdfPen(PdfBrushes.Blue, 2), new PointF(100, 400), new PointF(300, 400));

// Create a new layer named "green line" without specifying visibility (default is "Off")
layer = doc.Layers.AddLayer("green line");

// Create a graphics context for drawing on the first page's canvas using the newly created layer
PdfCanvas pcC = layer.CreateGraphics(doc.Pages[0].Canvas);

// Draw a green line on the graphics context using a pen with thickness 2, starting from (100, 450) to (300, 450)
pcC.DrawLine(new PdfPen(PdfBrushes.Green, 2), new PointF(100, 450), new PointF(300, 450));
```

---

# Spire.PDF Metadata Namespace Management
## Add namespace and custom properties to PDF document metadata
```csharp
//Add new namespace to metadata
PdfXmpNamespace.RegisterNamespace("http://myRandomNamespace", "zf");

//Add custom property to new namespace
pdfDocument.Metadata.SetPropertyString("http://myRandomNamespace", "test1", "my test");

//Reset namespace
PdfXmpNamespace.ResetNamespaces();
```

---

# Spire.PDF C# Booklet Creation
## Create a booklet from a PDF file with specified dimensions
```csharp
// Create a new instance of the PdfDocument class
PdfDocument doc = new PdfDocument();

// Set the width and height for the booklet, which is double the width of A4 size and the same height as A4
float width = PdfPageSize.A4.Width * 2;
float height = PdfPageSize.A4.Height;

// Create a booklet by using the CreateBooklet method with the specified source PDF, width, height, and duplex printing mode (true)
doc.CreateBooklet(srcPdf, width, height, true);
```

---

# Spire.PDF C# PDF Version Change
## Change PDF document version programmatically
```csharp
// Open a PDF document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(inputFilePath);

// Change the PDF version to Version 1.6
doc.FileInfo.Version = PdfVersion.Version1_6;

// Save the modified PDF document to a new file
doc.SaveToFile(outputFilePath);
```

---

# Spire.PDF C# Document Comparison
## Compare two PDF documents and save the differences
```csharp
// Load the first PDF file
PdfDocument pdf1 = new PdfDocument("path_to_first_pdf.pdf");

// Load the second PDF file
PdfDocument pdf2 = new PdfDocument("path_to_second_pdf.pdf");

// Create a PDF comparer object
PdfComparer compare = new PdfComparer(pdf1, pdf2);

// Set the comparison range for the pages to be compared
compare.Options.SetPageRanges(0, pdf1.Pages.Count - 1, 0, pdf2.Pages.Count - 1);

// Save the result of the comparison to a new PDF document
compare.Compare("comparison_result.pdf");
```

---

# spire.pdf csharp compression
## compress PDF document content and images
```csharp
// Compress the content in document
private void CompressContent(PdfDocument doc)
{
    // Disable the incremental update
    doc.FileInfo.IncrementalUpdate = false;

    // Set the compression level to best
    doc.CompressionLevel = PdfCompressionLevel.Best;
}

// Compress the images in document
private void CompressImage(PdfDocument doc)
{
    // Disable the incremental update
    doc.FileInfo.IncrementalUpdate = false;

    // Traverse all pages
    foreach (PdfPageBase page in doc.Pages)
    {
        if (page != null)
        {
            // Create a helper for image processing
            PdfImageHelper helper = new PdfImageHelper();

            // Get the image information for the current page
            Spire.Pdf.Utilities.PdfImageInfo[] pdfImageInfos = helper.GetImagesInfo(page);
            if (pdfImageInfos != null)
            {
                // Process each image on the page
                for (int i = 0; i < pdfImageInfos.Length; i++)
                {
                    // Try to compress the image
                    pdfImageInfos[i].TryCompressImage();
                }
            }
        }
    }
}
```

---

# Spire.PDF Document Compression
## Compress PDF documents using image quality settings
```csharp
// Create a new instance of PdfCompressor with the specified input PDF file path
PdfCompressor compressor = new PdfCompressor(inputFilePath);

// Set compression options for the compressor
compressor.Options.ImageCompressionOptions.ResizeImages = true;
compressor.Options.ImageCompressionOptions.ImageQuality = ImageQuality.Low;

// Compress the PDF document and save the result to a new PDF file
compressor.CompressToFile(outputFilePath);
```

---

# spire.pdf csharp multilayer pdf
## create a PDF document with text and image layers
```csharp
PdfDocument doc = new PdfDocument();

// Creates a new page in the document
PdfPageBase page = doc.Pages.Add();

// Create text to be displayed
String text = "Welcome to evaluate Spire.PDF for .NET !";

// Define the formatting options for the text
PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);

// Create a solid brush with black color
PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

// Defines a font to be used for the text
PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Calibri", 15f, FontStyle.Regular));

// Set the starting position for drawing the text
float x = 50;
float y = 50;

// Draw the text on the page's canvas
page.Canvas.DrawString(text, font, brush, new PointF(x, y), format);

// Measure the size of the first part of the text
SizeF size = font.MeasureString("Welcome to  evaluate", format);

// Measure the size of the second part of the text
SizeF size2 = font.MeasureString("Spire.PDF for .NET", format);

// Load an image from file
PdfImage image = PdfImage.FromFile("..\\..\\..\\..\\..\\..\\Data\\MultilayerImage.png");

// Draw the image on the page's canvas, positioned to the right of the text
page.Canvas.DrawImage(image, new PointF(x + size.Width, y), size2);
```

---

# Spire.PDF PDF/A1 Creation
## Create PDF/A1 compliant document with Spire.PDF library
```csharp
// Create a new PDF document
PdfNewDocument doc = new PdfNewDocument();

// Set PDF conformance level to PDF/A1B
// Spire.PDF supports Pdf_A1B, Pdf_X1A2001, Pdf_A1A, Pdf_A2A
doc.Conformance = PdfConformanceLevel.Pdf_A1B;

// Create one A4 page with margins
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(40));

// Draw content on the page
DrawPage(page);

// Save the document
doc.Save(result);

// Method to draw content on the PDF page
private void DrawPage(PdfPageBase page)
{
    float pageWidth = page.Canvas.ClientSize.Width;
    float y = 0;

    // Draw title
    y = y + 5;
    PdfBrush brush2 = new PdfSolidBrush(Color.Black);
    PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
    PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center);
    format2.CharacterSpacing = 1f;
    String text = "Summary of Science";
    page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2);
    SizeF size = font2.MeasureString(text, format2);
    y = y + size.Height + 6;

    // Draw image
    PdfImage image = PdfImage.FromFile(@"..\\..\\..\\..\\..\\..\\Data\\Wikipedia_Science.png");
    page.Canvas.DrawImage(image, new PointF(pageWidth - image.PhysicalDimension.Width, y));
    float imageLeftSpace = pageWidth - image.PhysicalDimension.Width - 2;
    float imageBottom = image.PhysicalDimension.Height + y;

    // Draw reference content
    PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 9f));
    PdfStringFormat format3 = new PdfStringFormat();
    format3.ParagraphIndent = font3.Size * 2;
    format3.MeasureTrailingSpaces = true;
    format3.LineSpacing = font3.Size * 1.5f;
    String text1 = "(All text and picture from ";
    String text2 = "Wikipedia";
    String text3 = ", the free encyclopedia)";
    page.Canvas.DrawString(text1, font3, brush2, 0, y, format3);

    size = font3.MeasureString(text1, format3);
    float x1 = size.Width;
    format3.ParagraphIndent = 0;
    PdfTrueTypeFont font4 = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Underline));
    PdfBrush brush3 = PdfBrushes.Blue;
    page.Canvas.DrawString(text2, font4, brush3, x1, y, format3);
    size = font4.MeasureString(text2, format3);
    x1 = x1 + size.Width;

    page.Canvas.DrawString(text3, font3, brush2, x1, y, format3);
    y = y + size.Height;

    // Draw main content
    PdfStringFormat format4 = new PdfStringFormat();
    text = System.IO.File.ReadAllText(@"..\\..\\..\\..\\..\\..\\Data\\Summary_of_Science.txt");
    PdfTrueTypeFont font5 = new PdfTrueTypeFont(new Font("Arial", 10f));
    format4.LineSpacing = font5.Size * 1.5f;
    PdfStringLayouter textLayouter = new PdfStringLayouter();
    float imageLeftBlockHeight = imageBottom - y;
    PdfStringLayoutResult result
        = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
    if (result.ActualSize.Height < imageBottom - y)
    {
        imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight;
        result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
    }
    foreach (LineInfo line in result.Lines)
    {
        page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4);
        y = y + result.LineHeight;
    }
    PdfTextWidget textWidget = new PdfTextWidget(result.Remainder, font5, brush2);
    PdfTextLayout textLayout = new PdfTextLayout();
    textLayout.Break = PdfLayoutBreakType.FitPage;
    textLayout.Layout = PdfLayoutType.Paginate;
    RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
    textWidget.StringFormat = format4;
    textWidget.Draw(page, bounds, textLayout);
}
```

---

# Spire.PDF C# PDF Portfolio
## Create a PDF portfolio with files and subfolders
```csharp
// Create a PDF document
PdfDocument doc = new PdfDocument(targetFile);

// Iterate through the files and add each file to the document's collection
for (int i = 0; i < files.Length; i++)
{
    doc.Collection.Folders.AddFile(files[i]);

    // Create a subfolder
    PdfFolder folder = doc.Collection.Folders.CreateSubfolder("SubFolder" + (i + 1));

    // Add the current file to the subfolder
    folder.AddFile(files[i]);
}

// Save the document
doc.SaveToFile(result);

// Dispose of the document
doc.Dispose();
```

---

# Spire.PDF C# Create Structure Tagged PDF
## Core functionality for creating a tagged PDF document with structured elements for accessibility
```csharp
// Create a PdfDocument
PdfDocument doc = new PdfDocument();

// Add a new page 
PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(20));
page.SetTabOrder(TabOrder.Structure);

// Create a PdfTaggedContent
PdfTaggedContent taggedContent = new PdfTaggedContent(doc);
taggedContent.SetLanguage("en-US");
taggedContent.SetTitle("test");
taggedContent.SetPdfUA1Identification();

// Create a true type font with size 14f, underline style
PdfTrueTypeFont font = new PdfTrueTypeFont(new System.Drawing.Font("Times New Roman", 14), true);

// Create a brush with black
PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

// Create a pdf structure child element
PdfStructureElement document = taggedContent.StructureTreeRoot.AppendChildElement(PdfStandardStructTypes.Document);
PdfStructureElement heading1 = document.AppendChildElement(PdfStandardStructTypes.HeadingLevel1);
heading1.BeginMarkedContent(page);
string headingText = "What is a Tagged PDF?";

// Draw text
page.Canvas.DrawString(headingText, font, brush, new PointF(0, 50));
heading1.EndMarkedContent(page);

// Create a pdf structure child element
PdfStructureElement paragraph = document.AppendChildElement(PdfStandardStructTypes.Paragraph);
paragraph.BeginMarkedContent(page);
string paragraphText = "“Tagged PDF” doesn't seem like a life-changing term. But for some, it is. For people who are " +
    "blind or have low vision and use assistive technology (such as screen readers and connected Braille displays) to " +
    "access information, an untagged PDF means they are missing out on information contained in the document because assistive " +
    "technology cannot "read" untagged PDFs.  Digital accessibility has opened up so many avenues to information that were once " +
    "closed to people with visual disabilities, but PDFs often get left out of the equation.";

// Create a Rectangle
RectangleF rect = new RectangleF(0, 80, page.Canvas.ClientSize.Width, page.Canvas.ClientSize.Height);

// Draw text
page.Canvas.DrawString(paragraphText, font, brush, rect);
paragraph.EndMarkedContent(page);

// Create a pdf structure child element
PdfStructureElement figure = document.AppendChildElement(PdfStandardStructTypes.Figure);
figure.BeginMarkedContent(page);
PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-logo.png");
page.Canvas.DrawImage(image, new PointF(350, 200));
figure.EndMarkedContent(page);

// Create a pdf structure child element
PdfStructureElement table = document.AppendChildElement(PdfStandardStructTypes.Table);

// Create a table
PdfTable pdfTable = new PdfTable();
pdfTable.Style.DefaultStyle.Font = font;
System.Data.DataTable dataTable = new System.Data.DataTable();

// Add columns
dataTable.Columns.Add("Name");
dataTable.Columns.Add("Age");
dataTable.Columns.Add("Sex");

// Add rows
dataTable.Rows.Add(new string[] { "John", "22", "Male" });
dataTable.Rows.Add(new string[] { "Katty", "25", "Female" });
pdfTable.DataSource = dataTable;
pdfTable.Style.ShowHeader = true;
pdfTable.StructureElement = table;

// Draw the table
pdfTable.Draw(page.Canvas, new PointF(0, 300), 300);
```

---

# Spire.PDF C# Tagged PDF Creation
## Creating a tagged PDF document with structure elements, text, and images
```csharp
// Create a new instance of PdfDocument
PdfDocument doc = new PdfDocument();

// Add a new page to the document
doc.Pages.Add();

// Set the tab order for the first page in the document
doc.Pages[0].SetTabOrder(TabOrder.Structure);

// Create a PdfTaggedContent object associated with the document
PdfTaggedContent taggedContent = new PdfTaggedContent(doc);
taggedContent.SetLanguage("en-US");
taggedContent.SetTitle("test");

// Set PDF/UA1 identification for accessibility
taggedContent.SetPdfUA1Identification();

// Set the font and brush for text rendering
PdfTrueTypeFont font = new PdfTrueTypeFont(new System.Drawing.Font("Times New Roman", 10), true);
PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

// Append structure elements to the document's structure tree
PdfStructureElement article = taggedContent.StructureTreeRoot.AppendChildElement(PdfStandardStructTypes.Document);
PdfStructureElement paragraph1 = article.AppendChildElement(PdfStandardStructTypes.Paragraph);
PdfStructureElement span1 = paragraph1.AppendChildElement(PdfStandardStructTypes.Span);
span1.BeginMarkedContent(doc.Pages[0]);

// Set the format for text alignment
PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Justify);

// Draw text on the page canvas within a specified rectangle
doc.Pages[0].Canvas.DrawString("Spire.PDF for .NET is a professional PDF API applied to creating, writing, editing, handling, and reading PDF files.",
    font, brush, new Rectangle(40, 0, 480, 80), format);
span1.EndMarkedContent(doc.Pages[0]);

// Append more structure elements and draw additional text
PdfStructureElement paragraph2 = article.AppendChildElement(PdfStandardStructTypes.Paragraph);
paragraph2.BeginMarkedContent(doc.Pages[0]);
doc.Pages[0].Canvas.DrawString("Spire.PDF for .NET can be applied to easily convert Text, Image, SVG, HTML to PDF and convert PDF to Excel with C#/VB.NET in high quality.",
    font, brush, new Rectangle(40, 80, 480, 60), format);
paragraph2.EndMarkedContent(doc.Pages[0]);

// Append a figure element and draw an image
PdfStructureElement figure1 = article.AppendChildElement(PdfStandardStructTypes.Figure);

// Set alternate text for the image
figure1.Alt = "replacement text1";
figure1.BeginMarkedContent(doc.Pages[0], null);
PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-logo.png");
doc.Pages[0].Canvas.DrawImage(image, new PointF(40, 200), new SizeF(100, 100));
figure1.EndMarkedContent(doc.Pages[0]);

// Append another figure element and draw a rectangle
PdfStructureElement figure2 = article.AppendChildElement(PdfStandardStructTypes.Figure);

// Set alternate text for the rectangle
figure2.Alt = "replacement text2";
figure2.BeginMarkedContent(doc.Pages[0], null);
doc.Pages[0].Canvas.DrawRectangle(PdfPens.Black, new Rectangle(300, 200, 100, 100));
figure2.EndMarkedContent(doc.Pages[0]);
```

---

# Spire.PDF C# Two-Column Layout
## Creating a PDF document with two-column text layout using Spire.PDF library
```csharp
// Create a new instance of PdfDocument
PdfDocument doc = new PdfDocument();

// Create a new page and assign it to the PdfPageBase object
PdfPageBase page = doc.Pages.Add();

// Define two strings containing text content
string s1 = "Spire.PDF for .NET is a professional PDF component applied to creating, writing, "
            + "editing, handling and reading PDF files without any external dependencies within "
            + ".NET application. Using this .NET PDF library, you can implement rich capabilities "
            + "to create PDF files from scratch or process existing PDF documents entirely through "
            + "C#/VB.NET without installing Adobe Acrobat.";
string s2 = "Many rich features can be supported by the .NET PDF API, such as security setting "
            + "(including digital signature), PDF text/attachment/image extract, PDF merge/split "
            + ", metadata update, section, graph/image drawing and inserting, table creation and "
            + "processing, and importing data etc.Besides, Spire.PDF for .NET can be applied to easily "
            + "converting Text, Image and HTML to PDF with C#/VB.NET in high quality.";

// Get the width and height of the page
float pageWidth = page.GetClientSize().Width;
float pageHeight = page.GetClientSize().Height;

// Set the brush, font, and format for text rendering
PdfBrush brush = PdfBrushes.Black;
PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 12f);
PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Justify);

// Draw the first string on the left half of the page
page.Canvas.DrawString(s1, font, brush, new RectangleF(0, 20, pageWidth / 2 - 8f, pageHeight), format);

// Draw the second string on the right half of the page
page.Canvas.DrawString(s2, font, brush, new RectangleF(pageWidth / 2 + 8f, 20, pageWidth / 2 - 8f, pageHeight), format);
```

---

# Spire.PDF Custom Document Properties
## Set custom properties for PDF documents
```csharp
// Create a new PdfDocument object
PdfDocument doc = new PdfDocument();

// Set custom document properties for the PDF document
doc.DocumentInformation.SetCustomProperty("Company", "E-iceblue");
doc.DocumentInformation.SetCustomProperty("Component", "Spire.PDF for .NET");
doc.DocumentInformation.SetCustomProperty("Name", "Daisy");
doc.DocumentInformation.SetCustomProperty("Team", "SalesTeam");
```

---

# spire.pdf csharp layer management
## delete a specific layer from pdf document
```csharp
// Initialize PDF document
PdfDocument doc = new PdfDocument();

// Remove the "red line" layer from the document
doc.Layers.RemoveLayer("red line");
```

---

# Spire.PDF C# Document and Page Piece Dictionaries
## Working with PDF document and page piece dictionaries to add, remove, and retrieve application data

```csharp
// If the document piece info is null, create it
if (pdf.DocumentPieceInfo == null)
{
    pdf.DocumentPieceInfo = new PdfPieceInfo();
}

// Add key-value pairs to the document piece info
pdf.DocumentPieceInfo.AddApplicationData("ice", "E-iceblue-ice");
pdf.DocumentPieceInfo.AddApplicationData("blue", "E-iceblue-blue");
pdf.DocumentPieceInfo.AddApplicationData("Blue", "E-iceblue-Blue");
pdf.DocumentPieceInfo.AddApplicationData("Ice", "E-iceblue-Ice");

// Remove a value based on its key from the document piece info
pdf.DocumentPieceInfo.RemoveApplicationData("blue");

// If the piece info in the first page is null, create it
if (pdf.Pages[0].PagePieceInfo == null)
{
    pdf.Pages[0].PagePieceInfo = new PdfPieceInfo();
}

// Add key-value pairs to the piece info of the first page
pdf.Pages[0].PagePieceInfo.AddApplicationData("ice", "E-iceblue-ice");
pdf.Pages[0].PagePieceInfo.AddApplicationData("blue", "E-iceblue-blue");
pdf.Pages[0].PagePieceInfo.AddApplicationData("Blue", "E-iceblue-Blue");
pdf.Pages[0].PagePieceInfo.AddApplicationData("Ice", "E-iceblue-Ice");

// Remove a value based on its key from the piece info of the first page
pdf.Pages[0].PagePieceInfo.RemoveApplicationData("Ice");

// Get the piece dictionaries from the document and page
IDictionary<string, PdfApplicationData> documentDict = pdf.DocumentPieceInfo.ApplicationDatas;
IDictionary<string, PdfApplicationData> pageDict = pdf.Pages[0].PagePieceInfo.ApplicationDatas;

// Function to process a dictionary and extract string values
StringBuilder ProcessDictionary(IDictionary<string, PdfApplicationData> dic)
{
    StringBuilder sb = new StringBuilder();
    
    // Iterate over all the keys in the dictionary
    foreach (string item in dic.Keys)
    {
        PdfApplicationData data = dic[item];
        if (data.Private is String)
        {
            // Get the value and append it to the StringBuilder
            string value = data.Private as string;
            sb.AppendLine(value);
        }
    }
    
    return sb;
}

// Process the document and page dictionaries
StringBuilder documentResult = ProcessDictionary(documentDict);
StringBuilder pageResult = ProcessDictionary(pageDict);
```

---

# Spire.PDF C# Document Properties
## Extract PDF document properties
```csharp
PdfDocument doc = new PdfDocument();

// Read a PDF file from the specified input path
doc.LoadFromFile(inputPath);

// Get the document information from the loaded PDF document
PdfDocumentInformation docInfo = doc.DocumentInformation;

// Get individual document properties
string author = docInfo.Author;
DateTime creationDate = docInfo.CreationDate;
string keywords = docInfo.Keywords;
DateTime modificationDate = docInfo.ModificationDate;
string subject = docInfo.Subject;
string title = docInfo.Title;
```

---

# Spire.PDF C# Get Viewer Preferences
## Retrieve PDF document viewer preferences
```csharp
// Create a new PdfDocument object
PdfDocument doc = new PdfDocument();

// Load a PDF file
doc.LoadFromFile("input.pdf");

// Get the viewer preferences for the loaded PDF document
PdfViewerPreferences viewer = doc.ViewerPreferences;

// Access various viewer preference properties
bool centerWindow = viewer.CenterWindow;
PdfPageMode pageMode = viewer.PageMode;
PdfPageLayout pageLayout = viewer.PageLayout;
bool displayTitle = viewer.DisplayTitle;
bool fitWindow = viewer.FitWindow;
bool hideMenubar = viewer.HideMenubar;
bool hideToolbar = viewer.HideToolbar;
bool hideWindowUI = viewer.HideWindowUI;
```

---

# Spire.PDF XMP Metadata Extraction
## Extract XMP metadata properties from a PDF document
```csharp
// Create a PdfDocument object
PdfDocument doc = new PdfDocument();
// Load a PDF file
doc.LoadFromFile(inputFilePath);

// Get the XMP metadata from the loaded PDF document
PdfXmpMetadata xmpMetadata = doc.Metadata;

// Define the namespace for PDF metadata properties
const string NsPdf = "http://ns.adobe.com/pdf/1.3/";

// Check and extract various metadata properties
if (xmpMetadata.ExistProperty(NsPdf, "Author"))
{
    string author = xmpMetadata.GetPropertyString(NsPdf, "Author");
}

if (xmpMetadata.ExistProperty(NsPdf, "Title"))
{
    string title = xmpMetadata.GetPropertyString(NsPdf, "Title");
}

if (xmpMetadata.ExistProperty(NsPdf, "Subject"))
{
    string subject = xmpMetadata.GetPropertyString(NsPdf, "Subject");
}

if (xmpMetadata.ExistProperty(NsPdf, "Producer"))
{
    string producer = xmpMetadata.GetPropertyString(NsPdf, "Producer");
}

if (xmpMetadata.ExistProperty(NsPdf, "Creator"))
{
    string creator = xmpMetadata.GetPropertyString(NsPdf, "Creator");
}

if (xmpMetadata.ExistProperty(NsPdf, "Keywords"))
{
    string keywords = xmpMetadata.GetPropertyString(NsPdf, "Keywords");
}
```

---

# spire.pdf csharp get zoom factor
## get zoom factor from pdf document
```csharp
// Create a new instance of the PdfDocument class
PdfDocument doc = new PdfDocument();

// Load a PDF document from the specified file path
doc.LoadFromFile(@"..\..\..\..\..\..\Data\GetZoomFactor.pdf");

// Get the AfterOpenAction of the loaded document as a PdfGoToAction object
PdfGoToAction action = doc.AfterOpenAction as PdfGoToAction;

// Get the zoom factor value from the destination of the action
float zoomvalue = action.Destination.Zoom;

// Display a message box showing the zoom factor of the document
MessageBox.Show("The zoom factor of the document is " + zoomvalue * 100 + "%.");
```

---

# Spire.PDF C# Layer Management
## Make all PDF layers invisible
```csharp
// Iterate each layer of Pdf file
for (int i = 0; i < doc.Layers.Count; i++)
{
    //Set all the Pdf layers invisible.
    doc.Layers[i].Visibility = PdfVisibility.Off;
}
```

---

# spire.pdf csharp layers
## make particular pdf layers invisible
```csharp
//Create a new PDF document
PdfDocument doc = new PdfDocument();

//Set the first layer invisible
doc.Layers[0].Visibility = PdfVisibility.Off;

//Set the layer named "blue line" invisible
doc.Layers["blue line"].Visibility = PdfVisibility.Off;
```

---

# Spire.PDF C# Check PDF Portfolio
## Determine if a PDF document is a portfolio
```csharp
// Create a pdf document
PdfDocument doc = new PdfDocument();

// Load from file
doc.LoadFromFile("sample.pdf");

// Judge whether the document is portfolio or not.
bool value = doc.IsPortfolio;
```

---

# spire.pdf csharp merge documents
## merge multiple PDF documents into one
```csharp
// Create an array of PdfDocument
PdfDocument[] docs = new PdfDocument[files.Length];

// Loop through the documents
for (int i = 0; i < files.Length; i++)
{
    // Load a specific document
    docs[i] = new PdfDocument(files[i]);
}

// Create a PdfDocument object for generating a new PDF document
PdfDocument doc = new PdfDocument();

// Insert the selected pages from different documents to the new document
doc.InsertPage(docs[0], 0);
doc.InsertPageRange(docs[1], 0, 2);
doc.InsertPage(docs[2], 0);

// Close the document
doc.Close();

// Close all the loaded documents
foreach (PdfDocument docf in docs)
{
    docf.Close();
}
```

---

# Spire.PDF Merge PDFs by Stream
## Merge multiple PDF documents using FileStream objects
```csharp
// Open PDF files as read-only streams
FileStream stream1 = File.OpenRead("first_pdf.pdf");
FileStream stream2 = File.OpenRead("second_pdf.pdf");
FileStream stream3 = File.OpenRead("third_pdf.pdf");

// Array of PDF document streams
Stream[] streams = new Stream[] { stream1, stream2, stream3 };

// Merge the PDF files using the streams
PdfDocumentBase doc = PdfDocument.MergeFiles(streams);
```

---

# Spire.PDF C# Modify Page Margins
## Modify page margins of a PDF document by creating a new document with adjusted margins
```csharp
// Create a new PdfDocument object for storing the modified page margins
PdfDocument newDoc = new PdfDocument();

// Define the top, bottom, left, and right margins of the new document
float top = 50;
float bottom = 50;
float left = 50;
float right = 50;

// Iterate through each page in the original document
foreach (PdfPageBase page in doc.Pages)
{
    // Add a new page to the new document with the same size as the source page and no margins
    PdfPageBase newPage = newDoc.Pages.Add(page.Size, new PdfMargins(0));

    // Set the scale of the new document content based on the actual size of the source page
    newPage.Canvas.ScaleTransform((page.ActualSize.Width - left - right) / page.ActualSize.Width,
                                     (page.ActualSize.Height - top - bottom) / page.ActualSize.Height);

    // Draw the content of the source page onto the new document page at the specified margin positions
    newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(left, top));
}
```

---

# Spire.PDF Document Properties
## Set PDF document properties and file information
```csharp
// Set document information
doc.DocumentInformation.Author = "E-iceblue";
doc.DocumentInformation.Creator = "E-iceblue";
doc.DocumentInformation.Keywords = "pdf, demo, document information";
doc.DocumentInformation.Producer = "Spire.Pdf";
doc.DocumentInformation.Subject = "Demo of Spire.Pdf";
doc.DocumentInformation.Title = "Document Information";

// Set file info
doc.FileInfo.CrossReferenceType = PdfCrossReferenceType.CrossReferenceStream;
doc.FileInfo.IncrementalUpdate = false;
```

---

# spire.pdf csharp page manipulation
## rearrange pdf page order
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load from file
doc.LoadFromFile("SampleB_3.pdf");

//Rearrange the page order
doc.Pages.ReArrange(new int[] { 1, 0 });

//Save to file
String result = "RearrangePageOrder-result.pdf";
doc.SaveToFile(result, FileFormat.PDF);
```

---

# Spire.PDF C# Remove Blank Pages
## Detect and remove blank pages from a PDF document
```csharp
// Iterate through all pages in reverse order.
for (int i = document.Pages.Count - 1; i >= 0; i--)
{
    // Check if the current page is blank.
    if (document.Pages[i].IsBlank())
    {
        // Remove the blank page from the document.
        document.Pages.RemoveAt(i);
    }
    else
    {
        // Convert the non-blank page to an image.
        Image image = document.SaveAsImage(i, PdfImageType.Bitmap);

        // Check if the image is blank.
        if (IsImageBlank(image))
        {
            // If the image is blank, remove the corresponding PDF page.
            document.Pages.RemoveAt(i);
        }
    }
}

public static bool IsImageBlank(Image image)
{
    // Convert the Image object to a Bitmap object for pixel manipulation.
    Bitmap bitmap = new Bitmap(image);

    // Iterate through each pixel in the image.
    for (int i = 0; i < bitmap.Width; i++)
    {
        for (int j = 0; j < bitmap.Height; j++)
        {
            // Get the color of the current pixel.
            Color pixel = bitmap.GetPixel(i, j);

            // Check if any of the RGB values of the pixel are less than 240.
            // If any of the RGB values are less than 240, it means the pixel is not blank.
            if (pixel.R < 240 || pixel.G < 240 || pixel.B < 240)
            {
                // Return false since a non-blank pixel is found.
                return false;
            }
        }
    }

    // If all pixels are blank (i.e., all RGB values are greater than or equal to 240), return true.
    return true;
}
```

---

# Spire.PDF C# Remove Page Margins
## This code demonstrates how to remove page margins from a PDF document using Spire.PDF library

```csharp
// Create a new PdfDocument object to load and manipulate the PDF document
PdfDocument doc = new PdfDocument();

// Load the content of the input PDF file into the PdfDocument object
doc.LoadFromFile(input);

// Create a new PdfDocument object to create a new PDF document with page margins removed
PdfDocument newDoc = new PdfDocument();

// Get the page margins of the source PDF document
PdfMargins margins = doc.PageSettings.Margins;

// Extract the top, bottom, left, and right margin values from the PdfMargins object
float top = margins.Left;
float bottom = margins.Bottom;
float left = margins.Left;
float right = margins.Right;

// Iterate through each page in the source PDF document
foreach (PdfPageBase page in doc.Pages)
{
    // Add a new page to the new PdfDocument object with adjusted size and margins
    PdfPageBase newPage = newDoc.Pages.Add(new SizeF(page.Size.Width - left - right, page.Size.Height - top - bottom), new PdfMargins(0));

    // Draw the content of the source page onto the new page in the new PdfDocument object
    newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(-left, -top));
}

// Save the modified PDF document to the specified output file path
newDoc.SaveToFile(result);
```

---

# Spire.PDF C# Save with Progress Notifier
## Save PDF document with custom progress notification
```csharp
// Create a pdf instance
PdfDocument doc = new PdfDocument();

// Register a custom progress notifier to monitor the save operation's progress
doc.RegisterProgressNotifier(new CustomProgressNotifier());

// Save the document to an XPS file
doc.SaveToFile("SaveWithProgressNotifier_output.xps", FileFormat.XPS);

// Close the document
doc.Close();
```

```csharp
public class CustomProgressNotifier : IProgressNotifier
{
    StringBuilder str = new StringBuilder();
    public void Notify(float progress)
    {
        str.AppendLine("==============Progress: " +progress + "%==============");
        File.WriteAllText("SaveWithProgressNotifier_output.txt", str.ToString());
    }
}
```

---

# Spire.PDF C# Booklet Binding
## Set binding options for PDF booklet creation
```csharp
// Create a PDF document
PdfDocument doc = new PdfDocument();

// Set the binding mode for the booklet.
BookletOptions bookletOptions = new BookletOptions();
bookletOptions.BookletBinding = PdfBookletBindingMode.Left;

// Set the size for the booklet.
float width = PdfPageSize.A4.Width * 2;
float height = PdfPageSize.A4.Height;
SizeF size = new SizeF(width, height);

// Generate the booklet file by creating a booklet with the specified options
PdfBookletCreator.CreateBooklet(doc, outputstream, size, bookletOptions);
```

---

# Spire.PDF C# Expiry Date Setting
## Set an expiry date for a PDF document using JavaScript action
```csharp
// Create a new PdfDocument object
PdfDocument doc = new PdfDocument();

// Define a JavaScript code snippet to check if the document has expired
string javaScript = "var rightNow = new Date();"
                  + "var endDate = new Date('October 20, 2015 23:59:59');"
                  + "if(rightNow.getTime() > endDate)"
                  + "app.alert('This document has expired, please contact us for a new one.',1);"
                  + "this.closeDoc();";

// Create a new PdfJavaScriptAction object with the defined JavaScript code
PdfJavaScriptAction js = new PdfJavaScriptAction(javaScript);

// Set the AfterOpenAction property of the PdfDocument object to the created PdfJavaScriptAction object
doc.AfterOpenAction = js;
```

---

# spire.pdf csharp layer print properties
## Set print properties for PDF layers
```csharp
// Create a Pdf document object
PdfDocument pdf = new PdfDocument();

// Get the first page
PdfPageBase page = pdf.Pages[0];

// Create a layer named "red line" within the Pdf document
PdfLayer layer = pdf.Layers.AddLayer("red line", PdfVisibility.On);

// Set the print state of the layer as "Nerver"
layer.PrintState = LayerPrintState.Nerver;

// Draw a red line on the layer using the graphics of the page canvas
PdfCanvas pcA = layer.CreateGraphics(page.Canvas);
pcA.DrawLine(new PdfPen(PdfBrushes.Red, 2), new PointF(100, 350), new PointF(300, 350));
```

---

# spire.pdf csharp magnification
## set PDF magnification to fit height
```csharp
// Get the first page
PdfPageBase page = myPdf.Pages[0];

// Create a PdfDestination with specific page, location
PdfDestination dest = new PdfDestination(page, new PointF(-40f, -40f));

// Set the Magnification to Fit-Height
dest.Mode = PdfDestinationMode.FitV;

//Create GoToAction with dest
PdfGoToAction gotoaction = new PdfGoToAction(dest);

// Set open action
myPdf.AfterOpenAction = gotoaction;
myPdf.ViewerPreferences.PageMode = PdfPageMode.UseOutlines;
```

---

# Spire.PDF XMP Metadata
## Set XMP metadata properties in a PDF document
```csharp
// Open a PDF document.
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(inputPath);

// Set XMP metadata for the document.
doc.DocumentInformation.Author = "Author Name";
doc.DocumentInformation.Creator = "Creator Name";
doc.DocumentInformation.Keywords = "Keywords";
doc.DocumentInformation.Producer = "Producer Name";
doc.DocumentInformation.Subject = "Document Subject";
doc.DocumentInformation.Title = "Document Title";

// Save the PDF document with the updated XMP metadata.
doc.SaveToFile(outputPath);
```

---

# spire.pdf csharp zoom factor
## set zoom factor for PDF document
```csharp
// Get the first page of the PDF document
PdfPageBase page = doc.Pages[0];

// Set the destination for the PDF document
PdfDestination dest = new PdfDestination(page);

// Set the mode of the destination to location
dest.Mode = PdfDestinationMode.Location;

// Set the location of the destination to (-40, -40)
dest.Location = new PointF(-40f, -40f);

// Set the zoom factor of the destination to 0.6
dest.Zoom = 0.6f;

// Create a new GoTo action with the specified destination
PdfGoToAction gotoAction = new PdfGoToAction(dest);

// Set the after open action of the document to the GoTo action
doc.AfterOpenAction = gotoAction;
```

---

# spire.pdf csharp document
## split PDF document into multiple files
```csharp
// Open PDF document
PdfDocument doc = new PdfDocument();
doc.LoadFromFile(@"..\..\..\..\..\..\Data\SplitDocument.pdf");

// Split the document based on the specified pattern
String pattern = "SplitDocument-{0}.pdf";
doc.Split(pattern);
String lastPageFileName = String.Format(pattern, doc.Pages.Count - 1);
doc.Close();
```

---

# spire.pdf csharp template
## create PDF document with templates
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();
doc.ViewerPreferences.PageLayout = PdfPageLayout.TwoColumnLeft;

//Set the margin
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

SetDocumentTemplate(doc, PdfPageSize.A4, margin);

//Create one section
PdfSection section = doc.Sections.Add();
section.PageSettings.Size = PdfPageSize.A4;
section.PageSettings.Margins = new PdfMargins(0);
SetSectionTemplate(section, PdfPageSize.A4, margin, "Section 1");

//Create one page
PdfNewPage page = section.Pages.Add();

private void SetSectionTemplate(PdfSection section, SizeF pageSize, PdfMargins margin, String label)
{
    // Create an element for the left blank space with the width of the left margin and the height of the page
    PdfPageTemplateElement leftSpace = new PdfPageTemplateElement(margin.Left, pageSize.Height);
    
    // Set the element as a foreground element
    leftSpace.Foreground = true;
    
    // Set the element as the left template for odd pages
    section.Template.OddLeft = leftSpace;
    
    // Create an Arial font object with a size of 9f and an italic style
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic));
    
    // Create a string format object with centered text alignment and vertically centered alignment
    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
    
    // Calculate the y-coordinate value to center the text on the page
    float y = (pageSize.Height - margin.Top - margin.Bottom) * (1 - 0.618f);
    
    // Create a rectangle object with the top-left corner at (10, y), and the bottom-right corner at (left margin - 20, font height + 6)
    RectangleF bounds = new RectangleF(10, y, margin.Left - 20, font.Height + 6);
    
    // Draw an orange-red rectangle within the left blank space element
    leftSpace.Graphics.DrawRectangle(PdfBrushes.OrangeRed, bounds);
    
    // Draw the label text within the rectangle using the Arial font created earlier, white color, and the previously created string format object
    leftSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format);
    
    // Create an element for the right blank space with the width of the right margin and the height of the page
    PdfPageTemplateElement rightSpace = new PdfPageTemplateElement(margin.Right, pageSize.Height);
    
    // Set the element as a foreground element
    rightSpace.Foreground = true;
    
    // Set the element as the right template for even pages
    section.Template.EvenRight = rightSpace;
    
    // Recalculate the bottom-right corner of the rectangle
    bounds = new RectangleF(10, y, margin.Right - 20, font.Height + 6);
    
    // Draw a brown rectangle within the right blank space element
    rightSpace.Graphics.DrawRectangle(PdfBrushes.SaddleBrown, bounds);
    
    // Draw the label text within the rectangle using the Arial font created earlier, white color, and the previously created string format object
    rightSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format);
}

// SetDocumentTemplate method for configuring document template with specified page size and margins
private void SetDocumentTemplate(PdfDocument doc, SizeF pageSize, PdfMargins margin)
{
    // Create a template element for the left space on the page
    PdfPageTemplateElement leftSpace = new PdfPageTemplateElement(margin.Left, pageSize.Height);
    doc.Template.Left = leftSpace;
    
    // Create a template element for the top space on the page
    PdfPageTemplateElement topSpace = new PdfPageTemplateElement(pageSize.Width, margin.Top);
    topSpace.Foreground = true;
    doc.Template.Top = topSpace;
    
    // Draw a header label
    PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic));
    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
    String label = "Demo of Spire.Pdf";
    SizeF size = font.MeasureString(label, format);
    float y = topSpace.Height - font.Height - 1;
    PdfPen pen = new PdfPen(Color.Black, 0.75f);
    topSpace.Graphics.SetTransparency(0.5f);
    topSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y);
    y = y - 1 - size.Height;
    topSpace.Graphics.DrawString(label, font, PdfBrushes.Black, pageSize.Width - margin.Right, y, format);
    
    // Create a template element for the right space on the page
    PdfPageTemplateElement rightSpace = new PdfPageTemplateElement(margin.Right, pageSize.Height);
    doc.Template.Right = rightSpace;
    
    // Create a template element for the bottom space on the page
    PdfPageTemplateElement bottomSpace = new PdfPageTemplateElement(pageSize.Width, margin.Bottom);
    bottomSpace.Foreground = true;
    doc.Template.Bottom = bottomSpace;
    
    // Draw a footer label
    y = font.Height + 1;
    bottomSpace.Graphics.SetTransparency(0.5f);
    bottomSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y);
    y = y + 1;
    PdfPageNumberField pageNumber = new PdfPageNumberField();
    PdfPageCountField pageCount = new PdfPageCountField();
    PdfCompositeField pageNumberLabel = new PdfCompositeField();
    pageNumberLabel.AutomaticFields = new PdfAutomaticField[] { pageNumber, pageCount };
    pageNumberLabel.Brush = PdfBrushes.Black;
    pageNumberLabel.Font = font;
    pageNumberLabel.StringFormat = format;
    pageNumberLabel.Text = "page {0} of {1}";
    pageNumberLabel.Draw(bottomSpace.Graphics, pageSize.Width - margin.Right, y);
}
```

---

# Spire.PDF Document Transitions
## Create PDF with different page transitions
```csharp
// Create a new PDF document
PdfDocument doc = new PdfDocument();
doc.ViewerPreferences.PageMode = PdfPageMode.FullScreen;

// Set the margins for the document
PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
PdfMargins margin = new PdfMargins();
margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Bottom = margin.Top;
margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
margin.Right = margin.Left;

// Create a section in the document
PdfSection section = doc.Sections.Add();
section.PageSettings.Size = PdfPageSize.A4;
section.PageSettings.Margins = margin;

// Configure the transition settings for the section's pages
section.PageSettings.Transition = new PdfPageTransition();
section.PageSettings.Transition.Duration = 2;
section.PageSettings.Transition.Style = PdfTransitionStyle.Fly;
section.PageSettings.Transition.PageDuration = 1;

// Add pages to the section
PdfNewPage page = section.Pages.Add();
page.BackgroundColor = Color.Red;
page = section.Pages.Add();
page.BackgroundColor = Color.Green;
page = section.Pages.Add();
page.BackgroundColor = Color.Blue;

// Create a new section with different transition settings
section = doc.Sections.Add();
section.PageSettings.Size = PdfPageSize.A4;
section.PageSettings.Margins = margin;

// Configure the transition settings for this section's pages
section.PageSettings.Transition = new PdfPageTransition();
section.PageSettings.Transition.Duration = 2;
section.PageSettings.Transition.Style = PdfTransitionStyle.Box;
section.PageSettings.Transition.PageDuration = 1;

// Add pages to the section
page = section.Pages.Add();
page.BackgroundColor = Color.Orange;
page = section.Pages.Add();
page.BackgroundColor = Color.Brown;
page = section.Pages.Add();
page.BackgroundColor = Color.Navy;

// Create another section with different transition settings
section = doc.Sections.Add();
section.PageSettings.Size = PdfPageSize.A4;
section.PageSettings.Margins = margin;

// Configure the transition settings for this section's pages
section.PageSettings.Transition = new PdfPageTransition();
section.PageSettings.Transition.Duration = 2;
section.PageSettings.Transition.Style = PdfTransitionStyle.Split;
section.PageSettings.Transition.Dimension = PdfTransitionDimension.Vertical;
section.PageSettings.Transition.Motion = PdfTransitionMotion.Inward;
section.PageSettings.Transition.PageDuration = 1;

// Add pages to the section
page = section.Pages.Add();
page.BackgroundColor = Color.Orange;
page = section.Pages.Add();
page.BackgroundColor = Color.Brown;
page = section.Pages.Add();
page.BackgroundColor = Color.Navy;
```

---

# spire.pdf viewer preferences
## set PDF viewer preferences
```csharp
// Center the window of the PDF viewer
doc.ViewerPreferences.CenterWindow = true;

// Do not display the title of the PDF document in the viewer
doc.ViewerPreferences.DisplayTitle = false;

// Do not fit the content of the PDF document to the window of the viewer
doc.ViewerPreferences.FitWindow = false;

// Hide the menu bar of the PDF viewer
doc.ViewerPreferences.HideMenubar = true;

// Hide the toolbar of the PDF viewer
doc.ViewerPreferences.HideToolbar = true;

// Display the PDF document as a single page
doc.ViewerPreferences.PageLayout = PdfPageLayout.SinglePage;
```

---

# spire.pdf c# booklet layout
## configure booklet layout settings for pdf printing
```csharp
//Create a PDF file
PdfDocument pdf = new PdfDocument();

//Load a PDF file from disk
pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

//If the printer can print with Duplex
bool isDuplex = pdf.PrintSettings.CanDuplex;
if (isDuplex)
{
    //Set PdfBookletSubsetMode as "BothSides" and PdfBookletBindingMode as "Left"
    pdf.PrintSettings.SelectBookletLayout(PdfBookletSubsetMode.BothSides, PdfBookletBindingMode.Left);

    //Print the PDF
    pdf.Print();
}
```

---

# spire.pdf csharp resolution
## get and set PDF printer resolution kind
```csharp
// Create a new PDF document object
PdfDocument doc = new PdfDocument();

// Set the PrinterResolutionKind property of the PDF document's PrintSettings to High
doc.PrintSettings.PrinterResolutionKind = PdfPrinterResolutionKind.High;

// Get the current value of the PrinterResolutionKind property of the PDF document's PrintSettings
PdfPrinterResolutionKind kind = doc.PrintSettings.PrinterResolutionKind;

// Use a switch statement to determine the value of the PrinterResolutionKind
switch (kind)
{
    case PdfPrinterResolutionKind.High:
        // High
        break;
    case PdfPrinterResolutionKind.Medium:
        // Medium
        break;
    case PdfPrinterResolutionKind.Low:
        // Low
        break;
    case PdfPrinterResolutionKind.Draft:
        // Draft
        break;
    case PdfPrinterResolutionKind.Custom:
        // Custom
        break;
}
```

---

# spire.pdf csharp print settings
## configure multi-page PDF printing
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Select muti page to one paper layout
doc.PrintSettings.SelectMultiPageLayout(2, 2, false, PdfMultiPageOrder.Horizontal);

//Set print page range
doc.PrintSettings.SelectPageRange(3, 15);

//Set paper margins,measured in hundredths of an inch
doc.PrintSettings.SetPaperMargins(10, 10, 10, 10);

//Indicating whether the page is printed in landscape or portrait orientation.
doc.PrintSettings.Landscape = false;

//Print document
doc.Print();

//Close the document
doc.Close();
```

---

# Spire.PDF C# Print Document
## Print a PDF document using print dialog
```csharp
// Create a new PDF document
PdfDocument doc = new PdfDocument();

// Load an existing PDF file into the document
doc.LoadFromFile("PrintPdfDocument.pdf");

// Create a print dialog to select the printer and pages to print
PrintDialog dialogPrint = new PrintDialog();
dialogPrint.AllowPrintToFile = true;
dialogPrint.AllowSomePages = true;
dialogPrint.PrinterSettings.FromPage = 1;
dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;

// If the user clicks OK in the print dialog, proceed with printing
if (dialogPrint.ShowDialog() == DialogResult.OK)
{
    // Configure the print settings based on the selected printer and page range
    doc.PrintSettings.SelectPageRange(dialogPrint.PrinterSettings.FromPage, dialogPrint.PrinterSettings.ToPage);
    doc.PrintSettings.PrinterName = dialogPrint.PrinterSettings.PrinterName;

    // Print the document using the specified settings
    doc.Print();
}
```

---

# spire.pdf csharp print
## print PDF document without showing print dialog
```csharp
//Create a document
PdfDocument doc = new PdfDocument();

//Load file
doc.LoadFromFile("sample.pdf");

//Set the print controller without printing process dialog
doc.PrintSettings.PrintController = new StandardPrintController();

//Print all pages with default printer
doc.Print();
```

---

# Spire.PDF C# Print Settings
## Configure PDF document printing margins and layout
```csharp
// Set the multi-page layout for printing, with 2 rows and 2 columns, without duplex printing,
// with horizontal page order, and a margin of 10 points
doc.PrintSettings.SelectMultiPageLayout(2, 2, false, PdfMultiPageOrder.Horizontal, 10);

// Select the page range to be printed, from page 1 to page 4
doc.PrintSettings.SelectPageRange(1, 4);

// Set the orientation of the print to portrait (non-landscape)
doc.PrintSettings.Landscape = false;

// Print the document using the selected settings
doc.Print();
```

---

# Spire.PDF C# Single Page Printing
## Demonstrates how to print specific pages from a PDF document with custom settings
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Indicate whether the page is printed in landscape or portrait orientation
doc.PrintSettings.Landscape = false;

//Set print page range
doc.PrintSettings.SelectPageRange(9, 15);

//Select one page to one paper layout
doc.PrintSettings.SelectSinglePageLayout(PdfSinglePageScalingMode.CustomScale, true, 100);

//Set paper margins,measured in hundredths of an inch
doc.PrintSettings.SetPaperMargins(10, 10, 10, 10);

//Print document
doc.Print();
```

---

# Spire.PDF C# Split Page Printing
## Split PDF pages for printing with specific settings
```csharp
//Create a pdf document
PdfDocument doc = new PdfDocument();

//Load a file
doc.LoadFromFile("SplitPage.pdf");

//Indicating whether the page is printed in landscape or portrait orientation.
doc.PrintSettings.Landscape = false;

//Set print page range
doc.PrintSettings.SelectPageRange(1, 1);

//Select split page to multiple paper layout
doc.PrintSettings.SelectSplitPageLayout();

//Print document
doc.Print();

//Close the document
doc.Close();
```

---

# Spire.PDF C# Tray Printing
## Print PDF document using different paper trays for different pages
```csharp
// Get available printer sources
foreach (string printer in PrinterSettings.InstalledPrinters)
{
    if (printer.Contains("HP ColorLaserJet MFP"))
    {
        // Set the printer name to the desired printer
        doc.PrinterSettings.PrinterName = printer;
        break;
    }

    var myDictPaperTray = new Dictionary<string, PaperSource>();
    for (int i = 0; i < doc.PrinterSettings.PaperSources.Count; i++)
    {
        // Create a dictionary of paper tray names and corresponding PaperSource objects
        myDictPaperTray.Add(doc.PrinterSettings.PaperSources[i].SourceName, doc.PrinterSettings.PaperSources[i]);
    }

    // Use Tray 1 to print the first page on one side
    pPrintPages(1, 1, myDictPaperTray["Tray 1"], false, true, false);
    // Use Tray 4 to print the second to fifth pages on both sides
    pPrintPages(2, 5, myDictPaperTray["Tray 4"], true, false, true);
}

private static void pPrintPages(int pStart, int pEnd, PaperSource pSource, bool pDuplex, bool IsColour, bool IsLandscape)
{
    PdfDocument doc = new Spire.Pdf.PdfDocument(@"..\..\..\..\..\..\Data\PrintPdfDocument.pdf");
    doc.PrintSettings.SelectPageRange(pStart, pEnd);

    // Configure duplex printing (vertical or simplex)
    if (pDuplex)
        doc.PrintSettings.Duplex = Duplex.Vertical;
    else
        doc.PrintSettings.Duplex = Duplex.Simplex;

    // Configure color printing
    if (IsColour)
        doc.PrintSettings.Color = true;
    else
        doc.PrintSettings.Color = false;

    // Configure landscape or portrait orientation
    if (IsLandscape)
        doc.PrintSettings.Landscape = true;
    else
        doc.PrintSettings.Landscape = false;

    // Set the paper source for printing
    doc.PrintSettings.PaperSettings += delegate (object sender, Spire.Pdf.Print.PdfPaperSettingsEventArgs e)
    {
        e.CurrentPaperSource = pSource;
    };

    // Print the document with the specified settings
    doc.Print();
}
```

---

# spire.pdf csharp print tray
## print PDF document with different paper trays for different page ranges
```csharp
//Initialize an object of PdfDocument class
PdfDocument doc = new PdfDocument();

//Load the PDF document
doc.LoadFromFile("PrintPdfDocument.pdf");

// Set colour printing. If false, printing in black and white
doc.PrintSettings.Color = true;

// Set landscape orientation printing. If false, printing in portrait orientation
doc.PrintSettings.Landscape = true;

// Set duplex printing
doc.PrintSettings.Duplex = Duplex.Horizontal;

//Set Paper source
doc.PrintSettings.PaperSettings += delegate(object sender1, PdfPaperSettingsEventArgs e1)
{
    //Set the paper source of page 1-50 as tray 1
    if (1 <= e1.CurrentPaper && e1.CurrentPaper <= 50)
    {
        e1.CurrentPaperSource = e1.PaperSources[0];
    }

    //Set the paper source of the rest of pages as tray 2
    else
    {
        e1.CurrentPaperSource = e1.PaperSources[1];
    }
};

//Print the document
doc.Print();
```

---

