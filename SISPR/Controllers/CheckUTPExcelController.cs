﻿using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SISPR.Models.ModelsUTP;
using SISPR.Controllers.Classes.CheckUTPExcelController;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using SISPR.Models;



namespace SISPR.Controllers
{
    public class CheckUTPExcelController : Controller
    {
        List<ModelVrem> propUTP = new List<ModelVrem>();
        public IActionResult Index()
        {
            return View("UploadFile");
        }


        //public IActionResult SaveOnChange(int ID, int Type, float Value)
        //{

        //    return Json("Изменения внесены!");
        //}

        public bool СontainsUTP(ExcelWorksheet Worksheet)
        {
            foreach (var cell in Worksheet.Cells)
            {
                string text = Regex.Replace(cell.Text.ToString().ToUpper(), @"^[a-zA-Z]+$",string.Empty);
               if (text == "ТИПОВОЙ УЧЕБНЫЙ ПЛАН")
                {
                    return true;
                    
                }
            }

            return false;
        }


        public async Task<IActionResult> AddUTP(IFormFile upload)
        {
            UploadFileController uploadFile = new UploadFileController();
           
           
            return View("~/Views/UTP/CheckUTPExcel/UTPViews.cshtml", CheckExcel(Directory.GetCurrentDirectory() + await uploadFile.AddFile(upload)));
        }

        public UTP CheckExcel(string path)
        {
           
            UTP uTP = new UTP();


            List<TableModel> listTable = new List<TableModel>();


            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                FileInfo existingFile = new FileInfo(path);
                //uTP.propertyUTP.Name 
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                    //get the first worksheet in the workbook
                    {
                        if (СontainsUTP(worksheet))
                        {
                            uTP.propertyUTP = PropertyFill(worksheet);

                            var colRow = worksheet.Dimension.End.Row;
                            var Table = InfoTable(worksheet, colRow);
                            listTable.Add(Table);
                        }
                    }
                }
            }
                     
            

            //WorkPropertyUTP workProperty = new WorkPropertyUTP();
           
            uTP.table=listTable;

              return  uTP;

            
          
        }

        private PropertyUTP PropertyFill(ExcelWorksheet Worksheet)
        {
            PropertyUTP propertyUTP = new PropertyUTP();
            var xz = Worksheet.Cells.ToArray();
            int index = 0;
            foreach (var cell in xz)
            {
                
                if (Regex.Replace(cell.Text.ToString().ToUpper(), "[^а-яА-Я]", string.Empty) == Regex.Replace("Количество слушателей в группе:".ToUpper(), "[^а-яА-Я]", string.Empty) )
                {
                    propertyUTP.Kol_slushatel_v_group =int.Parse( xz[index+1].Text);
;
                }
                if (Regex.Replace(cell.Text.ToString().ToUpper(), "[^а-яА-Я]", string.Empty) == Regex.Replace("Количество групп".ToUpper(), "[^а-яА-Я]", string.Empty))
                {
                    propertyUTP.Kol_groups = int.Parse(xz[index + 1].Text);
                    
                }
                if (Regex.Replace(cell.Text.ToString().ToUpper(), "[^а-яА-Я]", string.Empty) == Regex.Replace("Форма обучения".ToUpper(), "[^а-яА-Я]", string.Empty))
                {
                    propertyUTP.Forma_obuchen = xz[index + 1].Text;
                    
                }
                if (Regex.Replace(cell.Text.ToString().ToUpper(), "[^а-яА-Я]", string.Empty) == Regex.Replace("Режим занятий".ToUpper(), "[^а-яА-Я]", string.Empty))
                {
                    propertyUTP.Rejim_zanyati = int.Parse(Regex.Replace(xz[index + 1].Text.ToString().ToUpper(), "[^0-9]", string.Empty));
                    
                }
                //if (Regex.Replace(cell.Text.ToString().ToUpper(), "[^а-яА-Я]", string.Empty) == Regex.Replace("Количество слушателей в группе:".ToUpper(), "[^а-яА-Я]", string.Empty))
                //{
                //    propertyUTP.Kol_slushatel_v_group = int.Parse(xz[index + 1].Text);


                //}


                if (cell.Text == "Вид учебной работы" || cell.Text == "Вид учебной нагрузки")
                {
                    break;


                }




                index++;
            }

            return propertyUTP;
        }



        public class ModelVrem
        {
          public  string str1 { get; set; }
            public string str2 { get; set; }
        }
        public TableModel InfoTable(ExcelWorksheet sheet, int colRow)
        {



            TableModel Table = new TableModel();
            int endTable = 0;
            int startTable = 0;
            bool startTableBool = false;
            bool endTableBool = false;


            for (int i = colRow; i > 0; i--)
            {
                if (sheet.Cells[i, 1].Text == "Итого часов по УТП:" && endTable == 0)
                {

                    startTable = i;
                    startTableBool = true;
                }

                if (endTableBool == true)
                {
                    propUTP.Add(new ModelVrem { str1 = sheet.Cells[i, 1].Text, str2 = sheet.Cells[i, 2].Text });
                }
                if (sheet.Cells[i, 1].Text == "Вид учебной работы" || sheet.Cells[i, 1].Text == "Вид учебной нагрузки")
                {
                    endTable = i;
                    startTableBool = false;
                    endTableBool = true;


                }



                    if (startTableBool == true)
                {



                    var row = sheet;
                    endTable = i;



                    RowTableModel NewRow = new RowTableModel();
                    NewRow.NameTypeTrainingLoad = sheet.Cells[i, 1].Text;

                    NewRow.NumberControlForms = float.Parse(sheet.Cells[i, 5].Text != "" ? sheet.Cells[i, 5].Text : "0");
                    NewRow.NumberGroups = float.Parse(sheet.Cells[i, 3].Text != "" ? sheet.Cells[i, 3].Text : "0");
                    NewRow.NumberHours = float.Parse(sheet.Cells[i, 2].Text != "" ? sheet.Cells[i, 2].Text : "0");
                    NewRow.NumberListeners = float.Parse(sheet.Cells[i, 6].Text != "" ? sheet.Cells[i, 6].Text : "0");
                    NewRow.NumberSubgroups = float.Parse(sheet.Cells[i, 4].Text != "" ? sheet.Cells[i, 4].Text : "0");
                    NewRow.VolumeHours = float.Parse(sheet.Cells[i, 7].Text != "" ? sheet.Cells[i, 7].Text : "0");

                    if (NewRow.NumberHours != 0 && NewRow.VolumeHours == 0 && TypeTrainingLoad(NewRow.NameTypeTrainingLoad) != 0)
                    {
                        NewRow.Type = 3;

                    }

                    else
                        NewRow.Type = TypeTrainingLoad(NewRow.NameTypeTrainingLoad);



                    if (NewRow.VolumeHours != 0)
                    {
                        if (((NewRow.NumberHours == 0 ? 1 : NewRow.NumberHours) * (NewRow.NumberGroups == 0 ? 1 : NewRow.NumberGroups) * (NewRow.NumberSubgroups == 0 ? 1 : NewRow.NumberSubgroups) * (NewRow.NumberControlForms == 0 ? 1 : NewRow.NumberControlForms) * (NewRow.NumberListeners == 0 ? 1 : NewRow.NumberListeners)) != NewRow.VolumeHours)
                        {
                            NewRow.Status = "неверно";
                        }
                    }





                    Table.Add(NewRow);
                }
            }
            Table.Row.Reverse();
            int j = 0;
            foreach (var row in Table.Row)
            {
                row.ID = j;
                j++;
            }

            return Table;
        }


        public int TypeTrainingLoad(string NameTypeTrainingLoad)
        {
            List<string> Auditor = new List<string>() {"лекции",
"практическиезанятия",
"проведениегрупповыхконсультацийврамкахдпппк",
"проведениедиагностических,контрольныхработ,тестирование",
"итоговаяаттестация(защитапроектов,предусмотренныхучебнымпланом,обработкарезультатовтестированияидр.,всоответствиисуп)",
"итоговаяаттестация(приемписьменныхзачетныхработ,предусмотренныхучебнымпланом)",
"приёмэкзаменов,предусмотренныхучебнымпланом",
"участиевработеитоговойаттестационнойкомиссии",
"проведениевебинаров,видеоконференцийит.п.длядистанционногообучения"
 };
            List<string> VneAuditor = new List<string>() { "разработкановыхлекционныхматериаловиумк(дляочногообучения)конспектов,дидактическогоматериаладлялекционныхипрактическихзанятий",
"разработкаучебно-методическихматериаловдлядистанционногообучения(длязаочногообучения)",
"разработкадиагностическихматериалов(входной,промежуточной,выходнойдиагностики)",
"проверкавходнойи/иливыходнойдиагностикиуровняпредметнойготовностислушателей,подготовкааналитическойсправки",
"разработкаконтрольныхзаданийкзачету",
"разработкаэкзаменационныхматериалов",
"подготовкаматериаловпрезентационногохарактеравэлектронномвиде",
"организацияисопровождениефорумов,индивидуальныхконсультацийпридистанционномобучении(заочногообучения)",
"организационноеруководствокурсами",
"учебно-методическоеруководство",
"организационноесопровождениедистанционногообучения(заочногообучения)(вт.ч.техническое)",
"обработкарезультатовтестированияпомодулю,подготовкааналитическойсправки",
"промежуточныйконтрольповариативномумодулю(проверказачетныхработ)",
"руководствостажировкойпопрограммамдополнительногопрофессиональногообразованияворганизацияхспроверкойотчетов",
"проверкаконтрольныхизачетныхработ,эссе(втомчислепридистанционныхформахобучения),проектов(толькопридистанционнойформеобучения),предусмотренныхутп",
"проведениеиндивидуальныхконсультацийдляслушателейкурсоввсоответствиисутп(очноеобучение)",
"проведениеиндивидуальныхзанятийдляслушателей,обучающихсяпоиндивидуальномумаршрутуповышенияквалификации",
"разработкадпппкповышенияквалификации,модулейпрограмм",
"руководствокурсовойработой",
"подготовкакитоговойаттестации,вт.ч.руководствовыпускнойработой,включаянаписаниеотзыва",
"рецензированиевыпускныхработ",
"подготовкавидеоматериаловдляпроведениялекций(вт.ч.лекцийвдистанционномрежиме)"
 };



            List<string> Default = new List<string>()
            {
"всегочасов:",
"итогочасовпоутп:",
"внеаудиторнаяработа:",
"аудиторнаяработа:",
"дистанционноеобучение:"



        };

            List<TypeLoadAndCoefficientModel> ListLoad = new List<TypeLoadAndCoefficientModel>();
            ListLoad.AddRange(Auditor.Select(x => new TypeLoadAndCoefficientModel { NameLoad = x, TypeLoad = 1 }).ToList());
            ListLoad.AddRange(VneAuditor.Select(x => new TypeLoadAndCoefficientModel { NameLoad = x, TypeLoad = 2 }).ToList());
            ListLoad.AddRange(Default.Select(x => new TypeLoadAndCoefficientModel { NameLoad = x, TypeLoad = 0 }).ToList());
            DeterminateTypeLoad determinateTypeLoad = new DeterminateTypeLoad(ListLoad);


            /*  float percentAuditor = 0;
             float percentVneAuditor = 0;
             int tip = 0;
             NameTypeTrainingLoad = NameTypeTrainingLoad.Replace(" ", "");
             NameTypeTrainingLoad = NameTypeTrainingLoad.ToLower();
             foreach (var row in Auditor)
             {

                 int kolsovpad = 0;


                 int result = String.Compare(NameTypeTrainingLoad, row);

                 for (int i = 0; i < (NameTypeTrainingLoad.Length < row.Length ? NameTypeTrainingLoad.Length : row.Length); i++)
                 {
                     if (row[i] == NameTypeTrainingLoad[i])
                     {

                         kolsovpad++;
                     }



                 }


                 if (kolsovpad != 0)
                     if (kolsovpad / NameTypeTrainingLoad.Length * 100 > percentAuditor)
                     {
                         percentAuditor = kolsovpad / NameTypeTrainingLoad.Length * 100;

                     }


             }





             foreach (var row in VneAuditor)
             {
                 NameTypeTrainingLoad = NameTypeTrainingLoad.Replace(" ", "");
                 NameTypeTrainingLoad = NameTypeTrainingLoad.ToLower();
                 int kolsovpad = 0;




                 for (int i = 0; i < (NameTypeTrainingLoad.Length < row.Length ? NameTypeTrainingLoad.Length : row.Length); i++)
                 {
                     if (row[i] == NameTypeTrainingLoad[i])
                     {
                         kolsovpad++;
                     }



                 }


                 if (kolsovpad != 0)
                     if (kolsovpad / NameTypeTrainingLoad.Length * 100 > percentVneAuditor)
                     {
                         percentVneAuditor = kolsovpad / NameTypeTrainingLoad.Length * 100;

                     }


             }


             if (percentAuditor < percentVneAuditor)
             {
                 tip = 2;
             }
             else
             {
                 tip = 1;

             }
            */
            return determinateTypeLoad.SearchType(NameTypeTrainingLoad);
        }



    }


}





