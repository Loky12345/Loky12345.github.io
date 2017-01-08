using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class AddData : System.Web.UI.Page
{
    //------01 Соединение с базой данных
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TESTConnectionString1"].ToString());//@"Data Source=GMCWS0658;Initial Catalog=TEST;User ID=sa;Password=sa");
    public string MyConnectionString;
    // Строка соединения
    public SqlDataReader dr;
    // SqlCommand создает инструкцию хранимой процедуры
    public SqlCommand cmd;


//------02 Метод отвечающий за соединение
    public void ConnectionMethod()
    {
        // Присваиваем переменной (MyConnectionString) соединение (TESTConnectionString) и приобразовываем его в строку (ToString)
        MyConnectionString = ConfigurationManager.ConnectionStrings["TESTConnectionString1"].ToString();
        // Вносим в con (SqlConnection) строку соединения (MyConnectionString)
        con = new SqlConnection(MyConnectionString);
        // Открываем это соединение
        con.Open();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    // Инициализируем LINK SQL и таблицу Staff
    //    StaffdbDataContext db = new StaffdbDataContext();
    //    Staff staff = new Staff();
    //    // Присваиваем связь между столбцами таблицы и TextBox-ами
    //    staff.IdStaff = Convert.ToInt32(DropDownList1.Text);
    //    staff.Sername = TextBox1.Text;
    //    staff.Name = TextBox2.Text;
    //    staff.MiddleName = TextBox3.Text;
    //    staff.Position = TextBox4.Text;
    //    staff.TelNumber = TextBox5.Text;
    //    staff.PCNumber = TextBox6.Text;
    //    // Отображаем данные на таблице
    //    db.Staff.InsertOnSubmit(staff);
    //    db.SubmitChanges();
    //    // Обновляем страницу
    //    Response.Redirect("/AddData.aspx");
    //}



//=====Пакетная загрузка Excel таблицы в базу данных============================================
    protected void FileUpload1_Load(object sender, EventArgs e)
    {
        //if (FileUpload1.HasFile)
        //{

        //    System.IO.FileInfo fi = new System.IO.FileInfo("c:\\"+FileUpload1.FileName);
        //    Button2.Enabled = (fi.Extension.ToLower() == ".xls" || fi.Extension.ToLower() == ".xlsx");
        //}

    }

/* Файловая загрузка excel файла
    struct item_struct
    {
        public string razdel;
        public int year;
        public int work_code;
        public string name;
        public string status;
        public string fin_source;
        public string fill;
        public string save_place;

        public string ID_Раздела()
    {
        return " FROM Sections WHERE lower(replace(ltrim(rtrim([Полное наименование раздела])),' ',''))='" + razdel.Trim().Replace(" ", "").ToLower().Replace("'", "'+char(39)+'") + "' ";    
    }
        public string Год()
        {
            return "'" + year.ToString() + "'";
        }
        public string Код()
        {
            return "'" + work_code.ToString() + "'";
        }
        public string Наименование()
        {
            return "'" + name.Replace("'", "'+char(39)+'") + "'";
        }
        public string Статус()
        {
            return "'" + status.Replace("'", "'+char(39)+'") + "'";
        }
        public string Источник_финансирования()
        {
            return "'" + fin_source.Replace("'", "'+char(39)+'") + "'";
        }
        public string Заполнение()
        {
            return "'" + fill.Replace("'", "'+char(39)+'") + "'";
        }
        public string Место_хранения()
        {
            return "'" + save_place.Replace("'", "'+char(39)+'") + "'";
        }
       internal  string  get_script()
        {
            string fields_ = string.Join(",", new string[] { "SELECT [ID Раздела]", Год(), Код(), Наименование(), Статус(), Источник_финансирования(), Заполнение(), Место_хранения() });
            fields_ = fields_ + ID_Раздела();

            //return " INSERT INTO [MainTable] ( [ID Раздела] ,[Год],[Код],[Наименование], [Статус], [Источник финансирования] , [Заполнение], [Место хранения]) Values (" + fields_ + ") ";
            return " INSERT INTO [MainTable] " + fields_ + " ";

        }
    }

    

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
                System.IO.FileInfo fi = new System.IO.FileInfo("c:\\"+FileUpload1.FileName);
                if (!(fi.Extension.ToLower() == ".xls" || fi.Extension.ToLower() == ".xlsx"))
                {

                    return;
                }
            
            string tmpFolderName = System.IO.Path.GetTempPath();
            string tmpFileName = System.IO.Path.GetTempPath();
            if (!tmpFolderName.EndsWith(@"\"))
            {
                tmpFolderName += @"\";
            }

            FileUpload1.SaveAs(tmpFolderName + FileUpload1.FileName);

            ClosedXML.Excel.XLWorkbook wb = ClosedXMLExcel.GetWorkbook(tmpFolderName + FileUpload1.FileName);


            //создать новый Worksheet и накидать в него команды insert, чтобы заполнить таблицу
            ClosedXML.Excel.IXLWorksheet ws = wb.Worksheets.Worksheet(1);
            //=======================================

            List<string> scripts=new List<string>() ;
            for (int i = 2; i < 65536; i++)
            {
                item_struct is_ = new item_struct();
                bool f = false;
                for (int j = 1; j < 9; j++)
                {
                    if (ws.Cell(i, j).Value.ToString().Trim() != "" )
                    {f=true;}
                }
                if (f == false)
                { i = 65536; }
                else
                {
                    for (int j = 1; j < 9; j++)
                    {

                        {
                            string val_ = ws.Cell(i, j).Value.ToString().Trim();
                            int ival_ = 0;
                            switch (j)
                            {
                                case 1://Раздел
                                    if (val_ != "")
                                    {
                                        is_.razdel = val_;
                                        break;
                                    }
                                    throw new Exception("Раздел не должен быть пустым");

                                case 2://Год
                                    if (int.TryParse(val_, out ival_))
                                    {
                                        if (ival_ >= 1900 && ival_ <= 2099)
                                        {
                                            is_.year = ival_;
                                            break;
                                        }
                                    }
                                    throw new Exception("неправильно указан год");
                                case 3://Код
                                    if (int.TryParse(val_, out ival_))
                                    {
                                        if (ival_ >= 1000000 && ival_ <= 99999999)
                                        {
                                            is_.work_code = ival_;
                                            break;
                                        }
                                    }
                                    throw new Exception("неправильно указан код работы");


                                case 4://Наименование
                                    if (val_ != "")
                                    {
                                        is_.name = val_;
                                        break;
                                    }
                                    throw new Exception("наименование не должно быть пустым");

                                case 5://Статус
                                    if (new List<string>(new string[] { "доработанный", "первичный", "дополнение", "действующий", "-" }).Contains(val_))
                                    {
                                        is_.status = val_;
                                        break;
                                    }
                                    throw new Exception("неправильно указан статус");
                                case 6://Источник финансирования 
                                    if (val_ != "")
                                    {
                                        is_.fin_source = val_;
                                        break;
                                    }
                                    throw new Exception("Источник финансирования не должен быть пустым");
                                case 7://Заполнение
                                    if (new List<string>(new string[] { "Готово", "Заполняется", "-" }).Contains(val_))
                                    {
                                        is_.fill = val_;
                                        break;
                                    }
                                    throw new Exception("неправильно указано Заполнение");
                                case 8://Место хранения
                                    if (val_ != "")
                                    {
                                        is_.save_place = val_;
                                        break;
                                    }
                                    throw new Exception("Место хранения не должно быть пустым");
                                default: { break; };
                            }
                        }


                    }
                    scripts.Add(is_.get_script());
                }
            }

            //=======================================

            SQL.ExecSQL(ConfigurationManager.ConnectionStrings["TESTConnectionString1"].ConnectionString, string.Join(";",scripts ) );
//==================================================================================================================
       
        */
}
    
