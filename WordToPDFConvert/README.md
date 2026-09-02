# Word to PDF Converter

A simple ASP.NET Core web application that converts Word documents (.doc, .docx) to PDF using the [Syncfusion .NET Word (DocIO) library](https://help.syncfusion.com/document-processing/word/conversions/word-to-pdf/net/word-to-pdf).

The user selects a Word file in the browser, clicks **Convert to PDF**, and the app returns the converted PDF as a download.

## Features

- Upload a Word document (.doc, .docx) through a simple web form
- Convert the document to PDF using `DocIORenderer.ConvertToPDF`
- Download the converted PDF directly in the browser (keeps the original file name)

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- A [Syncfusion license key](https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate) (optional for local trial use)

### Run the application

1. Clone or download this repository.
2. (Optional) Register your Syncfusion license in `Program.cs`:
   ```csharp
   Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
   ```
3. Run the app:
   ```
   dotnet run
   ```
4. Open the browser at the URL shown in the console (e.g., `https://localhost:xxxx`).
5. Select a Word document and click **Convert to PDF**.

## How It Works

- `Views/Home/Index.cshtml` — renders the upload form.
- `Controllers/HomeController.cs` — the `ConvertToPdf` action validates the upload, loads it into a `WordDocument`, converts it to a `PdfDocument` with `DocIORenderer`, and streams it back as a file download.