using iTextSharp.text;
using iTextSharp.text.pdf;
using LazyStaff.Classes;
using System;
using System.IO;
using System.Windows.Forms;


namespace LazyStaff.Helpers
{
    static class PrintDeviceHelper
    {
        public static void FillPdf(PrintDevice device)
        {
            string oldFile = Application.StartupPath + @"\\Source\\PDF\\1_new.pdf";                                 // путь к исходному шаблону .pdf
            string newFile = Application.StartupPath + @"\\Source\\PDF\\2.pdf";                                 // путь экспорта заполненного .pdf

            PdfReader reader = new PdfReader(oldFile);                                                          // создаем ридер для iTextSharp
            string checkedChar = "+";
            using (FileStream fileStream = new FileStream(newFile, FileMode.Create, FileAccess.Write))             // создаем экспортируемый файл
            {
                using (PdfStamper stamper = new PdfStamper(reader, fileStream))
                {
                    PdfContentByte contentByte = stamper.GetOverContent(1);
                    BaseFont bf = BaseFont.CreateFont(Application.StartupPath + @"\\Source\\Title\\timesbd.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);      // настройка шрифтов
                                                                                                                                                               //BaseFont charFont = BaseFont.CreateFont(Application.StartupPath + @"\\Source\\Title\\ariblk.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    contentByte.SetColorFill(BaseColor.BLUE);
                    contentByte.SetFontAndSize(bf, 12);

                    contentByte.BeginText();                                                                        // пишем текст в новый .pdf

                    var main_start = 142;
                    var add_start = 690;
                    
                    // Поле: Табульный номер
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.TabelNumber, main_start, 506, 0);
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.TabelNumber, add_start, 506, 0);

                    // Поле: Заводской номер
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.SerialNumber, main_start, 472, 0);
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.SerialNumber, add_start, 472, 0);

                    // Поле: Тип
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.Type, main_start, 424, 0);
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.Type, add_start, 424, 0);

                    // Поле: год выпуска
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.YearOfRelease, main_start, 380, 0);
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.YearOfRelease, add_start, 380, 0);

                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.DateToPrint, 165, 28, 0);
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, device.DateToPrint, 590, 29, 0);

                    contentByte.SetFontAndSize(bf, 10);
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Пчельников А.С.", 49, 28, 0);
                    contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Пчельников А.С.", 590, 56, 0);

                    contentByte.SetFontAndSize(bf, 16);
                    if (device.IsMetrologicalControlType)
                    {
                        switch (device.McSelected)
                        {
                            case MetrologicalControlType.Verification:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 247, 158, 0);
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 660, 132, 0);
                                break;
                            case MetrologicalControlType.Calibration:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 247, 132, 0);
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 660, 104, 0);
                                break;
                            case MetrologicalControlType.AsReference:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 247, 108, 0);
                                break;
                            case MetrologicalControlType.InputControl:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 247, 82, 0);
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 804, 132, 0);
                                break;
                            case MetrologicalControlType.OutOfTown:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 247, 55, 0);
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 804, 82, 0);
                                break;
                            default:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 247, 158, 0);
                                break;
                        }
                    }
                    else if (device.IsRepairType)
                    {
                        switch (device.RepairSelected)
                        {
                            case RepairType.Current:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 502, 158, 0);
                                break;
                            case RepairType.Medium:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 502, 132, 0);
                                break;
                            case RepairType.Major:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 502, 108, 0);
                                break;
                            case RepairType.OnSite:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 502, 82, 0);
                                break;
                            case RepairType.OutOfTown:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 502, 55, 0);
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 804, 82, 0);
                                break;
                            default:
                                contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 502, 158, 0);
                                break;
                        }
                        contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, checkedChar, 804, 104, 0);
                    }

                    contentByte.EndText();
                }
            }
        }

        //---------------------------------------------------
        // Метод вывода на печать .pdf файла чрез Spire.PDF
        //---------------------------------------------------
        public static void PrintPdfFile()
        {
            string newFile = Application.StartupPath + @"\\Source\\PDF\\2.pdf";                                 // путь экспорта заполненного .pdf

            Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();                                    // создаём экземпляр
            pdfdocument.LoadFromFile(newFile);                                                                  // загружаем файл
            //pdfdocument.PrinterName = "My Printer";

            pdfdocument.PrintDocument.PrinterSettings.Copies = 1;                                               // количество копий (можно не указывать)
            pdfdocument.PrintDocument.Print();
            pdfdocument.Dispose();
        }
    }
}
