using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LabLINQ.Models;
namespace LabLINQ
{
    
    public partial class WebFormMain : System.Web.UI.Page
    {
        private toplivoEntities db = new toplivoEntities();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Определение LINQ запроса
            var queryLINQ = from f in db.Operations
                            where (f.Inc_Exp > 0 && f.Date.Value.Year == 2015)
                            orderby f.FuelID
                            select f;
            //то же, используя методы расширений
            //var queryLINQ = db.Operations.Where(f => (f.Inc_Exp > 0 && f.Date.Value.Year == 2015)).OrderBy(f=>f.FuelID) ;


            
            //Визуализация в табличном элементе результатов выполнения запроса

            //Создается табличный элемент управления (GridView) и настраиваются  его свойства.
            //* Можно было создать этот предварительно, используя возможности визуального конструирования.
            GridView gridLINQVisualize = new GridView();
            gridLINQVisualize.AutoGenerateColumns = true;
            gridLINQVisualize.AllowPaging = true;
            this.Form.Controls.Add(gridLINQVisualize);


            //Выполнение LINQ запроса и передача результатов в элементу правления
            Response.Write("<b>Результат выполнения запроса: </b><br><small>" + queryLINQ.ToString() + "</small><br>");
            gridLINQVisualize.DataSource = queryLINQ.ToList();



            this.DataBind();
           
        }
        

    }

}