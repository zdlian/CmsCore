using CmsCore.Model.Entities;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Admin.Helpers
{
    public static class FieldTypeHelpers
    {
        public static HtmlString FieldTypeFor(this HtmlHelper helper, FormField formField, bool required, bool read_only)
        {
            if (formField.FieldType.ToString() == "smallText")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                text.Attributes.Add("class", "form-controller");
                TagBuilder textbox = new TagBuilder("input");
                textbox.Attributes.Add("type", "text");
                textbox.Attributes.Add("name", formField.Name);
                if (required == true)
                {
                    text.InnerHtml.SetContent(formField.Name + "(*)");
                    textbox.Attributes.Add("required", "required");
                    if (formField.Value != null)
                    {
                        textbox.Attributes.Add("value", formField.Value.ToString());
                    }
                    textbox.Attributes.Add("data-val", "true");
                    textbox.Attributes.Add("data-val-required", "Lütfen bu alanı boş bırakmayınız.");
                }
                else
                {
                    if (formField.Value != null)
                    {
                        textbox.Attributes.Add("value", formField.Value.ToString());
                    }
                    else
                    {
                        textbox.Attributes.Add("value", "");
                    }
                }
                textbox.MergeAttribute("class", "form-control spinner");
                textbox.Attributes.Add("width", "100%");
                if (read_only == true)
                {
                    textbox.Attributes.Add("readonly", "readonly");
                }
                return new HtmlString(text.ToString() + "</br>" + textbox.ToString() + "</br>");
            }
            else if (formField.FieldType.ToString() == "largeText")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                TagBuilder textarea = new TagBuilder("textarea");
                if (required == true)
                {
                    text.InnerHtml.SetContent(formField.Name + "(*)");
                    textarea.Attributes.Add("required", "required");
                    if (formField.Value != null)
                    {
                        textarea.Attributes.Add("value", formField.Value.ToString());
                        textarea.InnerHtml.SetContent(formField.Value.ToString());
                    }
                    textarea.Attributes.Add("data-val", "true");
                    textarea.Attributes.Add("data-val-required", "Lütfen bu alanı boş bırakmayınız.");
                }
                else
                {
                    if (formField.Value != null)
                    {
                        textarea.Attributes.Add("value", formField.Value.ToString());
                        textarea.InnerHtml.SetContent(formField.Value.ToString());
                    }
                    else
                    {
                        textarea.Attributes.Add("value", "");
                    }
                }
                textarea.Attributes.Add("class", "form-control spinner valid");
                textarea.Attributes.Add("width", "100%");
                textarea.Attributes.Add("name", formField.Name);
                if (read_only == true)
                {
                    textarea.Attributes.Add("readonly", "readonly");
                }
                return new HtmlString(text.ToString() + "</br>" + textarea.ToString() + "</br>");
            }
            else if (formField.FieldType.ToString() == "singleChoice")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                TagBuilder list = new TagBuilder("select");
                var items = formField.Value.Split(',');
                string element = "";
                foreach (var item in items)
                {
                    if (item.ToString().Length > 3)
                    {
                        if (item.ToString().Remove(3, item.Length - 3) == "(+)")
                        {
                            TagBuilder singlechoice = new TagBuilder("option");
                            singlechoice.Attributes.Add("class", "form-controller");
                            singlechoice.Attributes.Add("value", item.ToString().Remove(0, 3));
                            singlechoice.Attributes.Add("selected", "selected");
                            singlechoice.InnerHtml.SetHtmlContent(item.ToString().Remove(0, 3));
                            element += singlechoice.ToString() + "</br>";
                        }
                        else
                        {
                            TagBuilder singlechoice = new TagBuilder("option");
                            singlechoice.Attributes.Add("class", "form-controller");
                            singlechoice.Attributes.Add("value", item);
                            singlechoice.InnerHtml.SetHtmlContent(item);
                            element += singlechoice.ToString() + "</br>";
                        }
                    }
                    else
                    {
                        TagBuilder singlechoice = new TagBuilder("option");
                        singlechoice.Attributes.Add("class", "form-controller");
                        singlechoice.Attributes.Add("value", item);
                        singlechoice.InnerHtml.SetHtmlContent(item);
                        element += singlechoice.ToString() + "</br>";
                    }
                }
                list.InnerHtml.SetHtmlContent(element);

                if (required == true)
                {
                    list.Attributes.Add("required", "required");
                    if (formField.Value != null)
                    {
                        list.Attributes.Add("value", formField.Value.ToString());
                    }
                    list.Attributes.Add("data-val", "true");
                    list.Attributes.Add("data-val-required", "Lütfen bu alanı boş bırakmayınız.");
                }
                else
                {
                    if (formField.Value != null)
                    {
                        list.Attributes.Add("value", formField.Value.ToString());
                    }
                    else
                    {
                        list.Attributes.Add("value", "");
                    }
                }
                if (read_only == true)
                {
                    list.Attributes.Add("disabled", "disabled");
                }
                list.Attributes.Add("class", "form-controller");
                list.Attributes.Add("name", formField.Name);
                return new HtmlString(text.ToString() + "</br>" + list.ToString() + "</br>");
            }
            else if (formField.FieldType.ToString() == "multipleChoice")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                var items = formField.Value.Split(',');
                string element = text.ToString() + "</br>";
                int i = 0;
                foreach (var item in items)
                {
                    i++;
                    TagBuilder multiplechoice = new TagBuilder("input");
                    multiplechoice.Attributes.Add("type", "checkbox");
                    multiplechoice.Attributes.Add("class", "form-controller");
                    multiplechoice.Attributes.Add("name", formField.Name + i.ToString());
                    if (item.ToString().Length > 3)
                    {
                        if (item.ToString().Remove(3, item.Length - 3) == "(+)")
                        {
                            multiplechoice.Attributes.Add("value", item.ToString().Remove(0, 3));
                            multiplechoice.Attributes.Add("checked", "checked");
                            multiplechoice.InnerHtml.SetHtmlContent(item.ToString().Remove(0, 3));
                        }
                        else
                        {
                            multiplechoice.Attributes.Add("value", item);
                            multiplechoice.InnerHtml.SetHtmlContent(item);
                        }
                    }
                    else
                    {
                        multiplechoice.Attributes.Add("value", item);
                        multiplechoice.InnerHtml.SetHtmlContent(item);
                    }
                    if (read_only == true)
                    {
                        multiplechoice.Attributes.Add("disabled", "disabled");
                    }
                    element += multiplechoice.ToString() + "</br>";
                }
                return new HtmlString(element + "</br>");
            }
            else if (formField.FieldType.ToString() == "email")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                //var items = formInfo.Value.Split(',');
                TagBuilder email = new TagBuilder("input");
                email.Attributes.Add("type", "email");
                email.Attributes.Add("multiple", "true");
                email.Attributes.Add("class", "form-control spinner");
                if (required == true)
                {
                    text.InnerHtml.SetContent(formField.Name + "(*)");
                    email.Attributes.Add("required", "required");
                    if (formField.Value != null)
                    {
                        email.Attributes.Add("value", formField.Value.ToString());
                    }
                    email.Attributes.Add("data-val", "true");
                    email.Attributes.Add("data-val-required", "Lütfen bu alanı boş bırakmayınız.");
                    email.Attributes.Add("data-val-email", "Lütfen geçerli bir e-posta adresi giriniz.");
                }
                else
                {
                    if (formField.Value != null)
                    {
                        email.Attributes.Add("value", formField.Value.ToString());
                    }
                    else
                    {
                        email.Attributes.Add("value", "");
                    }
                }
                if (read_only == true)
                {
                    email.Attributes.Add("readonly", "readonly");
                }
                email.Attributes.Add("width", "100%");
                email.Attributes.Add("name", formField.Name);
                return new HtmlString(text.ToString() + "</br>" + email.ToString() + "</br>");
            }
            else if (formField.FieldType.ToString() == "file")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                TagBuilder file = new TagBuilder("input");
                file.Attributes.Add("type", "file");
                if (required == true)
                {
                    file.Attributes.Add("required", "required");
                    if (formField.Value != null)
                    {
                        file.Attributes.Add("value", formField.Value.ToString());
                    }
                    file.Attributes.Add("data-val", "true");
                    file.Attributes.Add("data-val-required", "Lütfen bu alanı boş bırakmayınız.");
                }
                else
                {
                    if (formField.Value != null)
                    {
                        file.Attributes.Add("value", formField.Value.ToString());
                    }
                    else
                    {
                        file.Attributes.Add("value", "");
                    }
                }
                file.Attributes.Add("class", "form-controller");
                file.Attributes.Add("name", "upload");
                return new HtmlString(text.ToString() + "</br>" + file.ToString() + "</br> Dosyanın uzantısı.doc,.docx,.pdf,.rtf,.jpg,.gif,.png olmalıdır.");
            }
            else if (formField.FieldType.ToString() == "radioButtons")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                var items = formField.Value.Split(',');
                string element = text.ToString() + "</br>";
                foreach (var item in items)
                {
                    TagBuilder singlechoice = new TagBuilder("input");
                    singlechoice.Attributes.Add("type", "radio");
                    singlechoice.Attributes.Add("class", "form-controller");
                    singlechoice.Attributes.Add("name", formField.Name);
                    if (item.ToString().Length > 3)
                    {
                        if (item.ToString().Remove(3, item.Length - 3) == "(+)")
                        {
                            singlechoice.Attributes.Add("value", item.ToString().Remove(0, 3));
                            singlechoice.Attributes.Add("checked", "checked");
                            singlechoice.InnerHtml.SetHtmlContent(item.ToString().Remove(0, 3));
                        }
                        else
                        {
                            singlechoice.Attributes.Add("value", item);
                            singlechoice.InnerHtml.SetHtmlContent(item);
                        }
                    }
                    else
                    {
                        singlechoice.Attributes.Add("value", item);
                        singlechoice.InnerHtml.SetHtmlContent(item);
                    }
                    if (read_only == true)
                    {
                        singlechoice.Attributes.Add("disabled", "disabled");
                    }
                    element += singlechoice.ToString() + "</br>";
                }
                return new HtmlString(element + "</br>");
            }
            else if (formField.FieldType.ToString() == "datePicker")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                TagBuilder date = new TagBuilder("input");
                date.Attributes.Add("type", "date");
                if (required == true)
                {
                    text.InnerHtml.SetContent(formField.Name + "(*)");
                    date.Attributes.Add("required", "required");
                    if (formField.Value != null)
                    {
                        date.Attributes.Add("value", formField.Value.ToString());
                    }
                    date.Attributes.Add("data-val", "true");
                    date.Attributes.Add("data-val-required", "Lütfen bu alanı boş bırakmayınız.");
                }
                else
                {
                    if (formField.Value != null)
                    {
                        date.Attributes.Add("value", formField.Value.ToString());
                    }
                    else
                    {
                        date.Attributes.Add("value", "");
                    }
                }
                date.Attributes.Add("class", "form-control spinner");
                date.Attributes.Add("name", formField.Name);
                if (read_only == true)
                {
                    date.Attributes.Add("readonly", "readonly");
                }
                return new HtmlString(text.ToString() + "</br>" + date.ToString() + "</br>");
            }
            else if (formField.FieldType.ToString() == "urlWebSite")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                TagBuilder url = new TagBuilder("input");
                if (formField.Value != null)
                {
                    url.Attributes.Add("type", "url");
                }
                if (required == true)
                {
                    text.InnerHtml.SetContent(formField.Name + "(*)");
                    url.Attributes.Add("required", "required");
                    if (formField.Value != null)
                    {
                        url.Attributes.Add("value", formField.Value.ToString());
                    }
                    url.Attributes.Add("data-val", "true");
                    url.Attributes.Add("data-val-required", "Lütfen bu alanı boş bırakmayınız.");
                    url.Attributes.Add("data-val-url", "Lütfen geçerli bir web adresi giriniz.");
                }
                else
                {
                    if (formField.Value != null)
                    {
                        url.Attributes.Add("value", formField.Value.ToString());
                    }
                    else
                    {
                        url.Attributes.Add("value", "");
                    }
                }
                if (read_only == true)
                {
                    url.Attributes.Add("readonly", "readonly");
                }
                url.Attributes.Add("width", "100%");
                url.Attributes.Add("class", "form-control spinner");
                url.Attributes.Add("name", formField.Name);
                return new HtmlString(text.ToString() + "</br>" + url.ToString() + "</br>");
            }
            else if (formField.FieldType.ToString() == "numberValue")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                TagBuilder number = new TagBuilder("input");
                number.Attributes.Add("type", "number");
                if (required == true)
                {
                    text.InnerHtml.SetContent(formField.Name + "(*)");
                    number.Attributes.Add("required", "required");
                    if (formField.Value != null)
                    {
                        number.Attributes.Add("value", formField.Value.ToString());
                    }
                    number.Attributes.Add("data-val", "true");
                    number.Attributes.Add("data-val-required", "Lütfen geçerli bir değer giriniz.");
                    //number.Attributes.Add("data-val-number", "Lütfen geçerli bir sayı giriniz.");
                }
                else
                {
                    if (formField.Value != null)
                    {
                        number.Attributes.Add("value", formField.Value.ToString());
                    }
                    else
                    {
                        number.Attributes.Add("value", "");
                    }
                }
                if (read_only == true)
                {
                    number.Attributes.Add("readonly", "readonly");
                }
                number.Attributes.Add("class", "form-control spinner");
                number.Attributes.Add("width", "100%");
                number.Attributes.Add("name", formField.Name);
                return new HtmlString(text.ToString() + "</br>" + number.ToString() + "</br>");
            }
            else if (formField.FieldType.ToString() == "timeValue")
            {
                TagBuilder text = new TagBuilder("text");
                text.InnerHtml.SetContent(formField.Name);
                TagBuilder time = new TagBuilder("input");
                time.Attributes.Add("type", "time");
                if (required == true)
                {
                    text.InnerHtml.SetContent(formField.Name + "(*)");
                    time.Attributes.Add("required", "required");
                    if (formField.Value != null)
                    {
                        time.Attributes.Add("value", formField.Value.ToString());
                    }

                    time.Attributes.Add("data-val", "true");
                    time.Attributes.Add("data-val-required", "Lütfen bu alanı boş bırakmayınız.");
                }
                else
                {
                    if (formField.Value != null)
                    {
                        time.Attributes.Add("value", formField.Value.ToString());
                    }
                    else
                    {
                        time.Attributes.Add("value", "");
                    }
                }


                if (read_only == true)
                {
                    time.Attributes.Add("readonly", "readonly");
                }
                time.Attributes.Add("class", "form-control spinner");
                time.Attributes.Add("name", formField.Name);
                return new HtmlString(text.ToString() + "</br>" + time.ToString() + "</br>");
            }
            else
            {
                return new HtmlString("");
            }
        }
    }
}
