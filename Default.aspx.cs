//using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    //------01 Соединение с базой данных
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TESTConnectionString1"].ToString());//@"Data Source=GMCWS0658;Initial Catalog=TEST;User ID=sa;Password=sa");
    public string MyConnectionString;
    // Строка соединения
    public SqlDataReader dr;
    // SqlCommand создает инструкцию хранимой процедуры
    public SqlCommand cmd;
    public bool i = true; // Логическая проверка

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
        GridView1.Visible = true;
        /*
        // Логическое условие срабатывает только при первой загрузке страницы
        if (i)
        {
            SqlDataSource4.SelectCommand = "SELECT [ID Раздела] AS ID_Раздела, [Номер], [Год], [Код], [Наименование], [Статус], [Источник финансирования] AS Источник_финансирования, [Заполнение], [Место хранения] AS Место_хранения, [НомерРаз] FROM [View_1]";
            SqlDataSource4.DataBind();
        }
        // Строка ошибки ввода в поисковой строке, по умолчанию сделали невидимым
        Label2.Visible = false;
        GridView1.Visible = true;
        */

//------02 Вывод суммы строк таблицы Staff
        // Открытие соединения с БД
        con.Open();
        // Строка запросов в БД
        string GetData = "SELECT COUNT(*) PCNumber FROM Staff"; // Номер-столбец для отбора. MainTable-таблица
        // Получение указанной выше процедуры с помощью команды SqlCommand. GetData - строка выбора. con - соединение.
        cmd = new SqlCommand(GetData, con);
        // Читаем полученные данные.
        dr = cmd.ExecuteReader();
        // Вывод строк на экран
        if (dr.Read())
        {
            // Выводим всю информацию в Label1 
            Label1.Visible = true;
            Label1.Text = dr[0].ToString();
        }
        dr.Close();
    }

   /* //------03 Метод вытаскивающий нужное значение из БД
    private void BaseContact()
    {
        // Открываем соединение через Connection метод
        ConnectionMethod();
        // Обращаемся к таблице и выбираем то, что вписали в SearchBox
        string query = "SELECT [ID Раздела] AS ID_Раздела, [Номер], [Год], [Код], [Наименование], [Статус], [Источник финансирования] AS Источник_финансирования, [Заполнение], [Место хранения] AS Место_хранения, [НомерРаз] FROM [View_1] WHERE [" + DropDownList1.SelectedValue + "] LIKE'%" + SearchBox.Text.Replace("'", "'+char(39)+'") + "%'";

        // Создаем SQL адаптер и указываем соединение. SqlDataAdapter отвечает за то, чтобы данные вывелись в GridView
        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
        // Устанавливаем DataSet
        DataSet myDataSet = new DataSet();
        // Заполняем Dat Source1
        dataAdapter.Fill(myDataSet);
        SqlDataSource4.SelectCommand = query;
        SqlDataSource4.DataBind();
    }
    //------04 Настройка кнопки поиска
    protected void Button1_Click(object sender, EventArgs e)
    {
        i = false;
        // Исключение
        // Если cтрока поиcка НЕ пустая, то он их считывает
        if (SearchBox.Text != "")
        {
            // Запуск контакта
            BaseContact();
        }
        // Иначе, если SearchBox пустая, то выводится сообщение
        else if (SearchBox.Text == "")
        {
            GridView1.Visible = true;
            Label2.Visible = true;
            Label2.Text = "Вы ничего не ввели!";
            i = true;
        }
    }
    */
    public string NULL { get; set; }

    //Отображение страниц
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        Label2.Visible = true;
        Label2.Text = "Страница " + (GridView1.PageIndex + 1) + " из " + GridView1.PageCount;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

/*
 //--------Экспорт таблицы в Excel----------------------------------------------

    #region export to excel
    /// <summary>
    /// Таблица DataTable в массив
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    string[,] DtToArray(System.Data.DataTable dt)
    {
        string[,] Buf = new string[dt.Rows.Count + 1, dt.Columns.Count];

        int cc = 0;
        foreach (System.Data.DataColumn col_ in dt.Columns)
        {
            Buf[0, cc] = col_.ColumnName;
            cc += 1;


        }
        int rc = 1;
        foreach (System.Data.DataRow row_ in dt.Rows)
        {
            cc = 0;
            foreach (System.Data.DataColumn col_ in dt.Columns)
            {
                Buf[rc, cc] = row_[col_].ToString();
                cc += 1;
            }
            rc += 1;
        }
        return Buf;
    }
    /// <summary>
    /// таблица dataTable на лист Excel типа ClosedXML.Excel.IXLWorksheet
    /// начиная с левой верхней ячейки
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="ws"></param>
    void setDTtoWS(DataTable dt, ClosedXML.Excel.IXLWorksheet ws)
    {
        int delta = 1;
        int cc = 0 + delta;
        foreach (System.Data.DataColumn col_ in dt.Columns)
        {
            ws.Cell(delta, cc).Value = col_.ColumnName.Replace("_", " ");
            cc += 1;
        }
        int rc = 1 + delta;
        foreach (System.Data.DataRow row_ in dt.Rows)
        {
            cc = 0 + delta;
            foreach (System.Data.DataColumn col_ in dt.Columns)
            {
                ws.Cell(rc, cc).Value = row_[col_].ToString();
                cc += 1;
            }
            rc += 1;
        }
    }
    /// <summary>
    /// оставляем один лист в книге типа ClosedXML.Excel.XLWorkbook
    /// </summary>
    /// <param name="wb"></param>
    void setSingleWS(ClosedXML.Excel.XLWorkbook wb)
    {
        while (wb.Worksheets.Count != 1)
        {
            wb.Worksheets.Delete(0);
        }
    }

    DataTable GetDTBySQL(string constr, string query)
    {
        DataTable dt = null;
        try
        {
            // образовали объект соединения с помощью строки соединения
            using (SqlConnection con = new SqlConnection(constr))
            {
                // образовали объект команды, передав ему запрос и объект соединения
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        // открыли соединение
                        con.Open();
                        // образовали объект таблицы
                        dt = new DataTable();
                        // загрузили объект таблицы результатом выполнения запроса
                        // само выполнение - методом ExecuteReader()
                        dt.Load(cmd.ExecuteReader());
                        //уничтожили объект соединения
                        con.Dispose();
                        //очистили пул подключений
                        SqlConnection.ClearAllPools();
                    }
                    catch (Exception exx)
                    {
                        try
                        {
                            //уничтожили объект соединения
                            con.Dispose();
                            //очистили пул подключений
                            SqlConnection.ClearAllPools();
                        }
                        catch (Exception)
                        {
                        }
                        throw exx;
                    }
                }
            }
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
            return null;
        }
    }

    #endregion

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = SQL.GetDTBySQL(ConfigurationManager.ConnectionStrings["TESTConnectionString1"].ConnectionString, "SELECT [ID Раздела] AS ID_Раздела, [Номер], [Год], [Код], [Наименование], [Статус], [Источник финансирования] AS Источник_финансирования,[Заполнение], [Место хранения] AS Место_хранения FROM [MainTable]");

        // получаем книгу в памяти
        ClosedXML.Excel.XLWorkbook wb = ClosedXMLExcel.GetWorkbook();
        // оставляем в ней один лист
        setSingleWS(wb);
        // на этот лист - скидываем ранее полученные данные , содержащиеся в переменной dt типа DataTable
        setDTtoWS(dt, wb.Worksheets.Worksheet(1));
//======Стилизация таблицы============================================================
        ClosedXML.Excel.IXLWorksheet ws = wb.Worksheets.Worksheet(1);
        int rc = dt.Rows.Count;
        int down_delta = 3;
        //Строка суммы строк
        ws.Cell(rc + down_delta, 1).Value = "Кол-во единиц технологического инструментария хранящегося в ОФАП Росстата Итого:";
        ws.Cell(rc + down_delta, 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Right;
        ws.Range(ws.Cell(rc + down_delta, 1), ws.Cell(rc + down_delta, 5)).Merge();//Наименование итоговой строки начинается объединяется в 5 ячеек 
        ws.Cell(rc + down_delta, 6).Value = rc.ToString();//Сумма строк считается в 6 ячейке 
        ws.Cell(rc + down_delta, 6).Style.Font.Bold = true;
        ws.Cell(rc + down_delta, 6).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Left;
        //Ручная настройка ширины столбцов
        ws.Column(1).Width = 11;
        ws.Column(2).Width = 10;
        ws.Column(3).Width = 10;
        ws.Column(4).Width = 10;
        ws.Column(5).Width = 40;
        ws.Column(6).Width = 20;
        ws.Column(7).Width = 30;
        ws.Column(8).Width = 20;
        ws.Column(9).Width = 20;
        ws.Range(ws.Cell(1, 2), ws.Cell(rc + 1, 2)).Style.Alignment.WrapText = true;
        //Отцентирование и выделение наименований столбцов жирным
        ws.Range(ws.Cell(1, 1), ws.Cell(1, dt.Columns.Count)).Style.Font.Bold = true;
        ws.Range(ws.Cell(1, 1), ws.Cell(1, dt.Columns.Count)).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
        //Сетка
        ClosedXML.Excel.IXLRange trange = ws.Range(ws.Cell(1, 1), ws.Cell(rc + 1, dt.Columns.Count));
        trange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        trange.Style.Border.BottomBorderColor = XLColor.Black;
        trange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        trange.Style.Border.InsideBorderColor = XLColor.Black;
        trange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        trange.Style.Border.OutsideBorderColor = XLColor.Black;
        trange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
        trange.Style.Border.RightBorderColor = XLColor.Black;
        trange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        trange.Style.Border.LeftBorderColor = XLColor.Black;
        trange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
        trange.Style.Border.TopBorderColor = XLColor.Black;
        //Заголовок таблицы
        ws.Cell(1, 1).WorksheetRow().InsertRowsAbove(2);
        ws.Cell(1, 1).Value = "Перечень Технологического Инструментария, хранящегося в ОФАП Росстата на период с 2013 года";
        ws.Cell(1, 1).Style.Font.Bold = true;//Жирный текст
        ws.Cell(1, 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;//Центр по горизонтали
        ws.Cell(1, 1).Style.Alignment.Vertical = ClosedXML.Excel.XLAlignmentVerticalValues.Center;// Центр по вертикали
        ws.Range(ws.Cell(1, 1), ws.Cell(2, dt.Columns.Count)).Merge();
//================================================================================
        ClosedXMLExcel.DownloadXLWorkbook(wb);
            return;
    }
*/
    //--------------------------------------------------------------------------------

}