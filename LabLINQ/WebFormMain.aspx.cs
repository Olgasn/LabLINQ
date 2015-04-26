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
            //// Определение LINQ запроса
           var queryLINQ = from f in db.Operations
                           join t in db.Fuels
                           on f.FuelID equals t.FuelID
                           where (f.Inc_Exp > 0 && f.Date.Value.Year == 2015)
                           orderby f.FuelID
                           select new {f.OperationID, t.FuelType, f.Inc_Exp, f.Date.Value.Month };
            
            //то же, используя методы расширений
            //var queryLINQ = db.Operations.Where(f => (f.Inc_Exp > 0 && f.Date.Value.Year == 2015)).OrderBy(f => f.FuelID).Join(db.Fuels, f => f.FuelID, t => t.FuelID, (f, t) => new { f.OperationID, t.FuelType, f.Inc_Exp, f.Date.Value.Month });
            
            
            //// Визуализация в табличном элементе результатов выполнения запроса         
            
            //Выполнение LINQ запроса и передача результатов элементу управления gridLINQVisualize
            gridLINQVisualize.Caption="1. Результат выполнения запроса на выборку отсортированных записей из одной таблицы, удовлетворяющих некоторому условию : </b><br><small>" + queryLINQ.ToString() + "</small><br>";

            gridLINQVisualize.DataSource = queryLINQ.ToList();


           
        }

        protected void gridLINQVisualize_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridLINQVisualize.PageIndex = e.NewPageIndex;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            gridLINQVisualize.DataBind();

        }

        

    }

}