// See https://aka.ms/new-console-template for more information

using QuestPDF.Companion;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPdfExample;

QuestPDF.Settings.License = LicenseType.Community;

var font = File.OpenRead("NanumGothic.ttf");
FontManager.RegisterFont(font);

// code in your main method
var document = Example.Create();

// instead of the standard way of generating a PDF file
document.GeneratePdf("test.pdf");

// optionally, you can specify an HTTP port to communicate with the previewer host (default is 12500)
document.ShowInCompanion();