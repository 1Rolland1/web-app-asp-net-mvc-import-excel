﻿using web_app_asp_net_mvc_import_excel.Models.Attributes;
using web_app_asp_net_mvc_import_excel.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace web_app_asp_net_mvc_import_excel.Models
{
    public class ImportDisciplineViewModel
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        [Display(Name = "Файл импорта")]
        [Required(ErrorMessage = "Укажите файл импорта (.xlsx)")]
        public HttpPostedFileBase FileToImport { get; set; }
    }
}