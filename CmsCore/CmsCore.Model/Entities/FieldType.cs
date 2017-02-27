using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Model.Entities
{
    public enum FieldType
    {
        //[Display(Name = @"Ad Soyad")]
        fullName = 1,
        //[Display(Name = @"Telefon")]
        telephone = 2,
        //[Display(Name = @"E-Posta")]
        email = 3,
        //[Display(Name = @"Metin Kutusu")]
        smallText = 4,
        //[Display(Name = @"Metin Alanı")]
        largeText = 5,
        //[Display(Name = @"Tek Seçim")]
        singleChoice = 6,
        //[Display(Name = @"Çoklu Seçim")]
        multipleChoice = 7,
        //[Display(Name = @"Dosya Yükleme")]
        file = 8,
        //[Display(Name = @"Seçenek Düğmeleri")]
        radioButtons = 9,
        //[Display(Name = @"Takvim")]
        datePicker = 10,
        //[Display(Name = @"Web Sitesi")]
        urlWebSite = 11,
        //[Display(Name = @"Sayı Değer")]
        numberValue = 12,
        //[Display(Name = @"Zaman Değer")]
        timeValue = 13
        
        
    }
}
